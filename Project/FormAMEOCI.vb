Imports System.IO
Imports System.Security.Principal
Imports System.Text

Public Class FormAMEOCI
    Private linhas As New List(Of String)
    Private Sub btnGerarArquivo_Click(sender As Object, e As EventArgs) Handles btnGerarArquivo.Click
        Try
            Dim codigos As New List(Of String)
            Dim quantidades As New List(Of Integer)
            'Dim linhas As New List(Of String)
            Dim dataGeracao As String = Date.Now.ToString("yyyyMMdd")
            Dim dataProcessamento As String = Date.Now.ToString("yyyyMMdd")
            Dim versao As String = "1.0".PadRight(15, " "c) ' Versão deve ter 15 caracteres

            For Each row As DataGridViewRow In dgvProcedimentos.Rows
                If Not row.IsNewRow Then
                    codigos.Add(row.Cells("Codigo").Value.ToString())
                    quantidades.Add(Convert.ToInt32(row.Cells("Quantidade").Value))
                End If
            Next

            ' Dim campoControle As String = CalcularCampoControle(txtNumApac.Text, codigos, quantidades)
            Dim competenciaFormatada As String = My.Settings.OCIcompetencia

            ' Caminho fixo do arquivo principal
            Dim filePath As String = Path.Combine("C:\APAC\IMPORTA", "AP" & competenciaFormatada & ".SET")

            ' Se o arquivo ainda não existir, cria com o header
            If Not File.Exists(filePath) OrElse New FileInfo(filePath).Length = 0 Then
                ' ================= HEADER (Registro 01) =================
                Dim header As New StringBuilder()
                header.Append("01#APAC")                                     ' Identificação
                header.Append(competenciaFormatada)                          ' Competência (AAAAMM)

                Dim qtdApacs As Integer = 1 ' se for 1 APAC, ajuste se for mais
                header.Append(qtdApacs.ToString().PadLeft(6, "0"c))          ' Quantidade de APACs (6)

                Dim campoControle As String = CalcularCampoControle(txtNumApac.Text, codigos, quantidades)
                header.Append(campoControle.PadLeft(4, "0"c))

                header.Append(Fmt(My.Settings.OCInomeUnidade, 30))                  ' Nome órgão origem (30)
                header.Append(Fmt(My.Settings.OCIsigla, 6))                    ' Sigla (6)
                header.Append(My.Settings.OCIcnpj.Replace(".", "").Replace("/", "").Replace("-", "").PadLeft(14, "0"c)) ' 
                header.Append(Fmt(My.Settings.OCIorgaoDestino, 40))                 ' Nome órgão destino (40)
                header.Append(My.Settings.OCItipo.PadRight(1, " "c))         ' Tipo órgão destino M/E' Campo controle (4)

                'header.Append(Fmt(txtOrgaoOrigem.Text, 30))                  ' Nome órgão origem (30)
                'header.Append(Fmt(txtSiglaOrgao.Text, 6))                    ' Sigla (6)
                'header.Append(txtCGC.Text.Replace(".", "").Replace("/", "").Replace("-", "").PadLeft(14, "0"c)) ' CNPJ
                'header.Append(Fmt(txtOrgaoDestino.Text, 40))                 ' Nome órgão destino (40)
                'header.Append(txtDestinoTipo.Text.PadRight(1, " "c))         ' Tipo órgão destino M/E

                ' Aqui precisa usar a DATA DA COMPETÊNCIA, não a data de hoje
                Dim dataCompetencia As String = competenciaFormatada & "20"  ' AAAAMM + "20" (ajuste pro dia correto do mês)
                header.Append(dataCompetencia)

                header.Append("Versao 03.16".PadRight(15, " "c))             ' Versão
                'linhas.Add(header.ToString())
                File.AppendAllText(filePath, header.ToString() & Chr(13) & Chr(10), Encoding.GetEncoding("iso-8859-1"))

            End If

            Dim r14 As New StringBuilder()

            ' 01. Tipo registro
            r14.Append("14")                                  ' 2

            ' 02. Competência
            r14.Append(competenciaFormatada)                  ' 6 (AAAAMM)

            ' 03. Nº da APAC
            r14.Append(txtNumApac.Text.PadLeft(13, "0"c))     ' 13

            ' 05. UF
            r14.Append(My.Settings.OCIuf.PadRight(2, " "c))

            ' 06. CNES Solicitante
            r14.Append(txtCnesExecutante.Text.PadLeft(7, "0"c)) ' 7

            ' 08. Data autorização
            r14.Append(Date.Now.ToString("yyyyMMdd")) ' 8

            ' 09. Data emissão
            r14.Append(dtValidadeIni.Value.ToString("yyyyMMdd"))     ' 8

            ' 10. Data validade
            r14.Append(dtValidadeFim.Value.ToString("yyyyMMdd")) ' 8

            r14.Append("00")      ' Tipo de atendimento (2)

            ' 11. Tipo APAC
            r14.Append(txtTipoApac.SelectedValue.ToString())

            ' 13. Nome paciente
            r14.Append(Fmt(txtNomePaciente.Text, 30))           ' 30

            ' 14. Nome mãe
            r14.Append(Fmt(txtNomeMae.Text, 30))                ' 30

            ' 15. Logradouro
            r14.Append(Fmt(txtLogradouro.Text, 30))             ' 30

            ' 16. Número residência
            r14.Append(txtNumero.Text.PadRight(5, " "c))          ' 5

            ' 17. Complemento
            If txtComplemento.Text.Length > 0 Then
                r14.Append(txtComplemento.Text.PadRight(10, " "c))
            Else
                r14.Append("          ")
            End If

            ' 18. CEP
            r14.Append(txtCep.Text.PadRight(8, " "c))            ' 8

            ' 19. Município IBGE
            r14.Append(txtMunIbge.Text.PadLeft(7, "0"c))        ' 7

            ' 20. Data nascimento
            r14.Append(dtNascimento.Value.ToString("yyyyMMdd")) ' 8

            ' 21. Sexo
            r14.Append(txtSexo.Text.PadRight(1, " "c))          ' 1

            ' 22. Nome médico solicitante
            r14.Append(Fmt(txtNomeMedicoSolicitante.Text, 30))             ' 30

            ' 23. Procedimento principal
            r14.Append(txtProcedimentoPrincipal.SelectedValue.PadLeft(10, "0"c)) ' 10

            ' 24. Motivo saída
            r14.Append(txtMotivoSaida.SelectedValue.ToString().PadLeft(2, "0"c)) ' 2

            ' 25. Data alta/óbito/transf
            If txtMotivoSaida.SelectedValue.ToString() <> "00" Then
                r14.Append(dtAltaObito.Value.ToString("yyyyMMdd"))
            Else
                r14.Append("        ")
            End If                                              ' 8

            ' 26. Nome MEDICO AUTORIZADOR
            r14.Append(Fmt(txtNomeAutorizador.Text, 30))            ' 30

            ' 27. CNS paciente
            If txtCnsPaciente.Text.Length > 0 Then
                r14.Append(txtCnsPaciente.Text.PadLeft(15, "0"c))   ' 15
            Else
                r14.Append("               ")
            End If

            ' 28. CNS médico solicitante
            r14.Append(txtCNSMedicoSolicitante.Text.PadLeft(15, "0"c)) ' 15

            ' 29. CNS diretor
            r14.Append(txtCnsAutorizador.Text.PadLeft(15, "0"c))    ' 15

            r14.Append("    ")

            If txtProntuario.Text <> "" Then
                r14.Append(txtProntuario.Text.PadRight(10, " "c))
            Else
                r14.Append(Fmt("", 10))
            End If

            r14.Append(txtCnesSolicitante.Text.PadLeft(7, "0"c))

            r14.Append(dtEmissao.Value.ToString("yyyyMMdd"))

            r14.Append(dtAutorizacao.Value.ToString("yyyyMMdd"))

            r14.Append(Fmt(txtGestor.Text, 10))

            r14.Append(txtTipoAtend.SelectedValue.PadLeft(2, "0"c))      ' Tipo de atendimento (2)

            If String.IsNullOrWhiteSpace(txtApacAnterior.Text) Then
                r14.Append("0000000000000")
            Else
                r14.Append(txtApacAnterior.Text.PadLeft(13, "0"c))
            End If

            r14.Append(txtRaca.SelectedValue.ToString().PadLeft(2, "0"c))

            r14.Append(Fmt(txtNomeRespPaciente.Text, 30))

            r14.Append("010")

            If txtRaca.SelectedValue.ToString() = "05" Then
                r14.Append("    ")
            Else
                r14.Append("    ")
            End If

            r14.Append(cbTipoLogradouro.SelectedValue.PadLeft(3, "0"c))

            r14.Append(txtBairro.Text.PadRight(30, " "c))

            r14.Append(txtDDD.Text.PadLeft(2, " "c))

            r14.Append(txtTelefone.Text.PadLeft(9, " "c))

            r14.Append(txtEmail.Text.PadRight(40, " "c))

            r14.Append(txtCNSMedicoExecutante.SelectedValue.PadLeft(15, "0"c))

            r14.Append(txtCpfPaciente.Text.PadLeft(11, "0"c))

            r14.Append(txtEquipe.Text.PadLeft(10, " "c))

            r14.Append(If(chkSituacaoRua.Checked, "S", "N"))

            'linhas.Add(r14.ToString())
            File.AppendAllText(filePath, r14.ToString() & Chr(13) & Chr(10), Encoding.GetEncoding("iso-8859-1"))

            Dim r06 As New StringBuilder()
            r06.Append("06")
            r06.Append(competenciaFormatada)
            r06.Append(txtNumApac.Text.PadLeft(13, "0"c))
            r06.Append(txtCidPrincipal.Text.PadRight(4, " "c))
            If txtCidSecundario.Text.Length > 0 Then
                r06.Append(txtCidSecundario.Text.PadRight(4, " "c))
            End If
            'linhas.Add(r06.ToString())
            File.AppendAllText(filePath, r06.ToString() & Chr(13) & Chr(10), Encoding.GetEncoding("iso-8859-1"))

            ' ========== REGISTRO 13 PRINCIPAL ==========
            Dim r13Principal As New StringBuilder()
            r13Principal.Append("13")
            r13Principal.Append(competenciaFormatada)
            r13Principal.Append(txtNumApac.Text.PadLeft(13, "0"c))
            r13Principal.Append(txtProcedimentoPrincipal.SelectedValue.PadLeft(10, "0"c))
            r13Principal.Append(CBOmed.SelectedValue.PadLeft(6, "0"c))
            r13Principal.Append("0000001") ' quantidade = 1 (7 dígitos)
            r13Principal.Append(New String(" "c, 53))
            'linhas.Add(r13Principal.ToString()) ' NÃO põe vbCrLf aqui

            ' ========== REGISTRO 13 SECUNDÁRIOS ==========
            For i = 0 To dgvProcedimentos.RowCount - 1
                If dgvProcedimentos.Rows(i).IsNewRow Then Continue For

                Dim r13 As New StringBuilder() ' novo builder a cada linha

                r13.Append("13")
                r13.Append(competenciaFormatada)
                r13.Append(txtNumApac.Text.PadLeft(13, "0"c))
                r13.Append(dgvProcedimentos.Rows(i).Cells(0).Value.ToString().PadLeft(10, "0"c)) ' código procedimento
                r13.Append(dgvProcedimentos.Rows(i).Cells(1).Value.ToString().PadLeft(6, "0"c)) ' CBO
                r13.Append(dgvProcedimentos.Rows(i).Cells(2).Value.ToString().PadLeft(7, "0"c)) ' quantidade
                r13.Append(New String(" "c, 53))
                'linhas.Add(r13.ToString())
                File.AppendAllText(filePath, r13.ToString() & Chr(13) & Chr(10), Encoding.GetEncoding("iso-8859-1"))
            Next


            ' Grava automaticamente no arquivo .SET
            'File.AppendAllText(filePath, String.Join(vbCrLf, linhas) & vbCrLf, Encoding.GetEncoding("iso-8859-1"))
            MessageBox.Show("APAC adicionada e salva no arquivo com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show("Erro ao gerar arquivo: " & ex.Message)
        End Try

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
        Return valor.PadRight(tamanho, " "c).Substring(0, tamanho)
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

        main.loadComboBox($"SELECT SUS, nome FROM servidores WHERE cbo ='{CBOmed.SelectedValue}'", txtCNSMedicoExecutante, "nome", "SUS", True)

    End Sub

    Private Sub FormAMEOCI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            {"08", "AVENIDA"}
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

    End Sub

    ' Gera a lista de números de APAC a partir de um intervalo autorizado
    ' Gera a lista de números de APAC respeitando o número inicial e final fornecidos
    ' Função para gerar números de APAC respeitando faixa autorizada
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim numeros = GerarNumerosAPAC_Padrao("3525704850877", "3525704854860", 400)

        For Each n In numeros
            Debug.WriteLine(n)
        Next
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
            File.Copy(filePath, saveDialog.FileName, True)
            MessageBox.Show("Arquivo exportado com sucesso!" & vbCrLf & saveDialog.FileName, "Exportação concluída", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub ControleDeCompetênciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControleDeCompetênciaToolStripMenuItem.Click
        FormAMEOCIControleCompetencia.ShowDialog()

    End Sub
End Class