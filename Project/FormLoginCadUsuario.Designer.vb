<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLoginCadUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLoginCadUsuario))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbNovoNome = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbNovaSenha = New System.Windows.Forms.TextBox()
        Me.CheckBoxAtivo = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxeOuve = New System.Windows.Forms.CheckBox()
        Me.CheckBoxEMTU = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCNES = New System.Windows.Forms.CheckBox()
        Me.btSalvarUsuario = New System.Windows.Forms.Button()
        Me.cbUsuariosCadastrados = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbNovaSenhaConfirma = New System.Windows.Forms.TextBox()
        Me.btAtualizarUsuario = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btCancelaEdicao = New System.Windows.Forms.Button()
        Me.cbNivelAcesso = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbNivelAcesso)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CheckBoxAtivo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbNovaSenhaConfirma)
        Me.GroupBox1.Controls.Add(Me.cbUsuariosCadastrados)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbNovaSenha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbNovoNome)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(281, 301)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados do usuário"
        '
        'tbNovoNome
        '
        Me.tbNovoNome.Location = New System.Drawing.Point(19, 93)
        Me.tbNovoNome.Name = "tbNovoNome"
        Me.tbNovoNome.Size = New System.Drawing.Size(243, 20)
        Me.tbNovoNome.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nome"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Senha"
        '
        'tbNovaSenha
        '
        Me.tbNovaSenha.Location = New System.Drawing.Point(19, 132)
        Me.tbNovaSenha.Name = "tbNovaSenha"
        Me.tbNovaSenha.Size = New System.Drawing.Size(243, 20)
        Me.tbNovaSenha.TabIndex = 2
        '
        'CheckBoxAtivo
        '
        Me.CheckBoxAtivo.AutoSize = True
        Me.CheckBoxAtivo.Location = New System.Drawing.Point(19, 197)
        Me.CheckBoxAtivo.Name = "CheckBoxAtivo"
        Me.CheckBoxAtivo.Size = New System.Drawing.Size(88, 17)
        Me.CheckBoxAtivo.TabIndex = 4
        Me.CheckBoxAtivo.Text = "Usuário ativo"
        Me.CheckBoxAtivo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBoxCNES)
        Me.GroupBox2.Controls.Add(Me.CheckBoxEMTU)
        Me.GroupBox2.Controls.Add(Me.CheckBoxeOuve)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 220)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(243, 65)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sistemas"
        '
        'CheckBoxeOuve
        '
        Me.CheckBoxeOuve.AutoSize = True
        Me.CheckBoxeOuve.Location = New System.Drawing.Point(30, 29)
        Me.CheckBoxeOuve.Name = "CheckBoxeOuve"
        Me.CheckBoxeOuve.Size = New System.Drawing.Size(58, 17)
        Me.CheckBoxeOuve.TabIndex = 0
        Me.CheckBoxeOuve.Text = "eOuve"
        Me.CheckBoxeOuve.UseVisualStyleBackColor = True
        '
        'CheckBoxEMTU
        '
        Me.CheckBoxEMTU.AutoSize = True
        Me.CheckBoxEMTU.Location = New System.Drawing.Point(94, 29)
        Me.CheckBoxEMTU.Name = "CheckBoxEMTU"
        Me.CheckBoxEMTU.Size = New System.Drawing.Size(57, 17)
        Me.CheckBoxEMTU.TabIndex = 1
        Me.CheckBoxEMTU.Text = "EMTU"
        Me.CheckBoxEMTU.UseVisualStyleBackColor = True
        '
        'CheckBoxCNES
        '
        Me.CheckBoxCNES.AutoSize = True
        Me.CheckBoxCNES.Location = New System.Drawing.Point(157, 29)
        Me.CheckBoxCNES.Name = "CheckBoxCNES"
        Me.CheckBoxCNES.Size = New System.Drawing.Size(55, 17)
        Me.CheckBoxCNES.TabIndex = 2
        Me.CheckBoxCNES.Text = "CNES"
        Me.CheckBoxCNES.UseVisualStyleBackColor = True
        '
        'btSalvarUsuario
        '
        Me.btSalvarUsuario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvarUsuario.Location = New System.Drawing.Point(12, 319)
        Me.btSalvarUsuario.Name = "btSalvarUsuario"
        Me.btSalvarUsuario.Size = New System.Drawing.Size(75, 23)
        Me.btSalvarUsuario.TabIndex = 6
        Me.btSalvarUsuario.Text = "Salvar"
        Me.btSalvarUsuario.UseVisualStyleBackColor = True
        '
        'cbUsuariosCadastrados
        '
        Me.cbUsuariosCadastrados.FormattingEnabled = True
        Me.cbUsuariosCadastrados.Location = New System.Drawing.Point(19, 43)
        Me.cbUsuariosCadastrados.Name = "cbUsuariosCadastrados"
        Me.cbUsuariosCadastrados.Size = New System.Drawing.Size(243, 21)
        Me.cbUsuariosCadastrados.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Usuários cadastrados"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Confirmar senha"
        '
        'tbNovaSenhaConfirma
        '
        Me.tbNovaSenhaConfirma.Location = New System.Drawing.Point(19, 171)
        Me.tbNovaSenhaConfirma.Name = "tbNovaSenhaConfirma"
        Me.tbNovaSenhaConfirma.Size = New System.Drawing.Size(243, 20)
        Me.tbNovaSenhaConfirma.TabIndex = 7
        '
        'btAtualizarUsuario
        '
        Me.btAtualizarUsuario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAtualizarUsuario.Enabled = False
        Me.btAtualizarUsuario.Location = New System.Drawing.Point(93, 319)
        Me.btAtualizarUsuario.Name = "btAtualizarUsuario"
        Me.btAtualizarUsuario.Size = New System.Drawing.Size(75, 23)
        Me.btAtualizarUsuario.TabIndex = 7
        Me.btAtualizarUsuario.Text = "Atualizar"
        Me.btAtualizarUsuario.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(257, 319)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(36, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Sair"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btCancelaEdicao
        '
        Me.btCancelaEdicao.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btCancelaEdicao.Enabled = False
        Me.btCancelaEdicao.Location = New System.Drawing.Point(174, 319)
        Me.btCancelaEdicao.Name = "btCancelaEdicao"
        Me.btCancelaEdicao.Size = New System.Drawing.Size(75, 23)
        Me.btCancelaEdicao.TabIndex = 8
        Me.btCancelaEdicao.Text = "Cancelar"
        Me.btCancelaEdicao.UseVisualStyleBackColor = True
        '
        'cbNivelAcesso
        '
        Me.cbNivelAcesso.FormattingEnabled = True
        Me.cbNivelAcesso.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cbNivelAcesso.Location = New System.Drawing.Point(210, 195)
        Me.cbNivelAcesso.Name = "cbNivelAcesso"
        Me.cbNivelAcesso.Size = New System.Drawing.Size(52, 21)
        Me.cbNivelAcesso.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(124, 198)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Nivel de acesso"
        '
        'FormCadUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 364)
        Me.Controls.Add(Me.btCancelaEdicao)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btAtualizarUsuario)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btSalvarUsuario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCadUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Usuários"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckBoxCNES As CheckBox
    Friend WithEvents CheckBoxEMTU As CheckBox
    Friend WithEvents CheckBoxeOuve As CheckBox
    Friend WithEvents CheckBoxAtivo As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbNovaSenha As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbNovoNome As TextBox
    Friend WithEvents btSalvarUsuario As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbUsuariosCadastrados As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbNovaSenhaConfirma As TextBox
    Friend WithEvents btAtualizarUsuario As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btCancelaEdicao As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents cbNivelAcesso As ComboBox
End Class
