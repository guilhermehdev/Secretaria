<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogin
    Inherits Form



    'Descartar substituições de formulário para limpar a lista de componentes.
    <Diagnostics.DebuggerNonUserCode()>
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
    Private components As ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FormLogin))
        Me.btFechar = New Windows.Forms.Button()
        Me.cbUsuarios = New Windows.Forms.ComboBox()
        Me.btLogin = New Windows.Forms.Button()
        Me.tbSenha = New Windows.Forms.TextBox()
        Me.Label1 = New Windows.Forms.Label()
        Me.Label2 = New Windows.Forms.Label()
        Me.Label3 = New Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btFechar
        '
        Me.btFechar.BackColor = Drawing.Color.IndianRed
        Me.btFechar.Cursor = Windows.Forms.Cursors.Hand
        Me.btFechar.FlatAppearance.BorderColor = Drawing.Color.Maroon
        Me.btFechar.FlatAppearance.MouseDownBackColor = Drawing.Color.RosyBrown
        Me.btFechar.FlatAppearance.MouseOverBackColor = Drawing.Color.Firebrick
        Me.btFechar.FlatStyle = Windows.Forms.FlatStyle.Flat
        Me.btFechar.ForeColor = Drawing.Color.White
        Me.btFechar.Location = New Drawing.Point(176, 93)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New Drawing.Size(90, 23)
        Me.btFechar.TabIndex = 0
        Me.btFechar.Text = "Cancelar"
        Me.btFechar.UseVisualStyleBackColor = False
        '
        'cbUsuarios
        '
        Me.cbUsuarios.FormattingEnabled = True
        Me.cbUsuarios.Location = New Drawing.Point(77, 40)
        Me.cbUsuarios.Name = "cbUsuarios"
        Me.cbUsuarios.Size = New Drawing.Size(189, 21)
        Me.cbUsuarios.TabIndex = 1
        '
        'btLogin
        '
        Me.btLogin.BackColor = Drawing.Color.DarkSeaGreen
        Me.btLogin.Cursor = Windows.Forms.Cursors.Hand
        Me.btLogin.FlatAppearance.BorderColor = Drawing.Color.ForestGreen
        Me.btLogin.FlatAppearance.MouseDownBackColor = Drawing.Color.DarkGreen
        Me.btLogin.FlatAppearance.MouseOverBackColor = Drawing.Color.LawnGreen
        Me.btLogin.FlatStyle = Windows.Forms.FlatStyle.Flat
        Me.btLogin.ForeColor = Drawing.Color.White
        Me.btLogin.Location = New Drawing.Point(77, 93)
        Me.btLogin.Name = "btLogin"
        Me.btLogin.Size = New Drawing.Size(90, 23)
        Me.btLogin.TabIndex = 2
        Me.btLogin.Text = "OK"
        Me.btLogin.UseVisualStyleBackColor = False
        '
        'tbSenha
        '
        Me.tbSenha.Location = New Drawing.Point(77, 67)
        Me.tbSenha.Name = "tbSenha"
        Me.tbSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbSenha.Size = New Drawing.Size(189, 20)
        Me.tbSenha.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = Drawing.Color.White
        Me.Label1.Location = New Drawing.Point(32, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Drawing.Size(43, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Usuário"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = Drawing.Color.White
        Me.Label2.Location = New Drawing.Point(37, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Drawing.Size(38, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Senha"
        '
        'Label3
        '
        Me.Label3.BackColor = Drawing.Color.DodgerBlue
        Me.Label3.Font = New Drawing.Font("Microsoft Sans Serif", 8.25!, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = Drawing.Color.Yellow
        Me.Label3.Location = New Drawing.Point(0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Drawing.Size(307, 25)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "LOGIN"
        Me.Label3.TextAlign = Drawing.ContentAlignment.MiddleCenter
        '
        'FormLogin
        '
        Me.BackColor = Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New Drawing.Size(307, 136)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbSenha)
        Me.Controls.Add(Me.btLogin)
        Me.Controls.Add(Me.cbUsuarios)
        Me.Controls.Add(Me.btFechar)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FormLogin"
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Secretaria - Login"
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
