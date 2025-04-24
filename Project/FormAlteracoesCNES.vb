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

        dgAlteracoesPendentes.DataSource = alteracoes
        dgAlteracoesPendentes.Columns(0).Visible = False
        dgAlteracoesPendentes.Columns(8).Visible = False
        dgAlteracoesPendentes.Columns(9).Visible = False
        dgAlteracoesPendentes.Columns(10).Visible = False

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

        If alteracoes.Rows.Count > 0 Then

            dgAlteracoesPendentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

            dgAlteracoesPendentes.ClearSelection()

            For Each row In dgAlteracoesPendentes.Rows
                row.Cells(1).Value = xml.getCNESXML(row.Cells(1).Value.ToString)
                row.Cells(2).Value = xml.getINEXML(row.Cells(2).Value.ToString)
                If IsNumeric(row.Cells(3).Value) Then
                    row.Cells(3).Value = xml.getCNESXML(row.Cells(3).Value.ToString)
                End If

                If IsNumeric(row.Cells(4).Value) Then
                    row.Cells(4).Value = xml.getINEXML(row.Cells(4).Value)
                End If
            Next

        Else
            dgAlteracoesPendentes.DataSource = Nothing
            dgAlteracoesPendentes.Columns.Clear()
            dgAlteracoesPendentes.Rows.Clear()
            dgAlteracoesPendentes.Refresh()
        End If

    End Sub

    Private Sub loadHistorico()
        Dim historico = m.getDataset("SELECT * FROM movimento WHERE equipe_out <> 'NOVO CADASTRO' AND commited=1 ORDER BY data_conclusao DESC")

        dgHistoricoAlteracoes.DataSource = historico
        dgHistoricoAlteracoes.Columns(0).Visible = False
        dgHistoricoAlteracoes.Columns(8).Visible = False
        dgHistoricoAlteracoes.Columns(9).Visible = False
        dgHistoricoAlteracoes.Columns(1).HeaderText = "Desligando da Unidade"
        ' dgAlteracoesPendentes.Columns(1).Width = 150
        dgHistoricoAlteracoes.Columns(2).HeaderText = "da Equipe"
        ' dgAlteracoesPendentes.Columns(2).Width = 150
        dgHistoricoAlteracoes.Columns(3).HeaderText = "Realocado na Unidade"
        ' dgAlteracoesPendentes.Columns(3).Width = 150
        dgHistoricoAlteracoes.Columns(4).HeaderText = "na Equipe"
        ' dgAlteracoesPendentes.Columns(4).Width = 150
        dgHistoricoAlteracoes.Columns(5).HeaderText = "CPF"
        dgHistoricoAlteracoes.Columns(6).HeaderText = "Profissional"
        ' dgAlteracoesPendentes.Columns(4).Width = 150
        dgHistoricoAlteracoes.Columns(7).HeaderText = "CBO"
        dgHistoricoAlteracoes.Columns(10).HeaderText = "Data conclusão"

        If historico.Rows.Count > 0 Then

            For Each row In dgHistoricoAlteracoes.Rows
                row.Cells(1).Value = xml.getCNESXML(row.Cells(1).Value.ToString)
                row.Cells(2).Value = xml.getINEXML(row.Cells(2).Value.ToString)
                If IsNumeric(row.Cells(3).Value) Then
                    row.Cells(3).Value = xml.getCNESXML(row.Cells(3).Value.ToString)
                End If

                If IsNumeric(row.Cells(4).Value) Then
                    row.Cells(4).Value = xml.getINEXML(row.Cells(4).Value)
                End If
            Next

            dgHistoricoAlteracoes.ClearSelection()
            dgHistoricoAlteracoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Else
            dgHistoricoAlteracoes.DataSource = Nothing
            dgHistoricoAlteracoes.Columns.Clear()
            dgHistoricoAlteracoes.Rows.Clear()
            dgHistoricoAlteracoes.Refresh()
        End If

    End Sub
    Private Sub FormAlteracoesCNES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadAlteracoes()
        loadHistorico()
    End Sub

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub
    Private Sub btConcluirCadastro_Click(sender As Object, e As EventArgs) Handles btConcluirCadastro.Click
        If dgAlteracoesPendentes.SelectedRows.Count > 0 Then
            If m.doQuery($"UPDATE movimento SET commited=1 WHERE id={id}") Then
                loadAlteracoes()
                loadHistorico()
                FCNES.addPanelAlteracoes()
            End If
        Else
            m.msgInfo("Selecione um cadastro para concluir.")
        End If
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            btConcluirCadastro.Enabled = False
            dgHistoricoAlteracoes.ClearSelection()
        Else
            btConcluirCadastro.Enabled = True
        End If
    End Sub

End Class