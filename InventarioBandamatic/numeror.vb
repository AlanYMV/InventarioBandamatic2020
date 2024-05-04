Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class numeror
    Dim conexion As New SqlConnection
    Dim cmd As SqlCommand
    Dim adaptador As SqlDataAdapter
    Dim dt As DataTable
    Dim dr As SqlDataReader


    Sub New()

        Try
            conexion = New SqlConnection("Data Source=localhost;Initial Catalog=InventarioBandamatic;Integrated Security=True")
            conexion.Open()

        Catch ex As Exception
            MessageBox.Show("Error en conexion" + ex.ToString)
        End Try

    End Sub

    Function random()
        Dim codigo As String = ""
        Dim total As Integer = 0
        Try
            cmd = New SqlCommand("Select count(*) as totalRegistros from Productos", conexion)
            dr = cmd.ExecuteReader
            If dr.Read Then
                total = CInt(dr.Item("totalRegistros"))
            End If

            dr.Close()
            If total < 10 Then
                codigo = "BM-0000" + total.ToString
            ElseIf total < 100 Then
                codigo = "BM-000" + total.ToString
            ElseIf total < 1000 Then
                codigo = "BM-00" + total.ToString
            ElseIf total < 10000 Then
                codigo = "BM-0" + total.ToString
            End If
        Catch ex As Exception
            MessageBox.Show("Error al generar el código:" + ex.ToString)
        End Try
        Return codigo

    End Function

End Class
