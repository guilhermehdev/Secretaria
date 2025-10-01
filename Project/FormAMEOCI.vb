Imports System.IO
Imports System.Security.Principal
Imports System.Text

Public Class FormAMEOCI
    Private Sub btnGerarArquivo_Click(sender As Object, e As EventArgs) Handles btnGerarArquivo.Click
        Try
            Dim codigos As New List(Of String)
            Dim quantidades As New List(Of Integer)
            Dim linhas As New List(Of String)
            Dim dataGeracao As String = Date.Now.ToString("yyyyMMdd")
            Dim dataProcessamento As String = Date.Now.ToString("yyyyMMdd")
            Dim versao As String = "1.0".PadRight(15, " "c) ' Versão deve ter 15 caracteres

            For Each row As DataGridViewRow In dgvProcedimentos.Rows
                If Not row.IsNewRow Then
                    codigos.Add(row.Cells("Codigo").Value.ToString())
                    quantidades.Add(Convert.ToInt32(row.Cells("Quantidade").Value))
                End If
            Next

            Dim campoControle As String = CalcularCampoControle(txtNumApac.Text, codigos, quantidades)
            Dim competenciaFormatada As String = ""
            If txtCompetencia.Text.Contains("/") Then
                Dim partes() As String = txtCompetencia.Text.Split("/")
                competenciaFormatada = partes(1) & partes(0).PadLeft(2, "0"c)
            Else
                competenciaFormatada = txtCompetencia.Text
            End If

            ' ================= HEADER (Registro 01) =================
            Dim header As New StringBuilder()
            header.Append("01#")                                   ' Indicador Header (2)
            header.Append("APAC")               ' Texto fixo APAC (5)
            header.Append(competenciaFormatada)   ' Competência AAAAMM (6)
            header.Append(GetNextLoteNumber().PadLeft(6, "0"c))   ' Quantidade APACs gravadas (6)
            header.Append(campoControle.PadLeft(4, "0"c))         ' Campo controle (4)
            header.Append(Fmt(txtOrgaoOrigem.Text, 30))           ' Nome órgão origem (30)
            header.Append(Fmt(txtSiglaOrgao.Text, 6))             ' Sigla órgão origem (6)
            header.Append(txtCGC.Text.Replace(".", "").Replace("/", "").Replace("-", "").PadLeft(14, "0"c))
            header.Append(Fmt(txtOrgaoDestino.Text, 40))          ' Nome órgão destino (40)
            header.Append(txtDestinoTipo.Text.PadRight(1, " "c))  ' Destino M/E (1)
            header.Append(dataGeracao)   ' Campo data geração com 8 caracteres AAAAMMDD
            header.Append("Versao 03.16".PadRight(15, " "c))      ' Campo versão com 15 caracteres, 
            linhas.Add(header.ToString())

            ' ================= CORPO PRINCIPAL (Registro 14) =================
            Dim r14 As New StringBuilder()
            r14.Append("14")                                    ' Identificador corpo APAC (2)
            r14.Append(competenciaFormatada)    ' Competência AAAAMM (6)
            r14.Append(txtNumApac.Text.PadLeft(13, "0"c))       ' Nº da APAC (13)
            r14.Append(txtUf.SelectedValue.PadLeft(2, "0"c))
            r14.Append(txtCnesSolicitante.Text.PadLeft(7, "0"c))  ' CNES Solicitante (7)' Código UF IBGE (2)
            ' corpo.Append(txtCnesExecutante.Text.PadLeft(7, "0"c))    ' CNES Unidade Prestadora (7)
            r14.Append(dtAutorizacao.Value.ToString("yyyyMMdd")) ' Data processamento (8)
            r14.Append(dtEmissao.Value.ToString("yyyyMMdd"))
            ' r14.Append(dtValidadeIni.Value.ToString("yyyyMMdd"))   ' Data inicial validade (8)
            r14.Append(dtValidadeFim.Value.ToString("yyyyMMdd"))   ' Data final validade (8)
            ' corpo.Append(txtTipoAtend.SelectedValue.PadLeft(2, "0"c))      ' Tipo de atendimento (2)
            r14.Append(txtTipoApac.SelectedValue.PadLeft(1, "0"c))       ' Tipo de APAC (1)
            r14.Append("1") ' sequência
            r14.Append(Fmt(txtNomePaciente.Text, 30))           ' Nome paciente (30)
            r14.Append(Fmt(txtNomeMae.Text, 30))                ' Nome mãe paciente (30)
            r14.Append(Fmt(txtLogradouro.Text, 30))             ' Logradouro (30)
            r14.Append(txtNumero.Text.PadLeft(5, "0"c))
            r14.Append(Fmt(txtComplemento.Text, 10))
            r14.Append(txtCep.Text.PadLeft(8, "0"c))            ' CEP (8)
            r14.Append(txtMunIbge.Text.PadLeft(7, "0"c))        ' Município IBGE (7)
            r14.Append(dtNascimento.Value.ToString("yyyyMMdd"))  ' Data Nascimento (8)
            r14.Append(txtSexo.Text.PadRight(1, " "c))
            r14.Append(Fmt(txtNomeMedicoSolicitante.Text, 30))             ' Nome médico responsável (30)
            r14.Append(txtCodProcedimento.Text.PadLeft(10, "0"c)) ' Procedimento principal (10)
            r14.Append(txtMotivoSaida.SelectedValue.PadLeft(2, "0"c))  ' Motivo saída (2)

            ' Alta/óbito/transf
            If txtMotivoSaida.SelectedValue.ToString() <> "00" Then
                r14.Append(dtAltaObito.Value.ToString("yyyyMMdd"))
            Else
                r14.Append("        ")
            End If

            r14.Append(Fmt(txtNomeDiretor.Text, 30))
            r14.Append(txtCnsPaciente.Text.PadLeft(15, "0"c))   ' CNS paciente (15)
            r14.Append(txtCNSMedicoSolicitante.Text.PadLeft(15, "0"c))
            r14.Append(txtCnsDiretor.Text.PadLeft(15, "0"c))
            r14.Append(txtCPFDiretor.Text.Replace(".", "").Replace("-", "").PadLeft(11, "0"c))
            r14.Append(txtCidPrincipal.Text.PadRight(4, " "c))
            r14.Append(txtTelefone.Text.PadLeft(10, "0"c))
            r14.Append(txtCnesExecutante.Text.PadLeft(7, "0"c))
            r14.Append(dtValidadeIni.Value.ToString("yyyyMMdd"))
            r14.Append(dtValidadeFim.Value.ToString("yyyyMMdd"))
            r14.Append(Fmt(txtGestor.Text, 10))
            r14.Append(txtTipoAtend.SelectedValue.ToString().PadLeft(2, "0"c))
            r14.Append(txtRaca.SelectedValue.ToString().PadLeft(2, "0"c))
            r14.Append(Fmt(txtNomeRespPaciente.Text, 30))
            r14.Append("10")  ' Código nacionalidade (3)
            r14.Append("0000000000")
            r14.Append(Fmt(txtBairro.Text, 30))
            r14.Append(txtUf.SelectedValue.PadRight(2, " "c))
            r14.Append("00000000000")  ' Telefone Responsável
            r14.Append(Fmt(txtEmail.Text, 50))
            r14.Append("000000000000000") ' CNS Responsável
            r14.Append("00000000000")  ' CPF Responsável
            r14.Append("000000000000000") ' CNS Acompanhante
            r14.Append(If(chkSituacaoRua.Checked, "S", "N"))
            linhas.Add(r14.ToString())

            ' ========== REGISTRO 13 (Procedimentos) ==========
            For Each row As DataGridViewRow In dgvProcedimentos.Rows
                If row.IsNewRow Then Continue For

                Dim r13 As New StringBuilder()
                r13.Append("13")
                r13.Append(competenciaFormatada)
                r13.Append(txtNumApac.Text.PadLeft(13, "0"c))
                r13.Append(row.Cells("Codigo").Value.ToString().PadLeft(10, "0"c))
                r13.Append(row.Cells("CBO").Value.ToString().PadLeft(6, "0"c))
                r13.Append(row.Cells("Quantidade").Value.ToString().PadLeft(3, "0"c))
                r13.Append(row.Cells("CIDPrincipal").Value.ToString().PadRight(4, " "c))
                r13.Append(row.Cells("CIDSecundario").Value.ToString().PadRight(4, " "c))
                r13.Append(New String(" "c, 15))
                r13.Append(row.Cells("CNESExecutante").Value.ToString().PadLeft(7, "0"c))
                r13.Append(New String(" "c, 10))
                linhas.Add(r13.ToString())
            Next

            ' Salvar arquivo
            Using sfd As New SaveFileDialog
                sfd.Filter = "Arquivos APAC|*.SET"
                sfd.FileName = "AP" & txtCompetencia.Text & ".SET"
                If sfd.ShowDialog() = DialogResult.OK Then
                    File.WriteAllLines(sfd.FileName, linhas, Encoding.GetEncoding("iso-8859-1"))
                    MessageBox.Show("Arquivo gerado com sucesso!", "APAC", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao gerar arquivo: " & ex.Message)
        End Try
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


    Private Function GetNextLoteNumber() As String
        Dim filePath As String = Path.Combine(Application.StartupPath, "lote.txt")
        Dim lastNumber As Long = 0

        ' Lê último número, se existir
        If File.Exists(filePath) Then
            Dim content = File.ReadAllText(filePath).Trim()
            If IsNumeric(content) Then
                lastNumber = CLng(content)
            End If
        End If

        ' Incrementa
        Dim nextNumber As Long = lastNumber + 1

        ' Salva de volta
        File.WriteAllText(filePath, nextNumber.ToString())

        ' Retorna formatado (13 dígitos, zeros à esquerda)
        Return nextNumber.ToString().PadLeft(13, "0"c)
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


    Private Sub btnAdicionarProcedimento_Click(sender As Object, e As EventArgs) Handles btnAdicionarProcedimento.Click
        Dim cod As String = CodProcedimento.Text.Trim()
        If String.IsNullOrWhiteSpace(cod) Then Exit Sub

        Dim cbo As String = CBOmed.Text.Trim()
        Dim qtd As String = Quantidade.Text.Trim()
        Dim cidPri As String = txtCidPrincipal.Text.Trim()
        Dim cidSec As String = txtCidSecundario.Text.Trim()
        Dim cnsExec As String = txtCNSMedicoExecutante.Text.Trim()


        ' Adiciona a linha com todas as colunas necessárias
        dgvProcedimentos.Rows.Add(cod, cbo, qtd, cidPri, cidSec, cnsExec)
    End Sub
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

    Private Sub FormAMEOCI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvProcedimentos.Columns.Clear()

        dgvProcedimentos.Columns.Add("Codigo", "Código Procedimento")
        dgvProcedimentos.Columns.Add("CBO", "CBO")
        dgvProcedimentos.Columns.Add("Quantidade", "Qtd")
        dgvProcedimentos.Columns.Add("CIDPrincipal", "CID Principal")
        dgvProcedimentos.Columns.Add("CIDSecundario", "CID Secundário")
        dgvProcedimentos.Columns.Add("CNESExecutante", "CNS Exec.")

        dgvProcedimentos.AllowUserToAddRows = True
        dgvProcedimentos.AllowUserToDeleteRows = True
        dgvProcedimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        txtDestinoTipo.SelectedIndex = 0
        txtSexo.SelectedIndex = 0


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
            {"01", "INICIAL"},
            {"02", "CONTINUIDADE"},
            {"03", "UNICA"},
            {"04", "ENCERRAMENTO"}
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

        Dim uf As New Dictionary(Of String, String) From {
            {"35", "SP"}
        }

        txtUf.DataSource = New BindingSource(uf, Nothing)
        txtUf.DisplayMember = "Value"   ' O que aparece para o usuário
        txtUf.ValueMember = "Key"
        txtUf.SelectedIndex = 0

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

End Class