Imports Microsoft.Web.WebView2.WinForms
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Win32

Public Class Form1
    ' Target Framework: .NET Framework 4.8
    ' NuGet required: Microsoft.Web.WebView2

    Private Const REG_PATH As String = "Software\AutoTaskWebView"
    Private Const REG_VALUE As String = "DefaultUrl"
    Private Const DEFAULT_URL As String = "https://ww3.autotask.net/"
    Private Const REG_CONFIRM_ON_CLOSE As String = "ConfirmOnClose"
    Private Const REG_KIOSK_MODE As String = "KioskMode"


    Private WithEvents TabControl1 As New TabControl()
    Private ContextMenuTabs As New ContextMenuStrip()

    ' ---------------- Form Load ----------------
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Basic window setup (neutral defaults)
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.WindowState = FormWindowState.Maximized
        Me.TopMost = True
        Me.Text = "AutoTask"

        ' Add TabControl
        TabControl1.Dock = DockStyle.Fill
        Me.Controls.Add(TabControl1)

        ' Settings UI
        InitializeSettingsPanel()

        ' Load persisted settings from registry
        LoadSettings()

        ' Apply behavior (kiosk, etc.)
        ApplySettings()

        ' Context menu
        InitializeTabContextMenu()

        ' Initial tab
        Dim url As String = GetOrCreateDefaultUrl()
        CreateNewTab(url, "AutoTask")

    End Sub

    Private Sub LoadSettings()

        Using key = Registry.CurrentUser.CreateSubKey(REG_PATH)

            ' Default URL
            txtDefaultUrl.Text =
            key.GetValue(REG_VALUE, DEFAULT_URL).ToString()

            ' Confirm on close (default = True)
            CBConfOnClose.Checked =
            Convert.ToBoolean(key.GetValue(REG_CONFIRM_ON_CLOSE, True))

            ' Kiosk mode (default = False)
            CBKioskMode.Checked =
            Convert.ToBoolean(key.GetValue(REG_KIOSK_MODE, False))

        End Using

    End Sub

    Private Sub ApplySettings()
        ApplyKioskMode()
    End Sub


    ' ---------------- Form Close ----------------
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim confirmOnClose As Boolean

        Using key = Registry.CurrentUser.CreateSubKey(REG_PATH)
            confirmOnClose =
            Convert.ToBoolean(key.GetValue(REG_CONFIRM_ON_CLOSE, True))
        End Using

        If Not confirmOnClose Then
            ' Confirmation disabled → allow close
            Return
        End If

        Dim result = MessageBox.Show(
        "Are you sure you want to close the program?",
        "Confirm Exit",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question)

        If result = DialogResult.No Then
            e.Cancel = True
        End If

    End Sub

    ' ---------------- Registry ----------------
    Private Function GetOrCreateDefaultUrl() As String
        Using key = Registry.CurrentUser.CreateSubKey(REG_PATH)
            Dim value = key.GetValue(REG_VALUE)
            If value Is Nothing Then
                key.SetValue(REG_VALUE, DEFAULT_URL, RegistryValueKind.String)
                Return DEFAULT_URL
            Else
                Return value.ToString()
            End If
        End Using
    End Function

    ' ---------------- Tabs ----------------
    Private Sub CreateNewTab(url As String, title As String)
        Dim tab As New TabPage(title)
        Dim webView As New WebView2()

        webView.Dock = DockStyle.Fill
        tab.Controls.Add(webView)
        TabControl1.TabPages.Add(tab)
        TabControl1.SelectedTab = tab

        AddHandler webView.CoreWebView2InitializationCompleted,
        Sub(sender2, e2)
            If e2.IsSuccess Then
                webView.Source = New Uri(url)

                ' Update tab title dynamically
                AddHandler webView.CoreWebView2.DocumentTitleChanged,
                    Sub()
                        If TabControl1.TabPages.Contains(tab) Then
                            tab.Text = webView.CoreWebView2.DocumentTitle
                        End If
                    End Sub

                ' Force all new windows to open in a new tab
                AddHandler webView.CoreWebView2.NewWindowRequested,
                    Sub(sender3, args)
                        args.Handled = True
                        Me.Invoke(Sub() CreateNewTab(args.Uri, "New Tab"))
                    End Sub

            Else
                MessageBox.Show("WebView2 initialization failed: " & e2.InitializationException.Message)
            End If
        End Sub

        webView.EnsureCoreWebView2Async()
    End Sub

    ' ---------------- Context Menu ----------------
    Private Sub InitializeTabContextMenu()
        ContextMenuTabs.Items.Add("New Tab", Nothing, Sub() CreateNewTab(GetOrCreateDefaultUrl(), "New Tab"))
        ContextMenuTabs.Items.Add("Rename Tab", Nothing, AddressOf RenameSelectedTab)
        ContextMenuTabs.Items.Add("Close Tab", Nothing, AddressOf CloseSelectedTab)
        ContextMenuTabs.Items.Add("Settings", Nothing, AddressOf OpenSettings)

        AddHandler TabControl1.MouseUp, AddressOf TabControl_MouseUp
    End Sub

    Private Sub TabControl_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button <> MouseButtons.Right Then Return
        For i = 0 To TabControl1.TabCount - 1
            If TabControl1.GetTabRect(i).Contains(e.Location) Then
                TabControl1.SelectedIndex = i
                ContextMenuTabs.Show(TabControl1, e.Location)
                Exit For
            End If
        Next
    End Sub

    Private Sub RenameSelectedTab(sender As Object, e As EventArgs)
        If TabControl1.SelectedTab Is Nothing Then Return
        Using dlg As New RenameTabForm(TabControl1.SelectedTab.Text)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                TabControl1.SelectedTab.Text = dlg.TabName
            End If
        End Using
    End Sub

    Private Sub CloseSelectedTab(sender As Object, e As EventArgs)
        If TabControl1.SelectedTab Is Nothing Then Return
        If TabControl1.TabPages.Count = 1 Then
            ' Only one tab left — confirm exit
            If MessageBox.Show("Are you sure you want to close the program?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Application.Exit()
            End If
        Else
            TabControl1.TabPages.Remove(TabControl1.SelectedTab)
        End If
    End Sub

    ' ---------------- Settings Panel ----------------
    'Private btnRevert As New Button With {.Text = "Revert to Default", .Top = 90, .Left = 200, .Width = 120}

    Private Sub InitializeSettingsPanel()

        pnlSettings.Controls.Add(lblDefaultUrl)
        pnlSettings.Controls.Add(txtDefaultUrl)
        pnlSettings.Controls.Add(CBConfOnClose)
        pnlSettings.Controls.Add(CBKioskMode)
        pnlSettings.Controls.Add(btnSave)
        pnlSettings.Controls.Add(btnBack)
        pnlSettings.Controls.Add(btnRevert)
        Me.Controls.Add(pnlSettings)

        Using key = Registry.CurrentUser.CreateSubKey(REG_PATH)

            txtDefaultUrl.Text = key.GetValue(REG_VALUE, DEFAULT_URL).ToString()

            CBConfOnClose.Checked =
            Convert.ToBoolean(key.GetValue(REG_CONFIRM_ON_CLOSE, False))

            CBKioskMode.Checked =
            Convert.ToBoolean(key.GetValue(REG_KIOSK_MODE, False))

        End Using

        AddHandler btnSave.Click, Sub()
                                      If Not (txtDefaultUrl.Text).Contains("https://") Then
                                          MessageBox.Show("URL protocol not specified", "Protocol error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                          Return
                                      End If
                                      Using key = Registry.CurrentUser.CreateSubKey(REG_PATH)
                                          key.SetValue(REG_VALUE, txtDefaultUrl.Text, RegistryValueKind.String)
                                          key.SetValue(REG_CONFIRM_ON_CLOSE, CBConfOnClose.Checked, RegistryValueKind.DWord)
                                          key.SetValue(REG_KIOSK_MODE, CBKioskMode.Checked, RegistryValueKind.DWord)
                                      End Using

                                      ApplyKioskMode()
                                      MessageBox.Show("Settings Saved", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                  End Sub

        AddHandler btnBack.Click, Sub()
                                      pnlSettings.Visible = False
                                      TabControl1.Visible = True
                                  End Sub

        AddHandler btnRevert.Click, Sub()
                                        ' Reset URL
                                        txtDefaultUrl.Text = DEFAULT_URL

                                        ' Reset checkboxes to defaults
                                        CBConfOnClose.Checked = True          ' Ask for confirmation on close
                                        CBKioskMode.Checked = False           ' Kiosk mode off

                                        ' Save defaults to registry
                                        Using key = Registry.CurrentUser.CreateSubKey(REG_PATH)
                                            key.SetValue(REG_VALUE, DEFAULT_URL, RegistryValueKind.String)
                                            key.SetValue(REG_CONFIRM_ON_CLOSE, True, RegistryValueKind.DWord)
                                            key.SetValue(REG_KIOSK_MODE, False, RegistryValueKind.DWord)
                                        End Using

                                        ' Apply any behavior changes (kiosk mode, etc.)
                                        ApplySettings()

                                        MessageBox.Show("Settings reverted to defaults.", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    End Sub
    End Sub
    Private Sub ApplyKioskMode()

        Using key = Registry.CurrentUser.CreateSubKey(REG_PATH)

            Dim kioskEnabled As Boolean =
            Convert.ToBoolean(key.GetValue(REG_KIOSK_MODE, False))

            If kioskEnabled Then
                Me.FormBorderStyle = FormBorderStyle.None
                Me.TopMost = True

                ' Force true fullscreen (ignores taskbar)
                Me.WindowState = FormWindowState.Normal
                Me.Bounds = Screen.FromControl(Me).Bounds

                ' Prevent TabControl header clipping
                Me.Padding = New Padding(0, 2, 0, 0)

            Else
                Me.TopMost = True
                Me.FormBorderStyle = FormBorderStyle.Sizable
                Me.WindowState = FormWindowState.Maximized
                Me.Padding = Padding.Empty
            End If

        End Using

    End Sub

    ' ---------------- Open Settings ----------------
    Private Sub OpenSettings(sender As Object, e As EventArgs)
        ' Hide tabs/webview and show the settings panel
        TabControl1.Visible = False
        pnlSettings.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("https://sandwire-my.sharepoint.com/:f:/p/zachary_friedman/IgDmGdhHRu90TojEFvrKf5IgAbWWqraZI5cO6XVDdH5Qd7k?e=PRo7wc")
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class

' ---------------- Program Entry (.NET Framework) ----------------
Module Program
    <STAThread>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    End Sub
End Module