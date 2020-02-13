Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Prepare sample datatable
        Dim dt As DataTable = New DataTable
        With dt
            With .Columns
                .Add("SN")
                .Add("External")
                .Add("Table")
            End With

            .Rows.Add({1, $"Marc", "99"})
            .Rows.Add({2, $"Alfaro", "99"})
            .Rows.Add({3, $"TextGrid", "99"})

            For i As Integer = 4 To 8
                .Rows.Add({i, $"Person {i}", $"{i * 10}"})
            Next
        End With

        'Load data to usercontrol
        UcTextGrid1.Init("External", dt)
    End Sub
End Class
