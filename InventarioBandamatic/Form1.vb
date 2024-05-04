Imports System.Data.SqlClient

Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form13.Show()
        Me.Close()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim connection As New SqlConnection("Data Source=localhost;Initial Catalog=InventarioBandamatic;Integrated Security=True")

        Dim command As New SqlCommand("select * from Usuarios where Usuario = @username and Contraseña = @password", connection)

        command.Parameters.Add("@username", SqlDbType.VarChar).Value = TextBox1.Text
        command.Parameters.Add("@password", SqlDbType.VarChar).Value = TextBox2.Text

        Dim adapter As New SqlDataAdapter(command)

        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count() <= 0 Then

            MessageBox.Show("Ingrese Usuario y Contraseña correcta")

        Else

            Form2.Show()
            Me.Close()

        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox1.Focus()
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form11.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form12.Show()
        Me.Close()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
        ElseIf CheckBox1.Checked = False Then
            TextBox2.PasswordChar = "☼"
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Form16.Show()
        Me.Close()

    End Sub
End Class
