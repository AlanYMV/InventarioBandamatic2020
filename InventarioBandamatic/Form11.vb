Imports System.Data
Imports System.Data.SqlClient

Public Class Form11
    Dim con As SqlConnection = New SqlConnection("Data Source=localhost;Initial Catalog=InventarioBandamatic;Integrated Security=True")
    Dim cmd As SqlCommand


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

    Private Sub insert()
        sentencia = "INSERT INTO Usuarios values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + DateTimePicker1.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "')"
        mensaje = "Usuario Registrado, Correctamente"

        EjecutarSQL(sentencia, mensaje)

    End Sub

    Public Sub clr()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox1.Focus()


    End Sub

    Public Sub bindgv()
        con = New SqlConnection("Data Source=LAPTOP-ZUNIG;Initial Catalog=InventarioBandamatic;Integrated Security=True")
        con.Open()
        Using cmd = New SqlCommand("Select * from Usuarios", con)
            cmd.CommandType = CommandType.Text
            Using sda As New SqlDataAdapter(cmd)
                Using dt As New DataTable()
                    sda.Fill(dt)
                    DataGridView1.DataSource = dt

                End Using
            End Using

        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Llene todos los campos")
        Else
            con = New SqlConnection("Data Source=localhost;Initial Catalog=InventarioBandamatic;Integrated Security=True")
            Dim theQuery As String = "select * from Usuarios where Usuario = @roll"
            con.Open()
            Dim cmd1 As SqlCommand = New SqlCommand(theQuery, con)
            cmd1.Parameters.AddWithValue("@roll", TextBox6.Text)

            Dim reader As SqlDataReader = cmd1.ExecuteReader()

            If reader.HasRows Then
                MsgBox("Nombre de usuario ya existe, pruebe otro")
            Else
                insert()
                clr()

            End If
        End If
        con.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox7.PasswordChar = ""
        ElseIf CheckBox1.Checked = False Then
            TextBox7.PasswordChar = "☼"
        End If
    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bindgv()

    End Sub
End Class 'Muchos sqlconnection jaja