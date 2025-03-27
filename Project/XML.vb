Imports System.IO
Imports System.Net
Imports System.Threading.Tasks
Imports System.Xml
Imports System.Xml.Linq
Imports ServiceStack
Imports System.Linq
Imports System.Security.Cryptography


Public Class XML
    Private ultimoHash As String = ""
    Public xmlDoc As New XmlDocument()
    Public xmlDocCBO As New XmlDocument()
    Public xmlDocOrgao As New XmlDocument()
    Dim XMLCBOfilePath As String = Application.StartupPath & "\XML\CBO.XML"
    Dim XMLCNESfilePath As String = Application.StartupPath & "\XML\CNES.XML"
    Dim XMLOrgaofilePath As String = Application.StartupPath & "\XML\CLASSE.XML"
    Dim XMLEquipesPath As String = Application.StartupPath & "\XML\EQUIPES.XML"
    Public Function getCBOXML(ByVal codCBO As String) As String
        xmlDocCBO.Load(XMLCBOfilePath)

        Dim cbo As String = ""
        Dim dataxml As XmlNodeList = xmlDocCBO.GetElementsByTagName("CODIGO")

        For i = 0 To dataxml.Count - 1
            If dataxml.Item(i).InnerText = codCBO Then
                cbo = dataxml.Item(i).NextSibling.ChildNodes(0).Value
            End If
        Next

        Return cbo

    End Function

    Public Function getCNESXML(ByVal codCBO As String) As String
        xmlDocCBO.Load(XMLCNESfilePath)

        Dim cbo As String = ""
        Dim dataxml As XmlNodeList = xmlDocCBO.GetElementsByTagName("CODIGO")

        For i = 0 To dataxml.Count - 1
            If dataxml.Item(i).InnerText = codCBO Then
                cbo = dataxml.Item(i).NextSibling.ChildNodes(0).Value
            End If
        Next

        Return cbo

    End Function

    Public Function getOrgaodeClasse(ByVal codOrgao As String) As String
        xmlDocOrgao.Load(XMLOrgaofilePath)

        Dim orgao As String = ""
        Dim dataxml As XmlNodeList = xmlDocOrgao.GetElementsByTagName("ORGAO")

        For i = 0 To dataxml.Count - 1
            If dataxml.Item(i).Attributes("COD").Value = codOrgao Then
                orgao = dataxml.Item(i).Attributes("DESC").Value
            End If
        Next

        Return orgao

    End Function

    Public Sub cbBuscaUnidades(ByVal combobox As ComboBox)
        Dim comboSource As New Dictionary(Of String, String)()

        comboSource.Add("3537607036892", "AMBULATORIO MEDICO DE ESPECIALIDADES DE PERUIBE")
        comboSource.Add("3537609691723", "AMBULATORIO DE DOENCAS INFECTO CONTAGIOSAS")
        comboSource.Add("3537602085763", "AMFFITO")
        comboSource.Add("3537606439047", "CENTRO DE ATENCAO PSICOSSOCIAL DE PERUIBE - CAPS")
        comboSource.Add("3537607721439", "CASA DA MULHER E DA CRIANCA")
        comboSource.Add("3537607774826", "CASA DO ADOLESCENTE DE PERUIBE - CADOL")
        comboSource.Add("3537607841965", "CENTRAL DE REGULACAO DE PERUIBE")
        comboSource.Add("3537605057302", "CENTRO DE ESPECIALIDADES ODONTOLOGICAS DE PERUIBE")
        comboSource.Add("3537600135801", "CENTRAL DE ABASTECIMENTO FARMACEUTICO PERUIBE")
        comboSource.Add("3537609297715", "MATERNIDADE MUNICIPAL DE PERUIBE")
        comboSource.Add("3537602855747", "SERV DE ATENCAO PSICOSSOCIAL A INFANCIA E JUVENTUDE-SAPSIJ")
        comboSource.Add("3537606399576", "SECRETARIA MUNICIPAL DE SAUDE")
        comboSource.Add("3537607135173", "UNIDADE DE PRONTO ATENDIMENTO DE PERUIBE - UPA24H")
        comboSource.Add("3537607983174", "UNIDADE DE VIGILANCIA DE ZOONOSES")
        comboSource.Add("3537606912273", "USB 12 PERUIBE")
        comboSource.Add("3537606964869", "USA 40 ´PERUIBE")
        comboSource.Add("3537606964893", "USB 11 PERUIBE")
        comboSource.Add("3537609180249", "SAMU PERUIBE 192 MOTOLANCIA URAM 08")
        comboSource.Add("3537600413933", "USAFA CENTRO")
        comboSource.Add("3537602025795", "USAFA CARAGUAVA")
        comboSource.Add("3537602060647", "USAFA VILA PERUIBE")
        comboSource.Add("3537602085798", "USAFA GUARAU")
        comboSource.Add("3537602087294", "USAFA JARDIM RIBAMAR")
        comboSource.Add("3537602087308", "USAFA PARQUE DO TREVO")
        comboSource.Add("3537602087316", "USAFA JARDIM VENEZA")
        comboSource.Add("3537605341167", "USAFA NOVA ITARIRI")
        comboSource.Add("3537605348862", "USAFA TORRE")
        comboSource.Add("3537605348870", "USAFA JARDIM BRASIL")
        comboSource.Add("3537605348889", "USAFA SANTA IZABEL")
        comboSource.Add("3537607750269", "USAFA RECREIO SANTISTA")

        combobox.DataSource = New BindingSource(comboSource, Nothing)
        combobox.DisplayMember = "Value"
        combobox.ValueMember = "Key"
    End Sub

    Public Sub cbBuscaEquipes(ByVal combobox As ComboBox)
        Dim comboSource As New Dictionary(Of String, String)()

        comboSource.Add("0000343366", "EMULTI-(NASF)- INE:343366")
        comboSource.Add("0001988921", "EMAD- INE:1988921")
        comboSource.Add("0002163136", "USAFA CENTRO- INE:2163136")
        comboSource.Add("0000343358", "USAFA CARAGUAVA I- INE:343358")
        comboSource.Add("0001473107", "USAFA CARAGUAVA II- INE:1473107")
        comboSource.Add("0000343382", "USAFA GUARAU- INE:343382")
        comboSource.Add("0000343420", "USAFA JARDIM VENEZA- INE:343420")
        comboSource.Add("0000343463", "USAFA SANTA ISABEL I- INE:343463")
        comboSource.Add("0001635557", "USAFA SANTA ISABEL II- INE:1635557")
        comboSource.Add("0000343439", "USAFA NOVA ITARIRI- INE:343439")
        comboSource.Add("0000343455", "USAFA JD. BRASIL- INE:343455")
        comboSource.Add("0001652575", "USAFA RIBAMAR I- INE:1652575")
        comboSource.Add("0001652583", "USAFA RIBAMAR II- INE:1652583")
        comboSource.Add("0002294702", "USAFA RIBAMAR III- INE:2294702")
        comboSource.Add("0000343447", "USAFA TORRE- INE:343447")
        comboSource.Add("0000343412", "USAFA TREVO I- INE:343412")
        comboSource.Add("0000343390", "USAFA TREVO II- INE:343390")
        comboSource.Add("0000343404", "USAFA RECREIO SANTISTA- INE:343404")
        comboSource.Add("0000343374", "USAFA VILA PERUIBE- INE:343374")
        comboSource.Add("0002245825", "CARAGUAVA ODONTO- INE:2245825")
        comboSource.Add("0002372495", "ODONTO JD BRASIL- INE:2372495")
        comboSource.Add("0002245841", "GUARAU ODONTO- INE:2245841")
        comboSource.Add("0002245833", "VENEZA ODONTO- INE:2245833")
        comboSource.Add("0002245817", "TREVO ODONTO- INE:2245817")

        combobox.DataSource = New BindingSource(comboSource, Nothing)
        combobox.DisplayMember = "Value"
        combobox.ValueMember = "Key"
    End Sub

    Public Sub cbFormaContEstab(ByVal combobox As ComboBox)
        Dim comboSource As New Dictionary(Of String, String)()

        comboSource.Add("01-VINCULO EMPREGATICIO  /  ", "01-VINCULO EMPREGATICIO")
        comboSource.Add("02-AUTONOMO  /  ", "02-AUTONOMO")
        comboSource.Add("03-COOPERATIVA  /  ", "03-COOPERATIVA")
        comboSource.Add("04-OUTROS  /  ", "04-OUTROS")
        comboSource.Add("05-RESIDENCIA  /  ", "05-RESIDENCIA")
        comboSource.Add("06-ESTAGIO  /  ", "06-ESTAGIO")
        comboSource.Add("07-BOLSA  /  ", "07-BOLSA")
        comboSource.Add("08-INTERMEDIADO  /  ", "08-INTERMEDIADO")
        comboSource.Add("09-INFORMAL  /  ", "09-INFORMAL")
        comboSource.Add("10-SERVIDOR PUBLICO CEDIDO PARA INICIATIVA PRIVADA  /  ", "10-SERVIDOR PUBLICO CEDIDO PARA INICIATIVA PRIVADA")


        combobox.DataSource = New BindingSource(comboSource, Nothing)
        combobox.DisplayMember = "Value"
        combobox.ValueMember = "Key"
    End Sub

    Public Sub cbFormaContEmpregador(ByVal combobox As ComboBox, ByVal codFormaContEstab As String)
        Dim comboSource As New Dictionary(Of String, String)()

        Select Case codFormaContEstab
            Case "01-VINCULO EMPREGATICIO  /  "

                comboSource.Add("00-NAO SE APLICA  /  ", "00-NAO SE APLICA")
                comboSource.Add("01-ESTATUTARIO EFETIVO  /  ", "01-ESTATUTARIO EFETIVO")
                comboSource.Add("02-EMPREGADO PUBLICO CELETISTA  /  ", "02-EMPREGADO PUBLICO CELETISTA")
                comboSource.Add("03-CONTRATADO TEMPORÁRIO OU POR PRAZO/TEMPO DETERMINADO  /  ", "03-CONTRATADO TEMPORÁRIO OU POR PRAZO/TEMPO DETERMINADO")
                comboSource.Add("04-CARGO COMISSIONADO  /  ", "04-CARGO COMISSIONADO")
                comboSource.Add("05-CELETISTA  /  ", "05-CELETISTA")

            Case "02-AUTONOMO  /  "

                comboSource.Add("00-NAO SE APLICA  /  ", "00-NAO SE APLICA")
                comboSource.Add("01-INTERMEDIADO POR ORGANIZACAO SOCIAL(OS)  /  ", "01-INTERMEDIADO POR ORGANIZACAO SOCIAL(OS)")
                comboSource.Add("02-INTERMEDIADO ORG DA SOCIEDADE CIVIL DE INTERESSE PUBL(OSCIP)  /  ", "02-INTERMEDIADO ORG DA SOCIEDADE CIVIL DE INTERESSE PUBL(OSCIP)")
                comboSource.Add("03-INTERMEDIADO POR ORGANIZACAO NAO-GOVERNAMENTAL(ONG)  /  ", "03-INTERMEDIADO POR ORGANIZACAO NAO-GOVERNAMENTAL(ONG)")
                comboSource.Add("04-INTERMEDIADO P ENTIDADE FILANTROPICA E/OU SEM FINS LUCRATIVO  /  ", "04-INTERMEDIADO P ENTIDADE FILANTROPICA E/OU SEM FINS LUCRATIVO")
                comboSource.Add("05-INTERMEDIADO POR EMPRESA PRIVADA  /  ", "05-INTERMEDIADO POR EMPRESA PRIVADA")
                comboSource.Add("06-CONSULTORIA  /  ", "06-CONSULTORIA")
                comboSource.Add("07-SEM INTERMEDIACAO(RPA)  /  ", "07-SEM INTERMEDIACAO(RPA)")
                comboSource.Add("08-INTERMEDIADO POR COOPERATIVA  /  ", "08-INTERMEDIADO POR COOPERATIVA")
                comboSource.Add("09-PESSOA JURIDICA  /  ", "09-PESSOA JURIDICA")
                comboSource.Add("10-PESSOA FISICA  /  ", "10-PESSOA FISICA")
                comboSource.Add("11-COOPERADO  /  ", "11-COOPERADO")

            Case "03-COOPERATIVA  /  "

                comboSource.Add("00-NAO SE APLICA  /  ", "00-NAO SE APLICA")

            Case "04-OUTROS  /  "

                comboSource.Add("01-BOLSA  /  ", "01-BOLSA")
                comboSource.Add("02-CONTRATO VERBAL/INFORMAL  /  ", "02-CONTRATO VERBAL/INFORMAL")
                comboSource.Add("03-PROPRIETARIO  /  ", "03-PROPRIETARIO")

            Case "05-RESIDENCIA  /  "

                comboSource.Add("00-NAO SE APLICA  /  ", "00-NAO SE APLICA")
                comboSource.Add("01-RESIDENTE  /  ", "01-RESIDENTE")

            Case "06-ESTAGIO  /  "

                comboSource.Add("00-NAO SE APLICA  /  ", "00-NAO SE APLICA")
                comboSource.Add("01-ESTAGIARIO  /  ", "01-ESTAGIARIO")

            Case "07-BOLSA  /  "

                comboSource.Add("01-BOLSISTA  /  ", "01-BOLSISTA")

            Case "08-INTERMEDIADO  /  "

                comboSource.Add("01-EMPREGADO PUBLICO CELETISTA  /  ", "01-EMPREGADO PUBLICO CELETISTA")
                comboSource.Add("02-CONTRATADO TEMPORARIO OU POR PRAZO/TEMPO DETERMINADO  /  ", "02-CONTRATADO TEMPORARIO OU POR PRAZO/TEMPO DETERMINADO")
                comboSource.Add("03-CARGO COMISSIONADO  /  ", "03-CARGO COMISSIONADO")
                comboSource.Add("04-CELETISTA  /  ", "04-CELETISTA")
                comboSource.Add("05-AUTONOMO  /  ", "05-AUTONOMO")
                comboSource.Add("06-COOPERADO  /  ", "06-COOPERADO")
                comboSource.Add("07-SERVIDOR PUBLICO  /  ", "07-SERVIDOR PUBLICO")

            Case "09-INFORMAL  /  "

                comboSource.Add("01-CONTRATADO VERBALMENTE  /  ", "01-CONTRATADO VERBALMENTE")
                comboSource.Add("02-VOLUNTARIADO  /  ", "02-VOLUNTARIADO")

            Case "10-SERVIDOR PUBLICO CEDIDO PARA INICIATIVA PRIVADA  /  "

                comboSource.Add("01-SERVIDOR CEDIDO  /  ", "01-SERVIDOR CEDIDO")
                comboSource.Add("02-EMPREGADO PUBLICO CELETISTA  /  ", "02-EMPREGADO PUBLICO CELETISTA")
                comboSource.Add("03-CARGO COMISSIONADO  /  ", "03-CARGO COMISSIONADO")

        End Select

        combobox.DataSource = New BindingSource(comboSource, Nothing)
        combobox.DisplayMember = "Value"
        combobox.ValueMember = "Key"
    End Sub

    Public Sub cbDetalhaento(ByVal combobox As ComboBox, ByVal codFormaContEstab As String, ByVal codFormaContEmpregador As String)
        Dim comboSource As New Dictionary(Of String, String)()
        Dim cod As String

        cod = codFormaContEstab & codFormaContEmpregador

        Select Case cod
            Case "01-VINCULO EMPREGATICIO  /  00-NAO SE APLICA  /  "

                comboSource.Add("00-NAO SE APLICA  /  ", "00-NAO SE APLICA")

            Case "01-VINCULO EMPREGATICIO  /  01-ESTATUTARIO EFETIVO  /  "

                comboSource.Add("00-NAO SE APLICA", "00-NAO SE APLICA")
                comboSource.Add("01-SERVIDOR PROPRIO", "01-SERVIDOR PROPRIO")
                comboSource.Add("02-SERVIDOR CEDIDO", "02-SERVIDOR CEDIDO")

            Case "01-VINCULO EMPREGATICIO  /  02-EMPREGADO PUBLICO CELETISTA  /  "

                comboSource.Add("00-NAO SE APLICA", "00-NAO SE APLICA")
                comboSource.Add("01-CLT", "01-CLT")
                comboSource.Add("02-PROPRIO", "02-PROPRIO")
                comboSource.Add("03-CEDIDO", "03-CEDIDO")

            Case "01-VINCULO EMPREGATICIO  /  03-CONTRATADO TEMPORÁRIO OU POR PRAZO/TEMPO DETERMINADO  /  "

                comboSource.Add("00-NAO SE APLICA", "00-NAO SE APLICA")
                comboSource.Add("01-PUBLICO", "01-PUBLICO")
                comboSource.Add("02-PRIVADO", "02-PRIVADO")

            Case "01-VINCULO EMPREGATICIO  /  04-CARGO COMISSIONADO  /  "

                comboSource.Add("00-NAO SE APLICA", "00-NAO SE APLICA")
                comboSource.Add("01-CARGO COMISSIONADO NAO CEDIDO", "01-CARGO COMISSIONADO NAO CEDIDO")
                comboSource.Add("02-CARGO COMISSIONADO CEDIDO", "02-CARGO COMISSIONADO CEDIDO")
                comboSource.Add("03-SERVIDOR PUBLICO PROPRIO", "03-SERVIDOR PUBLICO PROPRIO")
                comboSource.Add("04-SERVIDOR PUBLICO CEDIDO", "04-SERVIDOR PUBLICO CEDIDO")
                comboSource.Add("05-SEM VINCULO COM O SETOR PUBLICO", "05-SEM VINCULO COM O SETOR PUBLICO")

            Case "01-VINCULO EMPREGATICIO  /  05-CELETISTA  /  "

                comboSource.Add("00-NAO SE APLICA", "00-NAO SE APLICA")
                comboSource.Add("01-CONTRATO POR OSCIP/OS", "01-CONTRATO POR OSCIP/OS")
                comboSource.Add("02-CONTRATO POR ONG", "02-CONTRATO POR ONG")
                comboSource.Add("03-CONTRATO POR ENTIDADE FILANTROPICA", "03-CONTRATO POR ENTIDADE FILANTROPICA")
                comboSource.Add("04-CONTRATO POR REDE PRIVADA", "04-CONTRATO POR REDE PRIVADA")

            Case "02-AUTONOMO  /  00-NAO SE APLICA  /  ", "02-AUTONOMO  /  01-INTERMEDIADO POR ORGANIZACAO SOCIAL(OS)  /  ", "02-AUTONOMO  /  02-INTERMEDIADO ORG DA SOCIEDADE CIVIL DE INTERESSE PUBL(OSCIP)  /  ", "02-AUTONOMO  /  03-INTERMEDIADO POR ORGANIZACAO NAO-GOVERNAMENTAL(ONG)  /  ", "02-AUTONOMO  /  04-INTERMEDIADO P ENTIDADE FILANTROPICA E/OU SEM FINS LUCRATIVO  /  ", "02-AUTONOMO  /  05-INTERMEDIADO POR EMPRESA PRIVADA  /  ", "02-AUTONOMO  /  06-CONSULTORIA  /  ", "02-AUTONOMO  /  07-SEM INTERMEDIACAO(RPA)  /  ", "02-AUTONOMO  /  08-INTERMEDIADO POR COOPERATIVA  /  ", "02-AUTONOMO  /  09-PESSOA JURIDICA  /  ", "02-AUTONOMO  /  10-PESSOA FISICA  /  ", "02-AUTONOMO  /  11-COOPERADO  /  ", "03-COOPERATIVA  /  00-NAO SE APLICA  /  ", "04-OUTROS  /  01-BOLSA  /  ", "04-OUTROS  /  02-CONTRATO VERBAL/INFORMAL  /  ", "04-OUTROS  /  03-PROPRIETARIO  /  ", "05-RESIDENCIA  /  00-NAO SE APLICA  /  ", "06-ESTAGIO  /  00-NAO SE APLICA  /  ", "08-INTERMEDIADO  /  01-EMPREGADO PUBLICO CELETISTA  /  ", "08-INTERMEDIADO  /  02-CONTRATADO TEMPORARIO OU POR PRAZO/TEMPO DETERMINADO  /  ", "08-INTERMEDIADO  /  03-CARGO COMISSIONADO  /  ", "08-INTERMEDIADO  /  04-CELETISTA  /  ", "08-INTERMEDIADO  /  06-COOPERADO  /  ", "06-COOPERADO", "09-INFORMAL  /  01-CONTRATADO VERBALMENTE  /  ", "09-INFORMAL  /  02-VOLUNTARIADO  /  ", "10-SERVIDOR PUBLICO CEDIDO PARA INICIATIVA PRIVADA  /  01-SERVIDOR CEDIDO  /  ", "10-SERVIDOR PUBLICO CEDIDO PARA INICIATIVA PRIVADA  /  02-EMPREGADO PUBLICO CELETISTA  /  ", "10-SERVIDOR PUBLICO CEDIDO PARA INICIATIVA PRIVADA  /  03-CARGO COMISSIONADO  /  "

                comboSource.Add("00-NAO SE APLICA", "00-NAO SE APLICA")

            Case "05-RESIDENCIA  /  01-RESIDENTE  /  "

                comboSource.Add("01-PROPRIO", "01-PROPRIO")
                comboSource.Add("02-SUBSIDIADO POR OUTRO ENTE/ENTIDADE", "02-SUBSIDIADO POR OUTRO ENTE/ENTIDADE")

            Case "06-ESTAGIO  /  01-ESTAGIARIO  /  "

                comboSource.Add("01-PROPRIO", "01-PROPRIO")
                comboSource.Add("02-SUBSIDIADO POR OUTRO ENTE/ENTIDADE", "02-SUBSIDIADO POR OUTRO ENTE/ENTIDADE")

            Case "07-BOLSA  /  01-BOLSISTA  /  "

                comboSource.Add("01-PROPRIO", "01-PROPRIO")
                comboSource.Add("02-SUBSIDIADO POR OUTRO ENTE/ENTIDADE", "02-SUBSIDIADO POR OUTRO ENTE/ENTIDADE")

            Case "08-INTERMEDIADO  /  05-AUTONOMO  /  "

                comboSource.Add("01-PESSOA JURIDICA", "01-PESSOA JURIDICA")
                comboSource.Add("02-PESSOA FISICA", "02-PESSOA FISICA")

            Case "08-INTERMEDIADO  /  07-SERVIDOR PUBLICO  /  "

                comboSource.Add("01-CEDIDO", "01-CEDIDO")

        End Select

        combobox.DataSource = New BindingSource(comboSource, Nothing)
        combobox.DisplayMember = "Value"
        combobox.ValueMember = "Key"
    End Sub
    Public Sub copyXMLFileFromServer()
        Try
            If My.Settings.server = "" Then
                FConnSettings.ShowDialog()
                Exit Sub
            End If

            If Not Directory.Exists(Application.StartupPath & "\XML") Or Not File.Exists(Application.StartupPath & "\XML\EQUIPES.xml") Then
                Directory.CreateDirectory(Application.StartupPath & "\XML")

                Dim origem As String = $"http://{My.Settings.server}/Secretaria/CNES/EQUIPES.xml"
                Dim destino As String = Application.StartupPath & "\XML\EQUIPES.xml" ' Caminho de destino no cliente
                ' Verificar se o arquivo existe no servidor HTTP
                Dim request As HttpWebRequest = CType(WebRequest.Create(origem), HttpWebRequest)
                request.Method = "HEAD"

                Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                    If response.StatusCode = HttpStatusCode.OK Then
                        Dim clienteWeb As New WebClient()
                        clienteWeb.DownloadFile(origem, destino)
                        MsgBox("Atualizando arquivo de equipes...")
                    Else
                        MsgBox("Arquivo não encontrado no servidor.")
                    End If
                End Using

            End If

        Catch ex As Exception
            MessageBox.Show("Erro ao copiar arquivo: " & ex.Message)
        End Try
    End Sub

    Public Sub copyXMLFileToServer()
        FCNES.OpenFileDialog1.ShowDialog()

        Try
            Dim arquivoLocal As String = FCNES.OpenFileDialog1.FileName ' Caminho do arquivo XML local
            Dim caminhoServidor As String = $"\\{My.Settings.server}\htdocs\Secretaria\CNES\EQUIPES.xml" ' Caminho da pasta no servidor

            File.Copy(arquivoLocal, caminhoServidor, True) ' O terceiro parâmetro 'True' permite sobrescrever o arquivo de destino

            MessageBox.Show("Arquivo copiado com sucesso!")
        Catch ex As Exception
            ' MessageBox.Show($"Erro ao copiar arquivo: {ex.Message}{vbCrLf}{ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Function equipesXML() As List(Of Estabelecimento)
        Dim estabelecimentos As New List(Of Estabelecimento)()
        Dim doc As XDocument

        Try

            If File.Exists(Application.StartupPath & "\XML\EQUIPES.xml") Then
                doc = XDocument.Load(XMLEquipesPath)
            Else
                copyXMLFileFromServer()

            End If

            ' Consulta os Estabelecimentos
            Dim estQuery = From est In doc.Descendants("DADOS_GERAIS_ESTABELECIMENTOS")
                           Select New Estabelecimento With {
                               .NOME = est.Attribute("NM_FANTA")?.Value,
                               .TIPOUNIDADE = est.Attribute("DS_TP_UNID")?.Value,
                               .CNES = est.Attribute("CNES")?.Value,
                               .Endereco = $"{est.Element("ENDERECO")?.Element("DADOS_ENDERECO")?.Attribute("LOGRADOURO")?.Value}, {est.Element("ENDERECO")?.Element("DADOS_ENDERECO")?.Attribute("NUMERO")?.Value}",
                               .Equipes = (From equipe In est.Element("EQUIPES")?.Elements("DADOS_EQUIPES")
                                           Select New Equipe With {
                                               .NomeReferencia = equipe.Attribute("NM_REFERENCIA")?.Value,
                                               .INE = equipe.Attribute("CO_INE")?.Value,
                                               .TIPO = equipe.Attribute("DS_EQUIPE")?.Value,
                                               .Profissionais = New List(Of Profissional)()
                                           }).ToList()
                           }

            estabelecimentos = estQuery.ToList()

            ' Consulta os Profissionais e os associa às equipes correspondentes
            Dim profissionais = From prof In doc.Descendants("DADOS_PROFISSIONAIS")
                                Select New Profissional With {
                                    .Nome = prof.Attribute("NM_PROF")?.Value,
                                    .CPF = prof.Attribute("CPF_PROF")?.Value,
                                    .CNS = prof.Attribute("CO_CNS")?.Value,
                                    .CNESLOTACAO = prof.Element("LOTACOES")?.Element("DADOS_LOTACOES")?.Attribute("CNES")?.Value,
                                    .CBOLOTACAO = prof.Element("LOTACOES")?.Element("DADOS_LOTACOES")?.Attribute("CO_CBO")?.Value,
                                    .INELOTACAO = prof.Element("LOTACOES")?.Element("DADOS_LOTACOES")?.Attribute("CO_INE")?.Value
                                }

            ' Associa profissionais às equipes correspondentes
            For Each est In estabelecimentos
                For Each eq In est.Equipes
                    eq.Profissionais = profissionais.Where(Function(p) p.CNESLOTACAO = est.CNES AndAlso p.INELOTACAO = eq.INE).ToList()
                Next
            Next

            Return estabelecimentos

        Catch ex As Exception
            Return Enumerable.Empty(Of Estabelecimento)().ToList
        End Try

    End Function

    Public Sub verificarAlteracao()
        Try
            Dim caminhoArquivoServidor As String = $"\\{My.Settings.server}\htdocs\Secretaria\CNES\EQUIPES.xml"
            Dim hashAtual As String = CalcularHashArquivo(caminhoArquivoServidor)

            If File.Exists(Application.StartupPath & "\XML\EQUIPES.xml") Then
                If hashAtual <> My.Settings.ultimoHash Then
                    copyXMLFileFromServer()
                    My.Settings.ultimoHash = hashAtual
                Else
                    'MessageBox.Show("O arquivo não foi alterado.")
                End If

            End If

        Catch ex As Exception
            MessageBox.Show($"Erro: {ex.Message}")
        End Try
    End Sub

    Private Function CalcularHashArquivo(caminhoArquivo As String) As String
        Using arquivo As New FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read)
            Using sha256 As SHA256 = sha256.Create()
                Dim hashBytes As Byte() = sha256.ComputeHash(arquivo)
                Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
            End Using
        End Using
    End Function

End Class

Public Class Estabelecimento
    Public Property NOME As String
    Public Property TIPOUNIDADE As String
    Public Property CNES As String
    Public Property Endereco As String
    Public Property Equipes As List(Of Equipe)
End Class

Public Class Equipe
    Public Property NomeReferencia As String
    Public Property TIPO As String
    Public Property INE As String
    Public Property Profissionais As List(Of Profissional)
End Class

Public Class Profissional
    Public Property Nome As String
    Public Property CPF As String
    Public Property CNS As String
    Public Property CNESLOTACAO As String
    Public Property INELOTACAO As String
    Public Property CBOLOTACAO As String
End Class

