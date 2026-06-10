Imports System.IO
Imports iTextSharp.text.pdf

Public Class OCI
    Dim m As New Main
    Public Sub GerarOCI(pdfOrigem As String, pdfDestino As String, paciente As DataTable, endereco As DataTable, procedimento As DataTable, procedimentoSecundario As DataTable)

        Dim reader As New PdfReader(pdfOrigem)
        Dim stamper As New PdfStamper(
            reader,
            New FileStream(
                pdfDestino,
                FileMode.Create
            )
        )

        Dim campos = stamper.AcroFields

        campos.SetField("NOME_PACIENTE", paciente.Rows(0)("nome").ToString())
        If paciente.Rows(0)("sexo").ToString() = "M" Then
            campos.SetField("SEXO_M", "On")
            campos.SetField("SEXO_F", "Off")
        Else
            campos.SetField("SEXO_F", "On")
            campos.SetField("SEXO_M", "Off")
        End If
        campos.SetField("CPF_PACIENTE", paciente.Rows(0)("cpf").ToString())
        campos.SetField("DN_PACIENTE", paciente.Rows(0)("dtnasc").ToString())
        campos.SetField("RACA_PACIENTE", paciente.Rows(0)("raca").ToString())
        campos.SetField("MAE_PACIENTE", paciente.Rows(0)("mae").ToString())
        campos.SetField("DDD_PACIENTE", paciente.Rows(0)("tel").ToString().Substring(0, 3))
        campos.SetField("TELEFONE_PACIENTE", paciente.Rows(0)("tel").ToString().Substring(4))
        If m.CalcularIdade(CDate(paciente.Rows(0)("dtnasc").ToString())) >= 18 Then
            campos.SetField("RESPONSAVEL_PACIENTE", paciente.Rows(0)("nome").ToString())
        Else
            campos.SetField("RESPONSAVEL_PACIENTE", paciente.Rows(0)("mae").ToString())
        End If

        campos.SetField("CEP_PACIENTE", endereco.Rows(0)("cep").ToString())
        campos.SetField("LOGRADOURO_PACIENTE", endereco.Rows(0)("tipo").ToString() & " " & endereco.Rows(0)("logradouro").ToString() & ", " & paciente.Rows(0)("numero").ToString() & " - " & endereco.Rows(0)("bairro").ToString())

        campos.SetField("CODPRINCIPAL", procedimento.Rows(0)("cod").ToString())
        campos.SetField("DESCRICAO_PROCEDIMENTO", procedimento.Rows(0)("descricao").ToString())

        If procedimento.Rows(0)("cod").ToString() = "0904010015" Then
            campos.SetField("CODPROCED_SECUNDARIO_1", "0301010072")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_1", "Consulta médica na atenção especializada".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_1", "1")

            campos.SetField("CODPROCED_SECUNDARIO_2", "0211070041")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_2", "Audiometria tonal limiar (via aérea/óssea)".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_2", "1")

        ElseIf procedimento.Rows(0)("cod").ToString() = "0902010026" OrElse procedimento.Rows(0)("cod").ToString() = "0902010018" Then
            campos.SetField("CODPROCED_SECUNDARIO_1", "0301010072")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_1", "Consulta médica na atenção especializada".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_1", "1")

            campos.SetField("CODPROCED_SECUNDARIO_2", "0211020036")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_2", "Eletrocardiograma".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_2", "1")

        ElseIf procedimento.Rows(0)("cod").ToString() = "0905010035" Then
            campos.SetField("CODPROCED_SECUNDARIO_1", "0301010072")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_1", "Consulta médica na atenção especializada".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_1", "1")

            campos.SetField("CODPROCED_SECUNDARIO_2", "0211060020")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_2", "Biomicroscopia de fundo de olho".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_2", "1")

            campos.SetField("CODPROCED_SECUNDARIO_3", "")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_3", "Mapeamento de retina".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_3", "1")

            campos.SetField("CODPROCED_SECUNDARIO_4", "")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_4", "Tonometria".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_4", "1")

        ElseIf procedimento.Rows(0)("cod").ToString() = "0904010031" Then
            campos.SetField("CODPROCED_SECUNDARIO_1", "0301010072")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_1", "Consulta médica na atenção especializada".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_1", "1")

            campos.SetField("CODPROCED_SECUNDARIO_2", "0209040025")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_2", "Laringoscopia".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_2", "1")

            campos.SetField("CODPROCED_SECUNDARIO_3", "0209040041")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_3", "Videolaringoscopia".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_3", "1")

        ElseIf procedimento.Rows(0)("cod").ToString() = "0903010011" Then
            campos.SetField("CODPROCED_SECUNDARIO_1", "0301010072")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_1", "Consulta médica na atenção especializada".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_1", "1")

            campos.SetField("CODPROCED_SECUNDARIO_2", "0211020036")
            campos.SetField("DESCRICAO_PROCED_SECUNDARIO_2", "Eletrocardiograma".ToUpper())
            campos.SetField("QTD_PROCED_SECUNDARIO_2", "1")

            For i As Integer = 0 To procedimentoSecundario.Rows.Count - 1

                Dim codigo = procedimentoSecundario.Rows(i)("cod_proced_secundario").Value.ToString()
                Dim descricao = procedimentoSecundario.Rows(i)("descricao").Value.ToString()
                Dim qtd = procedimentoSecundario.Rows(i)("qtd").Value.ToString()

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


        campos.SetField("CID1", procedimento.Rows(0)("cid_principal").ToString())
        campos.SetField("CID2", procedimento.Rows(0)("cid_sec").ToString())

        stamper.FormFlattening = True

        stamper.Close()
        reader.Close()



    End Sub

End Class
