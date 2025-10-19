Imports System.Data
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports MySql.Data.MySqlClient

Public Class PDF
    Dim pdfPath As String = Application.StartupPath & "/PDF/PROFISSIONAIS.pdf"
    Dim xml As New XML
    Public vconexao As MySqlConnection
    Public Sql As String

    Public Sub importPDFManifest(dialog As OpenFileDialog, multiselect As Boolean)
        Dim pdfFiles As New List(Of String)()
        Dim pdfNotFound As New List(Of String)()
        Dim m As New Main
        Dim pdf As New PDF

        dialog.Filter = "PDF Files (*.pdf)|*.pdf"
        dialog.Multiselect = multiselect

        If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            pdfFiles.AddRange(dialog.FileNames)
        Else
            Exit Sub
        End If

        For Each pdfFile As String In pdfFiles
            Dim dataOuvidoria As Dictionary(Of String, String) = pdf.ExtrairDadosOuvidoria(pdfFile)
            Dim datatable = m.getDataset($"SELECT id FROM ouvidoria WHERE protocolo ={dataOuvidoria("MANIFESTAÇÃO")}")
            Dim id As Integer

            If datatable.Rows.Count > 0 Then
                Dim dataManifestacao As String
                id = datatable.Rows(0).Item(0)

                dataManifestacao = "Protocolo: " & dataOuvidoria("MANIFESTAÇÃO") & vbCrLf & vbCrLf & "Data: " & dataOuvidoria("Recebido em") & vbCrLf & vbCrLf & "Solicitante: " & dataOuvidoria("Solicitante") & vbCrLf & vbCrLf & "Telefone: " & dataOuvidoria("Telefone") & vbCrLf & vbCrLf & "Manifestação: " & dataOuvidoria("Manifestação") & vbCrLf & vbCrLf & dataOuvidoria("Andamento")

                Dim res = m.SQLinsert("manifestacoes", "manifest,id_ouvidoria", "'" & dataManifestacao & "'," & id)

                If res <> True Then
                    m.doQuery($"UPDATE manifestacoes SET manifest='{dataManifestacao}' WHERE id_ouvidoria={id}")
                End If

            Else
                pdfNotFound.Add(dataOuvidoria("MANIFESTAÇÃO"))
            End If
        Next

        MessageBox.Show($"{pdfFiles.Count} arquivo(s) PDF importado(s) com sucesso!", "Importar arquivos PDF", MessageBoxButtons.OK)

        Dim joinProtocols As String = String.Join(vbCrLf, pdfNotFound)

        If joinProtocols.Count > 0 Then
            m.msgAlert($"Protocolos não cadastrados:{vbCrLf & vbCrLf & joinProtocols}")
        End If
    End Sub

    Public Function ExtrairDadosOuvidoria(ByVal pdfOuvidoria As String) As Dictionary(Of String, String)
        Dim resultado As New Dictionary(Of String, String) From {
        {"MANIFESTAÇÃO", ""},
        {"Recebido em", ""},
        {"Solicitante", ""},
        {"Telefone", ""},
        {"Manifestação", ""},
        {"Andamento", ""}
    }

        Try

            ' Criar um StringBuilder para armazenar o texto extraído
            Dim textoExtraido As New StringBuilder()

            ' Ler o PDF usando iTextSharp
            Using reader As New PdfReader(pdfOuvidoria)
                For i As Integer = 1 To reader.NumberOfPages
                    textoExtraido.AppendLine(PdfTextExtractor.GetTextFromPage(reader, i))
                Next
            End Using

            ' Converter o texto extraído em uma única string
            Dim texto As String = textoExtraido.ToString()

            Dim regexRemoverTrechos1 As New Regex("(?<=Endereço).*?(?=Reincidente)", RegexOptions.Singleline)
            texto = regexRemoverTrechos1.Replace(texto, "")

            texto = Regex.Replace(texto, "Usuário.*", "", RegexOptions.Singleline)

            ' Definir expressões regulares para extrair os campos necessários
            Dim regexManifestacaoID As New Regex("MANIFESTAÇÃO\s*:\s*(?<valor>\d+)")
            Dim regexRecebidoEm As New Regex("Recebido em\s*:\s*(?<valor>.+)")
            Dim regexSolicitante As New Regex("Solicitante\s*:\s*(?<valor>.+)")
            Dim regexTelefone As New Regex("Telefone\s*:\s*﴾(?<ddd>\d{2})﴿\s*(?<numero>\d{5}‐\d{4})")
            Dim regexManifestacao As New Regex("Manifestação\s*:\s*(?<valor>[\s\S]*)?(Andamento|$)", RegexOptions.Multiline)

            ' Extrair e armazenar os valores correspondentes
            Dim matchManifestacaoID = regexManifestacaoID.Match(texto)
            If matchManifestacaoID.Success Then resultado("MANIFESTAÇÃO") = matchManifestacaoID.Groups("valor").Value.Trim()

            Dim matchRecebido = regexRecebidoEm.Match(texto)
            If matchRecebido.Success Then resultado("Recebido em") = matchRecebido.Groups("valor").Value.Trim()

            Dim matchSolicitante = regexSolicitante.Match(texto)
            If matchSolicitante.Success Then resultado("Solicitante") = matchSolicitante.Groups("valor").Value.Trim()

            Dim matchTelefone As Match = regexTelefone.Match(texto)
            If matchTelefone.Success Then
                Dim ddd As String = matchTelefone.Groups("ddd").Value
                Dim numero As String = matchTelefone.Groups("numero").Value

                resultado("Telefone") = String.Format("({0}) {1}", ddd, numero)
            Else
                resultado("Telefone") = "Não informado" ' Ou um valor padrão
            End If

            ' Extrair "Manifestação" (até "Andamento" ou final do texto)
            Dim matchManifestacao As Match = regexManifestacao.Match(texto)
            If matchManifestacao.Success Then
                resultado("Manifestação") = matchManifestacao.Groups("valor").Value.Trim().Replace("'", "`").Replace("﴾", "(").Replace("﴿", ")")
            End If

            ' Extrair "Andamento" (se existir)
            Dim regexAndamento As New Regex("Andamento:(.*)", RegexOptions.Multiline)
            Dim matchAndamento As Match = regexAndamento.Match(texto)

            If matchAndamento.Success Then
                resultado("Andamento") = vbCrLf & matchAndamento.Groups(1).Value.Trim()
            End If

        Catch ex As Exception
            Console.WriteLine("Erro ao processar o PDF: " & ex.Message)
        End Try

        Return resultado

    End Function

    Public Function getProf(fc As String, cbo As String, cnes As String, gestao As String)
        Dim textoExtraido As String = ExtrairTextoDoPDF() ' Substitua pelo texto extraído.
        Dim dadosSeparados As Dictionary(Of String, List(Of String)) = ProcessarDados(textoExtraido)
        Dim linhasfiltradas As New List(Of String)()
        Dim texto As New Text.StringBuilder()
        Dim arrCNESPublico As String() = {"135801", "413933", "2025795", "2060647", "2085763", "2085798", "2087294", "4805194", "2087308", "2087316", "2855747", "5341167", "5348862", "5348870", "5348889", "6399576", "6439047", "6912273", "6964869", "7036892", "7135173", "7721439", "7750269", "7774826", "7841965", "9180249", "9297715", "9691723", "4329716", "0413933", "2869373", "6964893", "2869373", "4329716", "7983174", "5057302"}

        ' Exibir os dados organizados
        For Each formaContratacao In dadosSeparados.Keys
            If fc.Trim = formaContratacao.Trim Then
                For Each linha In dadosSeparados(formaContratacao)
                    If gestao = 0 Then
                        If arrCNESPublico.Contains(ExtrairCNES(linha)) Then
                            texto.AppendLine(linha)
                        End If
                    ElseIf gestao = 1 Then
                        If Not arrCNESPublico.Contains(ExtrairCNES(linha)) Then
                            texto.AppendLine(linha)
                        End If
                    End If
                Next
            End If
        Next

        linhasfiltradas = FiltrarLinhasPorCBOCNES(texto.ToString(), cbo, cnes)

        ' Criar um DataTable e configurar suas colunas
        Dim tabela As New DataTable()
        tabela.Columns.Add("CPF", GetType(String))
        tabela.Columns.Add("CNS", GetType(String))
        tabela.Columns.Add("Nome", GetType(String))
        tabela.Columns.Add("CNES", GetType(String))
        tabela.Columns.Add("CBO", GetType(String))
        tabela.Columns.Add("Descrição", GetType(String))

        ' Preencher o DataTable com as linhas filtradas
        Dim regexLinhaDados As New Regex("^(?<cpf>\d{11})\s+(?<cns>\d+)\s+(?<nome>.+?)\s+(?<cnes>\d+)\s+(?<cbo>\d{6})\s*-\s*(?<descricao>.+)$")
        For Each linha As String In linhasfiltradas
            Dim match = regexLinhaDados.Match(linha)
            If match.Success Then
                tabela.Rows.Add(
                    match.Groups("cpf").Value,
                    match.Groups("cns").Value,
                    match.Groups("nome").Value,
                    match.Groups("cnes").Value & " - " & xml.getCNESXML(match.Groups("cnes").Value),
                    match.Groups("cbo").Value,
                    match.Groups("descricao").Value
                )
            End If
        Next

        Return tabela

    End Function

    Public Function getProfByNameORCPF(Optional cpf As String = "", Optional nome As String = "") As DataTable
        Dim dtProfissionais As New DataTable()

        ' Definir colunas no DataTable
        dtProfissionais.Columns.Add("CPF", GetType(String))
        dtProfissionais.Columns.Add("CNS", GetType(String))
        dtProfissionais.Columns.Add("Nome", GetType(String))
        dtProfissionais.Columns.Add("CNES", GetType(String))
        dtProfissionais.Columns.Add("CBO", GetType(String))

        Try
            ' Abrir o arquivo PDF
            Using leitorPDF As New PdfReader(pdfPath)
                Dim totalPaginas As Integer = leitorPDF.NumberOfPages

                For i As Integer = 1 To totalPaginas
                    Dim textoPagina As String = PdfTextExtractor.GetTextFromPage(leitorPDF, i)

                    'texto.Split(New String() {vbLf, vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
                    ' Dividir o texto em linhas
                    Dim linhas As String() = textoPagina.Split(New String() {vbLf, vbCrLf}, StringSplitOptions.RemoveEmptyEntries)

                    ' Regex para identificar a estrutura esperada de cada linha de profissional
                    Dim regexLinhaProfissional As New Regex("(\d{11}) (\d{15}) (.+?) (\d{7}) (\d{6} - .+)")

                    For Each linha As String In linhas
                        Dim match As Match = regexLinhaProfissional.Match(linha)

                        If match.Success Then
                            Dim linhaCPF As String = match.Groups(1).Value
                            Dim linhaCNS As String = match.Groups(2).Value
                            Dim linhaNome As String = match.Groups(3).Value.Trim()
                            Dim linhaCNES As String = match.Groups(4).Value
                            Dim linhaCBO As String = match.Groups(5).Value

                            ' Aplicar filtros de CPF e Nome (se fornecidos)
                            If (String.IsNullOrEmpty(cpf) OrElse linhaCPF = cpf) AndAlso
                               (String.IsNullOrEmpty(nome) OrElse linhaNome.ToUpper().Contains(nome.ToUpper())) Then

                                ' Adicionar os dados ao DataTable
                                dtProfissionais.Rows.Add(linhaCPF, linhaCNS, linhaNome, xml.getCNESXML(linhaCNES), (linhaCBO))
                            End If
                        End If
                    Next
                Next
            End Using

            Console.WriteLine(dtProfissionais.Rows(0).Item(0).ToString)

        Catch ex As Exception
            Console.WriteLine("Erro ao processar o PDF: " & ex.Message)
        End Try

        Return dtProfissionais

    End Function

    Private Function ExtrairTextoDoPDF() As String
        Dim texto As New Text.StringBuilder()

        Try
            Using reader As New PdfReader(pdfPath)
                For i As Integer = 1 To reader.NumberOfPages
                    texto.AppendLine(PdfTextExtractor.GetTextFromPage(reader, i))
                Next
            End Using
        Catch ex As Exception
            Console.WriteLine("Erro ao ler o PDF: " & ex.Message)
        End Try

        Return texto.ToString()
    End Function

    Public Function ExtrairCNES(ByVal linha As String) As String
        Dim regexLinhaDados As New Regex("^(?<cpf>\d{11})\s+(?<cns>\d+)\s+(?<nome>.+?)\s+(?<cnes>\d+)\s+(?<cbo>\d{6})\s*-\s*(?<descricao>.+)$")
        Dim match = regexLinhaDados.Match(linha)

        If match.Success Then
            ' Retornar o valor do grupo "cnes"
            Return match.Groups("cnes").Value
        Else
            ' Retornar uma string vazia se a linha não corresponder ao formato esperado
            Return String.Empty
        End If
    End Function

    Public Function ExtrairCBO(ByVal linha As String) As String
        Dim regexLinhaDados As New Regex("^(?<cpf>\d{11})\s+(?<cns>\d+)\s+(?<nome>.+?)\s+(?<cnes>\d+)\s+(?<cbo>\d{6})\s*-\s*(?<descricao>.+)$")
        Dim match = regexLinhaDados.Match(linha)

        If match.Success Then
            ' Retornar o valor do grupo "cbo"
            Return match.Groups("cbo").Value
        Else
            ' Retornar uma string vazia se a linha não corresponder ao formato esperado
            Return String.Empty
        End If
    End Function

    Private Function FiltrarLinhasPorCBOCNES(ByVal texto As String, ByVal cbo As String, ByVal cnes As String) As List(Of String)
        Dim linhasFiltradas As New List(Of String)()

        ' Tentar dividir por diferentes separadores de linha
        Dim linhas As String() = texto.Split(New String() {vbLf, vbCrLf}, StringSplitOptions.RemoveEmptyEntries)

        For Each linha As String In linhas
            ' Verificar se a linha contém o CBO e o CNES
            If linha.Contains(cbo) AndAlso linha.Contains(cnes) Then
                linhasFiltradas.Add(linha)
            End If
        Next

        Return linhasFiltradas

    End Function

    Private Function ProcessarDados(ByVal texto As String) As Dictionary(Of String, List(Of String))
        Dim resultado As New Dictionary(Of String, List(Of String))()

        ' Dividir o texto por linhas
        Dim linhas As String() = texto.Split(New String() {vbLf, vbCrLf}, StringSplitOptions.RemoveEmptyEntries)

        Dim formaContratacaoAtual As String = ""
        Dim regexFormaContratacao As New Regex("Forma de Contratação\s*:\s*(.+)")
        Dim regexLinhaDados As New Regex("^(?<cpf>\d{11})\s+(?<cns>\d+)\s+(?<nome>.+?)\s+(?<cnes>\d+)\s+(?<cbo>\d{6})\s*-\s*(?<descricao>.+)$")


        For Each linha As String In linhas
            ' Detectar mudança de forma de contratação
            Dim matchContratacao = regexFormaContratacao.Match(linha)
            If matchContratacao.Success Then
                formaContratacaoAtual = matchContratacao.Groups(1).Value.Trim()
                If Not resultado.ContainsKey(formaContratacaoAtual) Then
                    resultado(formaContratacaoAtual) = New List(Of String)()
                End If
                Continue For
            End If

            Dim matchDados = regexLinhaDados.Match(linha)
            If matchDados.Success Then
                ' Adicionar a linha à lista correspondente à forma de contratação
                If Not String.IsNullOrEmpty(formaContratacaoAtual) Then
                    resultado(formaContratacaoAtual).Add(linha)
                End If
            End If

        Next

        Return resultado

    End Function


End Class

Public Class Endereco
    Public Property Logradouro As String
    Public Property CEP As String
    Public Property Bairro As String

    Public Function ExtrairCEPsDoTXT(caminhoArquivo As String) As List(Of Endereco)
        Dim lista As New List(Of Endereco)
        Dim rgxCep As New Regex("\d{5}-\d{3}")

        ' Dicionário de abreviações → forma completa
        Dim tipos As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
        {"r", "Rua"}, {"rua", "Rua"},
        {"av", "Avenida"}, {"avenida", "Avenida"},
        {"pç", "Praça"}, {"pr", "Praça"},
        {"al", "Alameda"}, {"rod", "Rodovia"},
        {"est", "Estrada"}, {"tr", "Travessa"},
        {"r ped", "Rua Padre"},
        {"r prof", "Rua Professor"},
        {"r dr", "Rua Doutor"},
        {"r dep", "Rua Deputado"},
        {"r cel", "Rua Coronel"},
        {"vl", "Vila"},
        {"vla", "Viela"}
    }

        For Each linha In File.ReadAllLines(caminhoArquivo)
            linha = linha.Trim()
            If String.IsNullOrWhiteSpace(linha) Then Continue For

            Dim m As Match = rgxCep.Match(linha)
            If Not m.Success Then Continue For

            Dim cep As String = m.Value
            Dim semCep As String = linha.Replace(cep, "").Trim()

            Dim partes() As String = semCep.Split(New String() {" - "}, StringSplitOptions.None)
            If partes.Length < 3 Then Continue For

            Dim logradouro As String = ""
            Dim tipoAbrev As String = ""
            Dim bairro As String = ""

            Select Case partes.Length
                Case 3
                    ' Formato normal: logradouro - tipo - bairro
                    logradouro = partes(0).Trim()
                    tipoAbrev = partes(1).Trim().ToLower()
                    bairro = partes(2).Trim()

                Case 4
                    ' Formato com complemento: logradouro - complemento - tipo - bairro
                    logradouro = $"{partes(0).Trim()} {partes(1).Trim()}"
                    tipoAbrev = partes(2).Trim().ToLower()
                    bairro = partes(3).Trim()

                Case Else
                    ' Linhas fora do padrão, ignora
                    Continue For
            End Select

            ' Substitui abreviação
            Dim tipoCompleto As String = If(tipos.ContainsKey(tipoAbrev), tipos(tipoAbrev), tipoAbrev)
            Dim logradouroCompleto As String = $"{tipoCompleto} {logradouro}"
            ' Inverter se contiver vírgula (ex: "Anchieta, Padre" → "Padre Anchieta")
            If logradouroCompleto.Contains(",") Then
                Dim partesNome() As String = logradouroCompleto.Split(","c)
                If partesNome.Length = 2 Then
                    logradouroCompleto = $"{partesNome(1).Trim()} {partesNome(0).Trim()}"
                End If
            End If

            ' Corrige tipo de logradouro posicionado no final (ex: "Doutor lado ímpar Rua Osvaldo Marçal")
            Dim tiposList = {"rua", "avenida", "travessa", "estrada", "rodovia", "praça", "alameda", "viela", "vila"}

            For Each tipo In tiposList
                Dim padrao As String = $"(\b[Dd]outor|\b[Pp]adre|\b[Pp]rofessor|\b[Dd]ep|\b[Cc]oronel).*?\b{tipo}\b"
                If Regex.IsMatch(logradouroCompleto, padrao, RegexOptions.IgnoreCase) Then
                    ' extrai "Rua" ou "Avenida" e move pro início
                    Dim tipoEncontrado As Match = Regex.Match(logradouroCompleto, "\b(" & String.Join("|", tiposList) & ")\b", RegexOptions.IgnoreCase)
                    If tipoEncontrado.Success Then
                        Dim tipoStr As String = tipoEncontrado.Value
                        logradouroCompleto = $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tipoStr)} {Regex.Replace(logradouroCompleto, tipoStr, "", RegexOptions.IgnoreCase).Trim()}"
                    End If
                    Exit For
                End If
            Next

            Dim prefixos = {"da", "do", "de", "das", "dos"}
            For Each pfx In prefixos
                For Each tipo In tipos.Values
                    Dim padrao As String = $"^{pfx}\s+{tipo}\b"
                    If Regex.IsMatch(logradouroCompleto, padrao, RegexOptions.IgnoreCase) Then
                        logradouroCompleto = Regex.Replace(logradouroCompleto, $"^{pfx}\s+", "", RegexOptions.IgnoreCase).Trim()
                        Exit For
                    End If
                Next
            Next

            ' Corrige abreviações de bairro
            bairro = bairro.Replace("Jd", "Jardim").Replace("Vl", "Vila").Replace("Etn", "Estancia").Replace("Baln", "Balneário").Trim()

            lista.Add(New Endereco With {
            .CEP = cep,
            .Logradouro = logradouroCompleto,
            .Bairro = bairro
        })
        Next

        Return lista
    End Function

    Public Sub SalvarCEPsNoMySQL(lista As List(Of Endereco))
        Try

            For Each item In lista
                Dim p As New Dictionary(Of String, Object) From {
                     {"@logradouro", item.Logradouro},
                     {"@cep", item.CEP},
                     {"@bairro", item.Bairro}
                 }
                FormAMEmain.doQuery("INSERT INTO ceps_peruibe (cep, logradouro, bairro) VALUES (@cep, @logradouro, @bairro)", p)
            Next

            MessageBox.Show($"Foram importados {lista.Count} registros com sucesso!", "Importação concluída", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Debug.WriteLine("Erro ao salvar no banco: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
