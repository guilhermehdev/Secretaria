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
        Me.btOuvidoria = New System.Windows.Forms.Button()
        Me.btEmendas = New System.Windows.Forms.Button()
        Me.btRecepcao = New System.Windows.Forms.Button()
        Me.btSair = New System.Windows.Forms.Button()
        Me.btCNES = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btOuvidoria
        '
        Me.btOuvidoria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btOuvidoria.Location = New System.Drawing.Point(12, 12)
        Me.btOuvidoria.Name = "btOuvidoria"
        Me.btOuvidoria.Size = New System.Drawing.Size(81, 47)
        Me.btOuvidoria.TabIndex = 1
        Me.btOuvidoria.Text = "Ouvidoria"
        Me.btOuvidoria.UseVisualStyleBackColor = True
        '
        'btEmendas
        '
        Me.btEmendas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btEmendas.Location = New System.Drawing.Point(186, 12)
        Me.btEmendas.Name = "btEmendas"
        Me.btEmendas.Size = New System.Drawing.Size(81, 47)
        Me.btEmendas.TabIndex = 0
        Me.btEmendas.Text = "AME"
        Me.btEmendas.UseVisualStyleBackColor = True
        '
        'btRecepcao
        '
        Me.btRecepcao.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btRecepcao.Location = New System.Drawing.Point(99, 12)
        Me.btRecepcao.Name = "btRecepcao"
        Me.btRecepcao.Size = New System.Drawing.Size(81, 47)
        Me.btRecepcao.TabIndex = 2
        Me.btRecepcao.Text = "Cadastro EMTU"
        Me.btRecepcao.UseVisualStyleBackColor = True
        '
        'btSair
        '
        Me.btSair.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btSair.Location = New System.Drawing.Point(192, 94)
        Me.btSair.Name = "btSair"
        Me.btSair.Size = New System.Drawing.Size(75, 23)
        Me.btSair.TabIndex = 3
        Me.btSair.Text = "Sair"
        Me.btSair.UseVisualStyleBackColor = True
        '
        'btCNES
        '
        Me.btCNES.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btCNES.Location = New System.Drawing.Point(12, 65)
        Me.btCNES.Name = "btCNES"
        Me.btCNES.Size = New System.Drawing.Size(81, 47)
        Me.btCNES.TabIndex = 4
        Me.btCNES.Text = "CNES"
        Me.btCNES.UseVisualStyleBackColor = True
        '
        'Fstart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(277, 129)
        Me.Controls.Add(Me.btCNES)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.btRecepcao)
        Me.Controls.Add(Me.btEmendas)
        Me.Controls.Add(Me.btOuvidoria)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fstart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecione o sistema"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btOuvidoria As System.Windows.Forms.Button
    Friend WithEvents btEmendas As System.Windows.Forms.Button
    Friend WithEvents btRecepcao As System.Windows.Forms.Button
    Friend WithEvents btSair As Button
    Friend WithEvents btCNES As Button
End Class
