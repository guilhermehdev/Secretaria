<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fmail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fmail))
        Me.cbEmail = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbDestino = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbAssunto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbAnexos = New System.Windows.Forms.Label()
        Me.btLimparEmail = New System.Windows.Forms.Button()
        Me.btSendEmail = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbTipoResposta = New System.Windows.Forms.ComboBox()
        Me.btAnexos = New System.Windows.Forms.Button()
        Me.tbEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbRespostas = New System.Windows.Forms.ComboBox()
        Me.btSair = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ofdAttachments = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbEmail
        '
        Me.cbEmail.FormattingEnabled = True
        Me.cbEmail.Location = New System.Drawing.Point(21, 41)
        Me.cbEmail.Name = "cbEmail"
        Me.cbEmail.Size = New System.Drawing.Size(226, 21)
        Me.cbEmail.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Email"
        '
        'lbDestino
        '
        Me.lbDestino.AutoSize = True
        Me.lbDestino.Location = New System.Drawing.Point(18, 19)
        Me.lbDestino.Name = "lbDestino"
        Me.lbDestino.Size = New System.Drawing.Size(43, 13)
        Me.lbDestino.TabIndex = 2
        Me.lbDestino.Text = "Destino"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbDestino)
        Me.GroupBox1.Location = New System.Drawing.Point(253, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(283, 44)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estabelecimento"
        '
        'tbAssunto
        '
        Me.tbAssunto.Location = New System.Drawing.Point(19, 44)
        Me.tbAssunto.Name = "tbAssunto"
        Me.tbAssunto.Size = New System.Drawing.Size(457, 20)
        Me.tbAssunto.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Assunto"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lbAnexos)
        Me.GroupBox2.Controls.Add(Me.btLimparEmail)
        Me.GroupBox2.Controls.Add(Me.btSendEmail)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cbTipoResposta)
        Me.GroupBox2.Controls.Add(Me.btAnexos)
        Me.GroupBox2.Controls.Add(Me.tbEmail)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbRespostas)
        Me.GroupBox2.Controls.Add(Me.tbAssunto)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 76)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(576, 466)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mensagem"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 422)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Anexos:"
        '
        'lbAnexos
        '
        Me.lbAnexos.AutoSize = True
        Me.lbAnexos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAnexos.Location = New System.Drawing.Point(65, 422)
        Me.lbAnexos.Name = "lbAnexos"
        Me.lbAnexos.Size = New System.Drawing.Size(0, 13)
        Me.lbAnexos.TabIndex = 29
        '
        'btLimparEmail
        '
        Me.btLimparEmail.Location = New System.Drawing.Point(499, 83)
        Me.btLimparEmail.Name = "btLimparEmail"
        Me.btLimparEmail.Size = New System.Drawing.Size(58, 21)
        Me.btLimparEmail.TabIndex = 28
        Me.btLimparEmail.Text = "Limpar"
        Me.btLimparEmail.UseVisualStyleBackColor = True
        '
        'btSendEmail
        '
        Me.btSendEmail.BackColor = System.Drawing.Color.Transparent
        '        Me.btSendEmail.BackgroundImage = Global.Project.My.Resources.Resources.sendmail
        Me.btSendEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btSendEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSendEmail.ForeColor = System.Drawing.Color.White
        Me.btSendEmail.Location = New System.Drawing.Point(506, 417)
        Me.btSendEmail.Name = "btSendEmail"
        Me.btSendEmail.Size = New System.Drawing.Size(51, 40)
        Me.btSendEmail.TabIndex = 24
        Me.ToolTip1.SetToolTip(Me.btSendEmail, "Enviar Email")
        Me.btSendEmail.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Tipo"
        '
        'cbTipoResposta
        '
        Me.cbTipoResposta.FormattingEnabled = True
        Me.cbTipoResposta.Items.AddRange(New Object() {"Todos", "Modelo Encaminhadas", "Modelo Duplicidades", "Modelo Esclarecimentos", "Modelo Elogio", "Modelo SAMU", "Reclamação a Coordenadores", "Elogio a Coordenadores"})
        Me.cbTipoResposta.Location = New System.Drawing.Point(19, 83)
        Me.cbTipoResposta.Name = "cbTipoResposta"
        Me.cbTipoResposta.Size = New System.Drawing.Size(171, 21)
        Me.cbTipoResposta.TabIndex = 26
        '
        'btAnexos
        '
        Me.btAnexos.Location = New System.Drawing.Point(482, 42)
        Me.btAnexos.Name = "btAnexos"
        Me.btAnexos.Size = New System.Drawing.Size(75, 23)
        Me.btAnexos.TabIndex = 25
        Me.btAnexos.Text = "Anexar"
        Me.btAnexos.UseVisualStyleBackColor = True
        '
        'tbEmail
        '
        Me.tbEmail.Location = New System.Drawing.Point(19, 110)
        Me.tbEmail.Multiline = True
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(538, 301)
        Me.tbEmail.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(196, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Respostas"
        '
        'cbRespostas
        '
        Me.cbRespostas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbRespostas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbRespostas.FormattingEnabled = True
        Me.cbRespostas.Location = New System.Drawing.Point(196, 83)
        Me.cbRespostas.Name = "cbRespostas"
        Me.cbRespostas.Size = New System.Drawing.Size(297, 21)
        Me.cbRespostas.TabIndex = 6
        '
        'btSair
        '
        Me.btSair.BackColor = System.Drawing.Color.DarkGray
        Me.btSair.FlatAppearance.BorderSize = 0
        Me.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSair.ForeColor = System.Drawing.Color.White
        Me.btSair.Location = New System.Drawing.Point(541, 31)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(56, 34)
        Me.btSair.TabIndex = 7
        Me.btSair.Text = "Sair"
        Me.btSair.UseVisualStyleBackColor = False
        '
        'ofdAttachments
        '
        Me.ofdAttachments.Multiselect = True
        Me.ofdAttachments.Title = "Selecione os arquivos"
        '
        'Fmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 554)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbEmail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Fmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enviar Email"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbEmail As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbDestino As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbAssunto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbRespostas As System.Windows.Forms.ComboBox
    Friend WithEvents tbEmail As System.Windows.Forms.TextBox
    Friend WithEvents btSendEmail As System.Windows.Forms.Button
    Friend WithEvents btAnexos As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbTipoResposta As System.Windows.Forms.ComboBox
    Friend WithEvents btSair As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btLimparEmail As System.Windows.Forms.Button
    Friend WithEvents ofdAttachments As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lbAnexos As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
