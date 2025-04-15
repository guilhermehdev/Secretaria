Public Class FormAlteracoesCNES
    Dim m As New Main
    Dim xml As New XML
    Dim id As Integer
    Private Sub dgCadastrosPendentes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAlteracoesPendentes.CellClick
        m.copyDatagridCellValue(dgAlteracoesPendentes, e)
        id = dgAlteracoesPendentes.SelectedRows.Item(0).Cells(0).Value
    End Sub
    Private Sub loadAlteracoes()
        Dim alteracoes = m.getDataset("SELECT * FROM movimento WHERE equipe_out <> 'NOVO CADASTRO' AND status=0 AND commited=0 ORDER BY id DESC")

        If alteracoes.Rows.Count = 0 Then
            dgAlteracoesPendentes.DataSource = Nothing
            Return
        End If

        dgAlteracoesPendentes.DataSource = alteracoes

        dgAlteracoesPendentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

        dgAlteracoesPendentes.ClearSelection()

        dgAlteracoesPendentes.Columns(0).Visible = False
        dgAlteracoesPendentes.Columns(8).Visible = False
        dgAlteracoesPendentes.Columns(9).Visible = False

        dgAlteracoesPendentes.Columns(1).HeaderText = "Desligando da Unidade"
        ' dgAlteracoesPendentes.Columns(1).Width = 150

        dgAlteracoesPendentes.Columns(2).HeaderText = "da Equipe"
        ' dgAlteracoesPendentes.Columns(2).Width = 150

        dgAlteracoesPendentes.Columns(3).HeaderText = "Realocado na Unidade"
        ' dgAlteracoesPendentes.Columns(3).Width = 150

        dgAlteracoesPendentes.Columns(4).HeaderText = "na Equipe"
        ' dgAlteracoesPendentes.Columns(4).Width = 150

        dgAlteracoesPendentes.Columns(5).HeaderText = "CPF"

        dgAlteracoesPendentes.Columns(6).HeaderText = "Profissional"
        ' dgAlteracoesPendentes.Columns(4).Width = 150

        dgAlteracoesPendentes.Columns(7).HeaderText = "CBO"

        For Each row In dgAlteracoesPendentes.Rows
            row.Cells(1).Value = xml.getCNESXML(row.Cells(1).Value.ToString)
            row.Cells(2).Value = xml.getINEXML(row.Cells(2).Value.ToString)
            row.Cells(3).Value = xml.getCNESXML(row.Cells(3).Value.ToString)
            row.Cells(4).Value = xml.getINEXML(row.Cells(4).Value.ToString)
        Next

    End Sub
    Private Sub FormAlteracoesCNES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadAlteracoes()
    End Sub

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub
    Private Sub btConcluirCadastro_Click(sender As Object, e As EventArgs) Handles btConcluirCadastro.Click
        If m.doQuery($"UPDATE movimento SET commited=1 WHERE id={id}") Then
            loadAlteracoes()
            FCNES.addPanelAlteracoes()
        End If
    End Sub

End Class