Imports System.Text
Imports Tesseract
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class OcrHelper

    Public Shared Function FindMaiorTDBGrid(
        parent As IntPtr) As IntPtr

        Dim maiorGrid As IntPtr = IntPtr.Zero
        Dim maiorArea As Integer = 0

        ProcurarGrid(parent, maiorGrid, maiorArea)

        Return maiorGrid

    End Function

    Private Shared Sub ProcurarGrid(
        parent As IntPtr,
        ByRef maiorGrid As IntPtr,
        ByRef maiorArea As Integer)

        Dim child As IntPtr = IntPtr.Zero

        Do

            child = WinApi.FindWindowEx(
                parent,
                child,
                Nothing,
                Nothing)

            If child = IntPtr.Zero Then Exit Do

            Dim sb As New StringBuilder(256)

            WinApi.GetClassName(
                child,
                sb,
                sb.Capacity)

            If sb.ToString() = "TDBGrid" Then

                Dim r As New WinApi.RECT

                If WinApi.GetWindowRect(child, r) Then

                    Dim area =
                        (r.Right - r.Left) *
                        (r.Bottom - r.Top)

                    If area > maiorArea Then

                        maiorArea = area
                        maiorGrid = child

                    End If

                End If

            End If

            ProcurarGrid(
                child,
                maiorGrid,
                maiorArea)

        Loop

    End Sub

    Public Shared Function ResizeImage(
        img As Bitmap,
        scale As Integer) As Bitmap

        Dim nova As New Bitmap(
            img.Width * scale,
            img.Height * scale)

        Using g As Graphics =
            Graphics.FromImage(nova)

            g.InterpolationMode =
                InterpolationMode.HighQualityBicubic

            g.DrawImage(
                img,
                0,
                0,
                nova.Width,
                nova.Height)

        End Using

        Return nova

    End Function

    Public Shared Function PretoBranco(
        img As Bitmap) As Bitmap

        Dim nova As New Bitmap(
            img.Width,
            img.Height)

        For y = 0 To img.Height - 1

            For x = 0 To img.Width - 1

                Dim c = img.GetPixel(x, y)

                Dim media As Integer = (CInt(c.R) + CInt(c.G) + CInt(c.B)) \ 3

                If media > 200 Then
                    nova.SetPixel(x, y, Color.White)
                Else
                    nova.SetPixel(x, y, Color.Black)
                End If

            Next

        Next

        Return nova

    End Function

    Public Shared Function LerImagem(
       arquivo As String) As String

        Dim texto As String = ""

        Using engine As New TesseractEngine(
            Application.StartupPath & "\tessdata",
            "por",
            EngineMode.Default)

            Using img = Pix.LoadFromFile(arquivo)

                Using page = engine.Process(img)

                    texto = page.GetText()

                End Using

            End Using

        End Using

        Return texto

    End Function

    Public Shared Function CropBitmap(img As Bitmap, x As Integer, y As Integer, largura As Integer, altura As Integer) As Bitmap

        Dim rect As New Rectangle(x, y, largura, altura)
        Return img.Clone(rect, img.PixelFormat)

    End Function

End Class