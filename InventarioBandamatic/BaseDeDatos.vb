Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class BaseDeDatos
    Public cn As SqlConnection
    Public adaptador As SqlDataAdapter
    Public dt As DataTable

    Sub New()
        Try
            cn = New SqlConnection("Data Source=localhost;Initial Catalog=InventarioBandamatic;Integrated Security=True")
            cn.Open()
        Catch ex As Exception
            MessageBox.Show("Error en la conexion: " + ex.ToString)
        End Try
    End Sub

    Sub llenarGrilla(ByVal dgv As DataGridView)
        Try
            adaptador = New SqlDataAdapter("Select * from Productos", cn)
            dt = New DataTable
            adaptador.Fill(dt)
            dgv.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error al llenar la grilla: " + ex.ToString)
        End Try
    End Sub

    Sub consultaDinamica(ByVal id As String, ByVal dgv As DataGridView)
        Try
            adaptador = New SqlDataAdapter("Select * from Productos where Nombre like '" & "%" + id + "%" & "'", cn)
            dt = New DataTable
            adaptador.Fill(dt)
            dgv.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error realizar la consulta dinamica en la grilla: " + ex.ToString)
        End Try
    End Sub
End Class
