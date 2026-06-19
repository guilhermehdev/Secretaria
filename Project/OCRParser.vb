Imports System.Data
Imports System.Text.RegularExpressions

Public Class OCRParser

    Public Shared Function TextoParaDataTable(
        texto As String) As DataTable

        Dim dt As New DataTable

        dt.Columns.Add("Nome")
        dt.Columns.Add("Nascimento")

        Dim linhas() As String =
            texto.Split(
                {vbCrLf, vbLf},
                StringSplitOptions.RemoveEmptyEntries)

        Dim rx As New Regex(
            "(.+?)\s+(\d{2}/\d{2}/\d{4})",
            RegexOptions.IgnoreCase)

        For Each linha As String In linhas

            Dim m As Match = rx.Match(linha)

            If m.Success Then

                Dim nome As String =
                    m.Groups(1).Value.Trim()

                Dim nascimento As String =
                    m.Groups(2).Value.Trim()

                dt.Rows.Add(
                    nome,
                    nascimento)

            End If

        Next

        Return dt

    End Function

End Class