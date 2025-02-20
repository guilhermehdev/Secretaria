Imports System.Threading.Tasks

Public Class FormFadeNotify
    Private fadeInTimer As New Timer()
    Private fadeOutTimer As New Timer()
    Private pForm As Form

    Public Sub New(parent As Form)
        InitializeComponent()
        pForm = parent

        ' Configurar os timers
        fadeInTimer.Interval = 30 ' Intervalo do fade-in (30 ms)
        fadeOutTimer.Interval = 30 ' Intervalo do fade-out (30 ms)
        AddHandler fadeInTimer.Tick, AddressOf FadeIn
        AddHandler fadeOutTimer.Tick, AddressOf FadeOut
    End Sub
    Private Sub FormFadeNotify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data = FmainOuvidoria.chechAprova()
        If data.count > 0 Then

            Me.Opacity = 0.8
            Me.BackColor = Color.FromArgb(55, 55, 63)

            ' Obtenha os limites do formulário pai
            Dim parentBounds = pForm.Bounds

            ' Calcule a posição na parte inferior direita do formulário pai
            Dim x = parentBounds.Right - Me.Width - 50
            Dim y = parentBounds.Bottom - Me.Height - 50

            ' Ajuste a posição do formulário
            Me.Location = New Point(x, y)
            ' Mostre o formulário com fade-in
            fadeInTimer.Start()

            lbCount.Text = data.Count
            lbCount.ForeColor = Color.FromArgb(255, 198, 88)

            lbNotify.Text = " Ouvidorias aguardando aprovação."
            lbNotify.ForeColor = Color.FromArgb(220, 220, 220)
        End If

    End Sub

    Private Sub FadeIn(sender As Object, e As EventArgs)
        If Me.Opacity < 0.9 Then
            Me.Opacity += 0.03
        Else
            fadeInTimer.Stop()
        End If
    End Sub

    Private Sub FadeOut(sender As Object, e As EventArgs)
        If Me.Opacity > 0 Then
            Me.Opacity -= 0.03
        Else
            fadeOutTimer.Stop()
            Me.Close() ' Fecha o formulário após o fade-out
        End If
    End Sub

    Private Sub btOK_Click(sender As Object, e As EventArgs) Handles btOK.Click
        Task.Delay(100).ContinueWith(Sub() fadeOutTimer.Start(), TaskScheduler.FromCurrentSynchronizationContext())
    End Sub

End Class