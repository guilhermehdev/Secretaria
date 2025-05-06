Public Class FormOuvidoriaEditarProtocolo
    Dim m As New Main

    Private Sub btAtualizarProtocolo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAtualizarProtocolo.Click
        Dim contato1 As Object
        Dim encerramento As Object

        If mtbEditar1contato.Text = "  /  /" Then
            contato1 = "NULL"
        Else
            contato1 = "'" & m.mysqlDateFormat(mtbEditar1contato.Text) & "'"
        End If

        If mtbEditarEncerramento.Text = "  /  /       :" Then
            encerramento = ""
        Else
            encerramento = mtbEditarEncerramento.Text
        End If

        Try
            Dim actualRow = FormOuvidoriaMain.dgListProtocolos.CurrentRow.Index

            m.SQLupdate("ouvidoria", "protocolo=" & tbEditarProtocolo.Text & ",sistema='" & cbEditarOrigem.Text & "',id_destino=" & cbEditarDestinatario.SelectedValue & ",forma_envio='" & cbEditarFormaEnvio.Text & "',abertura='" & m.mysqlDateFormat(mtbEditarAbertura.Text) & "',1contato=" & contato1 & ",encerramento='" & encerramento & "',status='" & cbEditarStatus.Text & "'", "id", FormOuvidoriaMain.dgListProtocolos, FormOuvidoriaMain.dgListProtocolos.CurrentRow.Cells(0).Value, "", False, False, False, True, 1)

            '   m.msgUpdate("Atualizado com sucesso!")

            Dim data = m.getDataset("SELECT ouvidoria.protocolo,ouvidoria.sistema,ouvidoria.forma_envio,ouvidoria.abertura,ouvidoria.1contato,ouvidoria.encerramento,ouvidoria.status,destinos.descricao AS destino, coordenador.nome AS Coord FROM destinos JOIN coordenador ON destinos.id_coordenador = coordenador.id JOIN ouvidoria ON ouvidoria.id_destino = destinos.id WHERE ouvidoria.id=" & FormOuvidoriaMain.dgListProtocolos.CurrentRow.Cells(1).Value)

            For i = 0 To data.Columns.Count - 1
                FormOuvidoriaMain.dgListProtocolos.Rows.Item(actualRow).Cells(i + 2).Value = data.Rows(0).Item(i).ToString
            Next

            m.msgUpdate("Atualizado com sucesso!")

        Catch ex As Exception
            m.msgError(ex.Message)
        End Try


    End Sub

    Private Sub btEditarExclusao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditarExclusao.Click
        Try
            m.SQLdelete("ouvidoria", "id", FormOuvidoriaMain.dgListProtocolos, 1)
            FormOuvidoriaMain.reloadGrid()
            Me.Close()
        Catch ex As Exception
            m.msgError(ex.Message)
        End Try

    End Sub

    Private Sub btHoje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHoje.Click
        Dim datahoraAtual As DateTime = Now
        mtbEditarEncerramento.Text = datahoraAtual
    End Sub

    Private Sub btSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSendEmail.Click
        FormOuvidoriaMail.ShowDialog()
    End Sub

    Private Sub btResposta_Click(sender As Object, e As EventArgs) Handles btResposta.Click
        FormOuvidoriaAndamento.Show()
        FormOuvidoriaAndamento.protocolo = tbEditarProtocolo.Text
        FormOuvidoriaAndamento.getManifestacoes()
    End Sub
    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

End Class