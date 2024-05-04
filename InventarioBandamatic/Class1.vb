Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class Class1

    Public cn As SqlConnection
    Public cmd As SqlCommand
    Public adaptador As SqlDataAdapter
    Public dt As DataTable
    Public dr As SqlDataReader


    Sub New()
        Try

            cn = New SqlConnection("Data Source=localhost;Initial Catalog=InventarioBandamatic;Integrated Security=True")
            cn.Open()
        Catch ex As Exception
            MessageBox.Show("Error en la conexion: " + ex.ToString)
        End Try
    End Sub



    Function RecuperarContraseña(ByVal id As String, id2 As String) As Boolean
        Dim resultado As Boolean = False
        Try
            cmd = New SqlCommand("Select * from Usuarios where Usuario= '" & id & "' and Nacimiento = '" & id2 & "' ", cn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                resultado = True
            End If
            dr.Close()

        Catch ex As Exception
            MsgBox("Error en el procedimiento:" + ex.ToString)
        End Try
        Return resultado


    End Function


End Class