<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Flogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Flogin))
        Me.txsenha = New System.Windows.Forms.TextBox()
        Me.btok = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txsenha
        '
        Me.txsenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txsenha.Location = New System.Drawing.Point(12, 28)
        Me.txsenha.Name = "txsenha"
        Me.txsenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txsenha.Size = New System.Drawing.Size(133, 20)
        Me.txsenha.TabIndex = 0
        Me.txsenha.UseSystemPasswordChar = True
        '
        'btok
        '
        Me.btok.Location = New System.Drawing.Point(151, 28)
        Me.btok.Name = "btok"
        Me.btok.Size = New System.Drawing.Size(75, 23)
        Me.btok.TabIndex = 1
        Me.btok.Text = "&OK"
        Me.btok.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Digite a senha"
        '
        'Flogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(238, 70)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btok)
        Me.Controls.Add(Me.txsenha)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Flogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autenticação"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txsenha As System.Windows.Forms.TextBox
    Friend WithEvents btok As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
