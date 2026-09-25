Imports System
Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class BancoAME

    Private ReadOnly connectionString As String

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub

    Public Function GetDataset(sql As String) As DataTable

        Dim tabela As New DataTable()

        Using conexao As New MySqlConnection(connectionString)
            Using comando As New MySqlCommand(sql, conexao)
                Using adaptador As New MySqlDataAdapter(comando)

                    conexao.Open()
                    adaptador.Fill(tabela)

                End Using
            End Using
        End Using

        Return tabela

    End Function

End Class
