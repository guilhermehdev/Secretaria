Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports MySql.Data.MySqlClient

Public Class CepAberto
    Public Property cep As String
    Public Property logradouro As String
    Public Property bairro As String
    Public Property cidade As String
    Public Property estado As String
    Public Property latitude As Double
    Public Property longitude As Double

    Public Sub getPeruibe()
        Dim token As String = "cbf3b482a8c836a57bbb5e62eaec60d4" ' <-- coloque seu token do CepAberto
        Dim cidade As String = "Peruibe"
        Dim uf As String = "SP"

        Dim url As String = $"https://www.cepaberto.com/api/v3/address?estado=SP&cidade=Peruíbe"

        ' >>> ajuste sua string de conexão MySQL <<<
        Dim conexaoString As String = "server=10.31.196.68;user=emendas;password=emendas123;database=ame;charset=utf8mb4;"

        Try
            Console.WriteLine($"Consultando endereços de {cidade}/{uf} via CepAberto...")

            Dim request As WebRequest = WebRequest.Create(url)
            request.Method = "GET"
            request.Headers.Add("Authorization", "Token token=" & token)

            Using response As WebResponse = request.GetResponse()
                Using reader As New StreamReader(response.GetResponseStream())
                    Dim json As String = reader.ReadToEnd()

                    Dim serializer As New JavaScriptSerializer()
                    Dim enderecos As List(Of CepAberto) = serializer.Deserialize(Of List(Of CepAberto))(json)

                    If enderecos Is Nothing OrElse enderecos.Count = 0 Then
                        MsgBox("Nenhum endereço encontrado para esta cidade.")
                        Return
                    End If

                    Using conexao As New MySqlConnection(conexaoString)
                        conexao.Open()

                        Dim cmd As New MySqlCommand("INSERT INTO enderecos_peruibe (cep, logradouro, bairro, cidade, uf, latitude, longitude) VALUES (@cep, @logradouro, @bairro, @cidade, @uf, @lat, @lon)", conexao)

                        For Each e In enderecos
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@cep", e.cep)
                            cmd.Parameters.AddWithValue("@logradouro", e.logradouro)
                            cmd.Parameters.AddWithValue("@bairro", e.bairro)
                            cmd.Parameters.AddWithValue("@cidade", e.cidade)
                            cmd.Parameters.AddWithValue("@uf", e.estado)
                            cmd.Parameters.AddWithValue("@lat", e.latitude)
                            cmd.Parameters.AddWithValue("@lon", e.longitude)
                            cmd.ExecuteNonQuery()
                        Next
                    End Using

                    MsgBox("Importação concluída com sucesso!")
                    MsgBox($"Total de registros inseridos: {enderecos.Count}")
                End Using
            End Using

        Catch ex As WebException
            MsgBox("Erro ao consultar API: " & ex.Message)
        Catch ex As Exception
            MsgBox("Erro geral: " & ex.Message)
        End Try

        MsgBox("Processo finalizado.")

    End Sub

End Class
