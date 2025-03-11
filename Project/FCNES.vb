Public Class FCNES
    Dim xml As New XML
    Dim toolTip As New ToolTip() ' Instância global do ToolTip
    Dim sourceContainer As FlowLayoutPanel = Nothing ' Container de origem do Label
    Private toolTipTimer As New Timer()
    Private scrollTimer As New Timer()
    Private scrollDirection As Integer = 0 ' 1 para baixo, -1 para cima


    Private Sub Container_DragEnter(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(GetType(Label)) Then
            Dim destinationContainer = DirectCast(sender, FlowLayoutPanel)

            e.Effect = DragDropEffects.Move ' Permite o drop
        Else
            e.Effect = DragDropEffects.None ' Não permite o drop
        End If
    End Sub

    Private Sub Container_DragDrop(sender As Object, e As DragEventArgs)
        Dim destinationContainer As FlowLayoutPanel = DirectCast(sender, FlowLayoutPanel)
        Dim control As Label = DirectCast(e.Data.GetData(GetType(Label)), Label)
        Dim labelText As String = control.Text

        ' Adiciona o controle ao container de destino
        destinationContainer.Controls.Add(control)
        destinationContainer.Controls.SetChildIndex(control, 1)
        ' Oculta o ToolTip após alguns segundos
        toolTip.Hide(destinationContainer)

        toolTip.Show($"{labelText}{vbCrLf}Movido para Equipe: {destinationContainer.Name}", destinationContainer, 10, 10, 6000)
        toolTipTimer.Tag = destinationContainer ' Armazena o container para ocultar depois
        toolTipTimer.Start()
        sourceContainer = Nothing

        scrollTimer.Stop() ' Para a rolagem ao soltar o label
    End Sub

    Private Sub Container_DragOver(sender As Object, e As DragEventArgs) Handles PanelContainer.DragOver
        e.Effect = DragDropEffects.Move
        Dim container As FlowLayoutPanel = DirectCast(sender, FlowLayoutPanel)
        Dim mousePosition As Point = PanelContainer.PointToClient(Cursor.Position)
        Dim scrollThreshold As Integer = 30 ' Ajuste a distância da borda conforme necessário

        If mousePosition.Y < scrollThreshold Then
            ' Rolar para cima
            scrollDirection = -1
            If Not scrollTimer.Enabled Then scrollTimer.Start()
        ElseIf mousePosition.Y > PanelContainer.ClientSize.Height - scrollThreshold Then
            ' Rolar para baixo
            scrollDirection = 1
            If Not scrollTimer.Enabled Then scrollTimer.Start()
        Else
            ' Parar a rolagem
            scrollTimer.Stop()
        End If
    End Sub

    Private Sub scrollTimer_Tick(sender As Object, e As EventArgs)
        ' Debug.WriteLine("scrollTimer_Tick disparado!")
        Try
            Dim scrollAmount As Integer = 50 ' Ajuste a velocidade da rolagem conforme necessário
            PanelContainer.VerticalScroll.Value += scrollDirection * scrollAmount

            ' Garante que o valor do scroll esteja dentro dos limites
            PanelContainer.VerticalScroll.Value = Math.Max(PanelContainer.VerticalScroll.Minimum, Math.Min(PanelContainer.VerticalScroll.Maximum, PanelContainer.VerticalScroll.Value))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim control As Label = DirectCast(sender, Label)
            Dim labelText As String = control.Text ' Captura o texto do label

            ' Identifica o container de origem
            sourceContainer = DirectCast(control.Parent, FlowLayoutPanel)

            ' Mostra o ToolTip indicando a origem
            toolTip.Show($"{labelText}{vbCrLf}Saindo de Equipe: {sourceContainer.Name}", sourceContainer, 10, 10, 6000)

            ' Inicia o arrasto
            control.DoDragDrop(control, DragDropEffects.Move)
        End If
    End Sub

    ' Evento Load para configurar os containers e labels
    Private Sub FCNES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estabelecimentos = xml.equipesXML()

        AddHandler PanelContainer.DragOver, AddressOf Container_DragOver

        For Each est In estabelecimentos
            If est.Equipes IsNot Nothing Then
                For Each eq In est.Equipes
                    Dim unidade As New FlowLayoutPanel()
                    unidade.Name = eq.NomeReferencia
                    unidade.AllowDrop = True
                    unidade.Width = 300
                    unidade.Height = 400
                    unidade.Margin = New Padding(10)
                    unidade.Padding = New Padding(0)
                    unidade.AutoScroll = True
                    unidade.FlowDirection = FlowDirection.TopDown
                    unidade.BorderStyle = BorderStyle.FixedSingle
                    unidade.WrapContents = False
                    unidade.HorizontalScroll.Visible = False

                    ' Adiciona os eventos de drag-and-drop
                    AddHandler unidade.DragEnter, AddressOf Container_DragEnter
                    AddHandler unidade.DragDrop, AddressOf Container_DragDrop

                    Dim labelNome As New Label() With {
                        .AutoSize = False,
                        .Width = 280,
                        .BackColor = Color.White,
                        .ForeColor = Color.Black,
                        .Font = New Font("Calibri", 10, FontStyle.Bold),
                        .Text = eq.NomeReferencia & " - " & eq.INE,
                        .TextAlign = ContentAlignment.MiddleCenter,
                        .Margin = New Padding(0, 0, 0, 10)
                    }

                    PanelContainer.Controls.Add(unidade)
                    unidade.Controls.Add(labelNome)

                    If eq.Profissionais IsNot Nothing Then
                        For Each prof In eq.Profissionais
                            Dim labelProf As New Label()
                            Dim labelCBO As New Label()
                            labelProf.AutoSize = False
                            labelProf.Width = 260
                            labelProf.Height = 45
                            labelProf.Font = New Font("Calibri", 10, FontStyle.Regular)
                            labelCBO.Font = New Font("Calibri", 10, FontStyle.Italic)
                            labelCBO.Text = xml.getCBOXML(prof.CBOLOTACAO)

                            labelProf.Text = prof.Nome & vbCrLf & labelCBO.Text
                            labelProf.Margin = New Padding(10, 5, 5, 10)
                            labelProf.Padding = New Padding(2, 2, 2, 2)
                            labelProf.BorderStyle = BorderStyle.None
                            labelProf.BackColor = Color.SteelBlue
                            labelProf.ForeColor = Color.White

                            ' Adiciona o evento de MouseDown para arrastar
                            AddHandler labelProf.MouseDown, AddressOf Control_MouseDown

                            Select Case prof.CBOLOTACAO
                                Case "225142"
                                    labelProf.BackColor = Color.ForestGreen
                                Case "223565"
                                    labelProf.BackColor = Color.IndianRed
                                Case "322245"
                                    labelProf.BackColor = Color.Orange
                                Case "515105"
                                    labelProf.BackColor = Color.SteelBlue
                                Case Else
                                    labelProf.BackColor = Color.DarkSlateGray
                            End Select

                            unidade.Controls.Add(labelProf)
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub FCNES_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PanelContainer.Height = Me.Height
    End Sub

    Public Sub New()
        InitializeComponent()
        toolTipTimer.Interval = 2000 ' 2 segundos
        AddHandler toolTipTimer.Tick, AddressOf toolTipTimer_Tick

        scrollTimer.Interval = 10 ' Ajuste o intervalo conforme necessário
        AddHandler scrollTimer.Tick, AddressOf scrollTimer_Tick
    End Sub

    Private Sub toolTipTimer_Tick(sender As Object, e As EventArgs)
        toolTipTimer.Stop()
        toolTip.Hide(DirectCast(toolTipTimer.Tag, FlowLayoutPanel))
    End Sub

    Private Sub FCNES_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
        toolTip.Active = False
    End Sub

    Private Sub PanelContainer_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelContainer.MouseUp
        scrollTimer.Stop()
    End Sub

End Class
