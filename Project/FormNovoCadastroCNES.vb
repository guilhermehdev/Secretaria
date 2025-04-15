Public Class FormNovoCadastroCNES
    Dim m As New Main
    Dim id As Integer
    Dim idMov As Integer

    Private Sub loadCadastros()
        Dim pendentes = m.getDataset("SELECT * FROM servidor_cnes WHERE status=0")
        dgCadastrosPendentes.DataSource = pendentes

        dgCadastrosPendentes.Columns(1).HeaderText = "Nome"
        dgCadastrosPendentes.Columns(1).Width = 150

        dgCadastrosPendentes.Columns(2).HeaderText = "CPF"
        dgCadastrosPendentes.Columns(2).Width = 55


        dgCadastrosPendentes.Columns(0).Visible = False
        dgCadastrosPendentes.Columns(3).Visible = False
        dgCadastrosPendentes.Columns(4).Visible = False
        dgCadastrosPendentes.Columns(5).Visible = False
        dgCadastrosPendentes.Columns(6).Visible = False
        dgCadastrosPendentes.Columns(7).Visible = False
        dgCadastrosPendentes.Columns(8).Visible = False
        dgCadastrosPendentes.Columns(9).Visible = False
        dgCadastrosPendentes.Columns(10).Visible = False
        dgCadastrosPendentes.Columns(11).Visible = False
        dgCadastrosPendentes.Columns(12).Visible = False
        dgCadastrosPendentes.Columns(13).Visible = False
        dgCadastrosPendentes.Columns(14).Visible = False
        dgCadastrosPendentes.Columns(15).Visible = False

    End Sub

    Private Sub loadHistorico()
        Dim pendentes = m.getDataset("SELECT * FROM servidor_cnes WHERE status=1")
        dgHistorico.DataSource = pendentes

        dgHistorico.Columns(1).HeaderText = "Nome"
        dgHistorico.Columns(1).Width = 150

        dgHistorico.Columns(2).HeaderText = "CPF"
        dgHistorico.Columns(2).Width = 55

    End Sub
    Private Sub FormNovoCadastroCNES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCadastros()
        loadHistorico()
    End Sub

    Private Sub loadDadosVinculo()
        tbCBO.Text = dgCadastrosPendentes.CurrentRow.Cells(6).Value.ToString
        tbOrgao.Text = dgCadastrosPendentes.CurrentRow.Cells(7).Value.ToString
        tbRegConselho.Text = dgCadastrosPendentes.CurrentRow.Cells(8).Value.ToString
        numericAMB.Value = dgCadastrosPendentes.CurrentRow.Cells(3).Value
        NumericHosp.Value = dgCadastrosPendentes.CurrentRow.Cells(4).Value
        NumericOutros.Value = dgCadastrosPendentes.CurrentRow.Cells(5).Value
        tbFormaContrato.Text = dgCadastrosPendentes.CurrentRow.Cells(9).Value.ToString.Replace("/", "")
        tbDetalhe.Text = dgCadastrosPendentes.CurrentRow.Cells(10).Value.ToString.Replace("/", "")
        tbUnidade.Text = dgCadastrosPendentes.CurrentRow.Cells(11).Value.ToString
        tbEquipe.Text = dgCadastrosPendentes.CurrentRow.Cells(12).Value.ToString
        id = dgCadastrosPendentes.CurrentRow.Cells(0).Value
        idMov = dgCadastrosPendentes.CurrentRow.Cells(15).Value
    End Sub
    Private Sub dgCadastrosPendentes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgCadastrosPendentes.CellEnter
        loadDadosVinculo()
    End Sub
    Private Sub btConcluirCadastro_Click(sender As Object, e As EventArgs) Handles btConcluirCadastro.Click

        If m.doQuery("UPDATE servidor_cnes SET status=1 WHERE id=" & id) Then
            m.doQuery("UPDATE movimento SET status=1 WHERE id=" & idMov)
            m.msgInfo("Cadastro concluído com sucesso!")
            loadCadastros()
            FCNES.addPanelAlteracoes()
        End If

    End Sub

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub

    Private Sub dgCadastrosPendentes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCadastrosPendentes.CellClick
        m.copyDatagridCellValue(dgCadastrosPendentes, e)
    End Sub

End Class