Imports System.Data.SqlClient
Public Class Form12

    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter

    Dim Accion As String
    Dim res As Integer
    Dim sql As String

    Dim dt As DataTable
    Dim id As String
    Public conn As New Class1

    Public Sub conectar()
        con = New SqlConnection
        con.ConnectionString = ("Data Source=localhost;Initial Catalog=InventarioBandamatic;Integrated Security=True")
        con.Open()

    End Sub

    Public Sub ejecutar(consulta As String)

        conectar()
        com = New SqlCommand(consulta, con)
        res = com.ExecuteNonQuery

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Or DateTimePicker1.Text = "" Or TextBox3.Text = "" Then

            MessageBox.Show("Llene todos los campos")

        Else

            If conn.RecuperarContraseña(TextBox1.Text, DateTimePicker1.Text) = True Then


                sql = "update Usuarios set Contraseña = '" + TextBox3.Text + "' where Usuario ='" + TextBox1.Text + "'"
                ejecutar(sql)

                MessageBox.Show("Contraseña cambiada")


                TextBox1.Clear()

                TextBox3.Clear()
                TextBox1.Focus()



            Else
                MessageBox.Show("Error")
            End If
        End If



    End Sub


    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox3.PasswordChar = ""
        ElseIf CheckBox1.Checked = False Then
            TextBox3.PasswordChar = "☼"
        End If
    End Sub
End Class