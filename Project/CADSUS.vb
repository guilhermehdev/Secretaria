Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.io

Public Class Paciente
    Public Property CPF As String
    Public Property CNS As String
    Public Property Nome As String
    Public Property NomeMae As String
    Public Property NomePai As String
    Public Property MunicipioNascimento As String
    Public Property DataNascimento As String
    Public Property NomeSocial As String

End Class

Public Class CADSUS

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
                End If

            Catch ex As Exception
                Debug.WriteLine($"Exceção durante a requisição: {ex.Message}")
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

        'System.IO.File.WriteAllText("D:\Desktop\retorno.xml", xmlInterno)

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
        .NomeSocial = If(retorno.<nomeSocial>.Value, "")
    }

        Return dados

    End Function
    Public Shared Function consultaCADSUS(cpf As String)
        Dim cadsus As New CADSUS()
        Return cadsus.apiCADSUS(cpf)
    End Function
    Public Shared Sub SUS_PDF(paciente As DadosPaciente)

        Dim reader As New PdfReader(Application.StartupPath & "\PDF\ModeloSUS.pdf")
        Dim stamper As New PdfStamper(reader, New FileStream(Application.StartupPath & $"\PDF\Gerados\{paciente.Nome}.pdf", FileMode.Create))
        Dim campos = stamper.AcroFields

        campos.SetField("nome_cabecalho", paciente.Nome & ",")
        campos.SetField("nome_cartao", paciente.Nome)
        campos.SetField("dtnasc", paciente.DataNascimento)
        campos.SetField("sexo", paciente.Sexo)
        campos.SetField("sus", paciente.CNS)
        campos.SetField("cpf", paciente.CPF)

        stamper.FormFlattening = True
        stamper.Close()
        reader.Close()

    End Sub

End Class
Public Class DadosPaciente

    Public Property Nome As String
    Public Property CPF As String
    Public Property CNS As String
    Public Property DataNascimento As String
    Public Property Sexo As String

End Class
