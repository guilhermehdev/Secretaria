<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Fstart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fstart))
        Me.btSair = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CadastroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuárioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SenhaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btCNES = New System.Windows.Forms.Button()
        Me.btRecepcao = New System.Windows.Forms.Button()
        Me.btOuvidoria = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btSair
        '
        Me.btSair.BackColor = System.Drawing.Color.IndianRed
        Me.btSair.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSair.FlatAppearance.BorderColor = System.Drawing.Color.Maroon
        Me.btSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown
        Me.btSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick
        Me.btSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSair.ForeColor = System.Drawing.Color.Gainsboro
        Me.btSair.Location = New System.Drawing.Point(230, 94)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(37, 23)
        Me.btSair.TabIndex = 3
        Me.btSair.Text = "Sair"
        Me.btSair.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastroToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(277, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CadastroToolStripMenuItem
        '
        Me.CadastroToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CadastroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuárioToolStripMenuItem})
        Me.CadastroToolStripMenuItem.ForeColor = System.Drawing.Color.Cyan
        Me.CadastroToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.CadastroToolStripMenuItem.Name = "CadastroToolStripMenuItem"
        Me.CadastroToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.CadastroToolStripMenuItem.Text = "Cadastro"
        '
        'UsuárioToolStripMenuItem
        '
        Me.UsuárioToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UsuárioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SenhaToolStripMenuItem})
        Me.UsuárioToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UsuárioToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue
        Me.UsuárioToolStripMenuItem.Name = "UsuárioToolStripMenuItem"
        Me.UsuárioToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.UsuárioToolStripMenuItem.Text = "Usuário"
        '
        'SenhaToolStripMenuItem
        '
        Me.SenhaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SenhaToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue
        Me.SenhaToolStripMenuItem.Name = "SenhaToolStripMenuItem"
        Me.SenhaToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.SenhaToolStripMenuItem.Text = "Senha"
        '
        'btCNES
        '
        Me.btCNES.BackColor = System.Drawing.Color.DodgerBlue
        Me.btCNES.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btCNES.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btCNES.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btCNES.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.btCNES.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btCNES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCNES.ForeColor = System.Drawing.Color.Yellow
        Me.btCNES.Image = CType(resources.GetObject("btCNES.Image"), System.Drawing.Image)
        Me.btCNES.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btCNES.Location = New System.Drawing.Point(186, 30)
        Me.btCNES.Name = "btCNES"
        Me.btCNES.Size = New System.Drawing.Size(81, 55)
        Me.btCNES.TabIndex = 4
        Me.btCNES.Text = "CNES"
        Me.btCNES.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btCNES.UseVisualStyleBackColor = False
        '
        'btRecepcao
        '
        Me.btRecepcao.BackColor = System.Drawing.Color.DodgerBlue
        Me.btRecepcao.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btRecepcao.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btRecepcao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btRecepcao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.btRecepcao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btRecepcao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRecepcao.ForeColor = System.Drawing.Color.Yellow
        Me.btRecepcao.Image = CType(resources.GetObject("btRecepcao.Image"), System.Drawing.Image)
        Me.btRecepcao.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btRecepcao.Location = New System.Drawing.Point(99, 30)
        Me.btRecepcao.Name = "btRecepcao"
        Me.btRecepcao.Size = New System.Drawing.Size(81, 55)
        Me.btRecepcao.TabIndex = 2
        Me.btRecepcao.Text = "EMTU"
        Me.btRecepcao.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btRecepcao.UseVisualStyleBackColor = False
        '
        'btOuvidoria
        '
        Me.btOuvidoria.BackColor = System.Drawing.Color.DodgerBlue
        Me.btOuvidoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btOuvidoria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btOuvidoria.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btOuvidoria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btOuvidoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.btOuvidoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btOuvidoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOuvidoria.ForeColor = System.Drawing.Color.Yellow
        Me.btOuvidoria.Image = CType(resources.GetObject("btOuvidoria.Image"), System.Drawing.Image)
        Me.btOuvidoria.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btOuvidoria.Location = New System.Drawing.Point(12, 30)
        Me.btOuvidoria.Name = "btOuvidoria"
        Me.btOuvidoria.Size = New System.Drawing.Size(81, 55)
        Me.btOuvidoria.TabIndex = 1
        Me.btOuvidoria.Text = "Ouvidoria"
        Me.btOuvidoria.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btOuvidoria.UseVisualStyleBackColor = False
        '
        'Fstart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(277, 129)
        Me.Controls.Add(Me.btCNES)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.btRecepcao)
        Me.Controls.Add(Me.btOuvidoria)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fstart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecione o sistema"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btOuvidoria As System.Windows.Forms.Button
    Friend WithEvents btSair As Button
    Friend WithEvents btCNES As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CadastroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsuárioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SenhaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btRecepcao As Button
End Class
