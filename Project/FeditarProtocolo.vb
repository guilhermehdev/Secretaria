Public Class FeditarProtocolo
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
            Dim actualRow = FmainOuvidoria.dgListProtocolos.CurrentRow.Index

            m.SQLupdate("ouvidoria", "protocolo=" & tbEditarProtocolo.Text & ",sistema='" & cbEditarOrigem.Text & "',id_destino=" & cbEditarDestinatario.SelectedValue & ",forma_envio='" & cbEditarFormaEnvio.Text & "',abertura='" & m.mysqlDateFormat(mtbEditarAbertura.Text) & "',1contato=" & contato1 & ",encerramento='" & encerramento & "',status='" & cbEditarStatus.Text & "'", "id", FmainOuvidoria.dgListProtocolos, FmainOuvidoria.dgListProtocolos.CurrentRow.Cells(0).Value, "", False, False, False, True, 1)

            '   m.msgUpdate("Atualizado com sucesso!")

            Dim data = m.getDataset("SELECT ouvidoria.protocolo,ouvidoria.sistema,ouvidoria.forma_envio,ouvidoria.abertura,ouvidoria.1contato,ouvidoria.encerramento,ouvidoria.status,destinos.descricao AS destino, coordenador.nome AS Coord FROM destinos JOIN coordenador ON destinos.id_coordenador = coordenador.id JOIN ouvidoria ON ouvidoria.id_destino = destinos.id WHERE ouvidoria.id=" & FmainOuvidoria.dgListProtocolos.CurrentRow.Cells(1).Value)

            For i = 0 To data.Columns.Count - 1
                FmainOuvidoria.dgListProtocolos.Rows.Item(actualRow).Cells(i + 2).Value = data.Rows(0).Item(i).ToString
            Next

            m.msgUpdate("Atualizado com sucesso!")

        Catch ex As Exception
            m.msgError(ex.Message)
        End Try


    End Sub

    Private Sub btEditarExclusao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditarExclusao.Click
        Try
            m.SQLdelete("ouvidoria", "id", FmainOuvidoria.dgListProtocolos, 1)
            FmainOuvidoria.reloadGrid()
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
        Fmail.ShowDialog()
    End Sub

    Private Sub btResposta_Click(sender As Object, e As EventArgs) Handles btResposta.Click
        FormOuvidoriaAndamento.Show()
        FormOuvidoriaAndamento.Text = FormOuvidoriaAndamento.Text & " - " & tbEditarProtocolo.Text

    End Sub
    Private Sub btClose_Click(sender As Object, e As EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

End Class