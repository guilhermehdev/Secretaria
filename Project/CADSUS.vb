Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CADSUS
    Dim m As New Main
    Private Async Function apiCADSUS(cpf As String) As Task(Of Paciente)
        ' 1. Limpa qualquer máscara (remove pontos, traços, espaços) mantendo apenas números
        Dim numeroLimpo As String = Regex.Replace(cpf, "[^\d]", "")

        ' 2. Define dinamicamente o método e as tags com base no tamanho do documento
        Dim nomeMetodo As String = ""
        Dim tagParametro As String = ""
        Dim urlEndpoint As String = "" ' Criamos a variável da URL vazia

        If numeroLimpo.Length = 11 Then
            ' MsgBox("CPF detectado. Consultando o DataSUS...")
            nomeMetodo = "consultarProfissionalPorCpf"
            tagParametro = "cpf"
            urlEndpoint = "http://cnescns.datasus.gov.br/cartao/services/consulta/cpf" ' URL para CPF
        Else
            Debug.WriteLine("Documento inválido. Apenas CPF (11 dígitos) é aceito.")
        End If

        ' 4. Monta o XML injetando o método e a tag corretos dinamicamente
        Dim soapEnvelope As String =
        "<?xml version=""1.0""?>" &
        "<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" " &
        "xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" " &
        "xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" " &
        "xmlns:SOAP-ENC=""http://schemas.xmlsoap.org/soap/encoding/"">" &
        "<SOAP-ENV:Body SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">" &
        $"<NS1:{nomeMetodo} xmlns:NS1=""http://servicos.cartao.webservice.cnes.datasus.gov.br/"">" &
        $"<login xsi:type=""xsd:string"">SCNES.VISUAL</login>" &
        $"<senha xsi:type=""xsd:string"">_SCNES#8$25#</senha>" &
        $"<{tagParametro} xsi:type=""xsd:string"">{numeroLimpo}</{tagParametro}>" &
        $"</NS1:{nomeMetodo}>" &
        "</SOAP-ENV:Body>" &
        "</SOAP-ENV:Envelope>"

        ' 5. Envio da requisição usando o HttpClient camuflado
        Using client As New HttpClient()
            Try
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Borland SOAP 1.2")
                client.DefaultRequestHeaders.Connection.Add("keep-alive")
                client.DefaultRequestHeaders.Add("Pragma", "no-cache")

                Dim content As New StringContent(soapEnvelope, Encoding.UTF8, "text/xml")
                content.Headers.Add("SOAPAction", """""")

                Dim response As HttpResponseMessage = Await client.PostAsync(urlEndpoint, content)
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                If response.IsSuccessStatusCode Then

                    Dim paciente As Paciente = formatData(responseBody)

                    If paciente Is Nothing Then
                        Debug.WriteLine("Nenhum dado de paciente encontrado na resposta.")
                    End If

                    Return paciente

                Else
                    Debug.WriteLine($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}")
                    Return Nothing
                End If

            Catch ex As Exception
                Debug.WriteLine($"Exceção durante a requisição: {ex.Message}")
                Return Nothing
            End Try
        End Using
    End Function

    Private Function formatData(xmlSoap As String) As Paciente
        ' Captura o conteúdo da tag <return>
        Dim match As Match = Regex.Match(xmlSoap, "<return>([\s\S]*?)</return>", RegexOptions.IgnoreCase)

        If Not match.Success Then
            Return Nothing
        End If

        ' Decodifica &lt; &gt; &amp;
        Dim xmlInterno As String = WebUtility.HtmlDecode(match.Groups(1).Value)
        Dim doc As XDocument = XDocument.Parse(xmlInterno)
        Dim retorno = doc...<retorno>.FirstOrDefault()

        System.IO.File.WriteAllText("D:\Desktop\retorno.xml", xmlInterno)

        If retorno Is Nothing Then
            Return Nothing
        End If

        Dim dados As New Paciente With {
        .CPF = If(retorno.<cpf>.Value, ""),
        .CNS = If(retorno.<cns>.Value, ""),
        .Nome = If(retorno.<nome>.Value, ""),
        .NomeMae = If(retorno.<nomeMae>.Value, ""),
        .NomePai = If(retorno.<nomePai>.Value, ""),
        .MunicipioNascimento = If(retorno.<municipioNascimento>.Value, ""),
        .DataNascimento = If(retorno.<dtNascimento>.Value, ""),
        .NomeSocial = If(retorno.<nomeSocial>.Value, ""),
        .Sexo = If(retorno.<sexo>.Value, "")
    }

        Return dados

    End Function
    Public Shared Function consultaCADSUS(cpf As String)
        Dim cadsus As New CADSUS()
        Return cadsus.apiCADSUS(cpf)
    End Function
    'Public Shared Sub SUS_PDF(paciente As DadosPaciente)

    '    Dim reader As New PdfReader(Application.StartupPath & "\PDF\ModeloSUS.pdf")
    '    Dim stamper As New PdfStamper(reader, New FileStream(Application.StartupPath & $"\PDF\Gerados\{paciente.Nome}.pdf", FileMode.Create))
    '    Dim campos = stamper.AcroFields

    '    campos.SetField("nome_cabecalho", paciente.Nome & ",")
    '    campos.SetField("nome_cartao", paciente.Nome)
    '    campos.SetField("dtnasc", CDate(paciente.DataNascimento).ToString("dd/MM/yyyy"))
    '    campos.SetField("sexo", paciente.Sexo)
    '    campos.SetField("sus", FormatarCNS(paciente.CNS))
    '    campos.SetField("cpf", FormatarCPF(paciente.CPF))

    '    stamper.FormFlattening = True
    '    stamper.Close()
    '    reader.Close()

    'End Sub

    Public Shared Function SUS_PDF(paciente As Paciente) As String

        Dim arquivoDestino As String = Application.StartupPath & "\PDF\Gerados\" & paciente.CPF & ".pdf"
        Dim reader As New PdfReader(Application.StartupPath & "\PDF\ModeloSUS.pdf")
        Dim stamper As New PdfStamper(reader, New FileStream(arquivoDestino, FileMode.Create))
        Dim campos = stamper.AcroFields

        campos.SetField("nome_cabecalho", paciente.Nome & ",")
        campos.SetField("nome_cartao", paciente.Nome)
        campos.SetField("dtnasc", CDate(paciente.DataNascimento).ToString("dd/MM/yyyy"))
        campos.SetField("sexo", paciente.Sexo)
        campos.SetField("sus", FormatarCNS(paciente.CNS))
        campos.SetField("cpf", FormatarCPF(paciente.CPF))

        stamper.FormFlattening = True

        stamper.Close()
        reader.Close()

        Return arquivoDestino

    End Function
    Private Shared Function FormatarCPF(cpf As String) As String

        cpf = Regex.Replace(cpf, "\D", "")
        If cpf.Length <> 11 Then
            Return cpf
        End If
        Return String.Format("{0}.{1}.{2}-{3}", cpf.Substring(0, 3), cpf.Substring(3, 3), cpf.Substring(6, 3), cpf.Substring(9, 2))

    End Function
    Private Shared Function FormatarCNS(cns As String) As String

        cns = New String(cns.Where(AddressOf Char.IsDigit).ToArray)
        If cns.Length <> 15 Then Return cns
        Return $"{cns.Substring(0, 3)} {cns.Substring(3, 4)} {cns.Substring(7, 4)} {cns.Substring(11, 4)}"

    End Function
    Public Shared Async Function GerarCartaoSus(CPF As String, sexo As String) As Task(Of ResultadoPdf)

        Try
            'Consulta DataSUS
            Dim paciente As Paciente = Await consultaCADSUS(CPF)
            paciente.Sexo = sexo

            If paciente Is Nothing Then
                Return New ResultadoPdf With {
                    .Sucesso = False,
                    .Mensagem = "Paciente não encontrado"
                }
            End If

            'Gera PDF
            Dim pdf As String = SUS_PDF(paciente)

            Return New ResultadoPdf With {
                .Sucesso = True,
                .Arquivo = pdf
            }

        Catch ex As Exception
            Return New ResultadoPdf With {
                .Sucesso = False,
                .Mensagem = ex.Message
            }

        End Try

    End Function

End Class

Public Class Paciente
    Public Property CPF As String
    Public Property CNS As String
    Public Property Nome As String
    Public Property NomeMae As String
    Public Property NomePai As String
    Public Property MunicipioNascimento As String
    Public Property DataNascimento As String
    Public Property NomeSocial As String
    Public Property Sexo As String

End Class

Public Class ResultadoPdf
    Public Property Sucesso As Boolean
    Public Property Arquivo As String
    Public Property Mensagem As String
End Class
