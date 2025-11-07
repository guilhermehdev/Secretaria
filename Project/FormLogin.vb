Imports Microsoft.VisualBasic.Devices

Public Class FormLogin
    Dim m As New Main
    Public system As String
    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        Me.Close()
    End Sub
    Private Sub FormLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Application.OpenForms.Count = 1 AndAlso Application.OpenForms(0) Is Me Then
            FormSystemStart.Visible = True
        End If
    End Sub

    Private Sub btLogin_Click(sender As Object, e As EventArgs) Handles btLogin.Click
        If checkCredentials(cbUsuarios.SelectedValue) = 1 Then
            Me.Cursor = Cursors.WaitCursor
            Select Case system
                Case "CNES"
                    FormCNESmain.Show()
                    Me.Visible = False
                Case "EMTU"
                    FormEMTUmain.Show()
                    Me.Visible = False
                Case "EOUVE"
                    FormOuvidoriaMain.Show()
                    Me.Visible = False
                Case "CADUSUARIOS"
                    FormLoginCadUsuario.Show()
                    Me.Visible = False
                Case "AME"
                    FormAMEOCI.idUser = cbUsuarios.SelectedValue
                    FormAMEOCI.Show()
                    Me.Visible = False
                Case "NUMAPAC"
                    FormAMEOCINumAPAC.Show()
                    Me.Visible = False
            End Select
        End If
    End Sub
    Private Function checkCredentials(id As Integer)
        Dim userData = m.getDataset($"SELECT * FROM usuarios WHERE id ={id}")
        Dim pass = userData.Rows(0).Item(2)
        Dim level = userData.Rows(0).Item(4)
        Dim eouve = userData.Rows(0).Item(5).ToString
        Dim emtu = userData.Rows(0).Item(6).ToString
        Dim cnes = userData.Rows(0).Item(7).ToString
        Dim ame = userData.Rows(0).Item(8).ToString
        Dim num_apac = userData.Rows(0).Item(9).ToString


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
                    m.msgAlert("Senha inválida")
                    Return 0
                End If
            Case "EMTU"
                If emtu = 1 And pass = tbSenha.Text Then
                    Return 1
                Else
                    m.msgAlert("Senha inválida")
                    Return 0
                End If
            Case "EOUVE"
                If eouve = 1 And pass = tbSenha.Text Then
                    Return 1
                Else
                    m.msgAlert("Senha inválida")
                    Return 0
                End If
            Case "CADUSUARIOS"
                If level = 10 And pass = tbSenha.Text Then
                    Return 1
                Else
                    m.msgAlert("Senha inválida")
                    Return 0
                End If
            Case "AME"
                If ame = 1 And pass = tbSenha.Text Then
                    Return 1
                Else
                    m.msgAlert("Senha inválida")
                    Return 0
                End If
            Case "NUMAPAC"
                If num_apac = 1 And pass = tbSenha.Text Then
                    Return 1
                Else
                    m.msgAlert("Senha inválida")
                    Return 0
                End If
            Case Else
                Return 0

        End Select

    End Function

    Private Sub FormLogin_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        tbSenha.Clear()
        tbSenha.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cbUsuarios_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbUsuarios.SelectionChangeCommitted
        tbSenha.Focus()
    End Sub
    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            m.loadComboBox("SELECT * FROM usuarios WHERE ativo=1", cbUsuarios, "nome", "id")
        Catch ex As Exception
            FormSystemConnSettings.ShowDialog()
        End Try

    End Sub
    Private Sub FormLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            btLogin_Click(sender, e)
        End If

    End Sub

End Class