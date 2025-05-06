Public Class FormEMTUcadPacientes
    Dim m As New Main

    Private Sub btFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub

    Private Sub btNovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNovo.Click
        m.clearFields(Me)
        m.clearFields(GroupBox1)
    End Sub

    Private Sub FcadPacientesEMTU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbEmissao.SelectedIndex = 0
    End Sub

    Private Sub btSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalvar.Click

        If m.requiredFields(tbNome, cbEmissao, tbLaudo) Then
            If m.SQLinsert("emtu", "nome,tel,emissao,laudo,data_solicitacao,retirada_nome,retirada_rg,retirada_data,obs", "'" & tbNome.Text.ToUpper & "' ,'" & mtbTel.Text & "' ,'" & cbEmissao.Text & "' ,'" & tbLaudo.Text & "' ,'" & m.mysqlDateFormat(dtpDataSol.Value.Date) & "' ,'" & tbNomeRetirada.Text.ToUpper & "' ,'" & mtbRG.Text & "' ,NULL ,'" & tbObs.Text & "'", True, False, "", Nothing, True) Then
                FormEMTUmain.loadGrid()
            End If
        End If

    End Sub

    Private Sub btAtualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAtualizar.Click
        Dim data_retirada
        If tbNomeRetirada.Text = "" Or mtbRG.Text = "  .   .   -" Then
            data_retirada = "NULL"
        Else
            data_retirada = "'" & m.mysqlDateFormat(dtpDataRetirada.Value.Date) & "'"
        End If

        If m.SQLupdate("emtu", "nome='" & tbNome.Text.ToUpper & "' ,tel='" & mtbTel.Text & "' ,emissao='" & cbEmissao.Text & "' ,laudo='" & tbLaudo.Text & "', data_solicitacao='" & m.mysqlDateFormat(dtpDataSol.Value.Date) & "' ,retirada_nome='" & tbNomeRetirada.Text.ToUpper & "', retirada_rg='" & mtbRG.Text & "', retirada_data=" & data_retirada & ", obs='" & tbObs.Text & "'", "id", FormEMTUmain.dgListPacientes, 0, "", True, False, "", True, 0) Then
            FormEMTUmain.loadGrid()
        End If

    End Sub

End Class