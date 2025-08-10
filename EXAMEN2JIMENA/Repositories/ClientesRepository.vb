Imports System.Data.SqlClient

Public Class ClientesRepository

    Private ReadOnly connectionString As String

    Public Sub New()
        connectionString = ConfigurationManager.ConnectionStrings("Conexion").ConnectionString
    End Sub

    ' Obtener todos los clientes
    Public Function GetAll() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("SELECT * FROM DatosCliente", conn)
                    conn.Open()
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener clientes: " & ex.Message)
        End Try
        Return dt
    End Function

    ' Insertar 
    Public Sub Insert(nombre As String, apellido1 As String, apellido2 As String, email As String, telefono As String)
        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("INSERT INTO DatosCliente (Nombre, Apellido1, Apellido2, Email, Telefono) VALUES (@Nombre, @Apellido1, @Apellido2, @Email, @Telefono)", conn)
                    cmd.Parameters.AddWithValue("@Nombre", nombre)
                    cmd.Parameters.AddWithValue("@Apellido1", apellido1)
                    cmd.Parameters.AddWithValue("@Apellido2", apellido2)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Telefono", telefono)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al insertar cliente: " & ex.Message)
        End Try
    End Sub

    ' Actualizar
    Public Sub Update(id As Integer, nombre As String, apellido1 As String, apellido2 As String, email As String, telefono As String)
        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("UPDATE DatosCliente SET Nombre=@Nombre, Apellido1=@Apellido1, Apellido2=@Apellido2, Email=@Email, Telefono=@Telefono WHERE Id=@Id", conn)
                    cmd.Parameters.AddWithValue("@Id", id)
                    cmd.Parameters.AddWithValue("@Nombre", nombre)
                    cmd.Parameters.AddWithValue("@Apellido1", apellido1)
                    cmd.Parameters.AddWithValue("@Apellido2", apellido2)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Telefono", telefono)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al actualizar cliente: " & ex.Message)
        End Try
    End Sub

    ' Eliminar
    Public Sub Delete(id As Integer)
        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("DELETE FROM DatosCliente WHERE Id=@Id", conn)
                    cmd.Parameters.AddWithValue("@Id", id)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al eliminar cliente: " & ex.Message)
        End Try
    End Sub

End Class
