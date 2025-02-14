Public Class FormOuvidoriaAndamento
    Dim main As New Main
    Dim idManifest As Integer = Nothing
    Public protocolo As Integer
    Dim sts As Integer
    Public Sub getManifestacoes()
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
            If TextBoxResposta.TextLength > 0 Then
                If main.doQuery($"UPDATE manifestacoes SET resposta='{TextBoxResposta.Text}' WHERE id={idManifest}") Then
                    main.msgInfo("Resposta cadastrada!")
                End If
                If CheckBoxOKResposta.Checked = True Then
                    sts = 1
                Else
                    sts = 0
                End If
                main.doQuery($"UPDATE manifestacoes SET ok={sts} WHERE id= {idManifest}")
            Else
                main.msgAlert("Resposta nãopode ser vazio!")
            End If

        Else
            main.msgInfo("Manifestação inexistente.")
        End If
    End Sub
    Private Sub btExcluirManifest_Click(sender As Object, e As EventArgs) Handles btExcluirManifest.Click
        If main.msgQuestion("Excluir esta manifestação?", "Excluir") Then
            If main.doQuery($"UPDATE manifestacoes SET manifest='' WHERE id= {idManifest}") Then
                TextBoxManifestacao.Clear()
            End If
        End If
    End Sub

    Private Sub CheckBoxOKResposta_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOKResposta.CheckedChanged
        If TextBoxResposta.Text.Length > 0 And idManifest <> Nothing Then
            If CheckBoxOKResposta.Checked = True Then
                sts = 1
            Else
                sts = 0
            End If
            main.doQuery($"UPDATE manifestacoes SET ok={sts} WHERE id= {idManifest}")
        Else
            CheckBoxOKResposta.Checked = False
        End If
    End Sub
    Private Sub btAtualizarManifest_Click(sender As Object, e As EventArgs) Handles btAtualizarManifest.Click
        Dim pdf As New PDF
        pdf.importPDFManifest(OFDUpdateManifest, False)
        getManifestacoes()
    End Sub
    Private Sub btLimparResposta_Click(sender As Object, e As EventArgs) Handles btLimparResposta.Click
        If main.doQuery($"UPDATE manifestacoes SET ok=0, resposta='' WHERE id= {idManifest}") Then
            TextBoxResposta.Clear()
        End If
    End Sub

End Class