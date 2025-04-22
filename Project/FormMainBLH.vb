﻿Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Data

Public Class FormMainBLH
    Dim m As New Main
    Dim blh As New BLH
    Dim importXLS As New XLStoSQL

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        importXLS.getXLSProcessamento()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        importXLS.getXLScadastroGeral()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If c1.Text = "" Or t1.Text = "" Or c2.Text = "" Or t2.Text = "" Or c3.Text = "" Or t3.Text = "" Then
            MessageBox.Show("Preencha todos os campos")
            Exit Sub
        End If

        lbGordura.Text = blh.PercentualDeGordura(CDbl(c1.Text), CDbl(t1.Text), CDbl(c2.Text), CDbl(t2.Text), CDbl(c3.Text), CDbl(t3.Text)).ToString

        lbCreme.Text = blh.percentualCreme(CDbl(c1.Text), CDbl(t1.Text), CDbl(c2.Text), CDbl(t2.Text), CDbl(c3.Text), CDbl(t3.Text)).ToString

        lbKal.Text = blh.Kcal(CDbl(c1.Text), CDbl(t1.Text), CDbl(c2.Text), CDbl(t2.Text), CDbl(c3.Text), CDbl(t3.Text)).ToString

    End Sub

    Private Function getProcessamento() As DataTable
        Dim res = m.getDataset("SELECT blh_cadastro.nome AS doadora,blh_processamento.ordenha AS ordenha,blh_processamento.parto AS parto,blh_processamento.percentGordura AS gordura, blh_processamento.calorias AS caloria, blh_processamento.acidez AS acidez, blh_processamento.bgbl AS bgbl, blh_processamento.dataPasteurizacao AS pasteurizacao FROM blh_cadastro JOIN blh_processamento ON blh_processamento.id_cadastro = blh_cadastro.id")

        Return res

    End Function

    'Public Sub GerarPDFComiTextSharp(dataTable As DataTable)
    '    Dim filePath As String = Application.StartupPath & "\PDF\Rotulos.pdf"

    '    ' Criação do documento PDF
    '    Dim documento As New Document(PageSize.A4, 36, 36, 36, 36)
    '    Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(filePath, FileMode.Create))

    '    ' Abre o documento para escrita
    '    documento.Open()

    '    ' Cria uma tabela de duas colunas
    '    Dim tabela As New PdfPTable(2)
    '    tabela.WidthPercentage = 100
    '    tabela.SetWidths(New Single() {50, 50}) ' Define a largura proporcional das colunas

    '    ' Itera sobre as linhas do DataTable
    '    For Each linha As DataRow In dataTable.Rows
    '        ' Prepara os dados como uma célula de tabela
    '        Dim dados As String = $"Doadora: {linha("doadora")}" & vbCrLf &
    '                          $"Data ordenha: {linha("ordenha")}" & vbCrLf &
    '                          $"Data parto: {linha("parto")}" & vbCrLf &
    '                          $"Tipo de leite: C" & vbCrLf &
    '                          $"Vol: 200 ml" & vbCrLf &
    '                          $"Gordura (%): {linha("gordura")}" & vbCrLf &
    '                          $"Kcal: {linha("caloria")}" & vbCrLf &
    '                          $"Acidez (°D): {linha("acidez")}" & vbCrLf &
    '                          $"BGBL: {linha("bgbl")}" & vbCrLf &
    '                          $"Data pasteurização: {linha("pasteurizacao")}" & vbCrLf &
    '                          $"Validade: 6 meses a partir da data da pasteurização" & vbCrLf &
    '                          $"Armazenamento: congelado, no máximo -4°C"

    '        ' Cria a célula da tabela
    '        Dim cell As New PdfPCell(New Phrase(dados, FontFactory.GetFont(FontFactory.HELVETICA, 10)))
    '        cell.Padding = 10
    '        cell.Border = Rectangle.NO_BORDER
    '        cell.VerticalAlignment = Element.ALIGN_TOP

    '        ' Adiciona a célula à tabela
    '        tabela.AddCell(cell)
    '    Next

    '    ' Adiciona a tabela ao documento
    '    documento.Add(tabela)

    '    ' Fecha o documento
    '    documento.Close()
    '    Console.WriteLine("PDF gerado com sucesso em: " & filePath)
    'End Sub

    Public Sub GerarPDFComiTextSharp(dataTable As DataTable)
        Dim filePath As String = Application.StartupPath & "\PDF\Rotulos.pdf"

        ' Criação do documento PDF
        Dim documento As New Document(PageSize.A4, 10, 10, 15, 15)
        Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(filePath, FileMode.Create))

        ' Abre o documento para escrita
        documento.Open()

        ' Cria uma tabela de duas colunas
        Dim tabela As New PdfPTable(2)
        tabela.WidthPercentage = 100
        tabela.SetWidths(New Single() {50, 50}) ' Define a largura proporcional das colunas

        ' Itera sobre as linhas do DataTable
        For Each linha As DataRow In dataTable.Rows
            ' Prepara os dados como uma célula de tabela
            Dim dados As String = "Leite Humano Pasteurizado" & vbCrLf & vbCrLf &
                $"Doadora: {linha("doadora")}" & vbCrLf &
                $"Data ordenha: {FormatDateTime(linha("ordenha"), DateFormat.ShortDate)}" & vbCrLf &
                $"Data parto: {FormatDateTime(linha("parto"), DateFormat.ShortDate)}" & vbCrLf &
                $"Tipo de leite: C" & vbCrLf &
                $"Vol: 200 ml" & vbCrLf &
                $"Gordura (%): {linha("gordura")}" & vbCrLf &
                $"Kcal: {linha("caloria")}" & vbCrLf &
                $"Acidez (°D): {linha("acidez")}" & vbCrLf &
                $"BGBL: {linha("bgbl")}" & vbCrLf &
                $"Data pasteurização: {FormatDateTime(linha("pasteurizacao"), DateFormat.ShortDate)}" & vbCrLf &
                $"Validade: 6 meses a partir da data da pasteurização" & vbCrLf &
                $"Armazenamento: congelado, no máximo -4°C"

            ' Cria a célula da tabela com borda
            Dim leading As Single = 14 ' Ajuste esse valor conforme necessário
            Dim phrase As New Phrase(leading, dados, FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10))
            Dim cell As New PdfPCell(phrase)
            cell.Padding = 10
            cell.Border = PdfPCell.BOX ' Adiciona borda ao redor da célula
            cell.VerticalAlignment = Element.ALIGN_TOP


            ' Adiciona a célula à tabela
            tabela.AddCell(cell)
        Next

        ' Adiciona a tabela ao documento
        documento.Add(tabela)

        ' Fecha o documento
        documento.Close()
        Console.WriteLine("PDF gerado com sucesso em: " & filePath)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GerarPDFComiTextSharp(getProcessamento())
    End Sub

End Class