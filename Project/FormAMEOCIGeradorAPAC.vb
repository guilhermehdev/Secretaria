Imports ClosedXML.Excel

Public Class FormAMEOCIGeradorAPAC
    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If tbFaixaInicio.Text.Length < 13 OrElse tbFaixaFim.Text.Length < 13 OrElse numQtd.Value < 1 Then
            MessageBox.Show("Preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim numeros
        SaveFileDialog1.ShowDialog()
        SaveFileDialog1.Filter = "Arquivos Excel|*.xlsx"
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.DefaultExt = "xlsx"
        ' SaveFileDialog1.FileName = "OCIAPAC.xlsx"

        If tbFaixaInicio.Text.Length = 13 AndAlso tbFaixaFim.Text.Length = 13 Then
            numeros = GerarNumerosAPAC_Padrao(tbFaixaInicio.Text, tbFaixaFim.Text, CInt(numQtd.Value))

            ' Cria o workbook
            Dim wb As New XLWorkbook()
            Dim ws = wb.Worksheets.Add("APACs")

            ' Cabeçalho
            'ws.Cell(1, 1).Value = "NÚMEROS APAC"
            'ws.Cell(1, 1).Style.Font.Bold = True

            ' Insere os números
            Dim linha As Integer = 1
            For Each n In numeros

                FormAMEmain.doQuery("INSERT INTO oci (num_apac) VALUES ('" & n.ToString() & "')")
                ws.Cell(linha, 1).Value = n.ToString()
                linha += 1
            Next

            ' Ajusta largura da coluna
            ws.Column(1).AdjustToContents()

            ' Salva o arquivo
            Dim caminho = SaveFileDialog1.FileName & ".xlsx"
            'IO.Path.Combine(Application.StartupPath, "numeros_apac.xlsx")
            wb.SaveAs(caminho)

            MessageBox.Show("Arquivo gerado com sucesso em:" & vbCrLf & caminho, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FormAMEOCINumAPAC.loadAPACAvailable()
            FormAMEOCI.loadAPACdisp()
        Else
            MessageBox.Show("Os números devem ter 13 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

    End Sub

    'Private Function GerarNumerosAPAC_Padrao(inicio As String, fim As String, quantidade As Integer) As List(Of String)
    '    Dim lista As New List(Of String)

    '    If String.IsNullOrWhiteSpace(inicio) Or String.IsNullOrWhiteSpace(fim) Then
    '        Throw New ArgumentException("Inicio e fim devem ser informados.")
    '    End If
    '    If inicio.Length <> 13 OrElse fim.Length <> 13 Then
    '        Throw New ArgumentException("Os números devem ter 13 dígitos.")
    '    End If
    '    If quantidade <= 0 Then
    '        Throw New ArgumentException("Quantidade deve ser maior que zero.")
    '    End If

    '    Dim atual As Long = CLng(inicio)
    '    Dim limite As Long = CLng(fim)
    '    Dim count As Integer = 0

    '    ' Flag para evitar aplicar +10 repetidamente quando estamos em uma dezena (último dígito 0)
    '    Dim lastWasPlus10 As Boolean = False

    '    While atual <= limite AndAlso count < quantidade
    '        lista.Add(atual.ToString().PadLeft(13, "0"c))
    '        count += 1

    '        If atual >= limite OrElse count >= quantidade Then Exit While

    '        Dim s As String = atual.ToString().PadLeft(13, "0"c)
    '        Dim ultimoDigito As Integer = Integer.Parse(s.Substring(s.Length - 1, 1))

    '        If ultimoDigito = 7 Then
    '            ' Se ainda não aplicamos +10 para esta dezena, aplicamos agora.
    '            ' Caso contrário (já aplicamos +10 na iteração anterior), voltamos para +11.
    '            If Not lastWasPlus10 Then
    '                atual += 10
    '                lastWasPlus10 = True
    '            Else
    '                atual += 11
    '                lastWasPlus10 = False
    '            End If
    '        ElseIf ultimoDigito = 7 Then
    '            ' 9 -> soma 1 para ir para a dezena cheia (ex: ...899 -> ...900)
    '            atual += 1
    '            lastWasPlus10 = False
    '        Else
    '            ' regra geral: soma 11
    '            atual += 11
    '            lastWasPlus10 = False
    '        End If
    '    End While

    '    ' Garante incluir o fim exato (autoridade fornecida), se ainda houver espaço
    '    If lista.Count < quantidade AndAlso lista.Last() <> fim Then
    '        lista.Add(fim)
    '    End If

    '    Return lista
    'End Function

    Private Function GerarNumerosAPAC_Padrao(inicio As String, fim As String, quantidade As Integer) As List(Of String)

        If inicio.Length <> 13 OrElse fim.Length <> 13 Then
            Throw New ArgumentException("Os números devem ter 13 dígitos.")
        End If

        If quantidade <= 0 Then
            Throw New ArgumentException("Quantidade deve ser maior que zero.")
        End If

        Dim lista As New List(Of String)

        Dim atual As String = inicio.PadLeft(13, "0"c)
        Dim limite As Long = CLng(fim)

        ' 0 = normal (+11)
        ' 1 = acabou de virar 0
        ' 2 = acabou de somar +10
        Dim estado As Integer = 0

        While CLng(atual) <= limite AndAlso lista.Count < quantidade

            lista.Add(atual)

            If lista.Count >= quantidade Then Exit While

            Dim ultimoDigito As Integer = CInt(atual.Last().ToString())

            If estado = 1 Then
                ' depois de virar 0 → +10
                atual = (CLng(atual) + 10).ToString().PadLeft(13, "0"c)
                estado = 2

            ElseIf estado = 2 Then
                ' volta ao normal
                atual = (CLng(atual) + 11).ToString().PadLeft(13, "0"c)
                estado = 0

            ElseIf ultimoDigito = 9 Then
                ' força virar 0
                atual = atual.Substring(0, atual.Length - 1) & "0"
                atual = (CLng(atual) + 10).ToString().PadLeft(13, "0"c)
                estado = 1

            Else
                ' regra padrão
                atual = (CLng(atual) + 11).ToString().PadLeft(13, "0"c)
            End If

        End While

        Return lista
    End Function

End Class