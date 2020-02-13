Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable = New DataTable
        With dt
            With .Columns
                .Add("SN")
                .Add("External")
                .Add("Table")
            End With
            For i As Integer = 1 To 5
                .Rows.Add({i, $"Person {i}", $"{i * 10}"})
            Next
        End With

        UcTextGrid1.Init("External", dt)
    End Sub
End Class
