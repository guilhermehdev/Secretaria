Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Newtonsoft.Json.Linq

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

    Public Shared Function SUS_PDF(paciente As Paciente) As String

        Dim arquivoDestino As String = Application.StartupPath & "\PDF\Gerados\" & paciente.CPF & ".pdf"
        Dim reader As New PdfReader(Application.StartupPath & "\PDF\ModeloSUS.pdf")
        Dim stamper As New PdfStamper(reader, New FileStream(arquivoDestino, FileMode.Create))
        Dim campos = stamper.AcroFields

        campos.SetField("nome_cabecalho", If(paciente.Sexo = "F", "Sra. " & paciente.Nome, "Sr. " & paciente.Nome))
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

    Public Async Function PuxadaSUS(CPF_NOME_SUS As String) As Threading.Tasks.Task(Of Boolean)
        Dim frm As New Form
        Dim m As Main = New Main

        frm.FormBorderStyle = FormBorderStyle.None
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Size = New Size(170, 50)
        Dim lbl As New Label
        lbl.Dock = DockStyle.Fill
        lbl.TextAlign = ContentAlignment.MiddleCenter
        lbl.BackColor = Color.FromArgb(64, 64, 64)
        lbl.ForeColor = Color.Gold
        lbl.Text = "Consultando CADSUS. Aguarde..."
        frm.Controls.Add(lbl)

        Dim entrada As String = CPF_NOME_SUS.Trim()
        Dim apenasDigitos As String = New String(entrada.Where(Function(c) Char.IsDigit(c)).ToArray())

        Dim modo As String
        If apenasDigitos.Length = 11 Then
            modo = "cpf"
        ElseIf apenasDigitos.Length = 15 Then
            modo = "cns"
        ElseIf entrada.Length > 0 Then
            modo = "nome"
        Else
            m.msgError("Digite um CPF, CNS ou nome pra buscar.")
            Return False
        End If

        Dim item As JObject = Nothing

        frm.Show()
        Try
            Using client As New HttpClient()
                client.DefaultRequestHeaders.Add("X-API-Key", "pxs_YsvC8sVxDUb7cMkgJ4r76PhXBFBtEBnZQFqyTeNx")
                client.DefaultRequestHeaders.Add("User-Agent", "AME-Peruibe/1.0")
                client.DefaultRequestHeaders.Add("X-Municipio", "3537602") ' IBGE de Peruíbe (o exemplo da documentação usa outro município, não usar o deles)

                If modo = "cpf" OrElse modo = "cns" Then
                    Dim resp = Await client.GetAsync($"https://puxadasus.blancsystem.com.br/v1/pessoas/{modo}/{apenasDigitos}")
                    Dim textoResposta As String = Await resp.Content.ReadAsStringAsync()

                    ' MsgBox(textoResposta)

                    If Not resp.IsSuccessStatusCode Then
                        m.msgError($"Erro na consulta CADSUS ({CInt(resp.StatusCode)}): {textoResposta}")
                        Return False
                    End If

                    item = ExtrairRegistroCadsus(JObject.Parse(textoResposta))
                    If item Is Nothing Then
                        m.msgError("Paciente não encontrado.")
                        Return False
                    End If
                Else
                    ' Busca por nome - só o /pesquisas atende, e pode devolver um
                    ' resumo (ver ExtrairRegistroCadsus). Se vier resumido (sem
                    ' endereço), complementa buscando o cadastro completo pelo CPF
                    ' que a busca por nome retornou.
                    Dim corpoBusca As New JObject
                    corpoBusca("nome") = entrada
                    Dim conteudo As New StringContent(corpoBusca.ToString(Newtonsoft.Json.Formatting.None), Encoding.UTF8, "application/json")
                    Dim resp = Await client.PostAsync("https://puxadasus.blancsystem.com.br/v1/pesquisas", conteudo)
                    Dim textoResposta As String = Await resp.Content.ReadAsStringAsync()

                    If Not resp.IsSuccessStatusCode Then
                        m.msgError($"Erro na consulta CADSUS ({CInt(resp.StatusCode)}): {textoResposta}")
                        Return False
                    End If

                    item = ExtrairRegistroCadsus(JObject.Parse(textoResposta))
                    If item Is Nothing Then
                        m.msgError("Paciente não encontrado.")
                        Return False
                    End If

                    If item("enderecoLogradouro") Is Nothing Then
                        Dim cpfBusca As String = New String(If(item("cpf")?.ToString(), "").Where(Function(c) Char.IsDigit(c)).ToArray())
                        If cpfBusca.Length = 11 Then
                            Dim respCompleto = Await client.GetAsync($"https://puxadasus.blancsystem.com.br/v1/pessoas/cpf/{cpfBusca}")
                            If respCompleto.IsSuccessStatusCode Then
                                Dim itemCompleto = ExtrairRegistroCadsus(JObject.Parse(Await respCompleto.Content.ReadAsStringAsync()))
                                If itemCompleto IsNot Nothing Then item = itemCompleto
                            End If
                        End If
                    End If


                End If
            End Using
        Catch ex As Exception
            m.msgError("Erro ao consultar CADSUS: " & ex.Message)
            Return False
        Finally
            frm.Close()
        End Try

        If item Is Nothing Then Return False

        ' Campos confirmados numa consulta real (GET /v1/pessoas/cpf/{cpf}) - CPF vem
        ' formatado com pontuação, por isso limpa antes de usar/comparar com o banco
        ' local (que guarda só dígitos).
        Dim cpfRetornado As String = New String(If(item("cpf")?.ToString(), "").Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim cns As String = item("numeroCns")?.ToString()
        Dim nome As String = item("nome")?.ToString()
        Dim nomeMae As String = item("nomeMae")?.ToString()
        Dim sexo As String = item("sexo")?.ToString() ' já vem "M"/"F", igual o sistema usa
        Dim racaCor As String = item("racaCor")?.ToString() ' código IBGE tipo "01" - assumindo mesma tabela usada em txtRaca
        Dim dataNascStr As String = item("dataNascimento")?.ToString() ' já vem dd/MM/yyyy

        Dim cepApi As String = New String(If(item("enderecoCep")?.ToString(), "").Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim numeroApi As String = item("enderecoNumero")?.ToString()
        Dim complementoApi As String = item("enderecoComplemento")?.ToString()
        Dim bairroApi As String = item("enderecoBairro")?.ToString()

        Dim primeiroTelefone As JObject = Nothing
        If item("telefone") IsNot Nothing AndAlso item("telefone").HasValues Then
            primeiroTelefone = CType(item("telefone")(0), JObject)
        End If

        ' Mesma lógica de antes (perguntar se quer imprimir o cartão SUS), só que
        ' usando o CPF que voltou da API em vez do texto digitado - cobre também o
        ' caso de ter buscado por CNS ou nome, sem CPF nenhum digitado na tela.
        'If Not String.IsNullOrEmpty(cpfRetornado) Then
        '    Dim pacData = FormAMEOCI.getPacientes(cpfRetornado)
        '    If pacData IsNot Nothing AndAlso pacData.Rows.Count > 0 Then

        '    End If
        'End If

        FormAMEOCI.isLoading = True
        Try
            If Not String.IsNullOrEmpty(cpfRetornado) Then FormAMEOCI.txtCpfPaciente.Text = cpfRetornado
            If Not String.IsNullOrEmpty(nome) Then FormAMEOCI.txtNomePaciente.Text = nome
            If Not String.IsNullOrEmpty(nomeMae) Then FormAMEOCI.txtNomeMae.Text = nomeMae
            If Not String.IsNullOrEmpty(sexo) Then FormAMEOCI.txtSexo.Text = sexo
            If Not String.IsNullOrEmpty(racaCor) Then FormAMEOCI.txtRaca.SelectedValue = racaCor

            If Not String.IsNullOrEmpty(dataNascStr) Then
                Dim dtNasc As Date
                If Date.TryParseExact(dataNascStr, {"dd/MM/yyyy", "yyyy-MM-dd"}, CultureInfo.InvariantCulture, DateTimeStyles.None, dtNasc) Then
                    FormAMEOCI.dtNascimento.Text = dtNasc.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                End If
            End If

            If cepApi.Length = 8 Then
                If FormAMEOCI.cep(cepApi.Insert(5, "-")) Then
                    FormAMEOCI.txtCep.Text = cepApi.Insert(5, "-")
                Else
                    FormAMEOCI.txtCep.Text = ""
                    If Not String.IsNullOrEmpty(bairroApi) Then FormAMEOCI.txtBairro.Text = bairroApi
                End If
            End If
            If Not String.IsNullOrEmpty(numeroApi) Then FormAMEOCI.txtNumero.Text = numeroApi
            If Not String.IsNullOrEmpty(complementoApi) Then FormAMEOCI.txtComplemento.Text = complementoApi

            If primeiroTelefone IsNot Nothing Then
                Dim ddd As String = primeiroTelefone("ddd")?.ToString()
                Dim numeroTel As String = New String(If(primeiroTelefone("numero")?.ToString(), "").Where(Function(c) Char.IsDigit(c)).ToArray())
                If Not String.IsNullOrEmpty(ddd) Then FormAMEOCI.txtDDD.Text = ddd
                If numeroTel.Length > 0 Then FormAMEOCI.txtTelefone.Text = numeroTel
            End If

            If Not String.IsNullOrEmpty(cns) Then FormAMEOCI.txtCnsPaciente.Text = cns
        Finally
            FormAMEOCI.isLoading = False
            FormAMEOCI.popupGrid.Visible = False
        End Try

        Return False
    End Function

    ''' <summary>
    ''' A resposta da API vem em dois formatos possíveis: direto (GET /v1/pessoas/...,
    ''' o cadastro completo sem envelope) ou dentro de {"total":N,"registro":[...]}
    ''' (POST /v1/pesquisas). Essa função aceita os dois e sempre devolve o registro
    ''' como JObject, ou Nothing se não achou nada.
    ''' </summary>
    Private Function ExtrairRegistroCadsus(json As JObject) As JObject
        If json Is Nothing Then Return Nothing

        If json("registro") IsNot Nothing Then
            If Not json("registro").HasValues Then Return Nothing
            Return CType(json("registro")(0), JObject)
        End If

        ' Sem "registro": ou é o cadastro completo direto, ou é {"registro":[]} vazio
        ' (já tratado acima) - se chegou aqui e tem "nome"/"cpf", é o cadastro direto.
        If json("nome") IsNot Nothing OrElse json("cpf") IsNot Nothing Then Return json

        Return Nothing
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
