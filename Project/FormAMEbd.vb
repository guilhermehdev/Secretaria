Public Class FormAMEbd
    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        My.Settings.userAME = tbUser.Text
        My.Settings.passwordAME = tbPass.Text
        My.Settings.databaseAME = tbDatabase.Text
        My.Settings.serverAME = tbServer.Text

        My.Settings.Save()
        MsgBox("Salvo com sucesso!" & vbCrLf & "Reinicie para aplicar as novas configurações.", MsgBoxStyle.Information, "Salvar dados")
        Application.Exit()
    End Sub
    Private Sub FormAMEbd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbUser.Text = My.Settings.userAME
        tbPass.Text = My.Settings.passwordAME
        tbDatabase.Text = My.Settings.databaseAME
        tbServer.Text = My.Settings.serverAME
    End Sub
    Private Sub cbShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles cbShowPass.CheckedChanged
        If cbShowPass.Checked Then
            tbPass.PasswordChar = ""
            tbPass.UseSystemPasswordChar = False
        Else
            tbPass.PasswordChar = "*"
            tbPass.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub FormAMEbd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

End Class