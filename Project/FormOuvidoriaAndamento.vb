Public Class FormOuvidoriaAndamento
    Dim main As New Main
    Public Sub getManifestacoes(protocolo As Integer)
        Dim data As DataTable = main.getDataset($"SELECT manifest FROM manifestacoes 
        JOIN ouvidoria ON ouvidoria.id = manifestacoes.id_ouvidoria
        WHERE ouvidoria.protocolo ={protocolo}")

        If data.Rows.Count > 0 Then
            TextBoxManifestacao.Text = data.Rows(0).Item(0).ToString
        End If


    End Sub
    Private Sub FormOuvidoriaAndamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = FmainOuvidoria.Icon
        TextBoxResposta.Focus()
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

End Class