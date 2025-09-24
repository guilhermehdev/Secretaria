Imports System.IO
Imports System.Text

Public Class FormAMEOCI
    Private Sub btnGerarArquivo_Click(sender As Object, e As EventArgs) Handles btnGerarArquivo.Click
        Try
            Dim linhas As New List(Of String)

            ' ================= HEADER (Registro 01) =================
            Dim header As New StringBuilder()
            header.Append("01") ' Código do registro
            header.Append(Fmt("#APAC", 5)) ' Literal fixo
            header.Append(Fmt(txtCompetencia.Text, 6, True)) ' Competência
            header.Append(Fmt("1", 6, True)) ' Quantidade de APACs (ajuste se tiver mais de uma)

            ' monta lista de códigos e quantidades para o campo de controle
            Dim procCodes As New List(Of String)
            Dim procQuantities As New List(Of Integer)
            For Each row As DataGridViewRow In dgvProcedimentos.Rows
                If row.IsNewRow Then Continue For
                procCodes.Add(row.Cells("Codigo").Value.ToString())
                procQuantities.Add(CInt(row.Cells("Quantidade").Value))
            Next

            Dim campoControle = ComputeControlField("0000000000001", procCodes, procQuantities)
            header.Append(Fmt(campoControle, 4, True))

            header.Append(Fmt(txtOrgaoOrigem.Text, 30))
            header.Append(Fmt(txtSiglaOrigem.Text, 6))
            header.Append(Fmt(txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", ""), 14, True))
            header.Append(Fmt("DATASUS", 40))
            header.Append("M")
            header.Append(Date.Now.ToString("yyyyMMdd"))
            header.Append(Fmt("VBAPP01", 15))
            linhas.Add(header.ToString())

            ' ================= PACIENTE / REGISTRO 14 =================
            Dim reg14 As New StringBuilder()
            reg14.Append("14")
            reg14.Append(Fmt(txtCompetencia.Text, 6, True))
            reg14.Append(txtNumApac.Text) ' número da APAC (ajustar se for mais de uma)
            If String.IsNullOrWhiteSpace(txtApacAnterior.Text) Then
                reg14.Append("0000000000000") ' primeira APAC
            Else
                reg14.Append(Fmt(txtApacAnterior.Text, 13, True))
            End If
            reg14.Append(Fmt(txtIdade.Text, 2, True))
            reg14.Append(Fmt(txtCNESSolicitante.Text, 7, True))
            reg14.Append(Date.Now.ToString("yyyyMMdd")) ' Data autorização
            reg14.Append(Date.Now.ToString("yyyyMMdd")) ' Data emissão
            reg14.Append(Date.Now.AddMonths(1).ToString("yyyyMMdd")) ' Data validade
            reg14.Append(Fmt("01", 2, True)) ' Tipo APAC
            reg14.Append(Fmt("1", 1, True)) ' Sequência
            reg14.Append(Fmt(txtNomePaciente.Text, 30))
            reg14.Append(Fmt(txtNomeMae.Text, 30))
            reg14.Append(Fmt(txtEndereco.Text, 30))
            reg14.Append(Fmt(txtNumero.Text, 5, True))
            reg14.Append(Fmt(txtComplemento.Text, 10))
            reg14.Append(Fmt(txtCep.Text, 8, True))
            reg14.Append(Fmt(txtMunicipioCod.Text, 7, True))
            reg14.Append(Fmt(dtNascimento.Text.Replace("/", ""), 8, True))
            reg14.Append(Fmt(cboSexo.Text, 1))
            reg14.Append(Fmt(txtNomeMedicoSolicitante.Text, 30))
            reg14.Append(Fmt(txtProcedimentoPrincipal.Text, 10, True))
            reg14.Append(Fmt(cboMotivoSaida.SelectedValue.ToString(), 2, True))

            ' Data de Alta/Óbito/Transferência
            If cboMotivoSaida.SelectedValue.ToString() <> "00" Then
                reg14.Append(dtAltaObito.Value.ToString("yyyyMMdd"))
            Else
                reg14.Append("        ")
            End If

            reg14.Append(Fmt(txtNomeDiretor.Text, 30))
            reg14.Append(Fmt(txtCnsPaciente.Text, 15, True))
            reg14.Append(Fmt(txtCnsMedicoSolicitante.Text, 15, True))
            reg14.Append(Fmt(txtCnsDiretor.Text, 15, True))
            reg14.Append(Fmt(txtCidPrincipal.Text, 4))
            reg14.Append(Fmt(txtTelefone.Text, 10, True))
            reg14.Append(Fmt(txtCnesExecutante.Text, 7, True))
            reg14.Append(dtValidadeIni.Value.ToString("yyyyMMdd")) ' Data início tratamento
            reg14.Append(dtValidadeFim.Value.ToString("yyyyMMdd")) ' Data fim tratamento
            reg14.Append(Fmt(txtCodOrgaoEmissor.Text, 10))
            reg14.Append(Fmt("010", 2, True)) ' Nacionalidade (010 = Brasil)
            reg14.Append(Fmt(txtCpfPaciente.Text, 11, True))
            reg14.Append(Fmt("0000000000", 10))
            reg14.Append(Fmt(txtBairro.Text, 30))
            reg14.Append(Fmt(txtUF.Text, 2))
            reg14.Append(Fmt("00000000000", 11, True))
            reg14.Append(Fmt(txtEmail.Text, 50))
            reg14.Append(Fmt("000000000000000", 15, True))
            reg14.Append(Fmt("00000000000", 11, True))
            reg14.Append(Fmt(txtCidSecundario.Text, 10))
            reg14.Append(If(chkSituacaoRua.Checked, "S", "N"))
            linhas.Add(reg14.ToString())

            ' ================= PROCEDIMENTOS / REGISTRO 13 =================
            For Each row As DataGridViewRow In dgvProcedimentos.Rows
                If row.IsNewRow Then Continue For

                Dim reg13 As New StringBuilder()
                reg13.Append("13")
                reg13.Append(Fmt(txtCompetencia.Text, 6, True))
                reg13.Append("0000000000001") ' número da APAC
                reg13.Append(Fmt(row.Cells("Codigo").Value.ToString(), 10, True))
                reg13.Append(Fmt(row.Cells("CBO").Value.ToString(), 6, True))
                reg13.Append(Fmt(row.Cells("Quantidade").Value.ToString(), 3, True))
                reg13.Append(Fmt(row.Cells("CIDPrincipal").Value.ToString(), 4))
                reg13.Append(Fmt(row.Cells("CIDSecundario").Value.ToString(), 4))
                reg13.Append(Fmt(row.Cells("Autorizacao").Value.ToString(), 15, True))
                reg13.Append(Fmt(row.Cells("CNESExecutante").Value.ToString(), 7, True))
                reg13.Append(Fmt(row.Cells("NotaFiscal").Value.ToString(), 10))
                linhas.Add(reg13.ToString())
            Next

            ' ================= SALVAR ARQUIVO =================
            Using sfd As New SaveFileDialog
                sfd.Filter = "Arquivos APAC|*.SET"
                sfd.FileName = "APAC_" & txtCompetencia.Text & ".SET"
                If sfd.ShowDialog() = DialogResult.OK Then
                    File.WriteAllLines(sfd.FileName, linhas, Encoding.GetEncoding("iso-8859-1"))
                    MessageBox.Show("Arquivo gerado com sucesso!", "APAC", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Erro ao gerar arquivo: " & ex.Message)
        End Try
    End Sub

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
        Dim cod As String = CodProcedimento.Text
        If String.IsNullOrWhiteSpace(cod) Then Exit Sub

        Dim cbo As String = CBOmed.Text
        Dim desc As String = Descricao.Text
        Dim qtd As String = Quantidade.Text
        Dim cidPri As String = CidPrincipal.Text
        Dim cidSec As String = CidSecundario.Text
        Dim cnsExec As String = CnsExecutante.Text

        ' Adiciona nova linha no grid
        dgvProcedimentos.Rows.Add(cod, desc, cbo, qtd, cidPri, cidSec, "", "", "")
    End Sub


    Private Function Fmt(valor As String, tamanho As Integer, Optional padLeft As Boolean = False) As String
        If valor Is Nothing Then valor = ""
        valor = valor.Trim()
        If padLeft Then
            Return valor.PadLeft(tamanho, "0"c).Substring(0, tamanho)
        Else
            Return valor.PadRight(tamanho, " "c).Substring(0, tamanho)
        End If
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
        dgvProcedimentos.Columns.Add("Descricao", "Descrição")
        dgvProcedimentos.Columns.Add("Quantidade", "Qtd")
        dgvProcedimentos.Columns.Add("CIDPrincipal", "CID Principal")
        dgvProcedimentos.Columns.Add("CIDSecundario", "CID Secundário")
        dgvProcedimentos.Columns.Add("CNESExecutante", "CNES Exec.")

        dgvProcedimentos.AllowUserToAddRows = True
        dgvProcedimentos.AllowUserToDeleteRows = True
        dgvProcedimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub
End Class