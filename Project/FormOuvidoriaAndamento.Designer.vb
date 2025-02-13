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
        Me.btExcluirManifest = New System.Windows.Forms.Button()
        Me.btAtualizarManifest = New System.Windows.Forms.Button()
        Me.TextBoxManifestacao = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxResposta = New System.Windows.Forms.RichTextBox()
        Me.CheckBoxOKResposta = New System.Windows.Forms.CheckBox()
        Me.btSalvarResposta = New System.Windows.Forms.Button()
        Me.btClose = New System.Windows.Forms.Button()
        Me.OFDUpdateManifest = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btExcluirManifest)
        Me.GroupBox1.Controls.Add(Me.btAtualizarManifest)
        Me.GroupBox1.Controls.Add(Me.TextBoxManifestacao)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(618, 306)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manifestação"
        '
        'btExcluirManifest
        '
        Me.btExcluirManifest.BackColor = System.Drawing.Color.IndianRed
        Me.btExcluirManifest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btExcluirManifest.FlatAppearance.BorderSize = 0
        Me.btExcluirManifest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btExcluirManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExcluirManifest.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btExcluirManifest.Location = New System.Drawing.Point(545, 13)
        Me.btExcluirManifest.Name = "btExcluirManifest"
        Me.btExcluirManifest.Size = New System.Drawing.Size(67, 20)
        Me.btExcluirManifest.TabIndex = 6
        Me.btExcluirManifest.Text = "Excluir"
        Me.btExcluirManifest.UseVisualStyleBackColor = False
        '
        'btAtualizarManifest
        '
        Me.btAtualizarManifest.BackColor = System.Drawing.Color.DodgerBlue
        Me.btAtualizarManifest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAtualizarManifest.FlatAppearance.BorderSize = 0
        Me.btAtualizarManifest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAtualizarManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAtualizarManifest.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btAtualizarManifest.Location = New System.Drawing.Point(472, 13)
        Me.btAtualizarManifest.Name = "btAtualizarManifest"
        Me.btAtualizarManifest.Size = New System.Drawing.Size(67, 20)
        Me.btAtualizarManifest.TabIndex = 5
        Me.btAtualizarManifest.Text = "Atualizar"
        Me.btAtualizarManifest.UseVisualStyleBackColor = False
        '
        'TextBoxManifestacao
        '
        Me.TextBoxManifestacao.BackColor = System.Drawing.Color.Linen
        Me.TextBoxManifestacao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxManifestacao.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBoxManifestacao.DetectUrls = False
        Me.TextBoxManifestacao.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxManifestacao.Location = New System.Drawing.Point(6, 38)
        Me.TextBoxManifestacao.Name = "TextBoxManifestacao"
        Me.TextBoxManifestacao.ReadOnly = True
        Me.TextBoxManifestacao.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.TextBoxManifestacao.Size = New System.Drawing.Size(606, 262)
        Me.TextBoxManifestacao.TabIndex = 0
        Me.TextBoxManifestacao.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxResposta)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.GroupBox2.Location = New System.Drawing.Point(12, 324)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(618, 306)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resposta"
        '
        'TextBoxResposta
        '
        Me.TextBoxResposta.BackColor = System.Drawing.Color.Linen
        Me.TextBoxResposta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxResposta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxResposta.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxResposta.Location = New System.Drawing.Point(6, 33)
        Me.TextBoxResposta.Name = "TextBoxResposta"
        Me.TextBoxResposta.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.TextBoxResposta.Size = New System.Drawing.Size(606, 267)
        Me.TextBoxResposta.TabIndex = 0
        Me.TextBoxResposta.Text = ""
        '
        'CheckBoxOKResposta
        '
        Me.CheckBoxOKResposta.AutoSize = True
        Me.CheckBoxOKResposta.Location = New System.Drawing.Point(324, 643)
        Me.CheckBoxOKResposta.Name = "CheckBoxOKResposta"
        Me.CheckBoxOKResposta.Size = New System.Drawing.Size(100, 17)
        Me.CheckBoxOKResposta.TabIndex = 2
        Me.CheckBoxOKResposta.Text = "OK para eOuve"
        Me.CheckBoxOKResposta.UseVisualStyleBackColor = True
        '
        'btSalvarResposta
        '
        Me.btSalvarResposta.BackColor = System.Drawing.Color.ForestGreen
        Me.btSalvarResposta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSalvarResposta.FlatAppearance.BorderSize = 0
        Me.btSalvarResposta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSalvarResposta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSalvarResposta.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btSalvarResposta.Location = New System.Drawing.Point(430, 635)
        Me.btSalvarResposta.Name = "btSalvarResposta"
        Me.btSalvarResposta.Size = New System.Drawing.Size(119, 32)
        Me.btSalvarResposta.TabIndex = 3
        Me.btSalvarResposta.Text = "Gravar resposta"
        Me.btSalvarResposta.UseVisualStyleBackColor = False
        '
        'btClose
        '
        Me.btClose.BackColor = System.Drawing.Color.IndianRed
        Me.btClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btClose.FlatAppearance.BorderSize = 0
        Me.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClose.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btClose.Location = New System.Drawing.Point(555, 635)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(75, 32)
        Me.btClose.TabIndex = 4
        Me.btClose.Text = "Sair"
        Me.btClose.UseVisualStyleBackColor = False
        '
        'FormOuvidoriaAndamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 672)
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
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckBoxOKResposta As CheckBox
    Friend WithEvents btSalvarResposta As Button
    Friend WithEvents btClose As Button
    Friend WithEvents TextBoxManifestacao As RichTextBox
    Friend WithEvents TextBoxResposta As RichTextBox
    Friend WithEvents btAtualizarManifest As Button
    Friend WithEvents btExcluirManifest As Button
    Friend WithEvents OFDUpdateManifest As OpenFileDialog
End Class
