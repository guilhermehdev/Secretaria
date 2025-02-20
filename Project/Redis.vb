Imports StackExchange.Redis

Public Class RedisClient
    Private connection As ConnectionMultiplexer
    Private subscriber As ISubscriber

    Public Sub New()
        ' Conectar ao Redis
        connection = ConnectionMultiplexer.Connect("localhost") ' Substitua pelo seu host Redis, se necessário
        subscriber = connection.GetSubscriber()
    End Sub

    Public Sub listeningRedis()
        ' Inscrever-se no canal "ouvidoria_ok"
        subscriber.Subscribe("ouvidoria_ok", Sub(channel, message)
                                                 ' Processar a mensagem recebida
                                                 Console.WriteLine($"Mensagem recebida do canal '{channel}': {message}")
                                             End Sub)
        Console.WriteLine("Consumidor Redis iniciado. Aguardando mensagens...")
    End Sub

    Public Sub RunPythonScript(scriptPath As String)
        Try
            '' Cria o processo para executar o Python
            'Dim pythonProcess As New Process()
            'pythonProcess.StartInfo.FileName = "python" ' Ou "python3" se estiver em um ambiente específico
            'pythonProcess.StartInfo.Arguments = $"{scriptPath} {args}"
            'pythonProcess.StartInfo.RedirectStandardOutput = True
            'pythonProcess.StartInfo.RedirectStandardError = True
            'pythonProcess.StartInfo.UseShellExecute = False
            'pythonProcess.StartInfo.CreateNoWindow = True

            '' Inicia o processo
            'pythonProcess.Start()

            '' Captura a saída do script Python
            'Dim output As String = pythonProcess.StandardOutput.ReadToEnd()
            'Dim errorOutput As String = pythonProcess.StandardError.ReadToEnd()

            '' Aguarda o término do processo
            'pythonProcess.WaitForExit()

            'If Not String.IsNullOrEmpty(output) Then
            '    Console.WriteLine("Saída do Python: " & output)
            'End If

            '' Exibe erros, se houver
            'If Not String.IsNullOrEmpty(errorOutput) Then
            '    Console.WriteLine("Erro do Python:")
            '    Console.WriteLine(errorOutput)
            'End If

        Catch ex As Exception
            Console.WriteLine($"Erro ao executar o script Python: {ex.Message}")
        End Try
    End Sub

End Class