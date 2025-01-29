Public Class FRelatorioPrazos
    Dim m As New Main

    Private Sub periodoVencido(ByVal combobox As ComboBox)
        Dim comboSource As New Dictionary(Of String, String)()

        comboSource.Add("0", "Todos")
        comboSource.Add("30", "1 mês")
        comboSource.Add("60", "2 meses")
        comboSource.Add("90", "3 meses")
        comboSource.Add("120", "4 meses")
        comboSource.Add("150", "5 meses")
        comboSource.Add("180", "6 meses")
        comboSource.Add("181", "Mais de 6 meses")

        combobox.DataSource = New BindingSource(comboSource, Nothing)
        combobox.DisplayMember = "Value"
        combobox.ValueMember = "Key"
    End Sub

    Private Sub FRelatorioPrazos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m.loadComboBox("SELECT id,descricao FROM destinos ORDER BY id", cbDestino, "descricao", "id")
        cbDestino.SelectedIndex = -1
        periodoVencido(cbPeriodoVencido)
        cbPeriodoVencido.SelectedIndex = -1
    End Sub

    Private Function emAndamento(ByVal dias As Integer, ByVal destino As Integer)
        Dim ndias As Integer
        ndias = 30 - dias
        Return m.getDataset("SELECT ouvidoria.protocolo AS protocolo FROM ouvidoria JOIN destinos ON ouvidoria.id_destino = destinos.id WHERE DATEDIFF(NOW(),ouvidoria.abertura) =" & ndias & " AND ouvidoria.`status` = 'Em andamento' AND ouvidoria.id_destino=" & destino)

    End Function

    Private Function vencidos(ByVal dias As Integer, Optional ByVal destino As Integer = 0)
        Dim ndias As Integer
        ndias = If(dias = 0, 30, dias + 30)

        Return m.getDataset("SELECT ouvidoria.protocolo AS protocolo FROM ouvidoria JOIN destinos ON ouvidoria.id_destino = destinos.id WHERE DATEDIFF(NOW(),ouvidoria.abertura) >= " & ndias & " AND ouvidoria.`status` = 'Vencido' AND ouvidoria.id_destino=" & destino, True)

    End Function

    Private Sub btOKEmAndamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOKEmAndamento.Click
        If cbDestino.SelectedIndex = 0 Then
            Dim dest = m.getDataset("SELECT id,descricao FROM destinos ORDER BY id")
            lbEmAndamento.Items.Clear()
            For Each destino As DataRow In dest.Rows
                Dim emandamentos = emAndamento(NumericUpDownEmAndamento.Value, destino.Item(0))
                Dim idDestrino = destino.Item(0)
                Dim nomeDestrino = destino.Item(1)

                lbEmAndamento.Items.Add(nomeDestrino)

                For i = 0 To emandamentos.Rows.Count - 1
                    lbEmAndamento.Items.Add(emandamentos.Rows(i).Item(0).ToString)
                Next
                lbEmAndamento.Items.Add(vbCrLf)

            Next
        Else

            Dim list = emAndamento(NumericUpDownEmAndamento.Value, cbDestino.SelectedValue)
            lbEmAndamento.Items.Clear()
            For Each row As DataRow In list.rows
                lbEmAndamento.Items.Add(row.Item(0).ToString)
            Next

        End If

    End Sub

    Private Sub btOKVencidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOKVencidos.Click
        If cbDestino.SelectedIndex = 0 Then
            Dim dest = m.getDataset("SELECT id,descricao FROM destinos ORDER BY id")
            lbVencidos.Items.Clear()
            For Each destino As DataRow In dest.Rows

                Dim vencido = vencidos(cbPeriodoVencido.SelectedValue, destino.Item(0))
                Dim idDestrino = destino.Item(0)
                Dim nomeDestrino = destino.Item(1)

                lbVencidos.Items.Add(nomeDestrino)

                For i = 0 To vencido.Rows.Count - 1
                    lbVencidos.Items.Add(vencido.Rows(i).Item(0).ToString)
                Next
                lbVencidos.Items.Add(vbCrLf)

            Next
        Else

            Dim list = vencidos(cbPeriodoVencido.SelectedValue, cbDestino.SelectedValue)

            lbVencidos.Items.Clear()
            For Each row As DataRow In list.rows
                lbVencidos.Items.Add(row.Item(0).ToString)
            Next

        End If

        '  Console.Write(cbPeriodoVencido.SelectedValue)

    End Sub

    Private Sub copyFromListBox(ByVal listbox As ListBox)
        Dim copy_buffer As New System.Text.StringBuilder
        For Each item As Object In listbox.SelectedItems
            copy_buffer.AppendLine(item.ToString)
        Next
        If copy_buffer.Length > 0 Then
            Clipboard.SetText(copy_buffer.ToString)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Click
        copyFromListBox(lbEmAndamento)
    End Sub

    Private Sub ContextMenuStrip2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuStrip2.Click
        copyFromListBox(lbVencidos)
    End Sub

    Private Sub lbEmAndamento_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbEmAndamento.DoubleClick
        For i = 0 To lbEmAndamento.Items.Count - 1
            lbEmAndamento.SetSelected(i, True)
        Next
    End Sub

    Private Sub lbVencidos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbVencidos.DoubleClick
        For i = 0 To lbVencidos.Items.Count - 1
            lbVencidos.SetSelected(i, True)
        Next
    End Sub

End Class