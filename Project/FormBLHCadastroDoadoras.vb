Public Class FormBLHCadastroDoadoras
    Dim m As New Main
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
    Private Sub btSalvarDoadora_Click(sender As Object, e As EventArgs) Handles btSalvarDoadora.Click
        If m.requiredFields(Me.Controls) Then
            m.doQuery("INSERT INTO blh_cadastro (nome, parto, origem, obs, sorologia, vencimento_exames, status) VALUES ('" & tbNome.Text & "','" & m.mysqlDateFormat(tbDataParto.Text) & "','" & cbOrigem.SelectedItem & "','" & tbOBS.Text & "','" & m.mysqlDateFormat(tbDataSorologia.Text) & "','" & m.mysqlDateFormat(tbDataVencimento.Text) & "','" & cbResultado.SelectedItem & "')", True)
        End If
    End Sub

    Private Sub loadDoadoras(datagrid As DataGridView)
        m.loadDataGrid("SELECT id, nome, parto, origem, data_cadastro, obs, sorologia, vencimento_exames, status FROM blh_cadastro", datagrid, {False, True, True, False, False, False, False, False, False}, {"id", "Nome", "Parto", "", "", "", "", "", ""}, {0, 240, 70, 0, 0, 0, 0, 0, 0})
    End Sub
    Private Sub FormBLHCadastroDoadoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDoadoras(dgDoadoras)
    End Sub

End Class