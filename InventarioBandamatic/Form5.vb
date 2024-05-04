Imports System.Data.SqlClient

Public Class Form5
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
    Private Sub clr()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox1.Focus()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As New DataTable
        Dim con As New SqlConnection("Data Source=localhost;Initial Catalog=InventarioBandamatic;Integrated Security=True")
        Dim consulta As String = "select * from Productos where Codigo = '" & TextBox1.Text & "' "
        Dim comando As New SqlCommand(consulta, con)

        Try

            Dim drd As SqlDataReader
            con.Open()
            drd = comando.ExecuteReader
            If drd.Read() Then
                Me.TextBox2.Text = drd.Item("Nombre").ToString
                Me.TextBox3.Text = drd.Item("Categoria").ToString
                Me.TextBox4.Text = drd.Item("Unidad").ToString
                Me.TextBox8.Text = drd.Item("Cantidad").ToString
            Else
                MsgBox("No existe", MsgBoxStyle.Critical)
            End If

            drd.Close()
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextBox5.Text = "" Or TextBox1.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox9.Text = "") Then

            MsgBox("Ingrese datos")

        Else
            ''Resta cantidad del producto
            sentencia = "update Productos set Cantidad = Cantidad - '" + TextBox5.Text + "' where Codigo = '" + TextBox1.Text + "'"
            mensaje = "Registro de Salida Completado"

            EjecutarSQL(sentencia, mensaje)
            ''Agrega datos a la tabla
            sentencia = " insert into Salida values ('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox5.Text + "','" + DateTimePicker1.Text + "', '" + Label1.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "', '" + TextBox9.Text + "')"
            mensaje = "Registro de Salida Completado"

            EjecutarSQL(sentencia, mensaje)
            clr()

        End If
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = DateTime.Now.ToShortTimeString
        Label2.Text = DateTime.Now.ToShortDateString
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form2.Show()
        Me.Close()

    End Sub



    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class