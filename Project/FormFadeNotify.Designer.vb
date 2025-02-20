<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFadeNotify
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
        Me.btOK = New System.Windows.Forms.Button()
        Me.lbNotify = New System.Windows.Forms.Label()
        Me.lbCount = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btOK
        '
        Me.btOK.BackColor = System.Drawing.Color.ForestGreen
        Me.btOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btOK.FlatAppearance.BorderSize = 0
        Me.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btOK.ForeColor = System.Drawing.Color.White
        Me.btOK.Location = New System.Drawing.Point(307, 22)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(43, 30)
        Me.btOK.TabIndex = 1
        Me.btOK.Text = "OK"
        Me.btOK.UseVisualStyleBackColor = False
        '
        'lbNotify
        '
        Me.lbNotify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbNotify.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNotify.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbNotify.Location = New System.Drawing.Point(50, 19)
        Me.lbNotify.Name = "lbNotify"
        Me.lbNotify.Size = New System.Drawing.Size(248, 36)
        Me.lbNotify.TabIndex = 2
        Me.lbNotify.Text = "Notificações"
        Me.lbNotify.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbCount
        '
        Me.lbCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCount.Location = New System.Drawing.Point(7, 12)
        Me.lbCount.Name = "lbCount"
        Me.lbCount.Size = New System.Drawing.Size(37, 51)
        Me.lbCount.TabIndex = 3
        Me.lbCount.Text = "0"
        Me.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormFadeNotify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(362, 75)
        Me.Controls.Add(Me.lbCount)
        Me.Controls.Add(Me.lbNotify)
        Me.Controls.Add(Me.btOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormFadeNotify"
        Me.Opacity = 0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btOK As Button
    Friend WithEvents lbNotify As Label
    Friend WithEvents lbCount As Label
End Class
