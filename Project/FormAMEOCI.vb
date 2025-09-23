Imports System.IO
Imports System.Text

Public Class FormAMEOCI
    Private Sub btnGerarArquivo_Click(sender As Object, e As EventArgs) Handles btnGerarArquivo.Click
        Dim enc As Encoding = Encoding.GetEncoding("iso-8859-1")
        Dim linhas As New List(Of String)

        ' ====================================================
        ' HEADER (01)
        ' ====================================================
        Dim header As String = ""
        header &= "01"
        header &= Fmt(txtCompetencia.Text, 6, True)          ' AAAAMM
        header &= Fmt(txtNumApac.Text, 13, True)             ' Número APAC
        header &= Fmt(txtCNESSolicitante.Text, 7, True)      ' CNES Solicitante
        header &= Fmt(txtCnesExecutante.Text, 7, True)       ' CNES Executante
        header &= Fmt(txtNomeDiretor.Text, 30)               ' Nome Diretor
        header &= Fmt(txtCnsAutorizador.Text, 15, True)      ' CNS Autorizador
        ' ... completar com os outros campos obrigatórios
        linhas.Add(header)

        ' ====================================================
        ' CORPO DA APAC (14) - Paciente
        ' ====================================================
        Dim corpo As String = ""
        corpo &= "14"
        corpo &= Fmt(txtCompetencia.Text, 6, True)
        corpo &= Fmt(txtNumApac.Text, 13, True)
        corpo &= Fmt(txtCpfPaciente.Text.Replace(".", "").Replace("-", ""), 11, True)
        corpo &= Fmt(txtCnsPaciente.Text, 15, True)
        corpo &= Fmt(txtNomePaciente.Text, 30)
        corpo &= Fmt(txtNomeMae.Text, 30)
        corpo &= Fmt(txtEndereco.Text, 30)
        corpo &= Fmt(txtNumero.Text, 5, True)
        corpo &= Fmt(txtComplemento.Text, 10)
        corpo &= Fmt(txtCep.Text, 8, True)
        corpo &= Fmt(txtMunicipioCod.Text, 7, True)
        corpo &= dtNascimento.Value.ToString("yyyyMMdd")
        corpo &= cboSexo.Text
        corpo &= Fmt(cboRaca.SelectedValue.ToString(), 2, True)
        corpo &= Fmt(txtEtnia.Text, 4, True)
        corpo &= Fmt(txtTelefone.Text, 10)
        corpo &= Fmt(txtEmail.Text, 40)

        ' Data de Alta/Óbito/Transferência (8 caracteres)
        If cboMotivoSaida.SelectedValue IsNot Nothing AndAlso cboMotivoSaida.SelectedValue.ToString() <> "00" Then
            corpo &= dtAltaObito.Value.ToString("yyyyMMdd")
        Else
            corpo &= "        " ' 8 espaços
        End If

        ' Caráter do Atendimento (2 dígitos)
        corpo &= Fmt(cboCaraterAtendimento.SelectedValue.ToString(), 2, True)

        ' Médico Responsável
        corpo &= Fmt(txtCnsMedicoSolicitante.Text, 15, True)
        corpo &= Fmt(txtNomeMedicoSolicitante.Text, 30)
        corpo &= dtSolicitacao.Value.ToString("yyyyMMdd")

        ' Autorizador
        corpo &= Fmt(txtCnsAutorizador.Text, 15, True)
        corpo &= Fmt(txtNomeAutorizador.Text, 30)
        corpo &= dtAutorizacao.Value.ToString("yyyyMMdd")
        corpo &= Fmt(txtCodOrgaoEmissor.Text, 2, True)

        linhas.Add(corpo)

        ' ====================================================
        ' PROCEDIMENTO PRINCIPAL (13)
        ' ====================================================
        Dim procPrincipal As String = ""
        procPrincipal &= "13"
        procPrincipal &= Fmt(txtCompetencia.Text, 6, True)
        procPrincipal &= Fmt(txtNumApac.Text, 13, True)
        procPrincipal &= Fmt(txtProcedimentoPrincipal.Text, 10, True)
        procPrincipal &= "225120" ' Exemplo de CBO fixo
        procPrincipal &= "001"    ' Sequência
        procPrincipal &= Fmt(txtCidPrincipal.Text, 4)
        procPrincipal &= Fmt(txtCidSecundario.Text, 4)
        procPrincipal &= Fmt(cboMotivoSaida.SelectedValue.ToString(), 2, True)
        linhas.Add(procPrincipal)

        ' ====================================================
        ' PROCEDIMENTOS SECUNDÁRIOS (13)
        ' ====================================================
        For Each row As DataGridViewRow In gridProcedimentos.Rows
            If row.IsNewRow Then Continue For

            Dim procSec As String = ""
            procSec &= "13"
            procSec &= Fmt(txtCompetencia.Text, 6, True)
            procSec &= Fmt(txtNumApac.Text, 13, True)
            procSec &= Fmt(row.Cells("CodProcedimento").Value.ToString(), 10, True)
            procSec &= Fmt(row.Cells("CBO").Value.ToString(), 6, True)
            procSec &= Fmt(row.Cells("Quantidade").Value.ToString(), 3, True)
            procSec &= Fmt(row.Cells("CidPrincipal").Value.ToString(), 4)
            procSec &= Fmt(row.Cells("CidSecundario").Value.ToString(), 4)
            procSec &= Fmt(row.Cells("CnsExecutante").Value.ToString(), 15, True)
            procSec &= Fmt(row.Cells("CnesTerceiro").Value.ToString(), 7, True)
            procSec &= Fmt(row.Cells("NotaFiscal").Value.ToString(), 10)
            linhas.Add(procSec)
        Next

        ' ====================================================
        ' GRAVA O ARQUIVO
        ' ====================================================
        Using sfd As New SaveFileDialog
            sfd.Filter = "Arquivos APAC|*.SET"
            sfd.FileName = "APAC_TESTE.SET"
            If sfd.ShowDialog() = DialogResult.OK Then
                File.WriteAllLines(sfd.FileName, linhas, enc)
                MessageBox.Show("Arquivo gerado em: " & sfd.FileName)
            End If
        End Using

    End Sub

    Private Sub btnAdicionarProcedimento_Click(sender As Object, e As EventArgs) Handles btnAdicionarProcedimento.Click
        Dim cod As String = CodProcedimento.Text
        If String.IsNullOrWhiteSpace(cod) Then Exit Sub

        Dim cbo As String = CBOmed.Text
        Dim desc As String = Descricao.Text
        Dim qtd As String = Quantidade.Text
        Dim cidPri As String = CidPrincipal.Text
        Dim cidSec As String = CidSecundario.Text

        ' Adiciona nova linha no grid
        gridProcedimentos.Rows.Add(cod, desc, cbo, qtd, cidPri, cidSec, "", "", "")
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
        If gridProcedimentos.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In gridProcedimentos.SelectedRows
                If Not row.IsNewRow Then
                    gridProcedimentos.Rows.Remove(row)
                End If
            Next
        Else
            MessageBox.Show("Selecione um procedimento para remover.")
        End If
    End Sub

    Private Sub FormAMEOCI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With gridProcedimentos
            .Columns.Clear()
            .Columns.Add("CodProcedimento", "Código")
            .Columns.Add("Descricao", "Descrição")
            .Columns.Add("CBO", "CBO")
            .Columns.Add("Quantidade", "Qtd")
            .Columns.Add("CidPrincipal", "CID.Principal")
            .Columns.Add("CidSecundario", "CID.Secundário")
        End With
    End Sub
End Class