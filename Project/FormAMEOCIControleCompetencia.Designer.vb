<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAMEOCIControleCompetencia
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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtUf = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtDestinoTipo = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtOrgaoDestino = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCPFDiretor = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNomeDiretor = New System.Windows.Forms.TextBox()
        Me.txtCompetencia = New System.Windows.Forms.TextBox()
        Me.txtSiglaOrgao = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOrgaoOrigem = New System.Windows.Forms.TextBox()
        Me.txtCGC = New System.Windows.Forms.TextBox()
        Me.txtCnsDiretor = New System.Windows.Forms.TextBox()
        Me.btSalvar = New System.Windows.Forms.Button()
        Me.btSair = New System.Windows.Forms.Button()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtUf)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.txtDestinoTipo)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.txtOrgaoDestino)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.txtCPFDiretor)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.txtNomeDiretor)
        Me.GroupBox5.Controls.Add(Me.txtCompetencia)
        Me.GroupBox5.Controls.Add(Me.txtSiglaOrgao)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.txtOrgaoOrigem)
        Me.GroupBox5.Controls.Add(Me.txtCGC)
        Me.GroupBox5.Controls.Add(Me.txtCnsDiretor)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(497, 157)
        Me.GroupBox5.TabIndex = 23
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Orgão responsável pela informação"
        '
        'txtUf
        '
        Me.txtUf.FormattingEnabled = True
        Me.txtUf.Location = New System.Drawing.Point(83, 48)
        Me.txtUf.Name = "txtUf"
        Me.txtUf.Size = New System.Drawing.Size(44, 21)
        Me.txtUf.TabIndex = 33
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(443, 110)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(28, 13)
        Me.Label29.TabIndex = 32
        Me.Label29.Text = "Tipo"
        '
        'txtDestinoTipo
        '
        Me.txtDestinoTipo.FormattingEnabled = True
        Me.txtDestinoTipo.Items.AddRange(New Object() {"M", "E"})
        Me.txtDestinoTipo.Location = New System.Drawing.Point(446, 124)
        Me.txtDestinoTipo.Name = "txtDestinoTipo"
        Me.txtDestinoTipo.Size = New System.Drawing.Size(45, 21)
        Me.txtDestinoTipo.TabIndex = 31
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(132, 110)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(73, 13)
        Me.Label28.TabIndex = 30
        Me.Label28.Text = "Orgão destino"
        '
        'txtOrgaoDestino
        '
        Me.txtOrgaoDestino.Location = New System.Drawing.Point(134, 125)
        Me.txtOrgaoDestino.Name = "txtOrgaoDestino"
        Me.txtOrgaoDestino.Size = New System.Drawing.Size(306, 20)
        Me.txtOrgaoDestino.TabIndex = 29
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 111)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "CPF Diretor"
        '
        'txtCPFDiretor
        '
        Me.txtCPFDiretor.Location = New System.Drawing.Point(14, 125)
        Me.txtCPFDiretor.Name = "txtCPFDiretor"
        Me.txtCPFDiretor.Size = New System.Drawing.Size(113, 20)
        Me.txtCPFDiretor.TabIndex = 27
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(254, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Diretor da Unidade"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(439, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Sigla"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(131, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "CNS Diretor"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(80, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "UF"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(131, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Nome"
        '
        'txtNomeDiretor
        '
        Me.txtNomeDiretor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomeDiretor.Location = New System.Drawing.Point(256, 87)
        Me.txtNomeDiretor.Name = "txtNomeDiretor"
        Me.txtNomeDiretor.Size = New System.Drawing.Size(235, 20)
        Me.txtNomeDiretor.TabIndex = 4
        '
        'txtCompetencia
        '
        Me.txtCompetencia.Location = New System.Drawing.Point(13, 48)
        Me.txtCompetencia.Name = "txtCompetencia"
        Me.txtCompetencia.Size = New System.Drawing.Size(64, 20)
        Me.txtCompetencia.TabIndex = 0
        '
        'txtSiglaOrgao
        '
        Me.txtSiglaOrgao.Location = New System.Drawing.Point(442, 48)
        Me.txtSiglaOrgao.Name = "txtSiglaOrgao"
        Me.txtSiglaOrgao.Size = New System.Drawing.Size(49, 20)
        Me.txtSiglaOrgao.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "CNPJ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Competência"
        '
        'txtOrgaoOrigem
        '
        Me.txtOrgaoOrigem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrgaoOrigem.Location = New System.Drawing.Point(134, 48)
        Me.txtOrgaoOrigem.Name = "txtOrgaoOrigem"
        Me.txtOrgaoOrigem.Size = New System.Drawing.Size(302, 20)
        Me.txtOrgaoOrigem.TabIndex = 9
        '
        'txtCGC
        '
        Me.txtCGC.Location = New System.Drawing.Point(13, 87)
        Me.txtCGC.Name = "txtCGC"
        Me.txtCGC.Size = New System.Drawing.Size(115, 20)
        Me.txtCGC.TabIndex = 11
        '
        'txtCnsDiretor
        '
        Me.txtCnsDiretor.Location = New System.Drawing.Point(134, 87)
        Me.txtCnsDiretor.Name = "txtCnsDiretor"
        Me.txtCnsDiretor.Size = New System.Drawing.Size(116, 20)
        Me.txtCnsDiretor.TabIndex = 8
        '
        'btSalvar
        '
        Me.btSalvar.Location = New System.Drawing.Point(353, 175)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btSalvar.TabIndex = 24
        Me.btSalvar.Text = "Salvar"
        Me.btSalvar.UseVisualStyleBackColor = True
        '
        'btSair
        '
        Me.btSair.Location = New System.Drawing.Point(434, 175)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(75, 23)
        Me.btSair.TabIndex = 25
        Me.btSair.Text = "Sair"
        Me.btSair.UseVisualStyleBackColor = True
        '
        'FormAMEOCIControleCompetencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 215)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.btSalvar)
        Me.Controls.Add(Me.GroupBox5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAMEOCIControleCompetencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Controle de Competência"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtUf As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtDestinoTipo As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtOrgaoDestino As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCPFDiretor As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNomeDiretor As TextBox
    Friend WithEvents txtCompetencia As TextBox
    Friend WithEvents txtSiglaOrgao As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtOrgaoOrigem As TextBox
    Friend WithEvents txtCGC As TextBox
    Friend WithEvents txtCnsDiretor As TextBox
    Friend WithEvents btSalvar As Button
    Friend WithEvents btSair As Button
End Class
