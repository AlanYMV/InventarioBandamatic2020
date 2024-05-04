
Imports iTextSharp.text.pdf
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Form3

    Dim obj As New numeror

    Dim conexion As New SqlConnection("Data Source=localhost;Initial Catalog=InventarioBandamatic;Integrated Security=True")

    Dim sentencia, mensaje As String

    Sub EjecutarSQL(sql As String, msg As String)
        Try
            Dim cmd As New SqlCommand(sql, conexion)
            conexion.Open()
            cmd.ExecuteNonQuery()
            conexion.Close()
            MsgBox(msg)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bcode As New Barcode128
        bcode.BarHeight = 50
        bcode.Code = TxtCodigo.Text
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
        Catch ex As Exception
            MsgBox("No genera codigo")
            PrintPreviewDialog1.ShowDialog()
        End Try
    End Sub

    Private Sub clr()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

        TextBox2.Focus()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox1.Text = "" Then


            MsgBox("Ingrese datos")

        Else

            ''Registro de productos
            sentencia = " insert into Productos values ('" + TxtCodigo.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "', '" + TextBox5.Text + "')"
            mensaje = "Producto Registrado"

            EjecutarSQL(sentencia, mensaje)
            ''Entradas de productos
            sentencia = " insert into Entradas values ('" + TxtCodigo.Text + "','" + TextBox2.Text + "','" + TextBox5.Text + "', '" + DateTimePicker1.Text + "', '" + Label1.Text + "', '" + TextBox1.Text + "' )"
            mensaje = "Producto Registrado"

            EjecutarSQL(sentencia, mensaje)
            PrintPreviewDialog1.ShowDialog()



            SaveFileDialog1.ShowDialog()
            If SaveFileDialog1.FileName > "" Then
                PictureBox1.Image.Save(SaveFileDialog1.FileName)

            End If

            TxtCodigo.Text = obj.random()
            clr()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = DateTime.Now.ToShortTimeString
        Label2.Text = DateTime.Now.ToShortDateString
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form2.Show()
        Me.Close()

    End Sub


    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False

        Else
            e.Handled = True
        End If
    End Sub


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtCodigo.Text = obj.random()

    End Sub
End Class