Imports System.Runtime.InteropServices
Imports System.Text

Public Class WinApi

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function FindWindow(
        lpClassName As String,
        lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function GetWindowTextLength(
    hWnd As IntPtr) As Integer
    End Function

    <DllImport("user32.dll")>
    Public Shared Function GetWindowRect(
        hWnd As IntPtr,
        ByRef lpRect As RECT) As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function GetWindowText(
    hwnd As IntPtr,
    lpString As StringBuilder,
    cch As Integer) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Public Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function FindWindowEx(
    hwndParent As IntPtr,
    hwndChildAfter As IntPtr,
    lpszClass As String,
    lpszWindow As String) As IntPtr
    End Function


    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function GetClassName(
    hWnd As IntPtr,
    lpClassName As Text.StringBuilder,
    nMaxCount As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SendMessage(
    hWnd As IntPtr,
    msg As Integer,
    wParam As Integer,
    lParam As StringBuilder) As Integer
    End Function

    Public Const WM_GETTEXT As Integer = &HD
    Public Const WM_GETTEXTLENGTH As Integer = &HE


End Class