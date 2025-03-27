Public Class FormLogin
    Dim m As New Main
    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub
    Private Sub FormLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Fstart.Visible = True
    End Sub
    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m.loadComboBox("SELECT * FROM usuarios", cbUsuarios, "nome", "id")
    End Sub

End Class