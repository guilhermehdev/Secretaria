Imports Microsoft.VisualBasic.Devices

Public Class FormLogin
    Dim m As New Main
    Dim m2 As New FormAMEmain
    Public system As String

    Public Sub closeForms(formPermitido As Form)

        For Each frm As Form In My.Application.OpenForms.Cast(Of Form).ToList()

            If frm IsNot formPermitido Or frm IsNot Me Then
                frm.Close()
            End If

        Next

    End Sub

    Private Sub btFechar_Click(sender As Object, e As EventArgs) Handles btFechar.Click
        'Application.Exit()
        closeForms(FormSystemStart)
        FormSystemStart.Show()
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
                    FormCNESPlanejamento.Show()
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
                    FormAMEOCI.idUser = cbUsuarios.SelectedValue
                    FormAMEOCIGeradorAPAC.ShowDialog()
                    Me.Visible = False
            End Select
        End If

    End Sub
    Private Function checkCredentials(id As Integer)
        Dim userData
        Dim pass
        Dim level = Nothing
        Dim eouve = Nothing
        Dim emtu = Nothing
        Dim cnes = Nothing
        Dim ame = Nothing
        Dim num_apac = Nothing

        If system = "AME" Or system = "NUMAPAC" Then
            userData = m2.getDataset($"SELECT * FROM usuarios WHERE id ={id} AND ativo=1")
            Try
                pass = userData.Rows(0).Item(5).ToString
            Catch ex As Exception
                MessageBox.Show("Usuário não encontrado./Senha inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 0
            End Try
            num_apac = 1
            ame = 1
        Else
            userData = m.getDataset($"SELECT * FROM usuarios WHERE id ={id} AND ativo=1")
            pass = userData.Rows(0).Item(2)
            level = userData.Rows(0).Item(4)
            eouve = userData.Rows(0).Item(5).ToString
            emtu = userData.Rows(0).Item(6).ToString
            cnes = userData.Rows(0).Item(7).ToString
            ame = userData.Rows(0).Item(8).ToString
            num_apac = userData.Rows(0).Item(9).ToString
        End If

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
            If system = "AME" Or system = "NUMAPAC" Then
                m2.loadComboBox("SELECT * FROM usuarios WHERE ativo=1", cbUsuarios, "nome", "id")
            Else
                m.loadComboBox("SELECT * FROM usuarios WHERE ativo=1", cbUsuarios, "nome", "id")
            End If

        Catch ex As Exception
            If system = "AME" Or system = "NUMAPAC" Then
                FormAMEbd.ShowDialog()
            Else
                FormSystemConnSettings.ShowDialog()
            End If
        End Try

    End Sub
    Private Sub FormLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            btLogin_Click(sender, e)
        End If

    End Sub

End Class