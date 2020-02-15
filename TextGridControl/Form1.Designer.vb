<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.UcTextGrid1 = New TextGridControl.ucTextGrid()
        Me.UcTextGrid21 = New TextGridControl.ucTextGrid2()
        Me.SuspendLayout()
        '
        'UcTextGrid1
        '
        Me.UcTextGrid1.Location = New System.Drawing.Point(41, 46)
        Me.UcTextGrid1.Name = "UcTextGrid1"
        Me.UcTextGrid1.Size = New System.Drawing.Size(192, 39)
        Me.UcTextGrid1.TabIndex = 0
        '
        'UcTextGrid21
        '
        Me.UcTextGrid21.Location = New System.Drawing.Point(327, 55)
        Me.UcTextGrid21.Name = "UcTextGrid21"
        Me.UcTextGrid21.Size = New System.Drawing.Size(198, 27)
        Me.UcTextGrid21.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 191)
        Me.Controls.Add(Me.UcTextGrid21)
        Me.Controls.Add(Me.UcTextGrid1)
        Me.DoubleBuffered = True
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "583"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcTextGrid1 As ucTextGrid
    Friend WithEvents UcTextGrid21 As ucTextGrid2
End Class
