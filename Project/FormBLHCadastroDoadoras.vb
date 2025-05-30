Public Class FormBLHCadastroDoadoras
    Dim m As New Main
    Dim blh As New BLH
    Dim currentIndex As Integer
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
        Dim apta_inapta As String = If(rbApta.Checked, 1, 0)
        If Not IsNothing(tbNome.Text) Then
            m.doQuery($"INSERT INTO blh_cadastro (nome, obs, dtnasc, apta_inapta) VALUES ('{tbNome.Text}','{tbOBS.Text}','{m.mysqlDateFormat(tbNasc.Text)}',{apta_inapta}", True)
            MessageBox.Show("Salvo com sucesso!")
            loadDoadoras(dgDoadoras)
        Else
            MessageBox.Show("Preencha todos os campos obrigatórios")
            Exit Sub
        End If
    End Sub

    Private Sub loadDoadoras(datagrid As DataGridView, Optional where As String = "")
        m.loadDataGrid($"Select id, nome, dtnasc, data_cadastro, obs FROM blh_cadastro WHERE ativo= 1 {where} ORDER BY nome", datagrid, {False, True, True, False, False}, {"id", "Nome", "Nasc", "", ""}, {0, 230, 70, 0, 0}, DataGridViewAutoSizeColumnsMode.Fill, True)
        ToolStripStatusLabel1.Text = "Total de doadoras " & datagrid.Rows.Count

    End Sub

    Private Sub loadDesativados(Optional where As String = "")
        m.loadDataGrid($"SELECT id, nome, dtnasc, data_cadastro, obs FROM blh_cadastro WHERE ativo=0 {where}  ORDER BY nome", dgDoadorasDesativadas, {False, True, True, True, False}, {"id", "Nome", "Nasc", "Cadastro", ""}, {0, 240, 75, 70, 0}, DataGridViewAutoSizeColumnsMode.None)
        dgDoadorasDesativadas.ClearSelection()
    End Sub

    Private Sub FormBLHCadastroDoadoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDoadoras(dgDoadoras)
        loadDesativados()
        dgDoadoras.ClearSelection()
    End Sub
    Private Sub tbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged

        If tbBusca.Text.Length >= 3 Then
            loadDoadoras(dgDoadoras, $"And nome Like '%{tbBusca.Text}%'")
        Else
            loadDoadoras(dgDoadoras)
        End If
    End Sub
    Private Sub tbBuscaDN_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaDN.TextChanged

        If tbBuscaDN.Text.Length = 10 Then
            loadDoadoras(dgDoadoras, $"AND dtnasc ='{m.mysqlDateFormat(tbBuscaDN.Text)}'")
        Else
            loadDoadoras(dgDoadoras)
        End If
    End Sub
    Private Sub btAtualizarDoadora_Click(sender As Object, e As EventArgs) Handles btAtualizarDoadora.Click
        If Not IsNothing(tbNome.Text) AndAlso tbNasc.Text.Length >= 10 Then
            currentIndex = dgDoadoras.CurrentRow.Index
            If m.SQLupdate("blh_cadastro", $"nome='{tbNome.Text.ToUpper}',obs='{tbOBS.Text.ToUpper}',dtnasc='{m.mysqlDateFormat(tbNasc.Text)}'", "id", dgDoadoras, 0, "", True) Then
                btAtualizarDoadora.Enabled = False
                btExcluirDoadora.Enabled = False
                btSalvarDoadora.Enabled = True
                'loadDoadoras(dgDoadoras)
                Dim updated = m.getDataset($"Select id, nome, dtnasc, data_cadastro, obs FROM blh_cadastro WHERE ativo=1 And id={dgDoadoras.CurrentRow.Cells(0).Value}")
                dgDoadoras.Rows(currentIndex).Cells(1).Value = updated.Rows(0).Item(1)
                tbNome.Text = updated.Rows(0).Item(1)
                dgDoadoras.Rows(currentIndex).Cells(2).Value = updated.Rows(0).Item(2)
                tbNasc.Text = updated.Rows(0).Item(2)
                tbDataCadastro.Text = updated.Rows(0).Item(3)
                tbOBS.Text = updated.Rows(0).Item(4)

                'dgDoadoras.Rows(currentIndex).Selected = True
                onDatagridCellEnter()
                tbNome.Focus()
            End If
        Else
            MessageBox.Show("Preencha todos os campos obrigatórios")
            Exit Sub
        End If
    End Sub
    Private Sub btExcluirDoadora_Click(sender As Object, e As EventArgs) Handles btExcluirDoadora.Click

        If dgDoadoras.RowCount > 0 Then

            If m.msgQuestion("Excluir Doadora?", "Atenção") Then

                If m.doQuery($"UPDATE blh_cadastro Set ativo=0 WHERE id={dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(0).Value}") Then
                    btAtualizarDoadora.Enabled = False
                    btExcluirDoadora.Enabled = False
                    btSalvarDoadora.Enabled = True
                    loadDoadoras(dgDoadoras)
                    loadDesativados()
                    tbBusca.Focus()
                End If

            End If

        End If

    End Sub
    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        btAtualizarDoadora.Enabled = False
        btSalvarDoadora.Enabled = True
        btExcluirDoadora.Enabled = False
        btNovoParto.Enabled = False
        rbApta.Checked = True
        tbNome.Clear()
        tbOBS.Clear()
        tbNasc.Clear()
        tbDataCadastro.Clear()
        cbPartos.DataSource = Nothing
        tbNovoParto.Clear()
        tbNome.Focus()
        gbPartos.Enabled = False
        btSorologias.Enabled = False
    End Sub

    Private Sub onDatagridCellEnter()
        If dgDoadoras.SelectedRows.Count > 0 Or currentIndex <> Nothing Then
            tbNome.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(1).Value.ToString
            tbNasc.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(2).Value.ToString
            tbOBS.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(4).Value.ToString
            tbDataCadastro.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(3).Value.ToString
            btAtualizarDoadora.Enabled = True
            btSalvarDoadora.Enabled = False
            btExcluirDoadora.Enabled = True
            btNovoParto.Enabled = True
            gbPartos.Enabled = True
            btSorologias.Enabled = True

            blh.loadPartos(cbPartos, dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(0).Value)
            If cbPartos.Items.Count > 0 Then
                btExcluirParto.Enabled = True
            Else
                btExcluirParto.Enabled = False
            End If
        Else
            btAtualizarDoadora.Enabled = False
            btSalvarDoadora.Enabled = True
            btExcluirDoadora.Enabled = False
            btNovoParto.Enabled = False
            btExcluirParto.Enabled = False
            ' gbPartos.Enabled = False
        End If
    End Sub

    Private Sub dgDoadoras_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgDoadoras.CellEnter
        onDatagridCellEnter()
    End Sub
    Private Sub btExcluirParto_Click(sender As Object, e As EventArgs) Handles btExcluirParto.Click
        If cbPartos.Items.Count > 0 Then
            If m.doQuery($"DELETE FROM blh_partos WHERE id={cbPartos.SelectedValue}") Then
                blh.loadPartos(cbPartos, dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(0).Value)
            End If
        Else
            m.msgAlert("Selecione uma data.")
            cbPartos.Focus()
        End If

    End Sub
    Private Sub btNovoParto_Click(sender As Object, e As EventArgs) Handles btNovoParto.Click
        Try
            Dim idDoadora = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(0).Value
            If tbNovoParto.Text.Length >= 10 Then
                If m.SQLinsert("blh_partos", "data, id_doadora", "'" & m.mysqlDateFormat(tbNovoParto.Text) & "'," & idDoadora, True) Then
                    blh.loadPartos(cbPartos, idDoadora)
                    'loadDoadoras(dgDoadoras)
                    tbNovoParto.Clear()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgDoadorasDesativadas_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgDoadorasDesativadas.CellEnter
        If dgDoadorasDesativadas.RowCount > 0 AndAlso dgDoadorasDesativadas.CurrentRow IsNot Nothing Then
            btReativar.Enabled = True
        Else
            btReativar.Enabled = False
        End If
    End Sub
    Private Sub btReativar_Click(sender As Object, e As EventArgs) Handles btReativar.Click
        If dgDoadorasDesativadas.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione uma doadora para reativar")
            Exit Sub
        End If
        If m.msgQuestion("Reativar Doadora?", "Atenção") Then
            If m.doQuery($"UPDATE blh_cadastro SET ativo=1 WHERE id={dgDoadorasDesativadas.Rows(dgDoadorasDesativadas.CurrentRow.Index).Cells(0).Value}") Then
                loadDoadoras(dgDoadoras)
                loadDesativados()
                dgDoadoras_CellClick(sender, e)
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaDesativados.TextChanged
        If tbBuscaDesativados.Text.Length >= 3 Then
            loadDesativados($"AND nome LIKE '%{tbBuscaDesativados.Text}%'")
        Else
            loadDesativados()
        End If

    End Sub
    Private Sub tbBuscaDNDesativados_TextChanged(sender As Object, e As EventArgs) Handles tbBuscaDNDesativados.TextChanged
        If tbBuscaDNDesativados.Text.Length = 10 Then
            loadDesativados($"AND dtnasc ='{m.mysqlDateFormat(tbBuscaDNDesativados.Text)}'")
        Else
            loadDesativados()
        End If
    End Sub

    Private Sub dgDoadoras_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDoadoras.CellClick
        dgDoadoras_CellEnter(sender, e)
    End Sub
    Private Sub FormBLHCadastroDoadoras_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        tbBusca.Focus()
    End Sub
    Private Sub tbBusca_Enter(sender As Object, e As EventArgs) Handles tbBusca.Enter
        tbBuscaDN.Clear()
    End Sub
    Private Sub tbBuscaDN_Enter(sender As Object, e As EventArgs) Handles tbBuscaDN.Enter
        tbBusca.Clear()
    End Sub
    Private Sub btSorologias_Click(sender As Object, e As EventArgs) Handles btSorologias.Click
        FormBLHSorologias.id_doadora = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(0).Value
        FormBLHSorologias.ShowDialog()
    End Sub

End Class