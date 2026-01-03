Public Class RenameTabForm

    Public ReadOnly Property TabName As String
        Get
            Return txtName.Text
        End Get
    End Property

    Public Sub New(currentName As String)
        InitializeComponent()
        txtName.Text = currentName
        txtName.SelectAll()
    End Sub

End Class
