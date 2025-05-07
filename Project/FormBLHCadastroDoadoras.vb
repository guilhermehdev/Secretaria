Imports Google.Protobuf.WellKnownTypes
Imports ServiceStack

Public Class FormBLHCadastroDoadoras
    Dim m As New Main
    Dim blh As New BLH
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
        If Not IsNothing(tbNome.Text) Then
            m.doQuery("INSERT INTO blh_cadastro (nome, obs) VALUES ('" & tbNome.Text & "','" & tbOBS.Text & "')", True)
            MessageBox.Show("Salvo com sucesso!")
            loadDoadoras(dgDoadoras)
        Else
            MessageBox.Show("Preencha todos os campos obrigatórios")
            Exit Sub
        End If
    End Sub

    Private Sub loadDoadoras(datagrid As DataGridView, Optional where As String = "")
        m.loadDataGrid($"SELECT id, nome, dtnasc, data_cadastro, obs FROM blh_cadastro WHERE ativo=1 {where} ORDER BY nome", datagrid, {False, True, True, False, False, False, False, False, False, False}, {"id", "Nome", "Nasc", "", "", "", "", "", "", ""}, {0, 230, 70, 0, 0, 0, 0, 0, 0, 0}, DataGridViewAutoSizeColumnsMode.Fill, True)
        ToolStripStatusLabel1.Text = "Total de doadoras: " & datagrid.Rows.Count
        dgDoadoras.ClearSelection()
    End Sub

    Private Sub FormBLHCadastroDoadoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDoadoras(dgDoadoras)

    End Sub
    Private Sub tbBusca_TextChanged(sender As Object, e As EventArgs) Handles tbBusca.TextChanged
        loadDoadoras(dgDoadoras, $"AND nome LIKE '%{tbBusca.Text}%'")
    End Sub
    Private Sub btAtualizarDoadora_Click(sender As Object, e As EventArgs) Handles btAtualizarDoadora.Click
        If Not IsNothing(tbNome.Text) Then

            If m.SQLupdate("blh_cadastro", $"nome='{tbNome.Text.ToUpper}',obs='{tbOBS.Text.ToUpper}'", "id", dgDoadoras, 0, "", True, True, "SELECT id, nome,data_cadastro, obs FROM blh_cadastro ORDER BY nome", True) Then
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

        ' If m.SQLdelete("blh_cadastro", "id", dgDoadoras, 0, True, True, "SELECT id, nome, dtnasc, data_cadastro, obs FROM blh_cadastro ORDER BY nome", True) Then
        If m.msgQuestion("Excluir Doadora?", "Atenção") Then

            If m.doQuery($"UPDATE blh_cadastro SET ativo=0 WHERE id={dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(0).Value}") Then
                btAtualizarDoadora.Enabled = False
                btExcluirDoadora.Enabled = False
                btSalvarDoadora.Enabled = True
                loadDoadoras(dgDoadoras)
            End If

        End If

    End Sub
    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        btAtualizarDoadora.Enabled = False
        btSalvarDoadora.Enabled = True
        btExcluirDoadora.Enabled = False
    End Sub

    Private Sub dgDoadoras_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgDoadoras.CellEnter
        If dgDoadoras.SelectedRows.Count > 0 Then
            tbNome.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(1).Value.ToString
            tbOBS.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(4).Value.ToString
            tbDataCadastro.Text = dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(3).Value.ToString
            btAtualizarDoadora.Enabled = True
            btSalvarDoadora.Enabled = False
            btExcluirDoadora.Enabled = True

            blh.loadPartos(cbPartos, dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(0).Value)

        End If
    End Sub
    Private Sub btExcluirParto_Click(sender As Object, e As EventArgs) Handles btExcluirParto.Click
        If m.doQuery($"DELETE FROM blh_partos WHERE id={cbPartos.SelectedValue}") Then
            blh.loadPartos(cbPartos, dgDoadoras.Rows(dgDoadoras.CurrentRow.Index).Cells(0).Value)
        End If
    End Sub
End Class