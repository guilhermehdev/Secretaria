Public Class FormCadastroServidorCNES
    Dim xml As New XML
    Dim m As New Main
    Private Sub btSair_Click(sender As Object, e As EventArgs) Handles btSair.Click
        Me.Close()
    End Sub
    Private Sub FormCadastroServidorCNES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xml.cbOrgaoClasse(cbOrgao)
        xml.cbBuscaEquipes(cbEquipe)
        xml.cbBuscaUnidades(cbUnidade)
        xml.cbCBO(cbCBO)
        xml.cbFormaContEstab(cbFormaContrato)
        xml.cbFormaContEmpregador(cbDetalhe, cbFormaContrato.SelectedValue)
    End Sub
    Private Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click
        If tbNome.Text <> "" And tbCPF.Text <> "   .   .   -" And (numericAMB.Value > 0 Or NumericHosp.Value > 0 Or NumericOutros.Value > 0) And cbCBO.SelectedIndex >= 0 And cbFormaContrato.SelectedIndex >= 0 And cbDetalhe.SelectedIndex >= 0 And cbUnidade.SelectedIndex >= 0 And cbEquipe.SelectedIndex >= 0 Then

            m.SQLinsert("movimento", "unidade_out,equipe_out,unidade_in, equipe_in, profissional, cbo, cpf", "'NOVO CADASTRO'," & "'NOVO CADASTRO'" & ",'" & cbUnidade.SelectedValue & "','" & cbEquipe.SelectedValue & "','" & tbNome.Text.ToUpper & "','" & cbCBO.Text & "','" & tbCPF.Text.Replace(".", "").Replace("-", "") & "'",,,,, True)
            FCNES.addPanelAlteracoes()

            Dim idProf = m.getDataset("SELECT MAX(id) FROM movimento").Rows(0).Item(0)

            m.SQLinsert("servidor_cnes", "nome,cpf,chHosp,chAmb,chOut,classe,cbo,numero_classe,contrato,detalhe,unidade,equipe,id_movimento", "'" & tbNome.Text.ToUpper & "','" & tbCPF.Text.Replace(".", "").Replace("-", "") & "'," & NumericHosp.Value & "," & numericAMB.Value & "," & NumericOutros.Value & ",'" & cbOrgao.SelectedValue & "','" & cbCBO.SelectedValue & "','" & tbRegConselho.Text & "','" & cbFormaContrato.SelectedValue & "','" & cbDetalhe.SelectedValue & "','" & cbUnidade.SelectedValue & "','" & cbEquipe.SelectedValue & "'," & idProf, True)
        Else
            m.msgAlert("Nome, CPF, CBO, Carga horaria, Forma de contrato, unidade e equipe são obrigatórios")
        End If

        clear()

    End Sub
    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        clear()
    End Sub
    Private Sub clear()
        tbNome.Clear()
        tbRegConselho.Clear()
        tbCPF.Clear()
        NumericHosp.Value = 0
        numericAMB.Value = 0
        NumericOutros.Value = 0
        cbCBO.SelectedIndex = -1
        cbFormaContrato.SelectedIndex = -1
        cbOrgao.SelectedIndex = -1
        cbDetalhe.SelectedIndex = -1
        cbUnidade.SelectedIndex = -1
        cbEquipe.SelectedIndex = -1
    End Sub

End Class