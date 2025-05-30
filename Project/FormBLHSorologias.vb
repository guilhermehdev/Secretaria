Imports ServiceStack

Public Class FormBLHSorologias
    Dim m As New Main
    Public id_doadora As Integer

    Public Sub loadSorologias()
        m.loadDataGrid($"SELECT * FROM blh_sorologia WHERE id_doadora ={id_doadora}", dgSorologias, {False, True, False, False, False}, {"", "Data", "", "", ""})

        dgSorologias.Columns(0).Visible = False
        dgSorologias.Columns(1).HeaderText = "Data"
        dgSorologias.Columns(2).Visible = False
        dgSorologias.Columns(3).Visible = False
        dgSorologias.Columns(4).Visible = False
    End Sub

    Private Sub dgSorologias_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgSorologias.CellEnter
        If dgSorologias.RowCount > 0 Then
            tbDataSorologia.Text = dgSorologias.SelectedRows.Item(0).Cells(1).Value.ToString
            tbDataVencimento.Text = dgSorologias.SelectedRows.Item(0).Cells(2).Value.ToString
            cbResultado.SelectedItem = dgSorologias.SelectedRows.Item(0).Cells(3).Value.ToString
        End If
    End Sub

    Private Sub btSalvarSorologias_Click(sender As Object, e As EventArgs) Handles btSalvarSorologias.Click
        If m.doQuery($"INSERT INTO blh_sorologia (data_sorologia, vencimento_sorologia, resultado_sorologia, id_doadora) VALUES ('{m.mysqlDateFormat(tbDataSorologia.Text)}','{m.mysqlDateFormat(tbDataVencimento.Text)}','{cbResultado.SelectedItem}',{id_doadora})", True) Then
            loadSorologias()
        End If
        MessageBox.Show("Salvo com sucesso!")
    End Sub
    Private Sub tbDataSorologia_TextChanged(sender As Object, e As EventArgs) Handles tbDataSorologia.TextChanged
        If tbDataSorologia.Text.Length = 10 Then
            Try
                Dim dataDigitada As Date = Date.ParseExact(tbDataSorologia.Text, "dd/MM/yyyy", Nothing)
                Dim dataSomada As Date = dataDigitada.AddMonths(6)
                tbDataVencimento.Text = dataSomada.ToString("dd/MM/yyyy")

                If dataSomada < Date.Now Then
                    cbResultado.SelectedIndex = 1
                Else
                    cbResultado.SelectedIndex = 0
                End If

            Catch ex As Exception
                MsgBox("Data inválida.", MsgBoxStyle.Critical)
                tbDataVencimento.Text = ""
            End Try
        End If
    End Sub
    Private Sub FormBLHSorologias_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        loadSorologias()
    End Sub
End Class