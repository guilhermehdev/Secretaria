Imports Microsoft.VisualBasic.Devices

Public Class FormLogin
    Dim m As New Main
    Public system As String
    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub
    Private Sub FormLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Fstart.Visible = True
    End Sub

    Private Sub btLogin_Click(sender As Object, e As EventArgs) Handles btLogin.Click
        If checkCredentials(cbUsuarios.SelectedValue) = 1 Then
            Select Case system
                Case "CNES"
                    FCNES.Show()
                Case "EMTU"
                    FmainEMTU.Show()
                Case "EOUVE"
                    FmainOuvidoria.Show()
            End Select
        End If
    End Sub
    Private Function checkCredentials(id As Integer)
        Dim userData = m.getDataset($"SELECT * FROM usuarios WHERE id ={id}")
        Dim eouve = userData.Rows(0).Item(5).ToString
        Dim emtu = userData.Rows(0).Item(6).ToString
        Dim cnes = userData.Rows(0).Item(7).ToString
        Dim pass = userData.Rows(0).Item(2)

        If tbSenha IsNot Nothing Then
            If tbSenha.Text = "" Then
                m.msgAlert("Digite a senha")
                tbSenha.Focus()
                Return 0
            ElseIf tbSenha.Text <> pass Then
                m.msgAlert("Senha inválida")
                tbSenha.Focus()
                Return 0
            End If
        End If

        Select Case system
            Case "CNES"
                If cnes = 1 And pass = tbSenha.Text Then
                    Return 1
                Else
                    Return 0
                End If
            Case "EMTU"
                If emtu = 1 And pass = tbSenha.Text Then
                    Return 1
                Else
                    Return 0
                End If
            Case "EOUVE"
                If eouve = 1 And pass = tbSenha.Text Then
                    Return 1
                Else
                    Return 0
                End If
            Case Else
                Return 0
        End Select

    End Function
    Private Sub FormLogin_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        m.loadComboBox("SELECT * FROM usuarios", cbUsuarios, "nome", "id")
    End Sub

End Class