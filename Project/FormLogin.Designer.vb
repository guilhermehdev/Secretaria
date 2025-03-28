<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogin
    Inherits Form



    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btFechar = New Button()
        Me.cbUsuarios = New ComboBox()
        Me.btLogin = New Button()
        Me.tbSenha = New TextBox()
        Me.Label1 = New Label()
        Me.Label2 = New Label()
        Me.Label3 = New Label()
        Me.SuspendLayout()
        '
        'btFechar
        '
        Me.btFechar.BackColor = Color.IndianRed
        Me.btFechar.Cursor = Cursors.Hand
        Me.btFechar.FlatAppearance.BorderColor = Color.Maroon
        Me.btFechar.FlatAppearance.MouseDownBackColor = Color.RosyBrown
        Me.btFechar.FlatAppearance.MouseOverBackColor = Color.Firebrick
        Me.btFechar.FlatStyle = FlatStyle.Flat
        Me.btFechar.ForeColor = Color.White
        Me.btFechar.Location = New Point(176, 93)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New Size(90, 23)
        Me.btFechar.TabIndex = 0
        Me.btFechar.Text = "Cancelar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'cbUsuarios
        '
        Me.cbUsuarios.FormattingEnabled = True
        Me.cbUsuarios.Location = New Point(77, 40)
        Me.cbUsuarios.Name = "cbUsuarios"
        Me.cbUsuarios.Size = New Size(189, 21)
        Me.cbUsuarios.TabIndex = 1
        '
        'btLogin
        '
        Me.btLogin.BackColor = Color.DarkSeaGreen
        Me.btLogin.Cursor = Cursors.Hand
        Me.btLogin.FlatAppearance.BorderColor = Color.ForestGreen
        Me.btLogin.FlatAppearance.MouseDownBackColor = Color.DarkGreen
        Me.btLogin.FlatAppearance.MouseOverBackColor = Color.LawnGreen
        Me.btLogin.FlatStyle = FlatStyle.Flat
        Me.btLogin.ForeColor = Color.White
        Me.btLogin.Location = New Point(77, 93)
        Me.btLogin.Name = "btLogin"
        Me.btLogin.Size = New Size(90, 23)
        Me.btLogin.TabIndex = 2
        Me.btLogin.Text = "OK"
        Me.btLogin.UseVisualStyleBackColor = False
        '
        'tbSenha
        '
        Me.tbSenha.Location = New Point(77, 67)
        Me.tbSenha.Name = "tbSenha"
        Me.tbSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbSenha.Size = New Size(189, 20)
        Me.tbSenha.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = Color.White
        Me.Label1.Location = New Point(32, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(43, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Usuário"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = Color.White
        Me.Label2.Location = New Point(37, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(38, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Senha"
        '
        'Label3
        '
        Me.Label3.BackColor = Color.DodgerBlue
        Me.Label3.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = Color.Yellow
        Me.Label3.Location = New Point(0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(307, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "LOGIN"
        Me.Label3.TextAlign = ContentAlignment.MiddleCenter
        '
        'FormLogin
        '
        Me.BackColor = Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New Size(307, 136)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbSenha)
        Me.Controls.Add(Me.btLogin)
        Me.Controls.Add(Me.cbUsuarios)
        Me.Controls.Add(Me.btFechar)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Name = "FormLogin"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btFechar As Button
    Friend WithEvents cbUsuarios As ComboBox
    Friend WithEvents btLogin As Button
    Friend WithEvents tbSenha As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
