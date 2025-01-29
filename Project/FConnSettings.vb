Public Class FConnSettings
    Dim Sql As String
    Dim Cconn As New Main


    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        My.Settings.user = tbUser.Text
        My.Settings.password = tbPass.Text
        My.Settings.database = tbDatabase.Text
        My.Settings.server = tbServer.Text

        My.Settings.Save()
        MsgBox("Salvo com sucesso!" & vbCrLf & "Reinicie para aplicar as novas configurações.", MsgBoxStyle.Information, "Salvar dados")
        Application.Exit()
    End Sub

    Private Sub FConnSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbUser.Text = My.Settings.user
        tbPass.Text = My.Settings.password
        tbDatabase.Text = My.Settings.database
        tbServer.Text = My.Settings.server
    End Sub

    Private Sub cbShowPass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShowPass.CheckedChanged
        If cbShowPass.Checked Then
            tbPass.PasswordChar = ""
            tbPass.UseSystemPasswordChar = False
        Else
            tbPass.PasswordChar = "*"
            tbPass.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub FConnSettings_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

End Class
