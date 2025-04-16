Imports System.IO
Imports OfficeOpenXml
Imports MySql.Data.MySqlClient
Public Class XLStoSQL
    Dim m As New Main
    Dim connectionString As String = $"Server={My.Settings.server };Database={My.Settings.database };Uid={My.Settings.user };Pwd={My.Settings.password };"

    Public Function excelDateToMysql(valorExcel As Object) As String
        Dim dataConvertida As Date

        ' Verifica se o valor é nulo, vazio ou um hífen
        If valorExcel Is Nothing OrElse valorExcel.ToString().Trim() = "-" OrElse String.IsNullOrWhiteSpace(valorExcel.ToString()) Then
            Throw New FormatException("Valor inválido ou vazio na célula.")
        End If

        ' Verifica se o valor é um número serial do Excel
        If TypeOf valorExcel Is Double Then
            ' Converte o número serial para uma data
            dataConvertida = DateTime.FromOADate(DirectCast(valorExcel, Double))
        ElseIf Date.TryParse(valorExcel.ToString(), dataConvertida) Then
            ' Tenta interpretar o valor como uma string de data
        Else
            Throw New FormatException("Valor inválido para conversão: " & valorExcel.ToString())
        End If

        ' Retorna a data formatada no padrão MySQL
        Return dataConvertida.ToString("yyyy-MM-dd")
    End Function

    Private Function sanitizeDecimal(value As String) As Decimal
        If value Is Nothing Or value.Trim() = "-" Or value = "" Then
            Return 0D
        Else
            Return value
        End If
    End Function

    Public Sub getXLSProcessamento()

        Using connection As New MySqlConnection(connectionString)
            Try
                ' Abre a conexão com o banco MySQL
                connection.Open()

                Dim excelPath As String = Application.StartupPath & "\XLS\processamento.xlsx"
                ' Configurar o pacote EPPlus para ler a planilha
                ExcelPackage.License.SetNonCommercialPersonal("Guilherme")
                Using package As New ExcelPackage(New FileInfo(excelPath))
                    ' Selecionar a aba desejada
                    Dim worksheet = package.Workbook.Worksheets("MAR") ' Substitua pelo nome da aba

                    ' Iterar sobre as linhas da planilha
                    For row As Integer = 3 To worksheet.Dimension.End.Row

                        ' Ler os valores das colunas
                        Dim dataPasteurizacao As Date = m.mysqlDateFormat(worksheet.Cells(row, 1).Text)
                        If dataPasteurizacao = "0001-01-01" Then
                            MsgBox("Dados transferidos com sucesso!")
                            Return
                        End If
                        Dim origem As String = worksheet.Cells(row, 2).Text
                        Dim doadora As String = worksheet.Cells(row, 3).Text
                        Dim frasco As String = worksheet.Cells(row, 4).Text
                        Dim tl As String = worksheet.Cells(row, 5).Text
                        Dim ordenha As Date = m.mysqlDateFormat(worksheet.Cells(row, 6).Text)
                        Dim parto As Date = m.mysqlDateFormat(worksheet.Cells(row, 7).Text)
                        Dim creme1 As Decimal = sanitizeDecimal(worksheet.Cells(row, 8).Text)
                        Dim creme2 As Decimal = sanitizeDecimal(worksheet.Cells(row, 9).Text)
                        Dim creme3 As Decimal = sanitizeDecimal(worksheet.Cells(row, 10).Text)
                        Dim total1 As Decimal = sanitizeDecimal(worksheet.Cells(row, 11).Text)
                        Dim total2 As Decimal = sanitizeDecimal(worksheet.Cells(row, 12).Text)
                        Dim total3 As Decimal = sanitizeDecimal(worksheet.Cells(row, 13).Text)
                        Dim percentCreme As Decimal = sanitizeDecimal(worksheet.Cells(row, 14).Text)
                        Dim percentGordura As Decimal = sanitizeDecimal(worksheet.Cells(row, 15).Text)
                        Dim calorias As Decimal = sanitizeDecimal(worksheet.Cells(row, 16).Text)
                        Dim acidez As Decimal = sanitizeDecimal(worksheet.Cells(row, 17).Text)
                        Dim bgbl As String = worksheet.Cells(row, 18).Text
                        Dim ml As Decimal = sanitizeDecimal(worksheet.Cells(row, 19).Text)
                        Dim dataDistrib As Date = m.mysqlDateFormat(worksheet.Cells(row, 20).Text)
                        Dim destino As String = worksheet.Cells(row, 21).Text

                        Dim query As String = "INSERT INTO blh_processamento (dataPasteurizacao, origem, doadora, frasco, tl, ordenha, parto, creme1, creme2, creme3, total1, total2, total3, percentCreme, percentGordura, calorias, acidez, bgbl, ml, dataDistrib, destino) VALUES (@dataPasteurizacao, @origem, @doadora, @frasco, @tl, @ordenha, @parto, @creme1, @creme2, @creme3, @total1, @total2, @total3, @percentCreme, @percentGordura, @calorias, @acidez, @bgbl, @ml, @dataDistrib, @destino)"

                        Using command As New MySqlCommand(query, connection)
                            ' Substituir parâmetros
                            command.Parameters.AddWithValue("@dataPasteurizacao", dataPasteurizacao)
                            command.Parameters.AddWithValue("@origem", origem)
                            command.Parameters.AddWithValue("@doadora", doadora)
                            command.Parameters.AddWithValue("@frasco", frasco)
                            command.Parameters.AddWithValue("@tl", tl)
                            command.Parameters.AddWithValue("@ordenha", ordenha)
                            command.Parameters.AddWithValue("@parto", parto)
                            command.Parameters.AddWithValue("@creme1", creme1)
                            command.Parameters.AddWithValue("@creme2", creme2)
                            command.Parameters.AddWithValue("@creme3", creme3)
                            command.Parameters.AddWithValue("@total1", total1)
                            command.Parameters.AddWithValue("@total2", total2)
                            command.Parameters.AddWithValue("@total3", total3)
                            command.Parameters.AddWithValue("@percentCreme", percentCreme)
                            command.Parameters.AddWithValue("@percentGordura", percentGordura)
                            command.Parameters.AddWithValue("@calorias", calorias)
                            command.Parameters.AddWithValue("@acidez", acidez)
                            command.Parameters.AddWithValue("@bgbl", bgbl)
                            command.Parameters.AddWithValue("@ml", ml)
                            command.Parameters.AddWithValue("@dataDistrib", dataDistrib)
                            command.Parameters.AddWithValue("@destino", destino)

                            ' Executar a query
                            command.ExecuteNonQuery()
                        End Using
                    Next
                End Using

            Catch ex As Exception
                Debug.Write("Erro: " & ex.Message)
            End Try
        End Using

    End Sub

    Public Sub getXLScadastroGeral()

        Using connection As New MySqlConnection(connectionString)
            Try
                ' Abre a conexão com o banco MySQL
                connection.Open()

                Dim excelPath As String = Application.StartupPath & "\XLS\cadastro.xlsx"
                ' Configurar o pacote EPPlus para ler a planilha
                ExcelPackage.License.SetNonCommercialPersonal("Guilherme")
                Using package As New ExcelPackage(New FileInfo(excelPath))
                    ' Selecionar a aba desejada
                    Dim worksheet = package.Workbook.Worksheets("CADASTRO GERAL 2025") ' Substitua pelo nome da aba

                    ' Iterar sobre as linhas da planilha
                    For row As Integer = 2 To worksheet.Dimension.End.Row

                        ' Ler os valores das colunas
                        Dim dataPasteurizacao As Date = m.mysqlDateFormat(worksheet.Cells(row, 1).Text)
                        If dataPasteurizacao = "0001-01-01" Then
                            MsgBox("Dados transferidos com sucesso!")
                            Return
                        End If
                        Dim origem As String = worksheet.Cells(row, 2).Text
                        Dim doadora As String = worksheet.Cells(row, 3).Text
                        Dim frasco As String = worksheet.Cells(row, 4).Text
                        Dim tl As String = worksheet.Cells(row, 5).Text
                        Dim ordenha As Date = m.mysqlDateFormat(worksheet.Cells(row, 6).Text)
                        Dim parto As Date = m.mysqlDateFormat(worksheet.Cells(row, 7).Text)
                        Dim creme1 As Decimal = sanitizeDecimal(worksheet.Cells(row, 8).Text)
                        Dim creme2 As Decimal = sanitizeDecimal(worksheet.Cells(row, 9).Text)
                        Dim creme3 As Decimal = sanitizeDecimal(worksheet.Cells(row, 10).Text)
                        Dim total1 As Decimal = sanitizeDecimal(worksheet.Cells(row, 11).Text)
                        Dim total2 As Decimal = sanitizeDecimal(worksheet.Cells(row, 12).Text)
                        Dim total3 As Decimal = sanitizeDecimal(worksheet.Cells(row, 13).Text)
                        Dim percentCreme As Decimal = sanitizeDecimal(worksheet.Cells(row, 14).Text)
                        Dim percentGordura As Decimal = sanitizeDecimal(worksheet.Cells(row, 15).Text)
                        Dim calorias As Decimal = sanitizeDecimal(worksheet.Cells(row, 16).Text)
                        Dim acidez As Decimal = sanitizeDecimal(worksheet.Cells(row, 17).Text)
                        Dim bgbl As String = worksheet.Cells(row, 18).Text
                        Dim ml As Decimal = sanitizeDecimal(worksheet.Cells(row, 19).Text)
                        Dim dataDistrib As Date = m.mysqlDateFormat(worksheet.Cells(row, 20).Text)
                        Dim destino As String = worksheet.Cells(row, 21).Text

                        Dim query As String = "INSERT INTO blh_procesamento (dataPasteurizacao, origem, doadora, frasco, tl, ordenha, parto, creme1, creme2, creme3, total1, total2, total3, percentCreme, percentGordura, calorias, acidez, bgbl, ml, dataDistrib, destino) VALUES (@dataPasteurizacao, @origem, @doadora, @frasco, @tl, @ordenha, @parto, @creme1, @creme2, @creme3, @total1, @total2, @total3, @percentCreme, @percentGordura, @calorias, @acidez, @bgbl, @ml, @dataDistrib, @destino)"

                        Using command As New MySqlCommand(query, connection)
                            ' Substituir parâmetros
                            command.Parameters.AddWithValue("@dataPasteurizacao", dataPasteurizacao)
                            command.Parameters.AddWithValue("@origem", origem)
                            command.Parameters.AddWithValue("@doadora", doadora)
                            command.Parameters.AddWithValue("@frasco", frasco)
                            command.Parameters.AddWithValue("@tl", tl)
                            command.Parameters.AddWithValue("@ordenha", ordenha)
                            command.Parameters.AddWithValue("@parto", parto)
                            command.Parameters.AddWithValue("@creme1", creme1)
                            command.Parameters.AddWithValue("@creme2", creme2)
                            command.Parameters.AddWithValue("@creme3", creme3)
                            command.Parameters.AddWithValue("@total1", total1)
                            command.Parameters.AddWithValue("@total2", total2)
                            command.Parameters.AddWithValue("@total3", total3)
                            command.Parameters.AddWithValue("@percentCreme", percentCreme)
                            command.Parameters.AddWithValue("@percentGordura", percentGordura)
                            command.Parameters.AddWithValue("@calorias", calorias)
                            command.Parameters.AddWithValue("@acidez", acidez)
                            command.Parameters.AddWithValue("@bgbl", bgbl)
                            command.Parameters.AddWithValue("@ml", ml)
                            command.Parameters.AddWithValue("@dataDistrib", dataDistrib)
                            command.Parameters.AddWithValue("@destino", destino)

                            ' Executar a query
                            command.ExecuteNonQuery()
                        End Using
                    Next
                End Using

            Catch ex As Exception
                Debug.Write("Erro: " & ex.Message)
            End Try
        End Using

    End Sub


End Class
