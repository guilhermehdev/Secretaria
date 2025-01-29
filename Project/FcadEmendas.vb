Public Class FcadEmendas
    Dim m As New Main

    Dim sqlEmendas = "SELECT id, id_emenda FROM emendas ORDER BY ano_ref"
    Dim sqlRecursos = "SELECT id, descricao FROM recursos ORDER BY descricao"
    Dim sqlCNES = "SELECT id, descricao FROM cnes ORDER BY descricao"
    Dim sqlSituacao = "SELECT id, descricao FROM situacoes ORDER BY descricao"
    Dim sqlBanco = "SELECT id, descricao FROM bancos ORDER BY descricao"
    Dim sqlConta = "SELECT id, numero FROM contas ORDER BY numero"
    Dim sql4ranterior = "SELECT id, numero FROM conta4r_anterior ORDER BY numero"
    Dim sql4vigente = "SELECT id, numero FROM conta4r_vigente ORDER BY numero"
    Dim sql4fichaVigente = "SELECT id, numero FROM ficha4r_vigente ORDER BY numero"

    Private Sub FcadEmendas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m.bsave = btsave
        m.bnew = btnew
        m.bupdate = btupdate
        m.bdelete = btdelete
        m.bcancel = btcancel

        btupdate.Enabled = False
        btdelete.Enabled = False



        m.loadComboBox(sqlCNES, cbCnes, "descricao", "id")
        m.loadComboBox(sqlEmendas, cbPesquisaNemenda, "id_emenda", "id")
        m.loadComboBox(sqlRecursos, cbRecursos, "descricao", "id")
        m.loadComboBox(sqlSituacao, cbSituacaoAtual, "descricao", "id")
        m.loadComboBox(sqlBanco, cbBanco, "descricao", "id")
        m.loadComboBox(sqlConta, cbConta, "numero", "id")
        m.loadComboBox(sql4ranterior, cbConta4rAnterior, "numero", "id")
        m.loadComboBox(sql4vigente, cb4RContaVigete, "numero", "id")
        m.loadComboBox(sql4fichaVigente, cbFicha4RVigente, "numero", "id")

        cbPesquisaNemenda.SelectedIndex = -1
        cbCnes.SelectedIndex = -1
    End Sub

    Private Sub btnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnew.Click
        m.clearFields(gbEmendas)
    End Sub

    Private Sub btSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSair.Click
        Me.Close()
    End Sub

    Private Sub btsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsave.Click

        Try

            If m.SQLinsert("emendas", "id_recursos,ano_ref,id_emenda,portaria,cib,processo,objeto,parlamentar,cnes,situacao_atual,valor,banco,contas,data_deposito,conta4R_anterior,conta4R_vigente,ficha4R_vigente,porfolio,rag,obs", cbRecursos.SelectedValue & ", '" & cbAnoRef.Text & "', '" & tbNemenda.Text & "', '" & tbPortaria.Text & "' ,'" & tbCIB.Text & "' ,'" & tbNprocesso.Text & "' ,'" & tbObjeto.Text & "' ,'" & cbParlamentar.Text & "' ,'" & cbCnes.SelectedValue & "' ," & cbSituacaoAtual.SelectedValue & ", '" & m.saveBRL(tbValor.Text) & "' ," & cbBanco.SelectedValue & " ," & cbConta.SelectedValue & " , '" & m.mysqlDateFormat(dtpDeposito.Value.Date) & "' ," & cbConta4rAnterior.SelectedValue & " ," & cb4RContaVigete.SelectedValue & " ," & cbFicha4RVigente.SelectedValue & " ,'" & tbPortfolio.Text & "' ,'" & tbRag.Text & "' ,'" & tbObs.Text & "'", True) Then

                FmainEmendas.loadEmendas()

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub tbValor_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbValor.Leave
        Try
            tbValor.Text = Format(CDec(tbValor.Text), "##,##0.00")
        Catch ex As Exception
            tbValor.Text = Nothing
        End Try
    End Sub

    Private Sub cbCnes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCnes.SelectedIndexChanged
        Try
            lbCNES.Text = cbCnes.SelectedValue.ToString
        Catch ex As Exception
            lbCNES.Text = "0000000"
        End Try

    End Sub

End Class