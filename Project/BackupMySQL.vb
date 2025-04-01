Imports System.Diagnostics
Imports System.IO
Imports System.IO.Compression

Public Class BackupMySQL
    Public Shared Function Backup(ByVal caminhoBackup As String, ByVal usuario As String, ByVal senha As String, ByVal banco As String, ByVal caminhoMysqlDump As String) As Boolean
        Try
            Dim processo As New Process()
            processo.StartInfo.FileName = caminhoMysqlDump
            processo.StartInfo.Arguments = $"--user={usuario} --password={senha} --host=localhost {banco} --result-file=""{caminhoBackup}"""
            processo.StartInfo.RedirectStandardOutput = True
            processo.StartInfo.RedirectStandardError = True
            processo.StartInfo.UseShellExecute = False
            processo.StartInfo.CreateNoWindow = True
            processo.Start()

            processo.WaitForExit()
            If processo.ExitCode = 0 Then
                ' Compactar o backup após a criação
                Dim caminhoZip As String = CompactarBackup(caminhoBackup)
                Return Not String.IsNullOrEmpty(caminhoZip)
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao criar backup: " & ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function CompactarBackup(ByVal caminhoBackup As String) As String
        Try
            Dim caminhoZip As String = Path.ChangeExtension(caminhoBackup, ".zip")
            Using zip As FileStream = New FileStream(caminhoZip, FileMode.Create)
                Using arquivoZip As ZipArchive = New ZipArchive(zip, ZipArchiveMode.Create)
                    arquivoZip.CreateEntryFromFile(caminhoBackup, Path.GetFileName(caminhoBackup), CompressionLevel.Optimal)
                End Using
            End Using
            File.Delete(caminhoBackup) ' Remove o arquivo original após a compactação
            Return caminhoZip
        Catch ex As Exception
            MessageBox.Show("Erro ao compactar backup: " & ex.Message)
            Return String.Empty
        End Try
    End Function
End Class
