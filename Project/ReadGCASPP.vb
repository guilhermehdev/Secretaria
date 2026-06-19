Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions

Public Class PacienteGCASPP

    Public Property Nome As String
    Public Property CPF As String
    Public Property Mae As String
    Public Property Nascimento As String
    Public Property CEP As String
    Public Property Bairro As String
    Public Property Numero As String
    Public Property Sexo As String
    Public Property Logradouro As String

End Class

Public Class CampoGCASPP

    Public Property Hwnd As IntPtr
    Public Property Classe As String
    Public Property Texto As String
    Public Property Left As Integer
    Public Property Top As Integer

End Class

Public Class GCASPPReader

#Region "API"

    Private Delegate Function EnumWindowsProc(
        hwnd As IntPtr,
        lParam As IntPtr) As Boolean

    <DllImport("user32.dll")>
    Private Shared Function EnumChildWindows(
        hwndParent As IntPtr,
        lpEnumFunc As EnumWindowsProc,
        lParam As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(
        lpClassName As String,
        lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetClassName(
        hwnd As IntPtr,
        lpClassName As StringBuilder,
        nMaxCount As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function GetWindowRect(
        hwnd As IntPtr,
        ByRef rect As RECT) As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(
        hwnd As IntPtr,
        msg As Integer,
        wParam As Integer,
        lParam As StringBuilder) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(
        hwnd As IntPtr,
        msg As Integer,
        wParam As Integer,
        lParam As Integer) As Integer
    End Function


#End Region

#Region "Constantes"

    Private Const WM_GETTEXT = &HD
    Private Const WM_GETTEXTLENGTH = &HE

#End Region

#Region "Struct"

    <StructLayout(LayoutKind.Sequential)>
    Private Structure RECT

        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer

    End Structure

#End Region

    Public Sub ListarControlesComPosicao(hwndJanela As IntPtr)

        EnumChildWindows(
        hwndJanela,
        Function(child, lp)

            Dim classe As New StringBuilder(256)
            GetClassName(child, classe, classe.Capacity)

            Dim txt As String = LerTextoControle(child)

            If txt <> "" Then

                Dim r As RECT
                GetWindowRect(child, r)

                Debug.WriteLine(
                    $"Classe={classe} " &
                    $"Valor=[{txt}] " &
                    $"Left={r.Left} " &
                    $"Top={r.Top}")

            End If

            Return True

        End Function,
        IntPtr.Zero)

    End Sub

    Public Function EnumChildProc(hWnd As IntPtr, lParam As IntPtr) As Boolean

        Dim classe As New StringBuilder(256)

        GetClassName(hWnd, classe, classe.Capacity)

        Dim txt As String = LerTextoControle(hWnd)

        Dim r As RECT
        GetWindowRect(hWnd, r)

        Debug.WriteLine(
        $"HWND={hWnd} " &
        $"Classe={classe} " &
        $"Valor=[{txt}] " &
        $"Left={r.Left} " &
        $"Top={r.Top}")

        Return True

    End Function

    Private Function LerTextoControle(hwnd As IntPtr) As String

        Dim tamanho As Integer =
            SendMessage(hwnd,
                        WM_GETTEXTLENGTH,
                        0,
                        0)

        If tamanho <= 0 Then Return ""

        Dim sb As New StringBuilder(tamanho + 1)

        SendMessage(hwnd,
                    WM_GETTEXT,
                    sb.Capacity,
                    sb)

        Return sb.ToString.Trim

    End Function

    Private Function ObterTituloJanela(hwnd As IntPtr) As String

        Dim tamanho As Integer = WinApi.GetWindowTextLength(hwnd)

        If tamanho = 0 Then Return ""

        Dim sb As New StringBuilder(tamanho + 1)

        WinApi.GetWindowText(hwnd, sb, sb.Capacity)

        Return sb.ToString()

    End Function

    Public Function LerPaciente() As PacienteGCASPP
        Dim typeofWindows As Integer = -1
        Dim hwndCliente As IntPtr =
    FindWindow(Nothing, "PM002 - Cadastro do Cliente")

        Dim hwndCidadao As IntPtr =
    FindWindow(Nothing, "PM002 - Cadastro do Cidadão")

        Dim hwndPrincipal As IntPtr = IntPtr.Zero

        If hwndCliente <> IntPtr.Zero Then
            hwndPrincipal = hwndCliente
            typeofWindows = 0
        ElseIf hwndCidadao <> IntPtr.Zero Then
            hwndPrincipal = hwndCidadao
            typeofWindows = 1
        End If


        Dim campos As New List(Of CampoGCASPP)
        campos.Clear()

        EnumChildWindows(hwndPrincipal, Function(child, lp)

                                            Dim sbClasse As New StringBuilder(255)

                                            GetClassName(child, sbClasse, sbClasse.Capacity)

                                            Dim classe As String = sbClasse.ToString()

                                            If classe = "TDBEdit" OrElse
                   classe = "TEdit" OrElse
                   classe = "TComboBox" Then

                                                Dim texto As String = LerTextoControle(child)

                                                If texto.Trim <> "" Then

                                                    Dim r As RECT
                                                    GetWindowRect(child, r)

                                                    campos.Add(New CampoGCASPP With {
                            .Hwnd = child,
                            .Classe = classe,
                            .Texto = texto.Trim,
                            .Left = r.Left,
                            .Top = r.Top
                        })

                                                End If

                                            End If

                                            Return True

                                        End Function,
            IntPtr.Zero)
        For Each c In campos

            If c.Texto.Contains("33") Then
                Debug.Print(
            $"[{c.Texto}] Left={c.Left} Top={c.Top}")
            End If

        Next

        Dim paciente As New PacienteGCASPP

        paciente.CPF =
                ProcurarCampo(campos, 450, 600, 200, 260)

        paciente.Nome =
                ProcurarCampo(campos, 450, 900, 230, 280)

        paciente.Nascimento =
                ProcurarCampo(campos, 620, 760, 200, 260)

        paciente.Sexo =
                ProcurarCampo(campos, 1000, 1200, 220, 280)

        paciente.Mae =
                ProcurarCampo(campos, 850, 1150, 300, 350)

        If typeofWindows = 0 Then 'tipo Cliente

            paciente.CEP =
                ProcurarCampo(campos, 850, 1050, 530, 580)

            paciente.Logradouro =
                ProcurarCampo(campos, 760, 860, 480, 520)

            paciente.Numero =
                ProcurarCampo(campos, 436, 536, 479, 579)

            paciente.Bairro =
                ProcurarCampo(campos, 760, 950, 500, 550)

        ElseIf typeofWindows = 1 Then 'tipo Cidadao
            ' Endereço
            paciente.CEP =
                ProcurarCampo(campos, 1073, 1150, 554, 580)

            paciente.Bairro =
                 ProcurarCampo(campos, 750, 900, 530, 580)

            paciente.Logradouro =
                ProcurarCampo(campos, 450, 700, 510, 550)

            paciente.Numero =
                ProcurarCampo(campos, 820, 950, 510, 550)

        End If

        Return paciente

    End Function


    Private Function ProcurarCampo(campos As List(Of CampoGCASPP), leftMin As Integer, leftMax As Integer, topMin As Integer, topMax As Integer) As String

        Dim campo = campos.FirstOrDefault(Function(c) c.Left >= leftMin AndAlso
                c.Left <= leftMax AndAlso
                c.Top >= topMin AndAlso
                c.Top <= topMax)

        If campo Is Nothing Then
            Return ""
        End If

        Return campo.Texto

    End Function

End Class