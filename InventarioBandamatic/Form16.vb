Imports iTextSharp.text.pdf
Imports System.Data.OleDb

Public Class Form16



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim bcode As New Barcode128
        bcode.BarHeight = 50
        bcode.Code = TextBox1.Text
        bcode.GenerateChecksum = True
        bcode.CodeType = Barcode.CODE128
        Try

            Dim bm As New Bitmap(bcode.CreateDrawingImage(Color.Black, Color.White))
            Dim img As Image
            img = New Bitmap(bm.Width, bm.Height)
            Dim g As Graphics = Graphics.FromImage(img)
            g.FillRectangle(New SolidBrush(Color.White), 0, 0, bm.Width, bm.Height)
            g.DrawImage(bm, 0, 0)
            PictureBox1.Image = img



            PrintPreviewDialog1.ShowDialog()
            SaveFileDialog1.ShowDialog()
            If SaveFileDialog1.FileName > "" Then
                PictureBox1.Image.Save(SaveFileDialog1.FileName)

            End If
            TextBox1.Clear()
            TextBox1.Focus()
        Catch ex As Exception
            MsgBox("No genera codigo")
            PrintPreviewDialog1.ShowDialog()

        End Try
    End Sub

    Private Sub Form16_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form6.Show()
        Me.Close()

    End Sub
End Class