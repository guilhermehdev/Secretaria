Imports System.IO
Imports OfficeOpenXml
Imports MySql.Data.MySqlClient
Public Class XLStoSQL

    Public Sub TransferirDados()

        ' Configuração da conexão MySQL
        Dim connectionString As String = $"Server={My.Settings.server };Database={My.Settings.database };Uid={My.Settings.user };Pwd={My.Settings.password };"

        Using connection As New MySqlConnection(connectionString)
            Try
                ' Abre a conexão com o banco MySQL
                connection.Open()

                Dim excelPath As String = Application.StartupPath & "\XLS\plan.xlsx"
                ' Configurar o pacote EPPlus para ler a planilha
                ExcelPackage.License.SetNonCommercialPersonal("Guilherme")
                Using package As New ExcelPackage(New FileInfo(excelPath))
                ' Selecionar a aba desejada
                Dim worksheet = package.Workbook.Worksheets("MAR") ' Substitua pelo nome da aba

                    ' Iterar sobre as linhas da planilha
                    For row As Integer = 3 To worksheet.Dimension.End.Row
                        ' Ler os valores das colunas
                        Dim dataPasteurizacao As String = worksheet.Cells(row, 1).Text
                        Dim origem As String = worksheet.Cells(row, 2).Text
                        Dim doadora As String = worksheet.Cells(row, 3).Text
                        ' Adicione mais colunas conforme necessário

                        ' Query de inserção
                        Dim query As String = "INSERT INTO blh (DataPasteurizacao, Origem, Doadora) VALUES (@DataPasteurizacao, @Origem, @Doadora)"
                        Using command As New MySqlCommand(query, connection)
                            ' Substituir parâmetros
                            command.Parameters.AddWithValue("@DataPasteurizacao", dataPasteurizacao)
                            command.Parameters.AddWithValue("@Origem", origem)
                            command.Parameters.AddWithValue("@Doadora", doadora)

                            ' Executar a query
                            command.ExecuteNonQuery()
                        End Using
                    Next
                End Using

            Console.WriteLine("Dados transferidos com sucesso!")
        Catch ex As Exception
            Console.WriteLine("Erro: " & ex.Message)
        End Try
        End Using

    End Sub

End Class
