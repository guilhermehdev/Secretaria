Imports System.IO
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
    Private Sub OCI_PDF(pdfOrigem As String, pdfDestino As String, oci As DataTable, Optional procedimentoSecundario As DataTable = Nothing)

        Dim reader As New PdfReader(pdfOrigem)
        Dim stamper As New PdfStamper(
            reader,
            New FileStream(
                pdfDestino,
                FileMode.Create
            )
        )

        Dim campos = stamper.AcroFields

        campos.SetField("NOME_PACIENTE", oci.Rows(0)("nome").ToString())

        If oci.Rows(0)("sexo").ToString() = "M" Then
            campos.SetField("SEXO_M", "On")
            campos.SetField("SEXO_F", "Off")
        Else
            campos.SetField("SEXO_F", "On")
            campos.SetField("SEXO_M", "Off")
        End If

        campos.SetField("CPF_PACIENTE", oci.Rows(0)("cpf").ToString())
        campos.SetField("DN_PACIENTE", DirectCast(oci.Rows(0)("dtnasc"), Date).ToString("dd/MM/yyyy"))
        campos.SetField("RACA_PACIENTE", oci.Rows(0)("raca").ToString())
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

        End If

        campos.SetField("CID1", oci.Rows(0)("cid_principal").ToString())
        campos.SetField("CID2", oci.Rows(0)("cid_sec").ToString())

        campos.SetField("DATA_SOLICITACAO", oci.Rows(0)("data_solicitacao").ToString())
        campos.SetField("NOME_MEDICO_SOLICITANTE", oci.Rows(0)("medico_solicitante").ToString().ToUpper)
        campos.SetField("TIPO_DOCUMENTO_MEDICO_SOLICITANTE_CNS", "On")
        campos.SetField("TIPO_DOCUMENTO_MEDICO_SOLICITANTE_CPF", "Off")
        campos.SetField("CNS_MEDICO_SOLICITANTE", oci.Rows(0)("sus_medico_solicitante").ToString())

        campos.SetField("NOME_MEDICO_AUTORIZADOR", oci.Rows(0)("medico_autorizador").ToString().ToUpper)
        campos.SetField("TIPO_DOCUMENTO_MEDICO_AUTORIZADOR_CNS", "On")
        campos.SetField("TIPO_DOCUMENTO_MEDICO_AUTORIZADOR_CPF", "Off")
        campos.SetField("CNS_MEDICO_AUTORIZADOR", oci.Rows(0)("sus_medico_autorizador").ToString())

        campos.SetField("NUMERO_APAC", oci.Rows(0)("num_apac").ToString())

        'DirectCast(oci.Rows(0)("dtnasc"), Date).ToString("dd/MM/yyyy"))

        Dim dataOCI As Date = CDate(oci.Rows(0)("data_solicitacao")).ToString("dd/MM/yyyy")
        campos.SetField("DATA_INICIO_OCI", dataOCI.ToString("dd/MM/yyyy"))
        campos.SetField("DATA_FIM_OCI", dataOCI.AddMonths(1).ToString("dd/MM/yyyy"))

        stamper.FormFlattening = True

        stamper.Close()
        reader.Close()

    End Sub

End Class
