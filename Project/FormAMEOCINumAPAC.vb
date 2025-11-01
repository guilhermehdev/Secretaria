Imports System.IO
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports ClosedXML.Excel
Imports System.Text

Public Class FormAMEOCINumAPAC

    Private Function GerarNumerosAPAC_Padrao(inicio As String, fim As String, quantidade As Integer) As List(Of String)
        Dim lista As New List(Of String)

        If String.IsNullOrWhiteSpace(inicio) Or String.IsNullOrWhiteSpace(fim) Then
            Throw New ArgumentException("Inicio e fim devem ser informados.")
        End If
        If inicio.Length <> 13 OrElse fim.Length <> 13 Then
            Throw New ArgumentException("Os números devem ter 13 dígitos.")
        End If
        If quantidade <= 0 Then
            Throw New ArgumentException("Quantidade deve ser maior que zero.")
        End If

        Dim atual As Long = CLng(inicio)
        Dim limite As Long = CLng(fim)
        Dim count As Integer = 0

        ' Flag para evitar aplicar +10 repetidamente quando estamos em uma dezena (último dígito 0)
        Dim lastWasPlus10 As Boolean = False

        While atual <= limite AndAlso count < quantidade
            lista.Add(atual.ToString().PadLeft(13, "0"c))
            count += 1

            If atual >= limite OrElse count >= quantidade Then Exit While

            Dim s As String = atual.ToString().PadLeft(13, "0"c)
            Dim ultimoDigito As Integer = Integer.Parse(s.Substring(s.Length - 1, 1))

            If ultimoDigito = 0 Then
                ' Se ainda não aplicamos +10 para esta dezena, aplicamos agora.
                ' Caso contrário (já aplicamos +10 na iteração anterior), voltamos para +11.
                If Not lastWasPlus10 Then
                    atual += 10
                    lastWasPlus10 = True
                Else
                    atual += 11
                    lastWasPlus10 = False
                End If
            ElseIf ultimoDigito = 9 Then
                ' 9 -> soma 1 para ir para a dezena cheia (ex: ...899 -> ...900)
                atual += 1
                lastWasPlus10 = False
            Else
                ' regra geral: soma 11
                atual += 11
                lastWasPlus10 = False
            End If
        End While

        ' Garante incluir o fim exato (autoridade fornecida), se ainda houver espaço
        If lista.Count < quantidade AndAlso lista.Last() <> fim Then
            lista.Add(fim)
        End If

        Return lista
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim numeros = GerarNumerosAPAC_Padrao("3525704850877", "3525704854860", 400)
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
            ws.Cell(1, 1).Value = "NÚMEROS APAC"
            ws.Cell(1, 1).Style.Font.Bold = True

            ' Insere os números
            Dim linha As Integer = 2
            For Each n In numeros
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

        Else
            MessageBox.Show("Os números devem ter 13 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        For Each n In numeros

        Next

    End Sub

    Public Sub substituirNumAPAC(caminhoArquivo As String)
        ' Dicionário de números errados → certos
        Dim mapa As New Dictionary(Of String, String) From {
        {"3525245389072", "3525705638587"},
        {"3525245389083", "3525705638598"},
        {"3525245389094", "3525705638609"},
        {"3525245389105", "3525705638610"},
        {"3525245389116", "3525705638620"},
        {"3525245389127", "3525705638631"},
        {"3525245389138", "3525705638642"},
        {"3525245389149", "3525705638653"},
        {"3525245389150", "3525705638664"},
        {"3525245389160", "3525705638675"},
        {"3525245389171", "3525705638686"},
        {"3525245389182", "3525705638697"},
        {"3525245389193", "3525705638708"},
        {"3525245389204", "3525705638719"},
        {"3525245389215", "3525705638720"},
        {"3525245389226", "3525705638730"},
        {"3525245389237", "3525705638741"},
        {"3525245389248", "3525705638752"},
        {"3525245389259", "3525705638763"},
        {"3525245389260", "3525705638774"},
        {"3525245389270", "3525705638785"},
        {"3525245389281", "3525705638796"},
        {"3525245389292", "3525705638807"},
        {"3525245389303", "3525705638818"},
        {"3525245389314", "3525705638829"},
        {"3525245389325", "3525705638830"},
        {"3525245389336", "3525705638840"},
        {"3525245389347", "3525705638851"},
        {"3525245389358", "3525705638862"},
        {"3525245389369", "3525705638873"},
        {"3525245389370", "3525705638884"},
        {"3525245389380", "3525705638895"},
        {"3525245389391", "3525705638906"},
        {"3525245389402", "3525705638917"},
        {"3525245389413", "3525705638928"},
        {"3525245389424", "3525705638939"},
        {"3525245389435", "3525705638940"},
        {"3525245389446", "3525705638950"},
        {"3525245389457", "3525705638961"},
        {"3525245389468", "3525705638972"},
        {"3525245389479", "3525705638983"},
        {"3525245389480", "3525705638994"},
        {"3525245389490", "3525705639005"},
        {"3525245389501", "3525705639016"},
        {"3525245389512", "3525705639027"},
        {"3525245389523", "3525705639038"},
        {"3525245389534", "3525705639049"},
        {"3525245389545", "3525705639050"},
        {"3525245389556", "3525705639060"},
        {"3525245389567", "3525705639071"},
        {"3525245389578", "3525705639082"},
        {"3525245389589", "3525705639093"},
        {"3525245389590", "3525705639104"},
        {"3525245389600", "3525705639115"},
        {"3525245389611", "3525705639126"},
        {"3525245389622", "3525705639137"},
        {"3525245389633", "3525705639148"},
        {"3525245389644", "3525705639159"},
        {"3525245389655", "3525705639160"},
        {"3525245389666", "3525705639170"},
        {"3525245389677", "3525705639181"},
        {"3525245389688", "3525705639192"},
        {"3525245389699", "3525705639203"},
        {"3525245389700", "3525705639214"},
        {"3525245389710", "3525705639225"},
        {"3525245389721", "3525705639236"},
        {"3525245389732", "3525705639247"},
        {"3525245389743", "3525705639258"},
        {"3525245389754", "3525705639269"},
        {"3525245389765", "3525705639270"},
        {"3525245389776", "3525705639280"},
        {"3525245389787", "3525705639291"},
        {"3525245389798", "3525705639302"},
        {"3525245389809", "3525705639313"},
        {"3525245389810", "3525705639324"},
        {"3525245389820", "3525705639335"},
        {"3525245389831", "3525705639346"},
        {"3525245389842", "3525705639357"},
        {"3525245389853", "3525705639368"},
        {"3525245389864", "3525705639379"},
        {"3525245389875", "3525705639380"},
        {"3525245389886", "3525705639390"},
        {"3525245389897", "3525705639401"},
        {"3525245389908", "3525705639412"},
        {"3525245389919", "3525705639423"},
        {"3525245389920", "3525705639434"},
        {"3525245389930", "3525705639445"},
        {"3525245389941", "3525705639456"},
        {"3525245389952", "3525705639467"},
        {"3525245389963", "3525705639478"},
        {"3525245389974", "3525705639489"},
        {"3525245389985", "3525705639490"},
        {"3525245389996", "3525705639500"},
        {"3525245390007", "3525705639511"},
        {"3525245390018", "3525705639522"},
        {"3525245390029", "3525705639533"},
        {"3525245390030", "3525705639544"},
        {"3525245390040", "3525705639555"},
        {"3525245390051", "3525705639566"},
        {"3525245390062", "3525705639577"}
    }

        ' --- 1. Lê o arquivo original em bytes (mantendo codificação ANSI) ---
        Dim conteudoBytes As Byte() = File.ReadAllBytes(caminhoArquivo)
        Dim conteudo As String = Encoding.Default.GetString(conteudoBytes)

        ' --- 2. Substitui literalmente, sem regex ---
        For Each par In mapa
            conteudo = conteudo.Replace(par.Key, par.Value)
        Next

        ' --- 3. Força CRLF em todas as quebras ---
        conteudo = conteudo.Replace(vbCrLf, vbLf) ' normaliza
        conteudo = conteudo.Replace(vbCr, vbLf)
        conteudo = conteudo.Replace(vbLf, vbCrLf)

        ' --- 4. Divide por linhas e checa comprimento ---
        Dim linhas = conteudo.Split({vbCrLf}, StringSplitOptions.None)
        Dim linhasComErro As New List(Of String)
        For i = 0 To linhas.Length - 1
            If linhas(i).Trim().Length > 0 AndAlso linhas(i).Length <> 533 Then
                linhasComErro.Add($"Linha {i + 1}: {linhas(i).Length} caracteres (esperado: 533)")
            End If
        Next

        ' --- 5. Salva novamente em ANSI (sem mudar tamanho) ---
        Dim novoCaminho As String = Path.Combine(
        Path.GetDirectoryName(caminhoArquivo),
        Path.GetFileNameWithoutExtension(caminhoArquivo) & "_corrigido" & Path.GetExtension(caminhoArquivo)
    )

        File.WriteAllText(novoCaminho, conteudo, Encoding.Default)

        ' --- 6. Relatório visual ---
        If linhasComErro.Count > 0 Then
            MsgBox("⚠️ Linhas desalinhadas detectadas:" & vbCrLf & String.Join(vbCrLf, linhasComErro))
        Else
            MsgBox($"✅ Arquivo corrigido com sucesso e validado: {novoCaminho}")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            substituirNumAPAC(OpenFileDialog1.FileName)
        End If
    End Sub

End Class