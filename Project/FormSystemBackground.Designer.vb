<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSystemBackground
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSystemBackground))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btSelecionar = New System.Windows.Forms.Button()
        Me.btOK = New System.Windows.Forms.Button()
        Me.pbDemo = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbLocal = New System.Windows.Forms.Label()
        Me.btRemover = New System.Windows.Forms.Button()
        CType(Me.pbDemo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.InitialDirectory = "@""C:\"""
        Me.OpenFileDialog1.RestoreDirectory = True
        Me.OpenFileDialog1.Title = "Selecionar Imagem"
        '
        'btSelecionar
        '
        Me.btSelecionar.BackColor = System.Drawing.Color.SteelBlue
        Me.btSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btSelecionar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btSelecionar.ForeColor = System.Drawing.Color.White
        Me.btSelecionar.Location = New System.Drawing.Point(12, 218)
        Me.btSelecionar.Name = "btSelecionar"
        Me.btSelecionar.Size = New System.Drawing.Size(150, 47)
        Me.btSelecionar.TabIndex = 1
        Me.btSelecionar.Text = "Selecionar imagem"
        Me.btSelecionar.UseVisualStyleBackColor = False
        '
        'btOK
        '
        Me.btOK.BackColor = System.Drawing.Color.DarkGray
        Me.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOK.ForeColor = System.Drawing.Color.White
        Me.btOK.Location = New System.Drawing.Point(305, 218)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(75, 47)
        Me.btOK.TabIndex = 2
        Me.btOK.Text = "OK"
        Me.btOK.UseVisualStyleBackColor = False
        '
        'pbDemo
        '
        Me.pbDemo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbDemo.Location = New System.Drawing.Point(12, 12)
        Me.pbDemo.Name = "pbDemo"
        Me.pbDemo.Size = New System.Drawing.Size(368, 200)
        Me.pbDemo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbDemo.TabIndex = 0
        Me.pbDemo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 273)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Local: "
        '
        'lbLocal
        '
        Me.lbLocal.AutoSize = True
        Me.lbLocal.Location = New System.Drawing.Point(48, 273)
        Me.lbLocal.Name = "lbLocal"
        Me.lbLocal.Size = New System.Drawing.Size(0, 13)
        Me.lbLocal.TabIndex = 4
        '
        'btRemover
        '
        Me.btRemover.BackColor = System.Drawing.Color.IndianRed
        Me.btRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btRemover.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRemover.ForeColor = System.Drawing.Color.White
        Me.btRemover.Location = New System.Drawing.Point(168, 218)
        Me.btRemover.Name = "btRemover"
        Me.btRemover.Size = New System.Drawing.Size(131, 47)
        Me.btRemover.TabIndex = 5
        Me.btRemover.Text = "Remover"
        Me.btRemover.UseVisualStyleBackColor = False
        '
        'Fbackground
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 295)
        Me.Controls.Add(Me.btRemover)
        Me.Controls.Add(Me.lbLocal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btOK)
        Me.Controls.Add(Me.btSelecionar)
        Me.Controls.Add(Me.pbDemo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Fbackground"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plano de Fundo"
        CType(Me.pbDemo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pbDemo As System.Windows.Forms.PictureBox
    Friend WithEvents btSelecionar As System.Windows.Forms.Button
    Friend WithEvents btOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbLocal As System.Windows.Forms.Label
    Friend WithEvents btRemover As System.Windows.Forms.Button
End Class
