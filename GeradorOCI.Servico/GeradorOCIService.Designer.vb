Imports System.ServiceProcess

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeradorOCIService
    Inherits System.ServiceProcess.ServiceBase

    'Descartar substituições de UserService para limpar lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    ' O ponto de entrada principal para o processo
    <MTAThread()> _
    <System.Diagnostics.DebuggerNonUserCode()> _
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' Mais de um Serviço NT pode rodar dentro do mesmo processo. Para adicionar
        ' outro serviço a este processo, modifique a linha seguinte para
        ' criar um segundo objeto de serviço. Por exemplo,
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New GeradorOCIService}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'Exigido pelo Designer de Componentes
    Private components As System.ComponentModel.IContainer

    ' OBSERVAÇÃO: o procedimento a seguir é exigido pelo Designer de Componentes
    ' Pode ser modificado usando o Designer de Componentes.
    ' Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        '
        'GeradorOCIService
        '
        Me.ServiceName = "GeradorOCI"

    End Sub

End Class
