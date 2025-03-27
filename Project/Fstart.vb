Public Class Fstart

    Private Sub btOuvidoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOuvidoria.Click
        FmainOuvidoria.Show()
        Me.Visible = False
    End Sub

    Private Sub btEmendas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormAME.Show()
        Me.Visible = False
    End Sub

    Private Sub btRecepcao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRecepcao.Click
        FmainEMTU.Show()
        Me.Visible = False
    End Sub

    Private Sub btSair_Click(sender As Object, e As EventArgs) Handles btSair.Click
        Me.Close()
    End Sub

    Private Sub btCNES_Click_1(sender As Object, e As EventArgs) Handles btCNES.Click
        FormLogin.Show()
        Me.Visible = False
    End Sub

    Private Sub checkCredentials()

    End Sub
    Private Sub Fstart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class