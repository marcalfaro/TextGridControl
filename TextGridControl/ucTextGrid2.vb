Public Class ucTextGrid2

    Private WithEvents sPanel As New Panel
    Private WithEvents dgv As New DataGridView
    Private WithEvents tsDropDown As New ToolStripDropDown


    Private Sub ucTextGrid2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Build_SearchControls()

        Dim frm As Form = FindForm()
        If frm IsNot Nothing Then
            'frm.Text = Now.ToString("fff")

            'AddHandler f.Move, Sub() tsDropDown.Hide()
            'AddHandler ParentForm.Click, AddressOf parent_Move
            'AddHandler ParentForm.Move, AddressOf parent_Move

            AddHandler ParentForm.Click, Sub() tsDropDown.Close()
            AddHandler ParentForm.Move, Sub() tsDropDown.Close()
        End If
    End Sub

    Private Sub parent_Move()
        Debug.Print("parent_Move()")
        tsDropDown.Close()
    End Sub

    Public Sub ShowDropDown()
        If tsDropDown.Visible = False Then
            Dim pts As Point = PointToScreen(tb.Location)
            'tsDropDown.Show(Me, Button1.Left + Button1.Height + 5, Button1.Top)
            tsDropDown.Show(pts.X, pts.Y + tb.Height)
        Else
            tsDropDown.Close()
        End If
    End Sub

    Private Sub Build_SearchControls()
        Try
            CType(dgv, ComponentModel.ISupportInitialize).BeginInit()

            With sPanel
                sPanel.SuspendLayout()
                .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                .Controls.Add(dgv)
                '.Controls.Add(tbSearch)
                .Name = "sPanel"
                .Size = New System.Drawing.Size(342, 161)
            End With

            'With tbSearch
            '    .ForeColor = Color.Red
            '    .Location = New System.Drawing.Point(3, 3)
            '    .Name = "sTB"
            '    .Size = New System.Drawing.Size(334, 20)
            '    '.Size = tb.Size
            '    .TabIndex = 0
            '    .Text = "Search here"
            '    '.Dock = DockStyle.Fill
            'End With

            With dgv
                .Name = "sDGV"
                .ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
                .Location = New System.Drawing.Point(3, 29)
                .Size = New System.Drawing.Size(334, 127)
            End With

            'sPanel.ResumeLayout(False)
            'sPanel.PerformLayout()
            CType(dgv, System.ComponentModel.ISupportInitialize).EndInit()


            Dim frm As Form = FindForm()
            If frm IsNot Nothing Then
                dgv.BindingContext = frm.BindingContext
            End If

            Dim tsmiHost As New ToolStripControlHost(sPanel)
            tsmiHost.Margin = New Padding(0)
            tsDropDown.Padding = New Padding(0)
            tsDropDown.Items.Add(tsmiHost)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub tb_TextChanged(sender As Object, e As EventArgs) Handles tb.TextChanged
        Try
            Dim pts As Point = PointToScreen(tb.Location)

            tsDropDown.AutoClose = False

            'tsDropDown.Show(pts.X, pts.Y + tb.Height)
            tsDropDown.Show(pts.X, pts.Y + tb.Height)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'tsDropDown.Hide()
        'ShowDropDown()
        tsDropDown.Close()
    End Sub
End Class
