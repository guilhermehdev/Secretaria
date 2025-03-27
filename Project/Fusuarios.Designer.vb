<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fusuarios
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fusuarios))
        Me.dgUsuarios = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkBkpBanco = New System.Windows.Forms.CheckBox()
        Me.chkBanco = New System.Windows.Forms.CheckBox()
        Me.chkConProd = New System.Windows.Forms.CheckBox()
        Me.chkConCli = New System.Windows.Forms.CheckBox()
        Me.chkRelatCaixa = New System.Windows.Forms.CheckBox()
        Me.chkRelatVendas = New System.Windows.Forms.CheckBox()
        Me.chkCaixa = New System.Windows.Forms.CheckBox()
        Me.chkVendas = New System.Windows.Forms.CheckBox()
        Me.chkCadUsuarios = New System.Windows.Forms.CheckBox()
        Me.chkCadProd = New System.Windows.Forms.CheckBox()
        Me.chkCadCli = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btSair = New System.Windows.Forms.Button()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.btNew = New System.Windows.Forms.Button()
        Me.btDelete = New System.Windows.Forms.Button()
        Me.btUpdate = New System.Windows.Forms.Button()
        Me.btSave = New System.Windows.Forms.Button()
        Me.gbDadosUsuario = New System.Windows.Forms.GroupBox()
        Me.btSearchName = New System.Windows.Forms.Button()
        Me.chkExibeSenha = New System.Windows.Forms.CheckBox()
        Me.tbSenha = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbAtivo = New System.Windows.Forms.ComboBox()
        Me.tbDesc = New System.Windows.Forms.TextBox()
        Me.lbNomeFantasia = New System.Windows.Forms.Label()
        CType(Me.dgUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbDadosUsuario.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgUsuarios
        '
        Me.dgUsuarios.AllowUserToAddRows = False
        Me.dgUsuarios.AllowUserToDeleteRows = False
        Me.dgUsuarios.AllowUserToResizeRows = False
        Me.dgUsuarios.BackgroundColor = System.Drawing.SystemColors.HighlightText
        Me.dgUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgUsuarios.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgUsuarios.Location = New System.Drawing.Point(6, 19)
        Me.dgUsuarios.MultiSelect = False
        Me.dgUsuarios.Name = "dgUsuarios"
        Me.dgUsuarios.ReadOnly = True
        Me.dgUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgUsuarios.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgUsuarios.RowHeadersWidth = 4
        Me.dgUsuarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgUsuarios.Size = New System.Drawing.Size(582, 199)
        Me.dgUsuarios.TabIndex = 23
        Me.dgUsuarios.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgUsuarios)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 245)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(594, 224)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Usuários Cadastrados"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 480)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(618, 22)
        Me.StatusStrip1.TabIndex = 25
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkBkpBanco)
        Me.GroupBox2.Controls.Add(Me.chkBanco)
        Me.GroupBox2.Controls.Add(Me.chkConProd)
        Me.GroupBox2.Controls.Add(Me.chkConCli)
        Me.GroupBox2.Controls.Add(Me.chkRelatCaixa)
        Me.GroupBox2.Controls.Add(Me.chkRelatVendas)
        Me.GroupBox2.Controls.Add(Me.chkCaixa)
        Me.GroupBox2.Controls.Add(Me.chkVendas)
        Me.GroupBox2.Controls.Add(Me.chkCadUsuarios)
        Me.GroupBox2.Controls.Add(Me.chkCadProd)
        Me.GroupBox2.Controls.Add(Me.chkCadCli)
        Me.GroupBox2.Location = New System.Drawing.Point(239, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(367, 145)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Permissões"
        '
        'chkBkpBanco
        '
        Me.chkBkpBanco.AutoSize = True
        Me.chkBkpBanco.Location = New System.Drawing.Point(246, 82)
        Me.chkBkpBanco.Name = "chkBkpBanco"
        Me.chkBkpBanco.Size = New System.Drawing.Size(63, 17)
        Me.chkBkpBanco.TabIndex = 10
        Me.chkBkpBanco.Text = "Backup"
        Me.chkBkpBanco.UseVisualStyleBackColor = True
        '
        'chkBanco
        '
        Me.chkBanco.AutoSize = True
        Me.chkBanco.Location = New System.Drawing.Point(246, 58)
        Me.chkBanco.Name = "chkBanco"
        Me.chkBanco.Size = New System.Drawing.Size(119, 17)
        Me.chkBanco.TabIndex = 9
        Me.chkBanco.Text = "Conf. Banco Dados"
        Me.chkBanco.UseVisualStyleBackColor = True
        '
        'chkConProd
        '
        Me.chkConProd.AutoSize = True
        Me.chkConProd.Location = New System.Drawing.Point(246, 35)
        Me.chkConProd.Name = "chkConProd"
        Me.chkConProd.Size = New System.Drawing.Size(115, 17)
        Me.chkConProd.TabIndex = 8
        Me.chkConProd.Text = "Consultar Produtos"
        Me.chkConProd.UseVisualStyleBackColor = True
        '
        'chkConCli
        '
        Me.chkConCli.AutoSize = True
        Me.chkConCli.Location = New System.Drawing.Point(128, 105)
        Me.chkConCli.Name = "chkConCli"
        Me.chkConCli.Size = New System.Drawing.Size(110, 17)
        Me.chkConCli.TabIndex = 7
        Me.chkConCli.Text = "Consultar Clientes"
        Me.chkConCli.UseVisualStyleBackColor = True
        '
        'chkRelatCaixa
        '
        Me.chkRelatCaixa.AutoSize = True
        Me.chkRelatCaixa.Location = New System.Drawing.Point(128, 82)
        Me.chkRelatCaixa.Name = "chkRelatCaixa"
        Me.chkRelatCaixa.Size = New System.Drawing.Size(97, 17)
        Me.chkRelatCaixa.TabIndex = 6
        Me.chkRelatCaixa.Text = "Relatório Caixa"
        Me.chkRelatCaixa.UseVisualStyleBackColor = True
        '
        'chkRelatVendas
        '
        Me.chkRelatVendas.AutoSize = True
        Me.chkRelatVendas.Location = New System.Drawing.Point(128, 59)
        Me.chkRelatVendas.Name = "chkRelatVendas"
        Me.chkRelatVendas.Size = New System.Drawing.Size(107, 17)
        Me.chkRelatVendas.TabIndex = 5
        Me.chkRelatVendas.Text = "Relatório Vendas"
        Me.chkRelatVendas.UseVisualStyleBackColor = True
        '
        'chkCaixa
        '
        Me.chkCaixa.AutoSize = True
        Me.chkCaixa.Location = New System.Drawing.Point(128, 35)
        Me.chkCaixa.Name = "chkCaixa"
        Me.chkCaixa.Size = New System.Drawing.Size(52, 17)
        Me.chkCaixa.TabIndex = 4
        Me.chkCaixa.Text = "Caixa"
        Me.chkCaixa.UseVisualStyleBackColor = True
        '
        'chkVendas
        '
        Me.chkVendas.AutoSize = True
        Me.chkVendas.Location = New System.Drawing.Point(10, 105)
        Me.chkVendas.Name = "chkVendas"
        Me.chkVendas.Size = New System.Drawing.Size(62, 17)
        Me.chkVendas.TabIndex = 3
        Me.chkVendas.Text = "Vendas"
        Me.chkVendas.UseVisualStyleBackColor = True
        '
        'chkCadUsuarios
        '
        Me.chkCadUsuarios.AutoSize = True
        Me.chkCadUsuarios.Location = New System.Drawing.Point(10, 82)
        Me.chkCadUsuarios.Name = "chkCadUsuarios"
        Me.chkCadUsuarios.Size = New System.Drawing.Size(115, 17)
        Me.chkCadUsuarios.TabIndex = 2
        Me.chkCadUsuarios.Text = "Cadastrar Usuários"
        Me.chkCadUsuarios.UseVisualStyleBackColor = True
        '
        'chkCadProd
        '
        Me.chkCadProd.AutoSize = True
        Me.chkCadProd.Location = New System.Drawing.Point(10, 58)
        Me.chkCadProd.Name = "chkCadProd"
        Me.chkCadProd.Size = New System.Drawing.Size(116, 17)
        Me.chkCadProd.TabIndex = 1
        Me.chkCadProd.Text = "Cadastrar Produtos"
        Me.chkCadProd.UseVisualStyleBackColor = True
        '
        'chkCadCli
        '
        Me.chkCadCli.AutoSize = True
        Me.chkCadCli.Location = New System.Drawing.Point(10, 35)
        Me.chkCadCli.Name = "chkCadCli"
        Me.chkCadCli.Size = New System.Drawing.Size(111, 17)
        Me.chkCadCli.TabIndex = 0
        Me.chkCadCli.Text = "Cadastrar Clientes"
        Me.chkCadCli.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btSair)
        Me.GroupBox3.Controls.Add(Me.btCancel)
        Me.GroupBox3.Controls.Add(Me.btNew)
        Me.GroupBox3.Controls.Add(Me.btDelete)
        Me.GroupBox3.Controls.Add(Me.btUpdate)
        Me.GroupBox3.Controls.Add(Me.btSave)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 163)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(594, 76)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ações"
        '
        'btSair
        '

        Me.btSair.Location = New System.Drawing.Point(513, 19)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(75, 47)
        Me.btSair.TabIndex = 20
        Me.btSair.Text = "Sair"
        Me.btSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btSair.UseVisualStyleBackColor = True
        '
        'btCancel
        '

        Me.btCancel.Location = New System.Drawing.Point(343, 19)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 47)
        Me.btCancel.TabIndex = 19
        Me.btCancel.Text = "Cancelar"
        Me.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'btNew
        '

        Me.btNew.Location = New System.Drawing.Point(19, 19)
        Me.btNew.Name = "btNew"
        Me.btNew.Size = New System.Drawing.Size(75, 47)
        Me.btNew.TabIndex = 18
        Me.btNew.Text = "Novo"
        Me.btNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btNew.UseVisualStyleBackColor = True
        '
        'btDelete
        '
        Me.btDelete.Enabled = False
        Me.btDelete.Location = New System.Drawing.Point(262, 19)
        Me.btDelete.Name = "btDelete"
        Me.btDelete.Size = New System.Drawing.Size(75, 47)
        Me.btDelete.TabIndex = 17
        Me.btDelete.Text = "Excluir"
        Me.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btDelete.UseVisualStyleBackColor = True
        '
        'btUpdate
        '
        Me.btUpdate.Enabled = False
        Me.btUpdate.Image = Global.Project.My.Resources.Resources.reload
        Me.btUpdate.Location = New System.Drawing.Point(181, 19)
        Me.btUpdate.Name = "btUpdate"
        Me.btUpdate.Size = New System.Drawing.Size(75, 47)
        Me.btUpdate.TabIndex = 16
        Me.btUpdate.Text = "Atualizar"
        Me.btUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btUpdate.UseVisualStyleBackColor = True
        '
        'btSave
        '
        Me.btSave.Enabled = False
        Me.btSave.Location = New System.Drawing.Point(100, 19)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(75, 47)
        Me.btSave.TabIndex = 15
        Me.btSave.Text = "Salvar"
        Me.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btSave.UseVisualStyleBackColor = True
        '
        'gbDadosUsuario
        '
        Me.gbDadosUsuario.Controls.Add(Me.btSearchName)
        Me.gbDadosUsuario.Controls.Add(Me.chkExibeSenha)
        Me.gbDadosUsuario.Controls.Add(Me.tbSenha)
        Me.gbDadosUsuario.Controls.Add(Me.Label2)
        Me.gbDadosUsuario.Controls.Add(Me.Label1)
        Me.gbDadosUsuario.Controls.Add(Me.cbAtivo)
        Me.gbDadosUsuario.Controls.Add(Me.tbDesc)
        Me.gbDadosUsuario.Controls.Add(Me.lbNomeFantasia)
        Me.gbDadosUsuario.Location = New System.Drawing.Point(12, 12)
        Me.gbDadosUsuario.Name = "gbDadosUsuario"
        Me.gbDadosUsuario.Size = New System.Drawing.Size(221, 145)
        Me.gbDadosUsuario.TabIndex = 28
        Me.gbDadosUsuario.TabStop = False
        Me.gbDadosUsuario.Text = "Dados Usuário"
        '
        'btSearchName        '

        Me.btSearchName.Location = New System.Drawing.Point(181, 26)
        Me.btSearchName.Name = "btSearchName"
        Me.btSearchName.Size = New System.Drawing.Size(33, 35)
        Me.btSearchName.TabIndex = 33
        Me.btSearchName.Tag = "1"
        Me.btSearchName.UseVisualStyleBackColor = True
        '
        'chkExibeSenha
        '
        Me.chkExibeSenha.AutoSize = True
        Me.chkExibeSenha.Enabled = False
        Me.chkExibeSenha.Location = New System.Drawing.Point(121, 81)
        Me.chkExibeSenha.Name = "chkExibeSenha"
        Me.chkExibeSenha.Size = New System.Drawing.Size(93, 17)
        Me.chkExibeSenha.TabIndex = 22
        Me.chkExibeSenha.Text = "Mostrar senha"
        Me.chkExibeSenha.UseVisualStyleBackColor = True
        '
        'tbSenha
        '
        Me.tbSenha.BackColor = System.Drawing.Color.White
        Me.tbSenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbSenha.Enabled = False
        Me.tbSenha.Location = New System.Drawing.Point(6, 79)
        Me.tbSenha.Name = "tbSenha"
        Me.tbSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbSenha.Size = New System.Drawing.Size(109, 20)
        Me.tbSenha.TabIndex = 20
        Me.tbSenha.Tag = ""
        Me.tbSenha.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Senha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Ativo"
        '
        'cbAtivo
        '
        Me.cbAtivo.Enabled = False
        Me.cbAtivo.FormattingEnabled = True
        Me.cbAtivo.Items.AddRange(New Object() {"NÃO", "SIM"})
        Me.cbAtivo.Location = New System.Drawing.Point(6, 118)
        Me.cbAtivo.Name = "cbAtivo"
        Me.cbAtivo.Size = New System.Drawing.Size(68, 21)
        Me.cbAtivo.TabIndex = 18
        '
        'tbDesc
        '
        Me.tbDesc.BackColor = System.Drawing.SystemColors.Info
        Me.tbDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbDesc.Location = New System.Drawing.Point(6, 40)
        Me.tbDesc.Name = "tbDesc"
        Me.tbDesc.Size = New System.Drawing.Size(172, 20)
        Me.tbDesc.TabIndex = 16
        Me.tbDesc.Tag = "1"
        '
        'lbNomeFantasia
        '
        Me.lbNomeFantasia.AutoSize = True
        Me.lbNomeFantasia.Location = New System.Drawing.Point(3, 24)
        Me.lbNomeFantasia.Name = "lbNomeFantasia"
        Me.lbNomeFantasia.Size = New System.Drawing.Size(35, 13)
        Me.lbNomeFantasia.TabIndex = 17
        Me.lbNomeFantasia.Text = "Nome"
        '
        'Fusuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 502)
        Me.Controls.Add(Me.gbDadosUsuario)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fusuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Usuários"
        CType(Me.dgUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.gbDadosUsuario.ResumeLayout(False)
        Me.gbDadosUsuario.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btSair As System.Windows.Forms.Button
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents btNew As System.Windows.Forms.Button
    Friend WithEvents btDelete As System.Windows.Forms.Button
    Friend WithEvents btUpdate As System.Windows.Forms.Button
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents gbDadosUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents tbDesc As System.Windows.Forms.TextBox
    Friend WithEvents lbNomeFantasia As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbAtivo As System.Windows.Forms.ComboBox
    Friend WithEvents tbSenha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkExibeSenha As System.Windows.Forms.CheckBox
    Friend WithEvents btSearchName As System.Windows.Forms.Button
    Friend WithEvents chkBkpBanco As System.Windows.Forms.CheckBox
    Friend WithEvents chkBanco As System.Windows.Forms.CheckBox
    Friend WithEvents chkConProd As System.Windows.Forms.CheckBox
    Friend WithEvents chkConCli As System.Windows.Forms.CheckBox
    Friend WithEvents chkRelatCaixa As System.Windows.Forms.CheckBox
    Friend WithEvents chkRelatVendas As System.Windows.Forms.CheckBox
    Friend WithEvents chkCaixa As System.Windows.Forms.CheckBox
    Friend WithEvents chkVendas As System.Windows.Forms.CheckBox
    Friend WithEvents chkCadUsuarios As System.Windows.Forms.CheckBox
    Friend WithEvents chkCadProd As System.Windows.Forms.CheckBox
    Friend WithEvents chkCadCli As System.Windows.Forms.CheckBox
End Class
