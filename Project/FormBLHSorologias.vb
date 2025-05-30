Imports ServiceStack

Public Class FormBLHSorologias
    Dim m As New Main
    Public id_doadora As Integer

    Public Sub loadSorologias()
        Dim soroData = m.getDataset($"SELECT  blh_sorologia.*, blh_cadastro.nome 
        FROM blh_sorologia
        JOIN blh_cadastro ON blh_cadastro.id = blh_sorologia.id_doadora 
        WHERE blh_sorologia.id_doadora={id_doadora}")

        dgSorologias.DataSource = soroData

        If dgSorologias.RowCount > 0 Then

            dgSorologias.Columns(0).Visible = False
            dgSorologias.Columns(1).HeaderText = "Data"
            'dgSorologias.Columns(1).Width = 80
            dgSorologias.Columns(2).Visible = False
            dgSorologias.Columns(3).Visible = False
            dgSorologias.Columns(4).Visible = False
            dgSorologias.Columns(5).Visible = False

            gbSorologias.Text = soroData.Rows(0).Item(5).ToString

            dgSorologias.ClearSelection()
        Else
            dgSorologias.DataSource = Nothing
            gbSorologias.Text = FormBLHCadastroDoadoras.dgDoadoras.SelectedRows(0).Cells(1).Value.ToString
        End If

        tbDataSorologia.Clear()
        tbDataVencimento.Clear()
        cbResultado.SelectedIndex = -1
        btExcluirSorologia.Enabled = False
        tbDataSorologia.Focus()
    End Sub

    Private Sub dgSorologias_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgSorologias.CellEnter
        Try
            If dgSorologias.RowCount > 0 Then
                tbDataSorologia.Text = dgSorologias.SelectedRows.Item(0).Cells(1).Value.ToString
                tbDataVencimento.Text = dgSorologias.SelectedRows.Item(0).Cells(2).Value.ToString
                cbResultado.SelectedItem = dgSorologias.SelectedRows.Item(0).Cells(3).Value.ToString
                btExcluirSorologia.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btSalvarSorologias_Click(sender As Object, e As EventArgs) Handles btSalvarSorologias.Click
        If IsDate(tbDataSorologia.Text) AndAlso IsDate(tbDataVencimento.Text) AndAlso cbResultado.Text <> Nothing Then
            If m.doQuery($"INSERT INTO blh_sorologia (data_sorologia, vencimento_sorologia, resultado_sorologia, id_doadora) VALUES ('{m.mysqlDateFormat(tbDataSorologia.Text)}','{m.mysqlDateFormat(tbDataVencimento.Text)}','{cbResultado.SelectedItem}',{id_doadora})", True) Then
                loadSorologias()
                btExcluirSorologia.Enabled = False
            End If
            MsgBox("Salvo com sucesso!")
        Else
            MsgBox("Preencha todos os campos!")
            tbDataSorologia.Focus()
        End If
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
    Private Sub FormBLHSorologias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadSorologias()
    End Sub
    Private Sub btExcluirSorologia_Click(sender As Object, e As EventArgs) Handles btExcluirSorologia.Click
        If m.SQLdelete("blh_sorologia", "id", dgSorologias, 0, True) Then
            loadSorologias()
        End If
    End Sub
    Private Sub dgSorologias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSorologias.CellClick
        dgSorologias_CellEnter(sender, e)
    End Sub
    Private Sub FormBLHSorologias_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        tbDataSorologia.Focus()
    End Sub

End Class