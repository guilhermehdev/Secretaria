<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FnovoProtocolo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FnovoProtocolo))
        Me.gbDadosProtocolo = New System.Windows.Forms.GroupBox()
        Me.btSair = New System.Windows.Forms.Button()
        Me.btEnviarEmail = New System.Windows.Forms.Button()
        Me.btSalvarProtocolo = New System.Windows.Forms.Button()
        Me.mtbAbertura = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbFormaEnvio = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbDestinatario = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbOrigem = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbProtocolo = New System.Windows.Forms.TextBox()
        Me.gbDadosProtocolo.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDadosProtocolo
        '
        Me.gbDadosProtocolo.Controls.Add(Me.btSair)
        Me.gbDadosProtocolo.Controls.Add(Me.btEnviarEmail)
        Me.gbDadosProtocolo.Controls.Add(Me.btSalvarProtocolo)
        Me.gbDadosProtocolo.Controls.Add(Me.mtbAbertura)
        Me.gbDadosProtocolo.Controls.Add(Me.Label5)
        Me.gbDadosProtocolo.Controls.Add(Me.Label4)
        Me.gbDadosProtocolo.Controls.Add(Me.cbFormaEnvio)
        Me.gbDadosProtocolo.Controls.Add(Me.Label3)
        Me.gbDadosProtocolo.Controls.Add(Me.cbDestinatario)
        Me.gbDadosProtocolo.Controls.Add(Me.Label2)
        Me.gbDadosProtocolo.Controls.Add(Me.cbOrigem)
        Me.gbDadosProtocolo.Controls.Add(Me.Label1)
        Me.gbDadosProtocolo.Controls.Add(Me.tbProtocolo)
        Me.gbDadosProtocolo.Location = New System.Drawing.Point(12, 12)
        Me.gbDadosProtocolo.Name = "gbDadosProtocolo"
        Me.gbDadosProtocolo.Size = New System.Drawing.Size(367, 192)
        Me.gbDadosProtocolo.TabIndex = 0
        Me.gbDadosProtocolo.TabStop = False
        Me.gbDadosProtocolo.Text = "Dados"
        '
        'btSair
        '
        Me.btSair.BackColor = System.Drawing.Color.DarkGray
        Me.btSair.FlatAppearance.BorderSize = 0
        Me.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSair.ForeColor = System.Drawing.Color.White
        Me.btSair.Location = New System.Drawing.Point(287, 151)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(56, 20)
        Me.btSair.TabIndex = 6
        Me.btSair.Text = "Sair"
        Me.btSair.UseVisualStyleBackColor = False
        '
        'btEnviarEmail
        '
        Me.btEnviarEmail.BackColor = System.Drawing.Color.DarkOrange
        Me.btEnviarEmail.FlatAppearance.BorderSize = 0
        Me.btEnviarEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btEnviarEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btEnviarEmail.ForeColor = System.Drawing.Color.White
        Me.btEnviarEmail.Location = New System.Drawing.Point(199, 151)
        Me.btEnviarEmail.Name = "btEnviarEmail"
        Me.btEnviarEmail.Size = New System.Drawing.Size(81, 20)
        Me.btEnviarEmail.TabIndex = 16
        Me.btEnviarEmail.Text = "Email"
        Me.btEnviarEmail.UseVisualStyleBackColor = False
        '
        'btSalvarProtocolo
        '
        Me.btSalvarProtocolo.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btSalvarProtocolo.FlatAppearance.BorderSize = 0
        Me.btSalvarProtocolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSalvarProtocolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSalvarProtocolo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btSalvarProtocolo.Location = New System.Drawing.Point(112, 151)
        Me.btSalvarProtocolo.Name = "btSalvarProtocolo"
        Me.btSalvarProtocolo.Size = New System.Drawing.Size(81, 20)
        Me.btSalvarProtocolo.TabIndex = 7
        Me.btSalvarProtocolo.Text = "Salvar"
        Me.btSalvarProtocolo.UseVisualStyleBackColor = False
        '
        'mtbAbertura
        '
        Me.mtbAbertura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mtbAbertura.Location = New System.Drawing.Point(25, 151)
        Me.mtbAbertura.Name = "mtbAbertura"
        Me.mtbAbertura.Size = New System.Drawing.Size(81, 20)
        Me.mtbAbertura.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Abertura"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(231, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Forma de envio"
        '
        'cbFormaEnvio
        '
        Me.cbFormaEnvio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbFormaEnvio.FormattingEnabled = True
        Me.cbFormaEnvio.Items.AddRange(New Object() {"Email", "Em mãos"})
        Me.cbFormaEnvio.Location = New System.Drawing.Point(234, 98)
        Me.cbFormaEnvio.Name = "cbFormaEnvio"
        Me.cbFormaEnvio.Size = New System.Drawing.Size(109, 21)
        Me.cbFormaEnvio.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Destinatário"
        '
        'cbDestinatario
        '
        Me.cbDestinatario.FormattingEnabled = True
        Me.cbDestinatario.Location = New System.Drawing.Point(25, 98)
        Me.cbDestinatario.Name = "cbDestinatario"
        Me.cbDestinatario.Size = New System.Drawing.Size(203, 21)
        Me.cbDestinatario.TabIndex = 4
        Me.cbDestinatario.Tag = "Destinatário"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Canal de origem"
        '
        'cbOrigem
        '
        Me.cbOrigem.FormattingEnabled = True
        Me.cbOrigem.Items.AddRange(New Object() {"eOuve", "OuvidorSUS"})
        Me.cbOrigem.Location = New System.Drawing.Point(182, 47)
        Me.cbOrigem.Name = "cbOrigem"
        Me.cbOrigem.Size = New System.Drawing.Size(161, 21)
        Me.cbOrigem.TabIndex = 2
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
        'tbProtocolo
        '
        Me.tbProtocolo.BackColor = System.Drawing.SystemColors.ControlText
        Me.tbProtocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbProtocolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbProtocolo.ForeColor = System.Drawing.Color.Orange
        Me.tbProtocolo.Location = New System.Drawing.Point(25, 46)
        Me.tbProtocolo.MaxLength = 8
        Me.tbProtocolo.Name = "tbProtocolo"
        Me.tbProtocolo.Size = New System.Drawing.Size(151, 22)
        Me.tbProtocolo.TabIndex = 0
        Me.tbProtocolo.Tag = "Nº Protocolo"
        '
        'FnovoProtocolo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 221)
        Me.Controls.Add(Me.gbDadosProtocolo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FnovoProtocolo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Novo Protocolo"
        Me.gbDadosProtocolo.ResumeLayout(False)
        Me.gbDadosProtocolo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDadosProtocolo As System.Windows.Forms.GroupBox
    Friend WithEvents btSair As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbProtocolo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbOrigem As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbDestinatario As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbFormaEnvio As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btSalvarProtocolo As System.Windows.Forms.Button
    Friend WithEvents mtbAbertura As System.Windows.Forms.DateTimePicker
    Friend WithEvents btEnviarEmail As System.Windows.Forms.Button
End Class
