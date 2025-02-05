Public Class FormOuvidoriaAndamento
    Dim main As New Main
    Dim idManifest As Integer = Nothing
    Public Sub getManifestacoes(protocolo As Integer)
        Dim dataManifest As DataTable = main.getDataset($"SELECT manifestacoes.id, manifest, resposta, ok FROM manifestacoes 
        JOIN ouvidoria ON ouvidoria.id = manifestacoes.id_ouvidoria
        WHERE ouvidoria.protocolo ={protocolo}")

        If dataManifest.Rows.Count > 0 Then
            idManifest = dataManifest.Rows(0).Item(0)
            TextBoxManifestacao.Text = dataManifest.Rows(0).Item(1).ToString
            TextBoxResposta.Text = dataManifest.Rows(0).Item(2).ToString

            If dataManifest.Rows(0).Item(3) = 1 Then
                CheckBoxOKResposta.Checked = True
            Else
                CheckBoxOKResposta.Checked = False
            End If
        End If

    End Sub
    Private Sub FormOuvidoriaAndamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = FmainOuvidoria.Icon
        TextBoxResposta.Focus()
    End Sub

    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Close()
    End Sub
    Private Sub btSalvarResposta_Click(sender As Object, e As EventArgs) Handles btSalvarResposta.Click
        If idManifest <> Nothing Then
            If main.doQuery($"UPDATE manifestacoes SET resposta='{TextBoxResposta.Text}' WHERE id={idManifest}") Then
                main.msgInfo("Resposta cadastrada!")
            End If
        Else
            main.msgInfo("Manifestação inexistente.")
        End If
    End Sub
    Private Sub CheckBoxOKResposta_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOKResposta.CheckedChanged
        Dim sts As Integer
        If CheckBoxOKResposta.Checked = True Then
            sts = 1
        Else
            sts = 0
        End If
        main.doQuery($"UPDATE manifestacoes SET ok={sts} WHERE id= {idManifest}")
    End Sub

End Class