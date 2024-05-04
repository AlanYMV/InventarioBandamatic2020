Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Form10
    Dim connection As New SqlConnection("Data Source=localhost;Initial Catalog=InventarioBandamatic;Integrated Security=True")

    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim table As New DataTable()
        Dim adapter As New SqlDataAdapter("SELECT * FROM Salida", connection)

        adapter.Fill(table)

        DataGridView1.DataSource = table
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim table As New DataTable()
        Dim command As New SqlCommand("SELECT * FROM Salida WHERE Fecha BETWEEN @d1 AND @d2", connection)

        command.Parameters.Add("@d1", SqlDbType.Date).Value = DateTimePicker1.Value
        command.Parameters.Add("@d2", SqlDbType.Date).Value = DateTimePicker2.Value

        Dim adapter As New SqlDataAdapter(command)

        adapter.Fill(table)

        DataGridView1.DataSource = table
    End Sub



    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        DataGridView1.DrawToBitmap(bm, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        llenarExcel(DataGridView1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form13.Show()
        Me.Close()

    End Sub
End Class