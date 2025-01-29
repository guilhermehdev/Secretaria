Public Class Flogin

    Dim Sql As String
    Dim vmain As New Main
    Dim vlog As New Logs
    Dim vproduto As New Produtos
    Public idOperador As String
    Public nomeOperador As String
    Public opinterno As String
    Dim msg As String = "Acesso não autorizado!"


    Private Sub Flogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txsenha.Clear()
        txsenha.Focus()
    End Sub

    Private Sub Flogin_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.BringToFront()
        txsenha.Clear()
        txsenha.Focus()
    End Sub

    Private Sub btok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btok.Click

    End Sub
End Class