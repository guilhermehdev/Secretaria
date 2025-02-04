<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOuvidoriaAndamento
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
        Me.TextBoxManifestacao = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxResposta = New System.Windows.Forms.TextBox()
        Me.CheckBoxOKResposta = New System.Windows.Forms.CheckBox()
        Me.btSalvarResposta = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxManifestacao)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(618, 306)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manifestação"
        '
        'TextBoxManifestacao
        '
        Me.TextBoxManifestacao.Location = New System.Drawing.Point(6, 19)
        Me.TextBoxManifestacao.Multiline = True
        Me.TextBoxManifestacao.Name = "TextBoxManifestacao"
        Me.TextBoxManifestacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxManifestacao.Size = New System.Drawing.Size(606, 281)
        Me.TextBoxManifestacao.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxResposta)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 324)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(618, 306)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resposta"
        '
        'TextBoxResposta
        '
        Me.TextBoxResposta.Location = New System.Drawing.Point(6, 19)
        Me.TextBoxResposta.Multiline = True
        Me.TextBoxResposta.Name = "TextBoxResposta"
        Me.TextBoxResposta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxResposta.Size = New System.Drawing.Size(606, 281)
        Me.TextBoxResposta.TabIndex = 0
        '
        'CheckBoxOKResposta
        '
        Me.CheckBoxOKResposta.AutoSize = True
        Me.CheckBoxOKResposta.Location = New System.Drawing.Point(530, 630)
        Me.CheckBoxOKResposta.Name = "CheckBoxOKResposta"
        Me.CheckBoxOKResposta.Size = New System.Drawing.Size(100, 17)
        Me.CheckBoxOKResposta.TabIndex = 2
        Me.CheckBoxOKResposta.Text = "OK para eOuve"
        Me.CheckBoxOKResposta.UseVisualStyleBackColor = True
        '
        'btSalvarResposta
        '
        Me.btSalvarResposta.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btSalvarResposta.FlatAppearance.BorderSize = 0
        Me.btSalvarResposta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSalvarResposta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSalvarResposta.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btSalvarResposta.Location = New System.Drawing.Point(18, 630)
        Me.btSalvarResposta.Name = "btSalvarResposta"
        Me.btSalvarResposta.Size = New System.Drawing.Size(75, 23)
        Me.btSalvarResposta.TabIndex = 3
        Me.btSalvarResposta.Text = "Salvar"
        Me.btSalvarResposta.UseVisualStyleBackColor = False
        '
        'btClose
        '
        Me.btClose.BackColor = System.Drawing.Color.IndianRed
        Me.btClose.FlatAppearance.BorderSize = 0
        Me.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClose.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btClose.Location = New System.Drawing.Point(99, 630)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(75, 23)
        Me.btClose.TabIndex = 4
        Me.btClose.Text = "Sair"
        Me.btClose.UseVisualStyleBackColor = False
        '
        'FormOuvidoriaAndamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 660)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btSalvarResposta)
        Me.Controls.Add(Me.CheckBoxOKResposta)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOuvidoriaAndamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Andamento Protocolo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBoxManifestacao As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBoxResposta As TextBox
    Friend WithEvents CheckBoxOKResposta As CheckBox
    Friend WithEvents btSalvarResposta As Button
    Friend WithEvents btClose As Button
End Class
