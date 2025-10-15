<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAMEbd
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbShowPass = New System.Windows.Forms.CheckBox()
        Me.tbUser = New System.Windows.Forms.TextBox()
        Me.btSave = New System.Windows.Forms.Button()
        Me.tbServer = New System.Windows.Forms.TextBox()
        Me.tbDatabase = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbPass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbShowPass)
        Me.GroupBox1.Controls.Add(Me.tbUser)
        Me.GroupBox1.Controls.Add(Me.btSave)
        Me.GroupBox1.Controls.Add(Me.tbServer)
        Me.GroupBox1.Controls.Add(Me.tbDatabase)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbPass)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 129)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Conexão Mysql"
        '
        'cbShowPass
        '
        Me.cbShowPass.AutoSize = True
        Me.cbShowPass.Location = New System.Drawing.Point(16, 106)
        Me.cbShowPass.Name = "cbShowPass"
        Me.cbShowPass.Size = New System.Drawing.Size(93, 17)
        Me.cbShowPass.TabIndex = 9
        Me.cbShowPass.Text = "Mostrar senha"
        Me.cbShowPass.UseVisualStyleBackColor = True
        '
        'tbUser
        '
        Me.tbUser.Location = New System.Drawing.Point(16, 44)
        Me.tbUser.Name = "tbUser"
        Me.tbUser.Size = New System.Drawing.Size(141, 20)
        Me.tbUser.TabIndex = 0
        Me.tbUser.Text = "root"
        '
        'btSave
        '
        Me.btSave.Location = New System.Drawing.Point(310, 44)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(75, 59)
        Me.btSave.TabIndex = 4
        Me.btSave.Text = "Salvar"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'tbServer
        '
        Me.tbServer.Location = New System.Drawing.Point(163, 44)
        Me.tbServer.Name = "tbServer"
        Me.tbServer.Size = New System.Drawing.Size(141, 20)
        Me.tbServer.TabIndex = 1
        Me.tbServer.Text = "localhost"
        '
        'tbDatabase
        '
        Me.tbDatabase.Location = New System.Drawing.Point(163, 83)
        Me.tbDatabase.Name = "tbDatabase"
        Me.tbDatabase.Size = New System.Drawing.Size(141, 20)
        Me.tbDatabase.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(160, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Server"
        '
        'tbPass
        '
        Me.tbPass.Location = New System.Drawing.Point(16, 83)
        Me.tbPass.Name = "tbPass"
        Me.tbPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPass.Size = New System.Drawing.Size(141, 20)
        Me.tbPass.TabIndex = 2
        Me.tbPass.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(160, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Database"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "User"
        '
        'FormAMEbd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 164)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormAMEbd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AME - Banco de dados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbShowPass As CheckBox
    Friend WithEvents tbUser As TextBox
    Friend WithEvents btSave As Button
    Friend WithEvents tbServer As TextBox
    Friend WithEvents tbDatabase As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbPass As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
