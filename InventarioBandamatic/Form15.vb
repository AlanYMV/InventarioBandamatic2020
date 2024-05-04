Imports System.Data.SqlClient

Public Class Form15

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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextBox1.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "") Then

            MsgBox("Ingrese datos")

        Else
            ''Resta cantidad del producto
            sentencia = "update Productos set Nombre = '" + TextBox6.Text + "', Categoria ='" + TextBox7.Text + "', Unidad = '" + TextBox8.Text + "', Cantidad = '" + TextBox9.Text + "'   where Codigo = '" + TextBox1.Text + "'"
            mensaje = "Producto Editado Correctamente"

            EjecutarSQL(sentencia, mensaje)
            clr
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form2.Show()
        Me.Close()

    End Sub

    Private Sub Form15_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False

        Else
            e.Handled = True
        End If
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
                Me.TextBox5.Text = drd.Item("Cantidad").ToString
            Else
                MsgBox("No existe", MsgBoxStyle.Critical)
            End If

            drd.Close()
            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
End Class