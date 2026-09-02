Imports System.IO
Imports System.Runtime.InteropServices
Imports iTextSharp.text.pdf


Public Class OCI
    Dim m As New Main

    Public Sub printOCI(idOCI As Integer, pdfDestino As String)
        Dim oci = datatableOCI(idOCI)
        OCI_PDF(Application.StartupPath & "\PDF\ModeloOCI.pdf", pdfDestino, oci)
    End Sub
    Private Function datatableOCI(idOCI As Integer, Optional parametros As String = "")
        If parametros <> "" Then
            parametros = " AND " & parametros
        End If
        Dim query = $"SELECT oci.num_apac, oci.`data` AS data_solicitacao, cod_oci_principal.cod, cod_oci_principal.descricao, oci.cid_principal, 
        oci.cid_sec, solicitante.nome AS medico_solicitante, solicitante.SUS AS sus_medico_solicitante, 
        autorizador.nome AS medico_autorizador, autorizador.SUS AS sus_medico_autorizador,
        pacientes.nome, pacientes.dtnasc, pacientes.sexo, pacientes.raca, pacientes.cpf, pacientes.mae, pacientes.tel, 
        ceps_peruibe.cep, ceps_peruibe.tipo, ceps_peruibe.logradouro, pacientes.numero, ceps_peruibe.bairro
        FROM oci 
        JOIN servidores solicitante ON solicitante.SUS = oci.id_medico
        JOIN servidores autorizador ON autorizador.SUS = oci.id_autorizador
        JOIN cod_oci_principal ON cod_oci_principal.id = oci.id_cod_principal
        JOIN pacientes ON pacientes.id = oci.id_paciente
        JOIN ceps_peruibe ON ceps_peruibe.id = pacientes.id_logradouro
        WHERE oci.id={idOCI} {parametros}"
        Return FormAMEmain.getDataset(query)

    End Function

    Private Function ValidarOCI(oci As DataTable) As List(Of String)

        Dim erros As New List(Of String)

        If oci Is Nothing OrElse oci.Rows.Count = 0 Then
            erros.Add("DataTable 'oci' está vazio ou nulo.")
            Return erros
        End If

        Dim linha = oci.Rows(0)

        ' --- Campos de texto obrigatórios ---
        Dim camposObrigatorios As String() = {
        "nome", "cpf", "mae", "tel", "cep", "tipo", "logradouro",
        "numero", "bairro", "cod", "descricao", "cid_principal",
        "data_solicitacao", "medico_solicitante", "sus_medico_solicitante",
        "medico_autorizador", "sus_medico_autorizador", "num_apac"
    }

        For Each campo In camposObrigatorios
            If Not oci.Columns.Contains(campo) Then
                erros.Add($"Coluna '{campo}' não existe no DataTable.")
            ElseIf String.IsNullOrWhiteSpace(linha(campo).ToString()) Then
                erros.Add($"Campo '{campo}' está vazio.")
            End If
        Next

        If erros.Count > 0 Then Return erros ' evita quebrar validações abaixo por coluna ausente

        ' --- Sexo ---
        Dim sexo = linha("sexo").ToString().Trim().ToUpper()
        If sexo <> "M" AndAlso sexo <> "F" Then
            erros.Add($"Campo 'sexo' inválido: '{sexo}' (esperado 'M' ou 'F').")
        End If

        ' --- Data de nascimento ---
        If Not IsDate(linha("dtnasc")) Then
            erros.Add("Campo 'dtnasc' não é uma data válida.")
        Else
            Dim dtNasc As Date = CDate(linha("dtnasc"))
            If dtNasc > DateTime.Today Then
                erros.Add("Campo 'dtnasc' está no futuro.")
            End If
        End If

        ' --- Raça ---
        Dim racasValidas As String() = {"01", "02", "03", "04", "05"}
        Dim idRaca = linha("raca").ToString().Trim()
        If Not racasValidas.Contains(idRaca) Then
            erros.Add($"Código de raça '{idRaca}' inválido.")
        End If

        ' --- CPF ---
        Dim cpf = New String(linha("cpf").ToString().Where(AddressOf Char.IsDigit).ToArray())
        If cpf.Length <> 11 Then
            erros.Add($"CPF '{linha("cpf")}' inválido: deve conter 11 dígitos.")
        ElseIf Not m.ValidarCPF(cpf) Then
            erros.Add($"CPF '{linha("cpf")}' inválido: dígitos verificadores incorretos.")
        End If

        ' --- Telefone ---
        Dim telDigitos = New String(linha("tel").ToString().Where(AddressOf Char.IsDigit).ToArray())
        If telDigitos.Length < 10 OrElse telDigitos.Length > 11 Then
            erros.Add($"Telefone '{linha("tel")}' inválido: esperado 10 ou 11 dígitos (DDD + número).")
        End If

        ' --- CEP ---
        Dim cepDigitos = New String(linha("cep").ToString().Where(AddressOf Char.IsDigit).ToArray())
        If cepDigitos.Length <> 8 Then
            erros.Add($"CEP '{linha("cep")}' inválido: esperado 8 dígitos.")
        End If

        ' --- Código do procedimento principal ---
        Dim codigosConhecidos As String() = {
        "0904010015", "0902010026", "0902010018", "0905010035",
        "0904010031", "0903010011"
    }
        Dim cod = linha("cod").ToString().Trim()
        If String.IsNullOrWhiteSpace(cod) Then
            erros.Add("Campo 'cod' (procedimento principal) está vazio.")
        ElseIf Not codigosConhecidos.Contains(cod) Then
            ' Não é erro fatal, mas alerta que não há regra de procedimentos secundários mapeada
            erros.Add($"Aviso: código de procedimento '{cod}' não possui procedimentos secundários mapeados no OCI_PDF.")
        End If

        ' --- Data de solicitação ---
        If Not IsDate(linha("data_solicitacao")) Then
            erros.Add("Campo 'data_solicitacao' não é uma data válida.")
        End If

        ' --- CID principal (formato básico: letra + 2 dígitos, opcionalmente + subcategoria) ---
        Dim cid = linha("cid_principal").ToString().Trim()
        If Not System.Text.RegularExpressions.Regex.IsMatch(cid, "^[A-Z]\d{2}(\.\d)?$") Then
            erros.Add($"CID principal '{cid}' fora do formato esperado (ex: A00 ou A00.0).")
        End If

        ' --- CNS (15 dígitos) dos médicos ---
        Dim cnsSolic = New String(linha("sus_medico_solicitante").ToString().Where(AddressOf Char.IsDigit).ToArray())
        If cnsSolic.Length <> 15 Then
            erros.Add("CNS do médico solicitante inválido: esperado 15 dígitos.")
        End If

        Dim cnsAutor = New String(linha("sus_medico_autorizador").ToString().Where(AddressOf Char.IsDigit).ToArray())
        If cnsAutor.Length <> 15 Then
            erros.Add("CNS do médico autorizador inválido: esperado 15 dígitos.")
        End If

        Return erros

    End Function

    Private Sub OCI_PDF(pdfOrigem As String, pdfDestino As String, oci As DataTable, Optional procedimentoSecundario As DataTable = Nothing)

        Dim reader As New PdfReader(pdfOrigem)
        Dim stamper As New PdfStamper(reader, New FileStream(pdfDestino, FileMode.Create))
        Dim campos = stamper.AcroFields

        Dim erros = ValidarOCI(oci)
        If erros.Count > 0 Then
            MsgBox("Não foi possível gerar o PDF. Erros encontrados:" & vbCrLf & vbCrLf & String.Join(vbCrLf, erros))
            Exit Sub
        End If

        campos.SetField("NOME_PACIENTE", oci.Rows(0)("nome").ToString())

        If oci.Rows(0)("sexo").ToString() = "M" Then
            MarcarCheckBox(campos, "SEXO_M", True)
            MarcarCheckBox(campos, "SEXO_F", False)
        Else
            MarcarCheckBox(campos, "SEXO_M", False)
            MarcarCheckBox(campos, "SEXO_F", True)
        End If

        campos.SetField("CPF_PACIENTE", oci.Rows(0)("cpf").ToString())
        campos.SetField("DN_PACIENTE", DirectCast(oci.Rows(0)("dtnasc"), Date).ToString("dd/MM/yyyy"))

        Dim idRaca = oci.Rows(0)("raca").ToString()
        Dim raca As String = "BRANCA"

        Select Case idRaca
            Case "99"
                raca = "BRANCA"
            Case "01"
                raca = "BRANCA"
            Case "02"
                raca = "PRETA"
            Case "03"
                raca = "PARDA"
            Case "04"
                raca = "AMARELA"
            Case "05"
                raca = "INDIGENA"
        End Select

        campos.SetField("RACA_PACIENTE", raca)
        campos.SetField("MAE_PACIENTE", oci.Rows(0)("mae").ToString())
        campos.SetField("DDD_PACIENTE", oci.Rows(0)("tel").ToString().Replace("(", "").Replace(")", "").Substring(0, 3))
        campos.SetField("TELEFONE_PACIENTE", oci.Rows(0)("tel").ToString().Replace("-", "").Substring(4))
        If m.CalcularIdade(CDate(oci.Rows(0)("dtnasc").ToString())) >= 18 Then
            campos.SetField("RESPONSAVEL_PACIENTE", oci.Rows(0)("nome").ToString())
        Else
            campos.SetField("RESPONSAVEL_PACIENTE", oci.Rows(0)("mae").ToString())
        End If

        campos.SetField("CEP_PACIENTE", oci.Rows(0)("cep").ToString().Replace("-", ""))
        campos.SetField("LOGRADOURO_PACIENTE", oci.Rows(0)("tipo").ToString() & " " & oci.Rows(0)("logradouro").ToString() & ", " & oci.Rows(0)("numero").ToString() & " - " & oci.Rows(0)("bairro").ToString())

        campos.SetField("CODPRINCIPAL", oci.Rows(0)("cod").ToString())
        campos.SetField("DESCRICAO_PROCEDIMENTO", oci.Rows(0)("descricao").ToString().ToUpper())

        If oci.Rows(0)("cod").ToString() = "0904010015" Then
            campos.SetField("CODPROCED_SECUNDARIO_1", "0301010072")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_1", "Consulta médica na atenção especializada".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_1", "1")

            campos.SetField("CODPROCED_SECUNDARIO_2", "0211070041")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_2", "Audiometria tonal limiar (via aérea/óssea)".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_2", "1")

        ElseIf oci.Rows(0)("cod").ToString() = "0902010026" OrElse oci.Rows(0)("cod").ToString() = "0902010018" Then
            campos.SetField("CODPROCED_SECUNDARIO_1", "0301010072")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_1", "Consulta médica na atenção especializada".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_1", "1")

            campos.SetField("CODPROCED_SECUNDARIO_2", "0211020036")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_2", "Eletrocardiograma".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_2", "1")

        ElseIf oci.Rows(0)("cod").ToString() = "0905010035" Then
            campos.SetField("CODPROCED_SECUNDARIO_1", "0301010072")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_1", "Consulta médica na atenção especializada".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_1", "1")

            campos.SetField("CODPROCED_SECUNDARIO_2", "0211060020")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_2", "Biomicroscopia de fundo de olho".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_2", "1")

            campos.SetField("CODPROCED_SECUNDARIO_3", "0211060127")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_3", "Mapeamento de retina".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_3", "1")

            campos.SetField("CODPROCED_SECUNDARIO_4", "0211060259")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_4", "Tonometria".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_4", "1")

        ElseIf oci.Rows(0)("cod").ToString() = "0904010031" Then
            campos.SetField("CODPROCED_SECUNDARIO_1", "0301010072")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_1", "Consulta médica na atenção especializada".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_1", "1")

            campos.SetField("CODPROCED_SECUNDARIO_2", "0209040025")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_2", "Laringoscopia".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_2", "1")

            campos.SetField("CODPROCED_SECUNDARIO_3", "0209040041")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_3", "Videolaringoscopia".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_3", "1")

        ElseIf oci.Rows(0)("cod").ToString() = "0903010011" Then
            campos.SetField("CODPROCED_SECUNDARIO_1", "0301010072")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_1", "Consulta médica na atenção especializada".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_1", "1")

            campos.SetField("CODPROCED_SECUNDARIO_2", "0211020036")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_2", "Eletrocardiograma".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_2", "1")

            Try

                For i As Integer = 0 To procedimentoSecundario.Rows.Count - 1

                    Dim codigo = procedimentoSecundario.Rows(i)("cod_proced_secundario").ToString()
                    Dim descricao = procedimentoSecundario.Rows(i)("descricao").ToString()
                    Dim qtd = procedimentoSecundario.Rows(i)("qtd").ToString()

                    Select Case i

                        Case 0

                            campos.SetField("CODPROCED_SECUNDARIO_1", codigo)
                            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_1", descricao)
                            campos.SetField("QTD_PROCED_SECUNDARIO_1", qtd)

                        Case 1

                            campos.SetField("CODPROCED_SECUNDARIO_2", codigo)
                            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_2", descricao)
                            campos.SetField("QTD_PROCED_SECUNDARIO_2", qtd)

                        Case 2

                            campos.SetField("CODPROCED_SECUNDARIO_3", codigo)
                            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_3", descricao)
                            campos.SetField("QTD_PROCED_SECUNDARIO_3", qtd)

                        Case 3

                            campos.SetField("CODPROCED_SECUNDARIO_4", codigo)
                            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_4", descricao)
                            campos.SetField("QTD_PROCED_SECUNDARIO_4", qtd)

                        Case 4

                            campos.SetField("CODPROCED_SECUNDARIO_5", codigo)
                            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_5", descricao)
                            campos.SetField("QTD_PROCED_SECUNDARIO_5", qtd)

                    End Select

                Next

            Catch ex As Exception
                MsgBox("Erro ao preencher procedimentos secundários: " & ex.Message)
            End Try
        End If

        campos.SetField("CID1", oci.Rows(0)("cid_principal").ToString())
        campos.SetField("CID2", oci.Rows(0)("cid_sec").ToString())

        campos.SetField("DATA_SOLICITACAO", oci.Rows(0)("data_solicitacao").ToString())
        campos.SetField("NOME_MEDICO_SOLICITANTE", oci.Rows(0)("medico_solicitante").ToString().ToUpper)
        MarcarCheckBox(campos, "TIPO_DOCUMENTO_MEDICO_SOLICITANTE_CNS", True)
        MarcarCheckBox(campos, "TIPO_DOCUMENTO_MEDICO_SOLICITANTE_CPF", False)
        campos.SetField("CNS_MEDICO_SOLICITANTE", oci.Rows(0)("sus_medico_solicitante").ToString())

        campos.SetField("NOME_MEDICO_AUTORIZADOR", oci.Rows(0)("medico_autorizador").ToString().ToUpper)
        MarcarCheckBox(campos, "TIPO_DOCUMENTO_MEDICO_AUTORIZADOR_CNS", True)
        MarcarCheckBox(campos, "TIPO_DOCUMENTO_MEDICO_AUTORIZADOR_CPF", False)
        campos.SetField("CNS_MEDICO_AUTORIZADOR", oci.Rows(0)("sus_medico_autorizador").ToString())

        campos.SetField("NUMERO_APAC", oci.Rows(0)("num_apac").ToString())

        Dim dataOCI As Date = CDate(oci.Rows(0)("data_solicitacao"))
        campos.SetField("DATA_INICIO_OCI", dataOCI.ToString("dd/MM/yyyy"))
        campos.SetField("DATA_FIM_OCI", dataOCI.AddMonths(1).ToString("dd/MM/yyyy"))

        stamper.FormFlattening = True
        stamper.Close()
        reader.Close()

    End Sub

    Public Function UnirPDFs(listaArquivos As List(Of String), pdfSaida As String)
        Try

            Dim doc As New iTextSharp.text.Document()
            Using fs As New FileStream(pdfSaida, FileMode.Create)

                Dim copy As New PdfSmartCopy(doc, fs)

                doc.Open()

                For Each arquivo In listaArquivos

                    Using reader As New PdfReader(arquivo)

                        For pagina As Integer = 1 To reader.NumberOfPages
                            copy.AddPage(
                            copy.GetImportedPage(reader, pagina)
                        )
                        Next

                    End Using

                Next

                doc.Close()

            End Using

            Return True
        Catch ex As Exception
            m.msgError("Erro ao unir PDFs: " & ex.Message)
            Return False
        End Try

    End Function

    Private Sub MarcarCheckBox(campos As AcroFields, nomeCampo As String, marcado As Boolean)
        Dim estado As String = If(marcado, "On", "Off")

        campos.SetField(nomeCampo, estado)

        Dim item = campos.GetFieldItem(nomeCampo)

        If item IsNot Nothing Then
            For i As Integer = 0 To item.Size - 1
                item.GetMerged(i).Put(
                    PdfName.AS,
                    New PdfName(estado)
                )
            Next
        End If

    End Sub

    <DllImport("user32.dll")>
    Private Shared Function FindWindowEx(
    hwndParent As IntPtr,
    hwndChildAfter As IntPtr,
    lpszClass As String,
    lpszWindow As String
) As IntPtr
    End Function

End Class
