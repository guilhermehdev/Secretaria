<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCadastroServidorCNES
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCadastroServidorCNES))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbCPF = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbNome = New System.Windows.Forms.TextBox()
        Me.cbOrgao = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbRegConselho = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbDetalhe = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbEquipe = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NumericOutros = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NumericHosp = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numericAMB = New System.Windows.Forms.NumericUpDown()
        Me.cbUnidade = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbFormaContrato = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbCBO = New System.Windows.Forms.ComboBox()
        Me.btSair = New System.Windows.Forms.Button()
        Me.btSalvar = New System.Windows.Forms.Button()
        Me.btCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumericOutros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericHosp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericAMB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbCPF)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbNome)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(413, 98)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados do servidor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(283, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "CPF"
        '
        'tbCPF
        '
        Me.tbCPF.Location = New System.Drawing.Point(286, 50)
        Me.tbCPF.Mask = "999,999,999-99"
        Me.tbCPF.Name = "tbCPF"
        Me.tbCPF.Size = New System.Drawing.Size(96, 20)
        Me.tbCPF.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nome"
        '
        'tbNome
        '
        Me.tbNome.Location = New System.Drawing.Point(29, 50)
        Me.tbNome.Name = "tbNome"
        Me.tbNome.Size = New System.Drawing.Size(251, 20)
        Me.tbNome.TabIndex = 0
        '
        'cbOrgao
        '
        Me.cbOrgao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbOrgao.FormattingEnabled = True
        Me.cbOrgao.Location = New System.Drawing.Point(29, 93)
        Me.cbOrgao.Name = "cbOrgao"
        Me.cbOrgao.Size = New System.Drawing.Size(212, 21)
        Me.cbOrgao.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Orgão emissor"
        '
        'tbRegConselho
        '
        Me.tbRegConselho.Location = New System.Drawing.Point(247, 93)
        Me.tbRegConselho.Name = "tbRegConselho"
        Me.tbRegConselho.Size = New System.Drawing.Size(135, 20)
        Me.tbRegConselho.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(244, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Reg do conselho de classe"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cbDetalhe)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cbEquipe)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.cbUnidade)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cbFormaContrato)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbCBO)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cbOrgao)
        Me.GroupBox2.Controls.Add(Me.tbRegConselho)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 116)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(413, 357)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dados do vinculo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 220)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Detalhe da contratação"
        '
        'cbDetalhe
        '
        Me.cbDetalhe.FormattingEnabled = True
        Me.cbDetalhe.Location = New System.Drawing.Point(29, 236)
        Me.cbDetalhe.Name = "cbDetalhe"
        Me.cbDetalhe.Size = New System.Drawing.Size(351, 21)
        Me.cbDetalhe.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(26, 305)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Equipe destino"
        '
        'cbEquipe
        '
        Me.cbEquipe.FormattingEnabled = True
        Me.cbEquipe.Location = New System.Drawing.Point(29, 321)
        Me.cbEquipe.Name = "cbEquipe"
        Me.cbEquipe.Size = New System.Drawing.Size(351, 21)
        Me.cbEquipe.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(26, 263)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Unidade destino"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.NumericOutros)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.NumericHosp)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.numericAMB)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 121)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(353, 54)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Carga horaria"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(215, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "CH Outros"
        '
        'NumericOutros
        '
        Me.NumericOutros.Location = New System.Drawing.Point(277, 21)
        Me.NumericOutros.Name = "NumericOutros"
        Me.NumericOutros.Size = New System.Drawing.Size(33, 20)
        Me.NumericOutros.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(120, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "CH Hosp"
        '
        'NumericHosp
        '
        Me.NumericHosp.Location = New System.Drawing.Point(176, 21)
        Me.NumericHosp.Name = "NumericHosp"
        Me.NumericHosp.Size = New System.Drawing.Size(33, 20)
        Me.NumericHosp.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "CH Amb"
        '
        'numericAMB
        '
        Me.numericAMB.Location = New System.Drawing.Point(81, 22)
        Me.numericAMB.Name = "numericAMB"
        Me.numericAMB.Size = New System.Drawing.Size(33, 20)
        Me.numericAMB.TabIndex = 0
        '
        'cbUnidade
        '
        Me.cbUnidade.FormattingEnabled = True
        Me.cbUnidade.Location = New System.Drawing.Point(29, 281)
        Me.cbUnidade.Name = "cbUnidade"
        Me.cbUnidade.Size = New System.Drawing.Size(351, 21)
        Me.cbUnidade.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(196, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Forma de contrato com estabelecimento"
        '
        'cbFormaContrato
        '
        Me.cbFormaContrato.FormattingEnabled = True
        Me.cbFormaContrato.Location = New System.Drawing.Point(29, 194)
        Me.cbFormaContrato.Name = "cbFormaContrato"
        Me.cbFormaContrato.Size = New System.Drawing.Size(351, 21)
        Me.cbFormaContrato.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "CBO"
        '
        'cbCBO
        '
        Me.cbCBO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbCBO.FormattingEnabled = True
        Me.cbCBO.Location = New System.Drawing.Point(29, 53)
        Me.cbCBO.Name = "cbCBO"
        Me.cbCBO.Size = New System.Drawing.Size(353, 21)
        Me.cbCBO.TabIndex = 0
        '
        'btSair
        '
        Me.btSair.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSair.Location = New System.Drawing.Point(350, 479)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(75, 23)
        Me.btSair.TabIndex = 4
        Me.btSair.Text = "Fechar"
        Me.btSair.UseVisualStyleBackColor = True
        '
        'btSalvar
        '
        Me.btSalvar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvar.Location = New System.Drawing.Point(188, 479)
        Me.btSalvar.Name = "btSalvar"
        Me.btSalvar.Size = New System.Drawing.Size(75, 23)
        Me.btSalvar.TabIndex = 2
        Me.btSalvar.Text = "Salvar"
        Me.btSalvar.UseVisualStyleBackColor = True
        '
        'btCancelar
        '
        Me.btCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btCancelar.Location = New System.Drawing.Point(269, 479)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btCancelar.TabIndex = 3
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.UseVisualStyleBackColor = True
        '
        'FormCadastroServidorCNES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 513)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.btSalvar)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCadastroServidorCNES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Novo cadastro CNES"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumericOutros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericHosp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericAMB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbNome As TextBox
    Friend WithEvents tbCPF As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbOrgao As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbRegConselho As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbCBO As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents NumericOutros As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents NumericHosp As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents numericAMB As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents cbFormaContrato As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbEquipe As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cbUnidade As ComboBox
    Friend WithEvents btSair As Button
    Friend WithEvents btSalvar As Button
    Friend WithEvents btCancelar As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents cbDetalhe As ComboBox
End Class
