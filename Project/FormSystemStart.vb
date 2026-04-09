Public Class FormSystemStart

    Private Sub btOuvidoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOuvidoria.Click
        FormLogin.Show()
        FormLogin.system = "EOUVE"
        Me.Visible = False
    End Sub

    Private Sub btRecepcao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRecepcao.Click
        FormLogin.Show()
        FormLogin.system = "EMTU"
        Me.Visible = False
    End Sub

    Private Sub btCNES_Click_1(sender As Object, e As EventArgs) Handles btCNES.Click
        FormLogin.Show()
        FormLogin.system = "CNES"
        Me.Visible = False
    End Sub
    Private Sub btSair_Click(sender As Object, e As EventArgs) Handles btSair.Click
        Me.Close()
    End Sub

    Private Sub UsuárioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuárioToolStripMenuItem.Click
        FormLogin.Show()
        FormLogin.system = "CADUSUARIOS"
        Me.Visible = False
    End Sub
    Private Sub btBLH_Click(sender As Object, e As EventArgs) Handles btBLH.Click
        FormBLHmain.Show()
        Me.Visible = False
    End Sub
    Private Sub btAME_Click(sender As Object, e As EventArgs) Handles btAME.Click
        If My.Settings.databaseAME = "" Then
            MessageBox.Show("Configuração do banco de dados AME não encontrada. Por favor, configure o banco de dados nas configurações do sistema.", "Configuração ausente", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            FormAMEbd.ShowDialog()
        End If
        FormLogin.Show()
        FormLogin.system = "AME"
        Me.Visible = False
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class