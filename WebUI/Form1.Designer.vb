<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBKioskMode = New System.Windows.Forms.CheckBox()
        Me.lblEnableKioskMode = New System.Windows.Forms.Label()
        Me.CBConfOnClose = New System.Windows.Forms.CheckBox()
        Me.lblConfirmOnClose = New System.Windows.Forms.Label()
        Me.btnRevert = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtDefaultUrl = New System.Windows.Forms.TextBox()
        Me.lblDefaultUrl = New System.Windows.Forms.Label()
        Me.pnlSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.Controls.Add(Me.Button1)
        Me.pnlSettings.Controls.Add(Me.CheckBox2)
        Me.pnlSettings.Controls.Add(Me.Label3)
        Me.pnlSettings.Controls.Add(Me.Label1)
        Me.pnlSettings.Controls.Add(Me.CBKioskMode)
        Me.pnlSettings.Controls.Add(Me.lblEnableKioskMode)
        Me.pnlSettings.Controls.Add(Me.CBConfOnClose)
        Me.pnlSettings.Controls.Add(Me.lblConfirmOnClose)
        Me.pnlSettings.Controls.Add(Me.btnRevert)
        Me.pnlSettings.Controls.Add(Me.btnBack)
        Me.pnlSettings.Controls.Add(Me.btnSave)
        Me.pnlSettings.Controls.Add(Me.txtDefaultUrl)
        Me.pnlSettings.Controls.Add(Me.lblDefaultUrl)
        Me.pnlSettings.Location = New System.Drawing.Point(12, 12)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(776, 426)
        Me.pnlSettings.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(363, 183)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Check For Updates"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(216, 143)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox2.TabIndex = 11
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(207, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Enable quick access toolbar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(549, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "(must contain https:// or http://)"
        '
        'CBKioskMode
        '
        Me.CBKioskMode.AutoSize = True
        Me.CBKioskMode.Location = New System.Drawing.Point(152, 103)
        Me.CBKioskMode.Name = "CBKioskMode"
        Me.CBKioskMode.Size = New System.Drawing.Size(15, 14)
        Me.CBKioskMode.TabIndex = 8
        Me.CBKioskMode.UseVisualStyleBackColor = True
        '
        'lblEnableKioskMode
        '
        Me.lblEnableKioskMode.AutoSize = True
        Me.lblEnableKioskMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnableKioskMode.Location = New System.Drawing.Point(3, 100)
        Me.lblEnableKioskMode.Name = "lblEnableKioskMode"
        Me.lblEnableKioskMode.Size = New System.Drawing.Size(143, 20)
        Me.lblEnableKioskMode.TabIndex = 7
        Me.lblEnableKioskMode.Text = "Enable kiosk mode"
        '
        'CBConfOnClose
        '
        Me.CBConfOnClose.AutoSize = True
        Me.CBConfOnClose.Checked = True
        Me.CBConfOnClose.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBConfOnClose.Location = New System.Drawing.Point(222, 63)
        Me.CBConfOnClose.Name = "CBConfOnClose"
        Me.CBConfOnClose.Size = New System.Drawing.Size(15, 14)
        Me.CBConfOnClose.TabIndex = 6
        Me.CBConfOnClose.UseVisualStyleBackColor = True
        '
        'lblConfirmOnClose
        '
        Me.lblConfirmOnClose.AutoSize = True
        Me.lblConfirmOnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmOnClose.Location = New System.Drawing.Point(3, 60)
        Me.lblConfirmOnClose.Name = "lblConfirmOnClose"
        Me.lblConfirmOnClose.Size = New System.Drawing.Size(213, 20)
        Me.lblConfirmOnClose.TabIndex = 5
        Me.lblConfirmOnClose.Text = "Ask for confirmation on close"
        '
        'btnRevert
        '
        Me.btnRevert.Location = New System.Drawing.Point(243, 183)
        Me.btnRevert.Name = "btnRevert"
        Me.btnRevert.Size = New System.Drawing.Size(114, 23)
        Me.btnRevert.TabIndex = 4
        Me.btnRevert.Text = "Revert to Defaults"
        Me.btnRevert.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(123, 183)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(114, 23)
        Me.btnBack.TabIndex = 3
        Me.btnBack.Text = "Return to Browser"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(3, 183)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(114, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtDefaultUrl
        '
        Me.txtDefaultUrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDefaultUrl.Location = New System.Drawing.Point(165, 20)
        Me.txtDefaultUrl.Name = "txtDefaultUrl"
        Me.txtDefaultUrl.Size = New System.Drawing.Size(378, 26)
        Me.txtDefaultUrl.TabIndex = 1
        '
        'lblDefaultUrl
        '
        Me.lblDefaultUrl.AutoSize = True
        Me.lblDefaultUrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultUrl.Location = New System.Drawing.Point(3, 20)
        Me.lblDefaultUrl.Name = "lblDefaultUrl"
        Me.lblDefaultUrl.Size = New System.Drawing.Size(153, 20)
        Me.lblDefaultUrl.TabIndex = 0
        Me.lblDefaultUrl.Text = "Default landing URL"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnlSettings)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSettings As Panel
    Friend WithEvents lblDefaultUrl As Label
    Friend WithEvents txtDefaultUrl As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnRevert As Button
    Friend WithEvents CBConfOnClose As CheckBox
    Friend WithEvents lblConfirmOnClose As Label
    Friend WithEvents CBKioskMode As CheckBox
    Friend WithEvents lblEnableKioskMode As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
End Class
