Public Class FormNovoCadastroCNES
    Dim m As New Main
    Dim xml As New XML
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

        If pendentes.Rows.Count > 0 Then

            Try

                dgHistorico.DataSource = pendentes

                dgHistorico.Columns(0).Visible = False
                dgHistorico.Columns(14).Visible = False
                dgHistorico.Columns(15).Visible = False

                dgHistorico.Columns(1).HeaderText = "Nome"
                dgHistorico.Columns(1).Width = 250

                dgHistorico.Columns(2).HeaderText = "CPF"
                dgHistorico.Columns(2).Width = 80

                dgHistorico.Columns(3).HeaderText = "CH Amb"
                dgHistorico.Columns(3).Width = 40

                dgHistorico.Columns(4).HeaderText = "CH Hosp"
                dgHistorico.Columns(4).Width = 40

                dgHistorico.Columns(5).HeaderText = "CH Outros"
                dgHistorico.Columns(5).Width = 40

                dgHistorico.Columns(6).HeaderText = "CBO"
                dgHistorico.Columns(6).Width = 300

                dgHistorico.Columns(7).HeaderText = "Orgão"
                dgHistorico.Columns(7).Width = 60

                dgHistorico.Columns(8).HeaderText = "Nº Conselho"
                dgHistorico.Columns(8).Width = 80

                dgHistorico.Columns(9).HeaderText = "Forma de contrato"
                dgHistorico.Columns(9).Width = 200

                dgHistorico.Columns(10).HeaderText = "Detalhe do contrato"
                dgHistorico.Columns(10).Width = 150

                dgHistorico.Columns(11).HeaderText = "Unidade"
                dgHistorico.Columns(11).Width = 250

                dgHistorico.Columns(12).HeaderText = "Equipe"
                dgHistorico.Columns(12).Width = 150

                dgHistorico.Columns(13).HeaderText = "Data"
                dgHistorico.Columns(13).Width = 90

                For Each row In dgHistorico.Rows
                    row.Cells(9).Value = row.cells(9).Value.ToString.Replace("/", "")
                    row.Cells(10).Value = row.cells(10).Value.ToString.Replace("/", "")
                    row.Cells(11).Value = xml.getCNESXML(row.Cells(11).Value.ToString)
                    row.Cells(13).Value = m.singleDateFormat(row.Cells(13).Value)
                Next

            Catch ex As Exception

            End Try

        End If

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
        tbUnidade.Text = xml.getCNESXML(dgCadastrosPendentes.CurrentRow.Cells(11).Value.ToString)
        tbEquipe.Text = dgCadastrosPendentes.CurrentRow.Cells(12).Value.ToString
        id = dgCadastrosPendentes.CurrentRow.Cells(0).Value
        idMov = dgCadastrosPendentes.CurrentRow.Cells(15).Value
    End Sub
    Private Sub dgCadastrosPendentes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgCadastrosPendentes.CellEnter
        loadDadosVinculo()
    End Sub
    Private Sub btConcluirCadastro_Click(sender As Object, e As EventArgs) Handles btConcluirCadastro.Click
        If dgCadastrosPendentes.RowCount > 0 Then
            If m.doQuery("UPDATE servidor_cnes SET status=1 WHERE id=" & id) Then
                m.doQuery("UPDATE movimento SET status=1 WHERE id=" & idMov)
                m.msgInfo("Cadastro concluído com sucesso!")
                loadCadastros()
                loadHistorico()
                FCNES.addPanelAlteracoes()
            End If
        Else
            m.msgInfo("Selecione um cadastro para concluir.")
        End If

    End Sub

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub

    Private Sub dgCadastrosPendentes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCadastrosPendentes.CellClick
        m.copyDatagridCellValue(dgCadastrosPendentes, e)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            btConcluirCadastro.Enabled = False
            dgHistorico.ClearSelection()
        Else
            btConcluirCadastro.Enabled = True
        End If
    End Sub

    Private Sub dgHistorico_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgHistorico.CellClick
        m.copyDatagridCellValue(dgHistorico, e)
    End Sub

End Class