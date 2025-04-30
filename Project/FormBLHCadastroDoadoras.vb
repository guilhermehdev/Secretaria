Imports Google.Protobuf.WellKnownTypes
Imports ServiceStack

Public Class FormBLHCadastroDoadoras
    Dim m As New Main
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Function dateCheck(tbMask As MaskedTextBox)
        Dim data As DateTime

        If DateTime.TryParseExact(tbMask.Text, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, data) Then
            ' Data válida
            Return True
        Else
            ' Data inválida
            tbMask.Focus()
            Return False
        End If

    End Function


    Private Sub btSalvarDoadora_Click(sender As Object, e As EventArgs) Handles btSalvarDoadora.Click
        If Not IsNothing(tbNome.Text) AndAlso dateCheck(tbDataParto) AndAlso dateCheck(tbDataSorologia) AndAlso dateCheck(tbDataVencimento) AndAlso cbOrigem.SelectedItem <> "" AndAlso cbResultado.SelectedItem <> "" Then
            m.doQuery("INSERT INTO blh_cadastro (nome, parto, origem, obs, sorologia, vencimento_exames, status) VALUES ('" & tbNome.Text & "','" & m.mysqlDateFormat(tbDataParto.Text) & "','" & cbOrigem.SelectedItem & "','" & tbOBS.Text & "','" & m.mysqlDateFormat(tbDataSorologia.Text) & "','" & m.mysqlDateFormat(tbDataVencimento.Text) & "','" & cbResultado.SelectedItem & "')", True)
            MessageBox.Show("Salvo com sucesso!")
            loadDoadoras(dgDoadoras)
        Else
            MessageBox.Show("Preencha todos os campos obrigatórios")
            Exit Sub
        End If
    End Sub

    Private Sub loadDoadoras(datagrid As DataGridView, Optional where As String = "")
        m.loadDataGrid($"SELECT id, nome, parto, origem, data_cadastro, obs, sorologia, vencimento_exames, status FROM blh_cadastro {where} ORDER BY nome", datagrid, {False, True, True, False, False, False, False, False, False}, {"id", "Nome", "Parto", "", "", "", "", "", ""}, {0, 240, 74, 0, 0, 0, 0, 0, 0},, True)
        ToolStripStatusLabel1.Text = "Total de doadoras: " & datagrid.Rows.Count
    End Sub

    Private Sub FormBLHCadastroDoadoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDoadoras(dgDoadoras)

    End Sub
    Private Sub tbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        loadDoadoras(dgDoadoras, $"WHERE nome LIKE '%{tbBusca.Text}%'")
    End Sub
    Private Sub btAtualizarDoadora_Click(sender As Object, e As EventArgs) Handles btAtualizarDoadora.Click
        If Not IsNothing(tbNome.Text) AndAlso tbDataParto.Text <> "  /  /" AndAlso tbDataSorologia.Text <> "  /  /" AndAlso tbDataVencimento.Text <> "  /  /" AndAlso cbOrigem.SelectedItem <> "" AndAlso cbResultado.SelectedItem <> "" Then

            If m.SQLupdate("blh_cadastro", $"nome='{tbNome.Text.ToUpper}',parto='{m.mysqlDateFormat(tbDataParto.Text)}',origem='{cbOrigem.SelectedItem}',obs='{tbOBS.Text.ToUpper}', sorologia='{m.mysqlDateFormat(tbDataSorologia.Text)}',vencimento_exames='{m.mysqlDateFormat(tbDataVencimento.Text)}',status='{cbResultado.SelectedItem}'", "id", dgDoadoras, 0, "", True, True, "SELECT id, nome, parto, origem, data_cadastro, obs, sorologia, vencimento_exames, status FROM blh_cadastro ORDER BY nome", True) Then
                btAtualizarDoadora.Enabled = False
                btExcluirDoadora.Enabled = False
                btSalvarDoadora.Enabled = True
            End If
        Else
            MessageBox.Show("Preencha todos os campos obrigatórios")
            Exit Sub
        End If
    End Sub
    Private Sub btExcluirDoadora_Click(sender As Object, e As EventArgs) Handles btExcluirDoadora.Click

        If m.SQLdelete("blh_cadastro", "id", dgDoadoras, 0, True, True, "SELECT id, nome, parto, origem, data_cadastro, obs, sorologia, vencimento_exames, status FROM blh_cadastro ORDER BY nome", True) Then
                btAtualizarDoadora.Enabled = False
                btExcluirDoadora.Enabled = False
                btSalvarDoadora.Enabled = True
            End If

    End Sub
    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        btAtualizarDoadora.Enabled = False
        btSalvarDoadora.Enabled = True
        btExcluirDoadora.Enabled = False
    End Sub

    Private Sub dgDoadoras_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDoadoras.CellClick
        If dgDoadoras.SelectedRows.Count > 0 Then
            tbNome.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(1).Value.ToString
            tbDataParto.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(2).Value.ToString
            cbOrigem.SelectedItem = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(3).Value.ToString
            tbDataSorologia.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(6).Value.ToString
            cbResultado.SelectedItem = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(8).Value.ToString
            tbDataVencimento.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(7).Value.ToString
            tbOBS.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(5).Value.ToString
            btAtualizarDoadora.Enabled = True
            btSalvarDoadora.Enabled = False
            btExcluirDoadora.Enabled = True
        End If

    End Sub
End Class