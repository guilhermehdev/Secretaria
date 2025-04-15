<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormNovoCadastroCNES
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNovoCadastroCNES))
        Me.dgCadastrosPendentes = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbCBO = New System.Windows.Forms.TextBox()
        Me.tbEquipe = New System.Windows.Forms.TextBox()
        Me.tbUnidade = New System.Windows.Forms.TextBox()
        Me.tbDetalhe = New System.Windows.Forms.TextBox()
        Me.tbFormaContrato = New System.Windows.Forms.TextBox()
        Me.tbOrgao = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NumericOutros = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NumericHosp = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numericAMB = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbRegConselho = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btFechar = New System.Windows.Forms.Button()
        Me.btConcluirCadastro = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgHistorico = New System.Windows.Forms.DataGridView()
        CType(Me.dgCadastrosPendentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumericOutros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericHosp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericAMB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgCadastrosPendentes
        '
        Me.dgCadastrosPendentes.AllowUserToAddRows = False
        Me.dgCadastrosPendentes.AllowUserToDeleteRows = False
        Me.dgCadastrosPendentes.AllowUserToOrderColumns = True
        Me.dgCadastrosPendentes.AllowUserToResizeRows = False
        Me.dgCadastrosPendentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCadastrosPendentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgCadastrosPendentes.BackgroundColor = System.Drawing.Color.White
        Me.dgCadastrosPendentes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgCadastrosPendentes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgCadastrosPendentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCadastrosPendentes.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgCadastrosPendentes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgCadastrosPendentes.Location = New System.Drawing.Point(6, 6)
        Me.dgCadastrosPendentes.MultiSelect = False
        Me.dgCadastrosPendentes.Name = "dgCadastrosPendentes"
        Me.dgCadastrosPendentes.ReadOnly = True
        Me.dgCadastrosPendentes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCadastrosPendentes.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgCadastrosPendentes.RowHeadersWidth = 4
        Me.dgCadastrosPendentes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgCadastrosPendentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCadastrosPendentes.Size = New System.Drawing.Size(367, 384)
        Me.dgCadastrosPendentes.TabIndex = 31
        Me.dgCadastrosPendentes.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbCBO)
        Me.GroupBox2.Controls.Add(Me.tbEquipe)
        Me.GroupBox2.Controls.Add(Me.tbUnidade)
        Me.GroupBox2.Controls.Add(Me.tbDetalhe)
        Me.GroupBox2.Controls.Add(Me.tbFormaContrato)
        Me.GroupBox2.Controls.Add(Me.tbOrgao)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.tbRegConselho)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(379, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(413, 365)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dados do vinculo"
        '
        'tbCBO
        '
        Me.tbCBO.Location = New System.Drawing.Point(29, 53)
        Me.tbCBO.Name = "tbCBO"
        Me.tbCBO.Size = New System.Drawing.Size(353, 20)
        Me.tbCBO.TabIndex = 0
        '
        'tbEquipe
        '
        Me.tbEquipe.Location = New System.Drawing.Point(29, 321)
        Me.tbEquipe.Name = "tbEquipe"
        Me.tbEquipe.Size = New System.Drawing.Size(351, 20)
        Me.tbEquipe.TabIndex = 7
        '
        'tbUnidade
        '
        Me.tbUnidade.Location = New System.Drawing.Point(29, 279)
        Me.tbUnidade.Name = "tbUnidade"
        Me.tbUnidade.Size = New System.Drawing.Size(351, 20)
        Me.tbUnidade.TabIndex = 6
        '
        'tbDetalhe
        '
        Me.tbDetalhe.Location = New System.Drawing.Point(29, 236)
        Me.tbDetalhe.Name = "tbDetalhe"
        Me.tbDetalhe.Size = New System.Drawing.Size(351, 20)
        Me.tbDetalhe.TabIndex = 5
        '
        'tbFormaContrato
        '
        Me.tbFormaContrato.Location = New System.Drawing.Point(29, 194)
        Me.tbFormaContrato.Name = "tbFormaContrato"
        Me.tbFormaContrato.Size = New System.Drawing.Size(351, 20)
        Me.tbFormaContrato.TabIndex = 4
        '
        'tbOrgao
        '
        Me.tbOrgao.Location = New System.Drawing.Point(29, 93)
        Me.tbOrgao.Name = "tbOrgao"
        Me.tbOrgao.Size = New System.Drawing.Size(212, 20)
        Me.tbOrgao.TabIndex = 1
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(26, 305)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Equipe destino"
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
        Me.GroupBox3.TabIndex = 3
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(196, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Forma de contrato com estabelecimento"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(244, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Reg do conselho de classe"
        '
        'tbRegConselho
        '
        Me.tbRegConselho.Location = New System.Drawing.Point(247, 93)
        Me.tbRegConselho.Name = "tbRegConselho"
        Me.tbRegConselho.Size = New System.Drawing.Size(135, 20)
        Me.tbRegConselho.TabIndex = 2
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
        'btFechar
        '
        Me.btFechar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btFechar.Location = New System.Drawing.Point(751, 450)
        Me.btFechar.Name = "btFechar"
        Me.btFechar.Size = New System.Drawing.Size(75, 23)
        Me.btFechar.TabIndex = 3
        Me.btFechar.Text = "Fechar"
        Me.btFechar.UseVisualStyleBackColor = True
        '
        'btConcluirCadastro
        '
        Me.btConcluirCadastro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btConcluirCadastro.Location = New System.Drawing.Point(596, 450)
        Me.btConcluirCadastro.Name = "btConcluirCadastro"
        Me.btConcluirCadastro.Size = New System.Drawing.Size(149, 23)
        Me.btConcluirCadastro.TabIndex = 2
        Me.btConcluirCadastro.Text = "Concluir cadastro"
        Me.btConcluirCadastro.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(818, 432)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgCadastrosPendentes)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(810, 406)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cadastros pendentes"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgHistorico)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(810, 406)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Histórico"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgHistorico
        '
        Me.dgHistorico.AllowUserToAddRows = False
        Me.dgHistorico.AllowUserToDeleteRows = False
        Me.dgHistorico.AllowUserToOrderColumns = True
        Me.dgHistorico.AllowUserToResizeRows = False
        Me.dgHistorico.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgHistorico.BackgroundColor = System.Drawing.Color.White
        Me.dgHistorico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgHistorico.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHistorico.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgHistorico.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgHistorico.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgHistorico.Location = New System.Drawing.Point(6, 6)
        Me.dgHistorico.MultiSelect = False
        Me.dgHistorico.Name = "dgHistorico"
        Me.dgHistorico.ReadOnly = True
        Me.dgHistorico.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgHistorico.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgHistorico.RowHeadersWidth = 4
        Me.dgHistorico.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgHistorico.Size = New System.Drawing.Size(798, 394)
        Me.dgHistorico.TabIndex = 32
        Me.dgHistorico.TabStop = False
        '
        'FormNovoCadastroCNES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 485)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btConcluirCadastro)
        Me.Controls.Add(Me.btFechar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormNovoCadastroCNES"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Novo cadastro servidor CNES"
        CType(Me.dgCadastrosPendentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumericOutros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericHosp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericAMB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgCadastrosPendentes As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents NumericOutros As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents NumericHosp As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents numericAMB As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tbRegConselho As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btFechar As Button
    Friend WithEvents btConcluirCadastro As Button
    Friend WithEvents tbOrgao As TextBox
    Friend WithEvents tbFormaContrato As TextBox
    Friend WithEvents tbDetalhe As TextBox
    Friend WithEvents tbEquipe As TextBox
    Friend WithEvents tbUnidade As TextBox
    Friend WithEvents tbCBO As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgHistorico As DataGridView
End Class
