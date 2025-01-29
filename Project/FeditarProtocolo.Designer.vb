<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FeditarProtocolo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FeditarProtocolo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.mtbEditar1contato = New System.Windows.Forms.MaskedTextBox()
        Me.btSendEmail = New System.Windows.Forms.Button()
        Me.btHoje = New System.Windows.Forms.Button()
        Me.btSair = New System.Windows.Forms.Button()
        Me.mtbEditarEncerramento = New System.Windows.Forms.MaskedTextBox()
        Me.btEditarExclusao = New System.Windows.Forms.Button()
        Me.mtbEditarAbertura = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbEditarStatus = New System.Windows.Forms.ComboBox()
        Me.btAtualizarProtocolo = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbEditarFormaEnvio = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbEditarDestinatario = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbEditarOrigem = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbEditarProtocolo = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.mtbEditar1contato)
        Me.GroupBox1.Controls.Add(Me.btSendEmail)
        Me.GroupBox1.Controls.Add(Me.btHoje)
        Me.GroupBox1.Controls.Add(Me.btSair)
        Me.GroupBox1.Controls.Add(Me.mtbEditarEncerramento)
        Me.GroupBox1.Controls.Add(Me.btEditarExclusao)
        Me.GroupBox1.Controls.Add(Me.mtbEditarAbertura)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cbEditarStatus)
        Me.GroupBox1.Controls.Add(Me.btAtualizarProtocolo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbEditarFormaEnvio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbEditarDestinatario)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbEditarOrigem)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbEditarProtocolo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 193)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(299, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Email:"
        '
        'mtbEditar1contato
        '
        Me.mtbEditar1contato.Location = New System.Drawing.Point(234, 100)
        Me.mtbEditar1contato.Mask = "00/00/0000"
        Me.mtbEditar1contato.Name = "mtbEditar1contato"
        Me.mtbEditar1contato.Size = New System.Drawing.Size(81, 20)
        Me.mtbEditar1contato.TabIndex = 26
        Me.mtbEditar1contato.ValidatingType = GetType(Date)
        '
        'btSendEmail
        '
        Me.btSendEmail.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btSendEmail.BackgroundImage = CType(resources.GetObject("btSendEmail.BackgroundImage"), System.Drawing.Image)
        Me.btSendEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btSendEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSendEmail.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btSendEmail.Location = New System.Drawing.Point(335, 139)
        Me.btSendEmail.Name = "btSendEmail"
        Me.btSendEmail.Size = New System.Drawing.Size(45, 39)
        Me.btSendEmail.TabIndex = 25
        Me.ToolTip1.SetToolTip(Me.btSendEmail, "Enviar Email")
        Me.btSendEmail.UseVisualStyleBackColor = False
        '
        'btHoje
        '
        Me.btHoje.Location = New System.Drawing.Point(126, 147)
        Me.btHoje.Name = "btHoje"
        Me.btHoje.Size = New System.Drawing.Size(21, 23)
        Me.btHoje.TabIndex = 22
        Me.btHoje.Text = "H"
        Me.btHoje.UseVisualStyleBackColor = True
        '
        'btSair
        '
        Me.btSair.BackColor = System.Drawing.Color.DarkGray
        Me.btSair.FlatAppearance.BorderSize = 0
        Me.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSair.ForeColor = System.Drawing.Color.White
        Me.btSair.Location = New System.Drawing.Point(386, 139)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(51, 39)
        Me.btSair.TabIndex = 7
        Me.btSair.Text = "Sair"
        Me.btSair.UseVisualStyleBackColor = False
        '
        'mtbEditarEncerramento
        '
        Me.mtbEditarEncerramento.Location = New System.Drawing.Point(25, 149)
        Me.mtbEditarEncerramento.Mask = "00/00/0000 90:00"
        Me.mtbEditarEncerramento.Name = "mtbEditarEncerramento"
        Me.mtbEditarEncerramento.Size = New System.Drawing.Size(101, 20)
        Me.mtbEditarEncerramento.TabIndex = 21
        Me.mtbEditarEncerramento.ValidatingType = GetType(Date)
        '
        'btEditarExclusao
        '
        Me.btEditarExclusao.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btEditarExclusao.BackgroundImage = CType(resources.GetObject("btEditarExclusao.BackgroundImage"), System.Drawing.Image)
        Me.btEditarExclusao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btEditarExclusao.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btEditarExclusao.FlatAppearance.BorderSize = 0
        Me.btEditarExclusao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btEditarExclusao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEditarExclusao.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btEditarExclusao.Location = New System.Drawing.Point(222, 139)
        Me.btEditarExclusao.Name = "btEditarExclusao"
        Me.btEditarExclusao.Size = New System.Drawing.Size(47, 39)
        Me.btEditarExclusao.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.btEditarExclusao, "Excluir")
        Me.btEditarExclusao.UseVisualStyleBackColor = False
        '
        'mtbEditarAbertura
        '
        Me.mtbEditarAbertura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mtbEditarAbertura.Location = New System.Drawing.Point(147, 100)
        Me.mtbEditarAbertura.Name = "mtbEditarAbertura"
        Me.mtbEditarAbertura.Size = New System.Drawing.Size(81, 20)
        Me.mtbEditarAbertura.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 133)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Encerramento"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(318, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Status"
        '
        'cbEditarStatus
        '
        Me.cbEditarStatus.FormattingEnabled = True
        Me.cbEditarStatus.Items.AddRange(New Object() {"Em andamento", "Concluido", "Duplicado", "Cancelado", "Reencaminhado", "Elogio"})
        Me.cbEditarStatus.Location = New System.Drawing.Point(321, 99)
        Me.cbEditarStatus.Name = "cbEditarStatus"
        Me.cbEditarStatus.Size = New System.Drawing.Size(116, 21)
        Me.cbEditarStatus.TabIndex = 16
        Me.cbEditarStatus.Tag = "Destinatário"
        '
        'btAtualizarProtocolo
        '
        Me.btAtualizarProtocolo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btAtualizarProtocolo.BackgroundImage = Global.Project.My.Resources.Resources.save_icon32
        Me.btAtualizarProtocolo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btAtualizarProtocolo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAtualizarProtocolo.FlatAppearance.BorderSize = 0
        Me.btAtualizarProtocolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAtualizarProtocolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAtualizarProtocolo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btAtualizarProtocolo.Location = New System.Drawing.Point(167, 139)
        Me.btAtualizarProtocolo.Name = "btAtualizarProtocolo"
        Me.btAtualizarProtocolo.Size = New System.Drawing.Size(49, 39)
        Me.btAtualizarProtocolo.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btAtualizarProtocolo, "Atualizar")
        Me.btAtualizarProtocolo.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(231, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "1º Contato"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(144, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Abertura"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Forma de envio"
        '
        'cbEditarFormaEnvio
        '
        Me.cbEditarFormaEnvio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbEditarFormaEnvio.FormattingEnabled = True
        Me.cbEditarFormaEnvio.Items.AddRange(New Object() {"Email", "Em mãos"})
        Me.cbEditarFormaEnvio.Location = New System.Drawing.Point(25, 100)
        Me.cbEditarFormaEnvio.Name = "cbEditarFormaEnvio"
        Me.cbEditarFormaEnvio.Size = New System.Drawing.Size(116, 21)
        Me.cbEditarFormaEnvio.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Destinatário"
        '
        'cbEditarDestinatario
        '
        Me.cbEditarDestinatario.FormattingEnabled = True
        Me.cbEditarDestinatario.Location = New System.Drawing.Point(234, 47)
        Me.cbEditarDestinatario.Name = "cbEditarDestinatario"
        Me.cbEditarDestinatario.Size = New System.Drawing.Size(203, 21)
        Me.cbEditarDestinatario.TabIndex = 4
        Me.cbEditarDestinatario.Tag = "Destinatário"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Canal de origem"
        '
        'cbEditarOrigem
        '
        Me.cbEditarOrigem.FormattingEnabled = True
        Me.cbEditarOrigem.Items.AddRange(New Object() {"eOuve", "OuvidorSUS"})
        Me.cbEditarOrigem.Location = New System.Drawing.Point(136, 47)
        Me.cbEditarOrigem.Name = "cbEditarOrigem"
        Me.cbEditarOrigem.Size = New System.Drawing.Size(92, 21)
        Me.cbEditarOrigem.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nº Protocolo"
        '
        'tbEditarProtocolo
        '
        Me.tbEditarProtocolo.BackColor = System.Drawing.SystemColors.ControlText
        Me.tbEditarProtocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbEditarProtocolo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.tbEditarProtocolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEditarProtocolo.ForeColor = System.Drawing.Color.Orange
        Me.tbEditarProtocolo.Location = New System.Drawing.Point(25, 46)
        Me.tbEditarProtocolo.Name = "tbEditarProtocolo"
        Me.tbEditarProtocolo.ReadOnly = True
        Me.tbEditarProtocolo.Size = New System.Drawing.Size(105, 22)
        Me.tbEditarProtocolo.TabIndex = 0
        Me.tbEditarProtocolo.TabStop = False
        Me.tbEditarProtocolo.Tag = "Nº Protocolo"
        '
        'FeditarProtocolo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 227)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FeditarProtocolo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Protocolos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btAtualizarProtocolo As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbEditarFormaEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbEditarDestinatario As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbEditarOrigem As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbEditarProtocolo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbEditarStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btSair As System.Windows.Forms.Button
    Friend WithEvents mtbEditarAbertura As System.Windows.Forms.DateTimePicker
    Friend WithEvents btEditarExclusao As System.Windows.Forms.Button
    Friend WithEvents mtbEditarEncerramento As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btHoje As System.Windows.Forms.Button
    Friend WithEvents btSendEmail As System.Windows.Forms.Button
    Friend WithEvents mtbEditar1contato As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
