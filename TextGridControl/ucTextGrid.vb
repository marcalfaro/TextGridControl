Option Explicit On

Public Class ucTextGrid

    Private WithEvents sPanel As New Panel
    Private WithEvents tbSearch As New TextBox
    Private WithEvents dgv As New DataGridView
    Private WithEvents tsDropDown As New ToolStripDropDown

    Private ColumnForSearching As String = String.Empty
    Private GridDataSource As Object = Nothing

    Public Sub Init(ByVal SearchColumn As String, ByVal DataSource As Object)
        ColumnForSearching = SearchColumn
        GridDataSource = DataSource
    End Sub

    Private Sub TextDrop_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Build_SearchControls()

    End Sub

    Private Sub Build_SearchControls()
        Try
            sPanel.SuspendLayout()
            CType(dgv, ComponentModel.ISupportInitialize).BeginInit()

            With sPanel
                .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
                .Controls.Add(dgv)
                .Controls.Add(tbSearch)
                .Name = "sPanel"
                .Size = New System.Drawing.Size(342, 161)
            End With

            With tbSearch
                .ForeColor = Color.Red
                .Location = New System.Drawing.Point(3, 3)
                .Name = "sTB"
                .Size = New System.Drawing.Size(334, 20)
                '.Size = tb.Size
                .TabIndex = 0
                .Text = "Search here"
                '.Dock = DockStyle.Fill
            End With

            With dgv
                .Name = "sDGV"
                .ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
                .Location = New System.Drawing.Point(3, 29)
                .Size = New System.Drawing.Size(334, 127)
            End With

            sPanel.ResumeLayout(False)
            sPanel.PerformLayout()
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

    Private Sub tsDropDown_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles tsDropDown.Closing
        'e.Cancel = Not (e.CloseReason = ToolStripDropDownCloseReason.CloseCalled OrElse e.CloseReason = ToolStripDropDownCloseReason.AppFocusChange)
        'TextBox1.Text = If(e.Cancel, "Close Options", "Open Options")
    End Sub

    Private Sub tsDropDown_Opened(sender As Object, e As EventArgs) Handles tsDropDown.Opened
        Debug.Print("tsDropDown_Opened")
    End Sub

    Private Sub tsDropDown_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles tsDropDown.Closed
        'return text and focus to the original textbox
        tb.Text = tbSearch.Text
        tb.SelectionStart = tb.Text.Length
    End Sub

    Private Sub tb_TextChanged(sender As Object, e As EventArgs) Handles tb.TextChanged
        Try
            'transfer text to secondary textbox for searching
            tbSearch.Text = tb.Text
            Dim pts As Point = PointToScreen(tb.Location)
            'tsDropDown.Show(pts.X, pts.Y + tb.Height)
            tsDropDown.Show(pts.X, pts.Y)
            tbSearch.Focus()
            tbSearch.SelectionStart = tbSearch.Text.Length
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
        Try
            Dim kword As String = tbSearch.Text
            dgv.DataSource = Nothing

            If GridDataSource IsNot Nothing Then
                Dim F As DataRow() = GridDataSource.Select($"{ColumnForSearching} LIKE '%{kword}%'")
                If F IsNot Nothing AndAlso F.Count > 0 Then
                    LoadDataGridViewData(F.CopyToDataTable)
                End If
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Private Sub LoadDataGridViewData(ByVal ds As Object)
        Try
            dgv.ColumnHeadersVisible = False
            dgv.DataSource = ds
            dgv.ColumnHeadersVisible = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim cp = MyBase.CreateParams
    '        cp.Style = cp.Style Or &H840000
    '        Return cp
    '    End Get
    'End Property
End Class
