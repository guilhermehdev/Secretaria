<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cbUsuarios = New System.Windows.Forms.ComboBox()
        Me.tbSenha = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btLogin = New System.Windows.Forms.Button()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbUsuarios
        '
        Me.cbUsuarios.FormattingEnabled = True
        Me.cbUsuarios.Location = New System.Drawing.Point(9, 44)
        Me.cbUsuarios.Name = "cbUsuarios"
        Me.cbUsuarios.Size = New System.Drawing.Size(217, 21)
        Me.cbUsuarios.TabIndex = 0
        '
        'tbSenha
        '
        Me.tbSenha.Location = New System.Drawing.Point(9, 90)
        Me.tbSenha.Name = "tbSenha"
        Me.tbSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbSenha.Size = New System.Drawing.Size(157, 20)
        Me.tbSenha.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Usuário"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Senha"
        '
        'btLogin
        '
        Me.btLogin.BackColor = System.Drawing.Color.SeaGreen
        Me.btLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btLogin.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen
        Me.btLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green
        Me.btLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime
        Me.btLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btLogin.ForeColor = System.Drawing.Color.White
        Me.btLogin.Location = New System.Drawing.Point(172, 88)
        Me.btLogin.Name = "btLogin"
        Me.btLogin.Size = New System.Drawing.Size(54, 23)
        Me.btLogin.TabIndex = 4
        Me.btLogin.Text = "Login"
        Me.btLogin.UseVisualStyleBackColor = False
        '
        'btFechar
        '
        Me.btFechar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btFechar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btFechar.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.btFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btFechar.ForeColor = System.Drawing.Color.White
        Me.btFechar.Location = New System.Drawing.Point(204, 3)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(26, 23)
        Me.btFechar.TabIndex = 5
        Me.btFechar.Text = "X"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'FormLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(233, 128)
        Me.Controls.Add(Me.btFechar)
        Me.Controls.Add(Me.btLogin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbSenha)
        Me.Controls.Add(Me.cbUsuarios)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormLogin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbUsuarios As ComboBox
    Friend WithEvents tbSenha As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btLogin As Button
    Friend WithEvents btFechar As Button
End Class
