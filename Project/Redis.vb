
Imports StackExchange.Redis

Public Class RedisListener
        Private connection As ConnectionMultiplexer
        Private subscriber As ISubscriber

        Public Sub Connect()
            connection = ConnectionMultiplexer.Connect("localhost")
            subscriber = connection.GetSubscriber()

        subscriber.Subscribe("ouvidoria_ok", Sub(channel, message)
                                                 Console.WriteLine($"Mensagem recebida: {message}")
                                                 ' Trate a mensagem recebida
                                             End Sub)
        Console.WriteLine("Conectado ao Redis e ouvindo o canal!")
        End Sub

        Public Sub Disconnect()
            If connection IsNot Nothing Then
                connection.Close()
                connection.Dispose()
            End If
        End Sub
    End Class

