Imports System.Data.SqlClient

Public Class Clientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub gvClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvClientes.SelectedIndexChanged
        Dim id As Integer = Convert.ToInt32(gvClientes.SelectedDataKey.Value)
        Response.Redirect("EditarCliente.aspx?id=" & id)
    End Sub

    Protected Sub gvClientes_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvClientes.RowDeleting
        Dim id As Integer = Convert.ToInt32(gvClientes.DataKeys(e.RowIndex).Value)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Examen2ConnectionString").ConnectionString

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "DELETE FROM Clientes WHERE Id = @Id"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Id", id)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        ' Lógica para guardar un cliente
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Conexion").ConnectionString

        ' Consulta SQL para insertar un nuevo cliente
        Dim query As String = "INSERT INTO Datoscliente (Nombre, Apellido1, Apellido2, Email, Telefono) VALUES (@Nombre, @Apellido1, @Apellido2,@Email, @Telefono)"

        ' Usar Using para manejar la conexión automáticamente
        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                ' Pasar parámetros desde los controles del formulario
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim())
                cmd.Parameters.AddWithValue("@Apellido1", txtApellido1.Text.Trim())
                cmd.Parameters.AddWithValue("@Apellido2", txtApellido2.Text.Trim())
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim())

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery() ' Ejecutar INSERT
                    lblMensaje.Text = "Cliente guardado correctamente."
                    lblMensaje.ForeColor = Drawing.Color.Green
                Catch ex As Exception
                    lblMensaje.Text = "Error al guardar el cliente: " & ex.Message
                    lblMensaje.ForeColor = Drawing.Color.Red
                End Try
            End Using
        End Using
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        Response.Redirect("Clientes.aspx")
    End Sub


End Class