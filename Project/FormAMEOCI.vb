Imports System.Globalization
Imports System.IO
Imports System.Security.Principal
Imports System.Text
Imports System.Web
Imports Mysqlx.XDevAPI.Common

Public Class FormAMEOCI
    Private linhas As New List(Of String)
    Dim m As New Main
    Dim result As DataTable
    'Private Sub btnGerarArquivo_Click(sender As Object, e As EventArgs) Handles btnGerarArquivo.Click
    '    If txtNumApac.Text = "" Then
    '        MessageBox.Show("Informe o número da APAC.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtNumApac.Focus()
    '        Exit Sub
    '    End If
    '    If txtCpfPaciente.Text = "" Then
    '        MessageBox.Show("Informe o CPF do paciente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtCpfPaciente.Focus()
    '        Exit Sub
    '    End If
    '    If dtNascimento.Text = "" Then
    '        MessageBox.Show("Informe a data de nascimento do paciente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        dtNascimento.Focus()
    '        Exit Sub
    '    End If
    '    If txtNomePaciente.Text = "" Then
    '        MessageBox.Show("Informe o nome do paciente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtNomePaciente.Focus()
    '        Exit Sub
    '    End If
    '    If txtNomeMae.Text = "" Then
    '        MessageBox.Show("Informe o nome da mãe do paciente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtNomeMae.Focus()
    '        Exit Sub
    '    End If
    '    If txtNomeRespPaciente.Text = "" Then
    '        MessageBox.Show("Informe o nome do responsavel pelo paciente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtNomeRespPaciente.Focus()
    '        Exit Sub
    '    End If
    '    If txtDDD.Text = "" Then
    '        MessageBox.Show("Informe o DDD.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtDDD.Focus()
    '        Exit Sub
    '    End If
    '    If txtTelefone.Text = "" Then
    '        MessageBox.Show("Informe o numero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtTelefone.Focus()
    '        Exit Sub
    '    End If
    '    If txtCep.Text.Length < 9 Then
    '        MessageBox.Show("Informe o CEP.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtCep.Focus()
    '        Exit Sub
    '    End If
    '    If txtNumero.Text = "" Then
    '        MessageBox.Show("Informe o Número.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtNumero.Focus()
    '        Exit Sub
    '    End If
    '    If txtProcedimentoPrincipal.SelectedIndex < 0 Then
    '        MessageBox.Show("Selecione o procedimento principal.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtNumero.Focus()
    '        Exit Sub
    '    End If

    '    Try
    '        Dim codigos As New List(Of String)
    '        Dim quantidades As New List(Of Integer)
    '        'Dim linhas As New List(Of String)
    '        Dim dataGeracao As String = Date.Now.ToString("yyyyMMdd")
    '        Dim dataProcessamento As String = Date.Now.ToString("yyyyMMdd")
    '        Dim versao As String = "1.0".PadRight(15, " "c) ' Versão deve ter 15 caracteres

    '        For Each row As DataGridViewRow In dgvProcedimentos.Rows
    '            If Not row.IsNewRow Then
    '                codigos.Add(row.Cells("Codigo").Value.ToString())
    '                quantidades.Add(Convert.ToInt32(row.Cells("Quantidade").Value))
    '            End If
    '        Next

    '        ' Dim campoControle As String = CalcularCampoControle(txtNumApac.Text, codigos, quantidades)
    '        Dim competenciaFormatada As String = My.Settings.OCIcompetencia

    '        ' Caminho fixo do arquivo principal
    '        Dim filePath As String = Path.Combine("C:\APAC\IMPORTA", "AP" & competenciaFormatada & chkMonthEXT())

    '        ' Se o arquivo ainda não existir, cria com o header
    '        If Not File.Exists(filePath) OrElse New FileInfo(filePath).Length = 0 Then
    '            ' ================= HEADER (Registro 01) =================
    '            Dim header As New StringBuilder()
    '            header.Append("01#APAC")                                     ' Identificação
    '            header.Append(competenciaFormatada)                          ' Competência (AAAAMM)

    '            Dim qtdApacs As Integer = 1 ' se for 1 APAC, ajuste se for mais
    '            header.Append(qtdApacs.ToString().PadLeft(6, "0"c))          ' Quantidade de APACs (6)

    '            Dim campoControle As String = CalcularCampoControle(txtNumApac.Text, codigos, quantidades)
    '            header.Append(campoControle.PadLeft(4, "0"c))

    '            header.Append(Fmt(RemoverAcentos(My.Settings.OCInomeUnidade), 30))                  ' Nome órgão origem (30)
    '            header.Append(Fmt(My.Settings.OCIsigla, 6))                    ' Sigla (6)
    '            header.Append(My.Settings.OCIcnpj.Replace(".", "").Replace("/", "").Replace("-", "").PadLeft(14, "0"c)) ' 
    '            header.Append(Fmt(RemoverAcentos(My.Settings.OCIorgaoDestino), 40))                 ' Nome órgão destino (40)
    '            header.Append(My.Settings.OCItipo.PadRight(1, " "c))         ' Tipo órgão destino M/E' Campo controle (4)

    '            'header.Append(Fmt(txtOrgaoOrigem.Text, 30))                  ' Nome órgão origem (30)
    '            'header.Append(Fmt(txtSiglaOrgao.Text, 6))                    ' Sigla (6)
    '            'header.Append(txtCGC.Text.Replace(".", "").Replace("/", "").Replace("-", "").PadLeft(14, "0"c)) ' CNPJ
    '            'header.Append(Fmt(txtOrgaoDestino.Text, 40))                 ' Nome órgão destino (40)
    '            'header.Append(txtDestinoTipo.Text.PadRight(1, " "c))         ' Tipo órgão destino M/E

    '            ' Aqui precisa usar a DATA DA COMPETÊNCIA, não a data de hoje
    '            Dim dataCompetencia As String = competenciaFormatada & "20"  ' AAAAMM + "20" (ajuste pro dia correto do mês)
    '            header.Append(dataCompetencia)

    '            header.Append("Versao 01.00".PadRight(15, " "c))             ' Versão
    '            'linhas.Add(header.ToString())
    '            File.AppendAllText(filePath, header.ToString() & Chr(13) & Chr(10), Encoding.GetEncoding("iso-8859-1"))

    '        End If

    '        Dim r14 As New StringBuilder()

    '        ' 01. Tipo registro
    '        r14.Append("14")                                  ' 2

    '        ' 02. Competência
    '        r14.Append(competenciaFormatada)                  ' 6 (AAAAMM)

    '        ' 03. Nº da APAC
    '        r14.Append(txtNumApac.Text.PadLeft(13, "0"c))     ' 13

    '        ' 05. UF
    '        r14.Append(My.Settings.OCIuf.PadRight(2, " "c))

    '        ' 06. CNES Solicitante
    '        r14.Append(txtCnesExecutante.Text.PadLeft(7, "0"c)) ' 7

    '        ' 08. Data autorização
    '        r14.Append(Date.Now.ToString("yyyyMMdd")) ' 8

    '        ' 09. Data emissão
    '        r14.Append(dtValidadeIni.Value.ToString("yyyyMMdd"))     ' 8

    '        ' 10. Data validade
    '        r14.Append(dtValidadeFim.Value.ToString("yyyyMMdd")) ' 8

    '        r14.Append("00")      ' Tipo de atendimento (2)

    '        ' 11. Tipo APAC
    '        r14.Append(txtTipoApac.SelectedValue.ToString())

    '        ' 13. Nome paciente
    '        r14.Append(Fmt(txtNomePaciente.Text, 30))

    '        ' 14. Nome mãe
    '        r14.Append(Fmt(txtNomeMae.Text, 30))

    '        ' 15. Logradouro
    '        r14.Append(Fmt(txtLogradouro.Text, 30))

    '        ' 16. Número residência
    '        r14.Append(txtNumero.Text.PadRight(5, " "c))

    '        ' 17. Complemento
    '        If txtComplemento.Text.Length > 0 Then
    '            r14.Append(RemoverAcentos(txtComplemento.Text.PadRight(10, " "c)))
    '        Else
    '            r14.Append("          ")
    '        End If

    '        ' 18. CEP
    '        r14.Append(txtCep.Text.Replace("-", "").PadRight(8, " "c))

    '        ' 19. Município IBGE
    '        r14.Append(txtMunIbge.Text.PadLeft(7, "0"c))        ' 7

    '        ' 20. Data nascimento
    '        r14.Append(Format(CDate(dtNascimento.Text).ToString("yyyyMMdd"))) ' 8

    '        ' 21. Sexo
    '        r14.Append(txtSexo.Text.PadRight(1, " "c))          ' 1

    '        ' 22. Nome médico solicitante
    '        r14.Append(Fmt(txtNomeMedicoSolicitante.Text, 30))             ' 30

    '        ' 23. Procedimento principal
    '        r14.Append(txtProcedimentoPrincipal.SelectedValue.PadLeft(10, "0"c)) ' 10

    '        ' 24. Motivo saída
    '        r14.Append(txtMotivoSaida.SelectedValue.ToString().PadLeft(2, "0"c)) ' 2

    '        ' 25. Data alta/óbito/transf
    '        If txtMotivoSaida.SelectedValue.ToString() <> "00" Then
    '            r14.Append(dtAltaObito.Value.ToString("yyyyMMdd"))
    '        Else
    '            r14.Append("        ")
    '        End If                                              ' 8

    '        ' 26. Nome MEDICO AUTORIZADOR
    '        r14.Append(Fmt(txtNomeAutorizador.Text, 30))            ' 30

    '        ' 27. CNS paciente
    '        If txtCnsPaciente.Text.Length > 0 Then
    '            r14.Append(txtCnsPaciente.Text.PadLeft(15, "0"c))   ' 15
    '        Else
    '            r14.Append("               ")
    '        End If

    '        ' 28. CNS médico solicitante
    '        r14.Append(txtNomeMedicoSolicitante.SelectedValue.PadLeft(15, "0"c)) ' 15

    '        ' 29. CNS diretor
    '        r14.Append(txtNomeAutorizador.SelectedValue.PadLeft(15, "0"c))    ' 15

    '        r14.Append("    ")

    '        If txtProntuario.Text <> "" Then
    '            r14.Append(txtProntuario.Text.PadRight(10, " "c))
    '        Else
    '            r14.Append("          ")
    '        End If

    '        r14.Append(txtCnesSolicitante.Text.PadLeft(7, "0"c))

    '        r14.Append(dtEmissao.Value.ToString("yyyyMMdd"))

    '        r14.Append(dtAutorizacao.Value.ToString("yyyyMMdd"))

    '        r14.Append(Fmt(txtGestor.Text, 10))

    '        r14.Append(txtTipoAtend.SelectedValue.PadLeft(2, "0"c))      ' Tipo de atendimento (2)

    '        If String.IsNullOrWhiteSpace(txtApacAnterior.Text) Then
    '            r14.Append("0000000000000")
    '        Else
    '            r14.Append(txtApacAnterior.Text.PadLeft(13, "0"c))
    '        End If

    '        r14.Append(txtRaca.SelectedValue.ToString().PadLeft(2, "0"c))

    '        r14.Append(Fmt(txtNomeRespPaciente.Text, 30))

    '        r14.Append("010")

    '        If txtRaca.SelectedValue.ToString() = "05" Then
    '            r14.Append("    ")
    '        Else
    '            r14.Append("    ")
    '        End If

    '        r14.Append(cbTipoLogradouro.SelectedValue.PadLeft(3, "0"c))

    '        r14.Append(txtBairro.Text.PadRight(30, " "c))

    '        r14.Append(txtDDD.Text.PadLeft(2, " "c))

    '        r14.Append(txtTelefone.Text.PadLeft(9, " "c))

    '        r14.Append(txtEmail.Text.PadRight(40, " "c))

    '        r14.Append(txtCNSMedicoExecutante.SelectedValue.PadLeft(15, "0"c))

    '        r14.Append(txtCpfPaciente.Text.PadLeft(11, "0"c))

    '        r14.Append(txtEquipe.Text.PadLeft(10, " "c))

    '        r14.Append(If(chkSituacaoRua.Checked, "S", "N"))

    '        'linhas.Add(r14.ToString())
    '        File.AppendAllText(filePath, r14.ToString() & Chr(13) & Chr(10), Encoding.GetEncoding("iso-8859-1"))

    '        Dim r06 As New StringBuilder()
    '        r06.Append("06")
    '        r06.Append(competenciaFormatada)
    '        r06.Append(txtNumApac.Text.PadLeft(13, "0"c))
    '        r06.Append(txtCidPrincipal.SelectedValue.PadRight(4, " "c))
    '        If txtCidSecundario.SelectedIndex >= 0 Then
    '            r06.Append(txtCidSecundario.SelectedValue.PadRight(4, " "c))
    '        End If
    '        'linhas.Add(r06.ToString())
    '        File.AppendAllText(filePath, r06.ToString() & Chr(13) & Chr(10), Encoding.GetEncoding("iso-8859-1"))

    '        ' ========== REGISTRO 13 PRINCIPAL ==========
    '        Dim r13Principal As New StringBuilder()
    '        r13Principal.Append("13")
    '        r13Principal.Append(competenciaFormatada)
    '        r13Principal.Append(txtNumApac.Text.PadLeft(13, "0"c))
    '        r13Principal.Append(txtProcedimentoPrincipal.SelectedValue.PadLeft(10, "0"c))
    '        r13Principal.Append(CBOmed.SelectedValue.PadLeft(6, "0"c))
    '        r13Principal.Append("0000001") ' quantidade = 1 (7 dígitos)
    '        r13Principal.Append(New String(" "c, 53))
    '        'linhas.Add(r13Principal.ToString()) ' NÃO põe vbCrLf aqui
    '        File.AppendAllText(filePath, r13Principal.ToString() & Chr(13) & Chr(10), Encoding.GetEncoding("iso-8859-1"))
    '        ' ========== REGISTRO 13 SECUNDÁRIOS ==========
    '        For i = 0 To dgvProcedimentos.RowCount - 1
    '            If dgvProcedimentos.Rows(i).IsNewRow Then Continue For

    '            Dim r13 As New StringBuilder() ' novo builder a cada linha

    '            r13.Append("13")
    '            r13.Append(competenciaFormatada)
    '            r13.Append(txtNumApac.Text.PadLeft(13, "0"c))
    '            r13.Append(dgvProcedimentos.Rows(i).Cells(0).Value.ToString().PadLeft(10, "0"c)) ' código procedimento
    '            r13.Append(dgvProcedimentos.Rows(i).Cells(1).Value.ToString().PadLeft(6, "0"c)) ' CBO
    '            r13.Append(dgvProcedimentos.Rows(i).Cells(2).Value.ToString().PadLeft(7, "0"c)) ' quantidade
    '            r13.Append(New String(" "c, 53))
    '            'linhas.Add(r13.ToString())
    '            File.AppendAllText(filePath, r13.ToString() & Chr(13) & Chr(10), Encoding.GetEncoding("iso-8859-1"))
    '        Next


    '        ' Grava automaticamente no arquivo .SET
    '        'File.AppendAllText(filePath, String.Join(vbCrLf, linhas) & vbCrLf, Encoding.GetEncoding("iso-8859-1"))
    '        MessageBox.Show("APAC adicionada e salva no arquivo com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        clearFields()

    '    Catch ex As Exception
    '        MessageBox.Show("Erro ao gerar arquivo: " & ex.Message)
    '    End Try

    'End Sub

    Private Sub btnAddPacAPAC_Click(sender As Object, e As EventArgs) Handles btnGerarArquivo.Click
        Try
            ' ==================== VALIDAÇÕES ====================
            If Not m.ValidarCPF(txtCpfPaciente.Text) Then Return
            If txtNumApac.Text.Trim() = "" Then Throw New Exception("Informe o número da APAC.")
            If txtCpfPaciente.Text.Trim() = "" Then Throw New Exception("Informe o CPF do paciente.")
            If dtNascimento.Text.Trim() = "" Then Throw New Exception("Informe a data de nascimento do paciente.")
            If txtNomePaciente.Text.Trim() = "" Then Throw New Exception("Informe o nome do paciente.")
            If txtNomeMae.Text.Trim() = "" Then Throw New Exception("Informe o nome da mãe.")
            If txtNomeRespPaciente.Text.Trim() = "" Then Throw New Exception("Informe o nome do responsável.")
            If txtDDD.Text.Trim() = "" Then Throw New Exception("Informe o DDD.")
            If txtTelefone.Text.Trim() = "" Then Throw New Exception("Informe o telefone.")
            If txtCep.Text.Length < 8 Then Throw New Exception("Informe o CEP corretamente.")
            If txtNumero.Text.Trim() = "" Then Throw New Exception("Informe o número.")
            If txtProcedimentoPrincipal.SelectedIndex < 0 Then Throw New Exception("Selecione o procedimento principal.")
            chkResponsavel()

            ' ==================== CONFIGURAÇÕES ====================
            Dim competencia As String = My.Settings.OCIcompetencia
            Dim caminhoArquivo As String = Path.Combine("C:\APAC\IMPORTA", "AP" & competencia & chkMonthEXT())
            Dim codigos As New List(Of String)
            Dim quantidades As New List(Of Integer)

            For Each row As DataGridViewRow In dgvProcedimentos.Rows
                If Not row.IsNewRow Then
                    codigos.Add(row.Cells("Codigo").Value.ToString())
                    quantidades.Add(Convert.ToInt32(row.Cells("Quantidade").Value))
                End If
            Next

            ' ==================== CRIA STREAM ÚNICO ====================
            Using fs As New FileStream(caminhoArquivo, FileMode.Append, FileAccess.Write, FileShare.None)
                Using sw As New StreamWriter(fs, Encoding.GetEncoding("iso-8859-1"))
                    ' ================= HEADER (01) =================
                    If fs.Length = 0 Then
                        Dim header As New StringBuilder()
                        header.Append("01#APAC")
                        header.Append(competencia)
                        header.Append("000001") ' Quantidade de APACs (ajuste se gerar mais)
                        header.Append("0000")   ' Campo controle
                        header.Append(Fmt(RemoverAcentos(My.Settings.OCInomeUnidade), 30))
                        header.Append(Fmt(My.Settings.OCIsigla, 6))
                        header.Append(My.Settings.OCIcnpj.Replace(".", "").Replace("/", "").Replace("-", "").PadLeft(14, "0"c))
                        header.Append(Fmt(RemoverAcentos(My.Settings.OCIorgaoDestino), 40))
                        header.Append(My.Settings.OCItipo.PadRight(1, " "c))
                        header.Append(competencia & "20") ' Data competência
                        header.Append("Versao 01.00".PadRight(15, " "c))
                        sw.WriteLine(header.ToString())
                    End If

                    ' ================= REGISTRO 14 =================
                    Dim r14 As New StringBuilder()
                    r14.Append("14") ' Tipo de registro
                    r14.Append(competencia)
                    r14.Append(txtNumApac.Text.PadLeft(13, "0"c))
                    r14.Append(My.Settings.OCIuf.PadRight(2, " "c))
                    r14.Append(txtCnesExecutante.Text.PadLeft(7, "0"c))
                    r14.Append(Date.Now.ToString("yyyyMMdd"))
                    r14.Append(dtValidadeIni.Value.ToString("yyyyMMdd"))
                    r14.Append(dtValidadeFim.Value.ToString("yyyyMMdd"))
                    r14.Append("00") ' Tipo atendimento
                    r14.Append(txtTipoApac.SelectedValue.ToString())
                    r14.Append(Fmt(txtNomePaciente.Text, 30))
                    r14.Append(Fmt(txtNomeMae.Text, 30))
                    r14.Append(Fmt(txtLogradouro.Text, 30))
                    r14.Append(txtNumero.Text.PadRight(5, " "c))
                    r14.Append(If(txtComplemento.Text <> "", RemoverAcentos(txtComplemento.Text.PadRight(10, " "c)), New String(" "c, 10)))
                    r14.Append(txtCep.Text.Replace("-", "").PadRight(8, " "c))
                    r14.Append(txtMunIbge.Text.PadLeft(7, "0"c))
                    r14.Append(Format(CDate(dtNascimento.Text).ToString("yyyyMMdd")))
                    r14.Append(txtSexo.Text.PadRight(1, " "c))
                    r14.Append(Fmt(txtNomeMedicoSolicitante.Text, 30))
                    r14.Append(txtProcedimentoPrincipal.SelectedValue.PadLeft(10, "0"c))
                    r14.Append(txtMotivoSaida.SelectedValue.ToString().PadLeft(2, "0"c))
                    If txtMotivoSaida.SelectedValue.ToString() <> "00" Then
                        r14.Append(dtAltaObito.Value.ToString("yyyyMMdd"))
                    Else
                        r14.Append(New String(" "c, 8))
                    End If
                    r14.Append(Fmt(txtNomeAutorizador.Text, 30))
                    r14.Append(If(txtCnsPaciente.Text.Length > 0, txtCnsPaciente.Text.PadLeft(15, "0"c), New String(" "c, 15)))
                    r14.Append(txtNomeMedicoSolicitante.SelectedValue.PadLeft(15, "0"c))
                    r14.Append(txtNomeAutorizador.SelectedValue.PadLeft(15, "0"c))
                    r14.Append(New String(" "c, 4)) ' Reservado
                    r14.Append(If(txtProntuario.Text <> "", txtProntuario.Text.PadRight(10, " "c), New String(" "c, 10)))
                    r14.Append(txtCnesSolicitante.Text.PadLeft(7, "0"c))
                    r14.Append(dtEmissao.Value.ToString("yyyyMMdd"))
                    r14.Append(dtAutorizacao.Value.ToString("yyyyMMdd"))
                    r14.Append(Fmt(txtGestor.Text, 10))
                    r14.Append(txtTipoAtend.SelectedValue.PadLeft(2, "0"c))
                    r14.Append(If(String.IsNullOrWhiteSpace(txtApacAnterior.Text), "0000000000000", txtApacAnterior.Text.PadLeft(13, "0"c)))
                    r14.Append(txtRaca.SelectedValue.ToString().PadLeft(2, "0"c))
                    r14.Append(Fmt(txtNomeRespPaciente.Text, 30))
                    r14.Append("010")
                    r14.Append(New String(" "c, 4))
                    r14.Append(cbTipoLogradouro.SelectedValue.PadLeft(3, "0"c))
                    r14.Append(txtBairro.Text.PadRight(30, " "c))
                    r14.Append(txtDDD.Text.PadLeft(2, " "c))
                    r14.Append(txtTelefone.Text.PadLeft(9, " "c))
                    r14.Append(txtEmail.Text.PadRight(40, " "c))
                    r14.Append(txtCNSMedicoExecutante.SelectedValue.PadLeft(15, "0"c))
                    r14.Append(txtCpfPaciente.Text.PadLeft(11, "0"c))
                    r14.Append(txtEquipe.Text.PadLeft(10, " "c))
                    r14.Append(If(chkSituacaoRua.Checked, "S", "N"))
                    sw.WriteLine(r14.ToString())

                    ' ================= REGISTRO 06 =================
                    Dim r06 As New StringBuilder()
                    r06.Append("06")
                    r06.Append(competencia)
                    r06.Append(txtNumApac.Text.PadLeft(13, "0"c))
                    r06.Append(txtCidPrincipal.SelectedValue.PadRight(4, " "c))
                    If txtCidSecundario.SelectedIndex >= 0 Then
                        r06.Append(txtCidSecundario.SelectedValue.PadRight(4, " "c))
                    Else
                        r06.Append(New String(" "c, 4))
                    End If

                    sw.WriteLine(r06.ToString())

                    ' ================= REGISTRO 13 (Principal + Secundários) =================
                    Dim r13Principal As New StringBuilder()
                    r13Principal.Append("13")
                    r13Principal.Append(competencia)
                    r13Principal.Append(txtNumApac.Text.PadLeft(13, "0"c))
                    r13Principal.Append(txtProcedimentoPrincipal.SelectedValue.PadLeft(10, "0"c))
                    r13Principal.Append(CBOmed.SelectedValue.PadLeft(6, "0"c))
                    r13Principal.Append("0000001")
                    r13Principal.Append(New String(" "c, 53))
                    sw.WriteLine(r13Principal.ToString())

                    For Each row As DataGridViewRow In dgvProcedimentos.Rows
                        If row.IsNewRow Then Continue For
                        Dim r13 As New StringBuilder()
                        r13.Append("13")
                        r13.Append(competencia)
                        r13.Append(txtNumApac.Text.PadLeft(13, "0"c))
                        r13.Append(row.Cells(0).Value.ToString().PadLeft(10, "0"c))
                        r13.Append(row.Cells(1).Value.ToString().PadLeft(6, "0"c))
                        r13.Append(row.Cells(2).Value.ToString().PadLeft(7, "0"c))
                        r13.Append(New String(" "c, 53))
                        sw.WriteLine(r13.ToString())
                    Next
                End Using
            End Using

            MessageBox.Show("✅ Arquivo .SET gerado com sucesso e validado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clearFields()

        Catch ex As Exception
            MessageBox.Show("⚠️ Erro ao gerar arquivo: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function RemoverAcentos(texto As String) As String
        If String.IsNullOrWhiteSpace(texto) Then Return texto

        ' Normaliza o texto para decompor acentos (ex: Á -> A + ́)
        Dim normalized As String = texto.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder()

        For Each c As Char In normalized
            Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c)
            ' Pula caracteres de acento (NonSpacingMark)
            If uc <> UnicodeCategory.NonSpacingMark Then
                sb.Append(c)
            End If
        Next

        ' Remove cedilha e tildes específicos
        Dim semAcento As String = sb.ToString().Normalize(NormalizationForm.FormC)
        semAcento = semAcento.Replace("ç", "C").Replace("Ç", "C")

        Return semAcento.ToUpper

    End Function


    Private Sub clearFields()
        txtCpfPaciente.Clear()
        txtCnsPaciente.Clear()
        txtProntuario.Clear()
        dtNascimento.Clear()
        txtSexo.SelectedIndex = 0
        txtNomePaciente.Text = ""
        txtNomeMae.Clear()
        txtNomeRespPaciente.Clear()
        txtRaca.SelectedIndex = 0
        chkSituacaoRua.Checked = False
        txtEmail.Clear()
        txtDDD.Clear()
        txtTelefone.Clear()
        txtCep.Clear()
        cbTipoLogradouro.SelectedIndex = 0
        txtCidSecundario.SelectedIndex = -1
        txtLogradouro.Clear()
        txtNumero.Clear()
        txtBairro.Clear()
        txtComplemento.Clear()
        txtNumApac.Clear()
        txtNumApac.Focus()

    End Sub

    Private Sub txtProcedimentoPrincipal_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles txtProcedimentoPrincipal.SelectionChangeCommitted
        Dim procedSec As New Dictionary(Of String, String)
        Dim cbo As New Dictionary(Of String, String)

        dgvProcedimentos.Rows.Clear()

        If txtProcedimentoPrincipal.SelectedValue = "0904010015" Then
            procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
            procedSec.Add("0211070041", "0211070041 - Audiometria tonal limiar (via aérea/óssea)")
            cbo.Add("225275", "225275 - Médico Otorrinolaringologista")
            dgvProcedimentos.Rows.Add("0301010072", "225275", "1")
            dgvProcedimentos.Rows.Add("0211070041", "225275", "1")

        ElseIf txtProcedimentoPrincipal.SelectedValue = "0902010026" Then
            procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
            procedSec.Add("0211020036", "0211020036 - Eletrocardiograma (ECG)")
            cbo.Add("225120", "225120 - Médico Cardiologista")
            dgvProcedimentos.Rows.Add("0301010072", "225120", "1")
            dgvProcedimentos.Rows.Add("0211020036", "225120", "1")

        ElseIf txtProcedimentoPrincipal.SelectedValue = "0902010018" Then
            procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
            procedSec.Add("0211020036", "0211020036 - Eletrocardiograma (ECG)")
            cbo.Add("225120", "225120 - Médico Cardiologista")
            dgvProcedimentos.Rows.Add("0301010072", "225120", "1")
            dgvProcedimentos.Rows.Add("0211020036", "225120", "1")

        ElseIf txtProcedimentoPrincipal.SelectedValue = "0905010035" Then
            procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
            procedSec.Add("0211060020", "0211060020 - Biomicroscopia de fundo de olho")
            procedSec.Add("0211060127", "0211060127 - Mapeamento de retina")
            procedSec.Add("0211060259", "0211060259 - Tonometria")
            cbo.Add("225265", "225265 - Médico Oftalmologista")
            dgvProcedimentos.Rows.Add("0301010072", "225265", "1")
            dgvProcedimentos.Rows.Add("0211060020", "225265", "1")
            dgvProcedimentos.Rows.Add("0211060127", "225265", "1")
            dgvProcedimentos.Rows.Add("0211060259", "225265", "1")

        ElseIf txtProcedimentoPrincipal.SelectedValue = "0903010011" Then
            procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
            cbo.Add("225270", "225270 - Médico ortopedista e traumatologista")
            dgvProcedimentos.Rows.Add("0301010072", "225270", "1")

        ElseIf txtProcedimentoPrincipal.SelectedValue = "0904010031" Then
            procedSec.Add("0301010072", "0301010072 - Consulta médica na atenção especializada")
            procedSec.Add("0209040025", "0209040025 - Laringoscopia")
            procedSec.Add("0209040041", "0209040041 - Videolaringoscopia")
            cbo.Add("225275", "225275 - Médico Otorrinolaringologista")
            dgvProcedimentos.Rows.Add("0301010072", "225275", "1")
            dgvProcedimentos.Rows.Add("0209040025", "225275", "1")
            dgvProcedimentos.Rows.Add("0209040041", "225275", "1")

        End If

        CodProcedimento.DataSource = New BindingSource(procedSec, Nothing)
        CodProcedimento.DisplayMember = "Value"   ' O que aparece para o usuário
        CodProcedimento.ValueMember = "Key"
        CodProcedimento.SelectedIndex = 0

        CBOmed.DataSource = New BindingSource(cbo, Nothing)
        CBOmed.DisplayMember = "Value"   ' O que aparece para o usuário
        CBOmed.ValueMember = "Key"
        CBOmed.SelectedIndex = 0

        getServersSUS()
        Dim queryCID As String = $"SELECT cid.cid,cid.descricao FROM cid 
        JOIN cod_oci_principal ON cid.id_oci_principal = cod_oci_principal.id
        WHERE cod_oci_principal.cod ='{txtProcedimentoPrincipal.SelectedValue}'"
        FormAMEmain.loadComboBox(queryCID, txtCidPrincipal, "descricao", "cid")
        FormAMEmain.loadComboBox(queryCID, txtCidSecundario, "descricao", "cid")

        txtCidSecundario.SelectedIndex = -1

    End Sub
    Private Sub btnAdicionarProcedimento_Click(sender As Object, e As EventArgs) Handles btnAdicionarProcedimento.Click
        Dim cod As String = CodProcedimento.SelectedValue.Trim()
        If String.IsNullOrWhiteSpace(cod) Then Exit Sub

        Dim cbo As String = CBOmed.SelectedValue.Trim()
        Dim qtd As String = Quantidade.Text.Trim()

        ' Adiciona a linha com todas as colunas necessárias
        dgvProcedimentos.Rows.Add(cod, cbo, qtd)
    End Sub

    Public Function CalcularCampoControle(apacNumber As String, codigosProcedimento As List(Of String), quantidadesProcedimento As List(Of Integer)) As String
        Dim total As Long = 0

        ' Soma os dígitos dos códigos dos procedimentos
        For Each codigo In codigosProcedimento
            Dim apenasDigitos = New String(codigo.Where(Function(c) Char.IsDigit(c)).ToArray())
            If apenasDigitos <> "" Then
                total += CLng(apenasDigitos)
            End If
        Next

        ' Soma as quantidades dos procedimentos
        For Each qtd In quantidadesProcedimento
            total += CLng(qtd)
        Next

        ' Soma os dígitos do número da APAC
        Dim apacNumeros = New String(apacNumber.Where(Function(c) Char.IsDigit(c)).ToArray())
        If apacNumeros <> "" Then
            total += CLng(apacNumeros)
        End If

        ' Calcula o campo controle: (total Mod 1111) + 1111
        Dim resto As Integer = CInt(total Mod 1111)
        Dim campoControle As Integer = resto + 1111

        ' Retorna com 4 dígitos, zeros à esquerda
        Return campoControle.ToString().PadLeft(4, "0"c)
    End Function

    Private Function GetNextLoteNumber(qtdApacs As Integer) As String
        ' Retorna a quantidade de APACs do lote com 6 dígitos
        Return qtdApacs.ToString().PadLeft(6, "0"c)
    End Function

    Private Function ComputeControlField(apacNumber As String, procCodes As List(Of String), procQuantities As List(Of Integer)) As String
        Dim total As Long = 0

        ' soma códigos numéricos
        For Each code In procCodes
            Dim digits = New String(code.Where(Function(c) Char.IsDigit(c)).ToArray())
            If digits <> "" Then total += CLng(digits)
        Next

        ' soma quantidades
        total += procQuantities.Sum(Function(x) CLng(x))

        ' soma número da APAC
        Dim apacDigits = New String(apacNumber.Where(Function(c) Char.IsDigit(c)).ToArray())
        If apacDigits <> "" Then total += CLng(apacDigits)

        ' calcula controle
        Dim resto As Integer = CInt(total Mod 1111)
        Dim campo As Integer = resto + 1111
        Return campo.ToString().PadLeft(4, "0"c)
    End Function

    Private Function Fmt(valor As String, tamanho As Integer) As String
        If valor Is Nothing Then valor = ""
        valor = valor.Trim()
        Return RemoverAcentos(valor.PadRight(tamanho, " "c).Substring(0, tamanho))
    End Function

    Private Sub btnRemoverProcedimento_Click(sender As Object, e As EventArgs) Handles btnRemoverProcedimento.Click
        If dgvProcedimentos.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In dgvProcedimentos.SelectedRows
                If Not row.IsNewRow Then
                    dgvProcedimentos.Rows.Remove(row)
                End If
            Next
        Else
            MessageBox.Show("Selecione um procedimento para remover.")
        End If
    End Sub

    Private Sub getServersSUS()
        Dim main As New FormAMEmain
        Dim comboList As New List(Of System.Windows.Forms.ComboBox) From {
            txtCNSMedicoExecutante,
            txtNomeMedicoSolicitante
        }

        For Each cbb As ComboBox In comboList
            main.loadComboBox($"SELECT SUS, nome FROM servidores WHERE cbo ='{CBOmed.SelectedValue}'", cbb, "nome", "SUS", True)
        Next

        main.loadComboBox($"SELECT SUS, nome FROM servidores WHERE oci_autorizador=1", txtNomeAutorizador, "nome", "SUS", True)

    End Sub

    Private Function getPacientes(Optional ByVal cpf As String = Nothing, Optional nome As String = Nothing, Optional dtnasc As String = Nothing, Optional id As Integer = 0)
        Dim data As DataTable = Nothing
        Dim query As String = "SELECT pacientes.*, ceps_peruibe.cep AS CEP,ceps_peruibe.tipo,ceps_peruibe.logradouro,ceps_peruibe.bairro
          FROM pacientes
          JOIN ceps_peruibe ON pacientes.id_logradouro = ceps_peruibe.id "

        If cpf IsNot Nothing Then
            data = FormAMEmain.getDataset(query & $" WHERE pacientes.cpf ='{cpf}'")

        ElseIf nome IsNot Nothing Then
            data = FormAMEmain.getDataset(query & $" WHERE pacientes.nome LIKE '%{nome}%'")

        ElseIf dtnasc IsNot Nothing Then

            data = FormAMEmain.getDataset(query & $" WHERE pacientes.dtnasc ='{dtnasc}'")
        ElseIf id > 0 Then

            data = FormAMEmain.getDataset(query & $" WHERE pacientes.id ={id}")
        End If

        Return data

    End Function

    Private Sub FormAMEOCI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim novoMes As Integer

        Try
            ' 1. Converter a string para um número inteiro

            If Integer.TryParse(My.Settings.OCIcompetencia.Substring(4, 2), novoMes) Then

                ' O TryParse foi bem-sucedido e a variável novoMes agora contém o valor numérico (1 a 12)

                ' Pega a data atual do DateTimePicker
                Dim dataAtual As Date = dtValidadeIni.Value

                ' Pega o Ano e o Dia da data atual
                Dim anoAtual As Integer = dataAtual.Year
                Dim diaAtual As Integer = dataAtual.Day

                Try
                    ' 2. Criar uma nova data com o Novo Mês, mas mantendo o Ano e o Dia atuais
                    dtValidadeIni.Value = New Date(anoAtual, novoMes, diaAtual)

                Catch ex As ArgumentOutOfRangeException

                    ' Este erro ocorre se o dia atual for inválido no novo mês.
                    ' Exemplo: Tentar colocar o dia 31 em um mês que só tem 30 dias (como Abril, Junho, Setembro, Novembro).

                    ' Solução Comum: Ajustar para o último dia válido do novo mês.
                    Dim ultimoDiaDoMes As Integer = Date.DaysInMonth(anoAtual, novoMes)
                    dtValidadeIni.Value = New Date(anoAtual, novoMes, ultimoDiaDoMes)

                    ' (Opcional) Mostrar uma mensagem de aviso
                    MessageBox.Show($"O dia {diaAtual} não existe no mês {novoMes}. A data foi ajustada para o dia {ultimoDiaDoMes}.", "Ajuste de Data", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End Try

            Else
                ' (Opcional) Tratamento de erro se a string não puder ser convertida
                MessageBox.Show("A string do mês não é um número válido (01-12).", "Erro de Conversão", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            dgvProcedimentos.Columns.Clear()

            dgvProcedimentos.Columns.Add("Codigo", "Procedimento")
            dgvProcedimentos.Columns.Add("CBO", "CBO")
            dgvProcedimentos.Columns.Add("Quantidade", "Qtd")

            dgvProcedimentos.AllowUserToAddRows = True
            dgvProcedimentos.AllowUserToDeleteRows = True
            dgvProcedimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            txtSexo.SelectedIndex = 0

            Dim cbProcedPrincipal As New Dictionary(Of String, String) From {
                {"0904010015", "0904010015 - OCI Avaliação inicial diagnóstica de deficit auditivo"},
                {"0902010026", "0902010026 - OCI Avaliação Cardiológica"},
                {"0902010018", "0902010018 - OCI Avaliação de risco cirúrgico"},
                {"0905010035", "0905010035 - OCI Avaliação inicial em oftalmologia"},
                {"0903010011", "0903010011 - OCI Avaliação disgnóstica em ortopedia com recursos de raio-x"},
                {"0904010031", "0904010031 - OCI Avaliação disgnóstica de nasofaringe e orofaringe"}
            }

            txtProcedimentoPrincipal.DataSource = New BindingSource(cbProcedPrincipal, Nothing)
            txtProcedimentoPrincipal.DisplayMember = "Value"   ' O que aparece para o usuário
            txtProcedimentoPrincipal.ValueMember = "Key"
            txtProcedimentoPrincipal.SelectedIndex = -1

            Dim tipoLogra As New Dictionary(Of String, String) From {
                {"081", "RUA"},
                {"008", "AVENIDA"},
                {"031", "ESTRADA"},
                {"004", "ALAMEDA"},
                {"065", "PRAÇA"},
                {"105", "VIELA"},
                {"095", "SETOR"}
            }

            cbTipoLogradouro.DataSource = New BindingSource(tipoLogra, Nothing)
            cbTipoLogradouro.DisplayMember = "Value"   ' O que aparece para o usuário
            cbTipoLogradouro.ValueMember = "Key"
            cbTipoLogradouro.SelectedIndex = 0


            Dim racas As New Dictionary(Of String, String) From {
                {"01", "BRANCA"},
                {"02", "PRETA"},
                {"03", "PARDA"},
                {"04", "AMARELA"},
                {"05", "INDIGENA"},
                {"99", "SEM INFO"}
            }

            txtRaca.DataSource = New BindingSource(racas, Nothing)
            txtRaca.DisplayMember = "Value"   ' O que aparece para o usuário
            txtRaca.ValueMember = "Key"

            Dim tipo As New Dictionary(Of String, String) From {
                {"1", "INICIAL"},
                {"2", "CONTINUIDADE"},
                {"3", "UNICA"},
                {"4", "ENCERRAMENTO"}
            }

            txtTipoApac.DataSource = New BindingSource(tipo, Nothing)
            txtTipoApac.DisplayMember = "Value"   ' O que aparece para o usuário
            txtTipoApac.ValueMember = "Key"
            txtTipoApac.SelectedIndex = 2

            Dim tipoAtend As New Dictionary(Of String, String) From {
               {"01", "ELETIVO"},
               {"02", "URGENCIA"},
               {"03", "ACIDENTE NO LOCAL DE TRAB.OU A SERV.EMPR"},
               {"04", "ACIDENTE NO TRAJETO PARA O TRABALHO"},
               {"05", "OUTROS TIPOS DE ACIDENTE DE TRANSITO"},
               {"06", "OUTROS TIPOS DE LESOES/ENV.POR AGENT.Q/F"}
           }

            txtTipoAtend.DataSource = New BindingSource(tipoAtend, Nothing)
            txtTipoAtend.DisplayMember = "Value"   ' O que aparece para o usuário
            txtTipoAtend.ValueMember = "Key"
            txtTipoAtend.SelectedIndex = 0

            Dim motivo As New Dictionary(Of String, String) From {
                {"11", "ALTA CURADO"},
                {"12", "ALTA MELHORADO"},
                {"14", "ALTA A PEDIDO"},
                {"15", "ALTA COM PREVISAO DE RETORNO P/ACOMP.PAC"},
                {"16", "ALTA POR EVASAO"},
                {"18", "ALTA POR OUTROS MOTIVOS"}
            }

            txtMotivoSaida.DataSource = New BindingSource(motivo, Nothing)
            txtMotivoSaida.DisplayMember = "Value"   ' O que aparece para o usuário
            txtMotivoSaida.ValueMember = "Key"
            txtMotivoSaida.SelectedIndex = 1

            'FormAMEmain.loadComboBox("SELECT id, nome FROM pacientes WHERE id > 1 ORDER BY nome", txtNomePaciente, "nome", "id")
            'txtNomePaciente.Text = ""

        Catch ex As Exception
            FormAMEOCIControleCompetencia.ShowDialog()
        End Try

    End Sub

    Private Function chkMonthEXT()

        Select Case My.Settings.OCIcompetencia.Substring(4, 2)
            Case "01"
                Return ".JAN"
            Case "02"
                Return ".FEV"
            Case "03"
                Return ".MAR"
            Case "04"
                Return ".ABR"
            Case "05"
                Return ".MAI"
            Case "06"
                Return ".JUN"
            Case "07"
                Return ".JUL"
            Case "08"
                Return ".AGO"
            Case "09"
                Return ".SET"
            Case "10"
                Return ".OUT"
            Case "11"
                Return ".NOV"
            Case "12"
                Return ".DEZ"
            Case Else
                Return ""
        End Select

    End Function

    Private Sub btAddAPAC_Click(sender As Object, e As EventArgs) Handles btAddAPAC.Click
        ' Caminho padrão
        Dim pastaDestino As String = "C:\APAC\IMPORTA"
        If Not Directory.Exists(pastaDestino) Then
            Directory.CreateDirectory(pastaDestino)
        End If

        Dim fileAPAC As String

        'If txtCompetencia.Text.Contains("/") Then
        '    Dim partes() As String = txtCompetencia.Text.Split("/")
        '    fileAPAC = "AP" & partes(1) & partes(0).PadLeft(2, "0"c) & chkMonthEXT()
        'Else
        fileAPAC = "AP" & My.Settings.OCIcompetencia & chkMonthEXT()
        'End If

        Dim filePath As String = Path.Combine(pastaDestino, fileAPAC)

        ' Verifica se o arquivo existe
        If Not File.Exists(filePath) Then
            MessageBox.Show("Nenhuma APAC foi adicionada ainda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Pergunta onde salvar a cópia/exportação
        Dim saveDialog As New SaveFileDialog()
        saveDialog.Title = "Exportar arquivo APAC"
        saveDialog.Filter = $"Arquivos APAC (*{chkMonthEXT()})|*{chkMonthEXT()}|Todos os arquivos (*{chkMonthEXT()})|*{chkMonthEXT()}"
        saveDialog.FileName = fileAPAC

        If saveDialog.ShowDialog() = DialogResult.OK Then
            'File.Copy(filePath, saveDialog.FileName, True)
            If File.Exists(filePath) Then
                File.Move(filePath, saveDialog.FileName)
                MessageBox.Show($"Arquivo exportado com sucesso!{vbCrLf}{saveDialog.FileName}", "Exportação concluída", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub ControleDeCompetênciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControleDeCompetênciaToolStripMenuItem.Click
        FormAMEOCIControleCompetencia.ShowDialog()

    End Sub
    Private Sub NúmerosAPACToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NúmerosAPACToolStripMenuItem.Click
        FormAMEOCINumAPAC.ShowDialog()
    End Sub
    Private Sub cep(param As String)
        Try

            Dim CEP As New CEP()
            Dim resultado As DataTable = CEP.getAddress(param)

            If resultado IsNot Nothing Then

                Dim tipo = resultado.Rows(0).Item(2).ToString
                Dim logra = resultado.Rows(0).Item(3).ToString
                Dim bairro = resultado.Rows(0).Item(4).ToString


                Dim foundItem = CType(cbTipoLogradouro.DataSource, BindingSource) _
                .Cast(Of KeyValuePair(Of String, String))() _
                .FirstOrDefault(Function(x) x.Value.Equals(tipo, StringComparison.OrdinalIgnoreCase))

                If foundItem.Key IsNot Nothing Then
                    cbTipoLogradouro.SelectedValue = foundItem.Key
                End If

                txtLogradouro.Text = logra
                txtBairro.Text = bairro
            Else
                MsgBox("CEP não encontrado ou erro na consulta.")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCep_Leave(sender As Object, e As EventArgs) Handles txtCep.Leave
        cep(txtCep.Text.Trim())
        dgvSugestoes.Visible = False
    End Sub
    Private Sub txtCep_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCep.KeyDown
        If e.KeyCode = Keys.Enter Then
            cep(txtCep.Text.Trim())
            dgvSugestoes.Visible = False
        End If
    End Sub
    Private Sub formatGrid()
        dgvSugestoes.Width = 650
        dgvSugestoes.Height = 150
        dgvSugestoes.BringToFront()
        dgvSugestoes.Visible = True
        dgvSugestoes.Location = New Point(24, 235)

        ' Oculta o ID (se existir)
        If dgvSugestoes.Columns.Contains("id") Then
            dgvSugestoes.Columns("id").Visible = False
        End If

        ' Ajusta os headers
        If dgvSugestoes.Columns.Contains("cep") Then dgvSugestoes.Columns("cep").HeaderText = "CEP"
        If dgvSugestoes.Columns.Contains("tipo") Then dgvSugestoes.Columns("tipo").HeaderText = "Tipo"
        If dgvSugestoes.Columns.Contains("logradouro") Then dgvSugestoes.Columns("logradouro").HeaderText = "Logradouro"
        If dgvSugestoes.Columns.Contains("bairro") Then dgvSugestoes.Columns("bairro").HeaderText = "Bairro"

        ' Ajusta larguras
        If dgvSugestoes.Columns.Contains("cep") Then dgvSugestoes.Columns("cep").Width = 80
        If dgvSugestoes.Columns.Contains("tipo") Then dgvSugestoes.Columns("tipo").Width = 70
        If dgvSugestoes.Columns.Contains("logradouro") Then dgvSugestoes.Columns("logradouro").Width = 300
        If dgvSugestoes.Columns.Contains("bairro") Then dgvSugestoes.Columns("bairro").Width = 200

        ' Aparência geral
        dgvSugestoes.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgvSugestoes.DefaultCellStyle.Font = New Font("Segoe UI", 9)
        dgvSugestoes.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue
        dgvSugestoes.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvSugestoes.RowHeadersVisible = False
        dgvSugestoes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        dgvSugestoes.AllowUserToResizeRows = False
        dgvSugestoes.AllowUserToResizeColumns = False
    End Sub

    Private Sub txtLogradouro_TextChanged(sender As Object, e As EventArgs) Handles txtLogradouro.TextChanged
        Try
            Dim texto = txtLogradouro.Text.Trim()
            If texto.Length < 3 Then
                dgvSugestoes.Visible = False
                Exit Sub
            End If

            ' Busca no banco (usa sua função existente)
            Dim cepObj As New CEP()
            Dim resultado As DataTable = cepObj.getAddress("", texto, "")

            If resultado Is Nothing OrElse resultado.Rows.Count = 0 Then
                dgvSugestoes.Visible = False
                Exit Sub
            End If

            ' Configura grid
            dgvSugestoes.DataSource = resultado
            formatGrid()

        Catch ex As Exception
            Debug.WriteLine("Erro ao carregar sugestões: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvSugestoes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSugestoes.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Dim linha As DataGridViewRow = dgvSugestoes.Rows(e.RowIndex)

        Dim tipo = linha.Cells("tipo").Value.ToString()
        Dim logra = linha.Cells("logradouro").Value.ToString()
        Dim bairro = linha.Cells("bairro").Value.ToString()
        Dim cep = linha.Cells("cep").Value.ToString()

        ' Preenche os campos
        txtCep.Text = cep
        txtLogradouro.Text = logra
        txtBairro.Text = bairro

        ' Seleciona tipo no ComboBox
        Dim foundItem = CType(cbTipoLogradouro.DataSource, BindingSource) _
            .Cast(Of KeyValuePair(Of String, String))() _
            .FirstOrDefault(Function(x) x.Value.Equals(tipo, StringComparison.OrdinalIgnoreCase))

        If foundItem.Key IsNot Nothing Then
            cbTipoLogradouro.SelectedValue = foundItem.Key
        End If

        dgvSugestoes.Visible = False
        txtNumero.Focus()

    End Sub
    Private Sub txtLogradouro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLogradouro.KeyDown
        If e.KeyCode = Keys.Escape Then dgvSugestoes.Visible = False
    End Sub
    Private Sub txtBairro_TextChanged(sender As Object, e As EventArgs) Handles txtBairro.TextChanged
        Try
            Dim texto = txtBairro.Text.Trim()
            If texto.Length < 1 Then
                dgvSugestoes.Visible = False
                Exit Sub
            End If

            ' Busca no banco (usa sua função existente)
            Dim cepObj As New CEP()
            Dim resultado As DataTable = cepObj.getAddress("", "", texto)

            If resultado Is Nothing OrElse resultado.Rows.Count = 0 Then
                dgvSugestoes.Visible = False
                Exit Sub
            End If

            ' Configura grid
            dgvSugestoes.DataSource = resultado
            formatGrid()

        Catch ex As Exception
            Debug.WriteLine("Erro ao carregar sugestões: " & ex.Message)
        End Try
    End Sub
    Private Sub txtBairro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBairro.KeyDown
        If e.KeyCode = Keys.Escape Then dgvSugestoes.Visible = False
    End Sub

    Private Sub txtCep_TextChanged(sender As Object, e As EventArgs) Handles txtCep.TextChanged
        If txtCep.Text.Length = 9 Then
            cep(txtCep.Text.Trim())
            dgvSugestoes.Visible = False
        End If
    End Sub

    Private Sub txtNomePaciente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtNomePaciente.SelectedIndexChanged
        'Try
        '    result = getPacientes(Nothing, Nothing, Nothing, txtNomePaciente.SelectedValue)
        '    resultPacientes(result)
        'Catch ex As Exception

        'End Try

    End Sub

    ' nível de classe:
    Private _upperLock As Boolean = False

    Private Sub cbo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomePaciente.KeyPress
        ' já sobe letras na digitação (evita mexer em Text)
        If Char.IsLetter(e.KeyChar) Then e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub cbo_TextChanged(sender As Object, e As EventArgs) Handles txtNomePaciente.TextChanged
        If _upperLock Then Return
        Dim cb = DirectCast(sender, ComboBox)
        Dim txt = cb.Text
        Dim upper = txt.ToUpper()

        If txt <> upper Then
            _upperLock = True
            Dim pos = cb.SelectionStart
            cb.Text = upper
            ' protege o cursor mesmo se o texto encurtar
            cb.SelectionStart = Math.Min(pos, cb.Text.Length)
            _upperLock = False
        End If

        If txtNomePaciente.Text.Length >= 5 Then
            Try
                Dim textoAtual As String = txtNomePaciente.Text  ' salva o que o usuário digitou
                Dim posicaoCursor As Integer = txtNomePaciente.SelectionStart

                ' Carrega dados do banco
                Dim query As String = $"SELECT id, nome FROM pacientes WHERE id > 1 AND nome LIKE '%{textoAtual.Replace("'", "''")}%' ORDER BY nome"
                FormAMEmain.loadComboBox(query, txtNomePaciente, "nome", "id")

                ' Restaura o texto digitado
                txtNomePaciente.Text = textoAtual
                txtNomePaciente.SelectionStart = posicaoCursor
                txtNomePaciente.DroppedDown = True  ' força abrir o dropdown
                txtNomePaciente.DroppedDown = True  ' (duas vezes ajuda a forçar atualização visual)
                txtNomePaciente.IntegralHeight = False
                txtNomePaciente.MaxDropDownItems = 10
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub resultPacientes(result As DataTable)
        Try

            If result.Rows.Count > 0 Then
                ' txtNomePaciente.Text = result.Rows(0).Item("nome").ToString
                If result.Rows(0).Item("id_logradouro") <> 0 Then
                    txtCep.Text = result.Rows(0).Item("cep").ToString
                    txtNumero.Text = result.Rows(0).Item("numero").ToString
                    txtComplemento.Text = result.Rows(0).Item("complemento").ToString
                Else
                    txtCep.Text = ""
                    txtNumero.Text = ""
                    txtComplemento.Text = ""
                    txtLogradouro.Text = ""
                    txtBairro.Text = ""
                End If

                txtNomePaciente.Text = result.Rows(0).Item("nome").ToString
                txtCpfPaciente.Text = result.Rows(0).Item("cpf").ToString
                dtNascimento.Text = result.Rows(0).Item("dtnasc").ToString
                txtNomeMae.Text = result.Rows(0).Item("mae").ToString
                chkResponsavel()

                If result.Rows(0).Item("tel").ToString.Length >= 13 Then
                    Dim ddd = result.Rows(0).Item("tel").ToString.Substring(1, 2)
                    txtDDD.Text = ddd
                    Dim tel = result.Rows(0).Item("tel").ToString.Substring(4, 10)
                    txtTelefone.Text = tel.Replace("-", "")
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub chkResponsavel()
        Try
            If m.CalcularIdade(CDate(dtNascimento.Text)) >= 18 Then
                txtNomeRespPaciente.Text = txtNomePaciente.Text.ToString
            Else
                txtNomeRespPaciente.Text = ""
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtValidadeIni_Leave(sender As Object, e As EventArgs) Handles dtValidadeIni.Leave
        dtValidadeFim.Value = dtValidadeIni.Value.AddMonths(1)
        dtAltaObito.Value = dtValidadeIni.Value
        dtEmissao.Value = dtValidadeIni.Value
        dtAutorizacao.Value = dtValidadeIni.Value
    End Sub
    Private Sub txtNomePaciente_Leave(sender As Object, e As EventArgs) Handles txtNomePaciente.Leave
        chkResponsavel()
    End Sub

    Private Sub txtCpfPaciente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCpfPaciente.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If m.ValidarCPF(txtCpfPaciente.Text) Then
                    Dim result As DataTable = getPacientes(txtCpfPaciente.Text.Trim())
                    resultPacientes(result)
                Else
                    MsgBox("CPF invalido!")
                End If

            Catch ex As Exception
                MsgBox("CPF invalido!")
            End Try
        End If
    End Sub

    Private Sub txtCNSMedicoExecutante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtCNSMedicoExecutante.SelectedIndexChanged
        Try
            txtNomeMedicoSolicitante.SelectedIndex = txtCNSMedicoExecutante.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FormAMEOCI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormSystemStart.Visible = True
    End Sub

End Class