﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.btBLH = New System.Windows.Forms.Button()
        Me.btCNES = New System.Windows.Forms.Button()
        Me.btRecepcao = New System.Windows.Forms.Button()
        Me.btOuvidoria = New System.Windows.Forms.Button()
        Me.btAME = New System.Windows.Forms.Button()
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
        Me.btSair.Location = New System.Drawing.Point(248, 130)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(298, 24)
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
        Me.UsuárioToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UsuárioToolStripMenuItem.ForeColor = System.Drawing.Color.DodgerBlue
        Me.UsuárioToolStripMenuItem.Name = "UsuárioToolStripMenuItem"
        Me.UsuárioToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.UsuárioToolStripMenuItem.Text = "Usuários"
        '
        'btBLH
        '
        Me.btBLH.BackColor = System.Drawing.Color.DodgerBlue
        Me.btBLH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btBLH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btBLH.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btBLH.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btBLH.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.btBLH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btBLH.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btBLH.ForeColor = System.Drawing.Color.Yellow
        Me.btBLH.Image = Global.Project.My.Resources.Resources.blh
        Me.btBLH.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btBLH.Location = New System.Drawing.Point(12, 98)
        Me.btBLH.Name = "btBLH"
        Me.btBLH.Size = New System.Drawing.Size(87, 55)
        Me.btBLH.TabIndex = 6
        Me.btBLH.Text = "Banco de Leite"
        Me.btBLH.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btBLH.UseVisualStyleBackColor = False
        '
        'btCNES
        '
        Me.btCNES.BackColor = System.Drawing.Color.DodgerBlue
        Me.btCNES.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btCNES.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btCNES.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btCNES.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.btCNES.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btCNES.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCNES.ForeColor = System.Drawing.Color.Yellow
        Me.btCNES.Image = CType(resources.GetObject("btCNES.Image"), System.Drawing.Image)
        Me.btCNES.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btCNES.Location = New System.Drawing.Point(105, 98)
        Me.btCNES.Name = "btCNES"
        Me.btCNES.Size = New System.Drawing.Size(87, 55)
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
        Me.btRecepcao.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRecepcao.ForeColor = System.Drawing.Color.Yellow
        Me.btRecepcao.Image = CType(resources.GetObject("btRecepcao.Image"), System.Drawing.Image)
        Me.btRecepcao.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btRecepcao.Location = New System.Drawing.Point(105, 37)
        Me.btRecepcao.Name = "btRecepcao"
        Me.btRecepcao.Size = New System.Drawing.Size(87, 55)
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
        Me.btOuvidoria.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOuvidoria.ForeColor = System.Drawing.Color.Yellow
        Me.btOuvidoria.Image = CType(resources.GetObject("btOuvidoria.Image"), System.Drawing.Image)
        Me.btOuvidoria.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btOuvidoria.Location = New System.Drawing.Point(12, 37)
        Me.btOuvidoria.Name = "btOuvidoria"
        Me.btOuvidoria.Size = New System.Drawing.Size(87, 55)
        Me.btOuvidoria.TabIndex = 1
        Me.btOuvidoria.Text = "Ouvidoria"
        Me.btOuvidoria.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btOuvidoria.UseVisualStyleBackColor = False
        '
        'btAME
        '
        Me.btAME.BackColor = System.Drawing.Color.DodgerBlue
        Me.btAME.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btAME.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
        Me.btAME.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.btAME.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue
        Me.btAME.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAME.Font = New System.Drawing.Font("Calibri", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAME.ForeColor = System.Drawing.Color.Yellow
        Me.btAME.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btAME.Location = New System.Drawing.Point(198, 37)
        Me.btAME.Name = "btAME"
        Me.btAME.Size = New System.Drawing.Size(87, 55)
        Me.btAME.TabIndex = 7
        Me.btAME.Text = "AME"
        Me.btAME.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btAME.UseVisualStyleBackColor = False
        '
        'Fstart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(298, 170)
        Me.Controls.Add(Me.btAME)
        Me.Controls.Add(Me.btBLH)
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
    Friend WithEvents btRecepcao As Button
    Friend WithEvents btBLH As Button
    Friend WithEvents btAME As Button
End Class
