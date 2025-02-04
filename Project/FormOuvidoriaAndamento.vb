Public Class FormOuvidoriaAndamento
    Private Sub FormOuvidoriaAndamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = FmainOuvidoria.Icon
        TextBoxResposta.Focus()
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

End Class