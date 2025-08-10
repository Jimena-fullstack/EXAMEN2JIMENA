Imports System.Data.SqlClient

Public Class Clientes
    Inherits System.Web.UI.Page

    Private repo As New ClientesRepository()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarClientes()
        End If
    End Sub

    Private Sub CargarClientes()
        gvClientes.DataSource = repo.GetAll()
        gvClientes.DataBind()
    End Sub

    Protected Sub gvClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvClientes.SelectedIndexChanged
        Dim id As Integer = Convert.ToInt32(gvClientes.SelectedDataKey.Value)
        Response.Redirect("EditarCliente.aspx?id=" & id)
    End Sub

    Protected Sub gvClientes_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvClientes.RowDeleting

        Try
            repo.Delete(id)
            CargarClientes() ' Recargar después de eliminar
        Catch ex As Exception
            lblMensaje.Text = "Error al eliminar el cliente: " & ex.Message
            lblMensaje.ForeColor = Drawing.Color.Red
        End Try
    End Sub


    Protected Sub gvClientes_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles gvClientes.RowEditing
        gvClientes.EditIndex = e.NewEditIndex
        CargarClientes()
    End Sub

    Protected Sub gvClientes_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles gvClientes.RowCancelingEdit
        gvClientes.EditIndex = -1
        CargarClientes()
    End Sub

    Protected Sub gvClientes_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gvClientes.RowUpdating
        Dim id As Integer = Convert.ToInt32(gvClientes.DataKeys(e.RowIndex).Value)


        Dim nombre As String = CType(gvClientes.Rows(e.RowIndex).FindControl("txtNombre"), TextBox).Text.Trim()
        Dim apellido1 As String = CType(gvClientes.Rows(e.RowIndex).FindControl("txtApellido1"), TextBox).Text.Trim()
        Dim apellido2 As String = CType(gvClientes.Rows(e.RowIndex).FindControl("txtApellido2"), TextBox).Text.Trim()
        Dim email As String = CType(gvClientes.Rows(e.RowIndex).FindControl("txtEmail"), TextBox).Text.Trim()
        Dim telefono As String = CType(gvClientes.Rows(e.RowIndex).FindControl("txtTelefono"), TextBox).Text.Trim()

        Try
            repo.Update(id, nombre, apellido1, apellido2, email, telefono)
            gvClientes.EditIndex = -1
            CargarClientes()
        Catch ex As Exception
            lblMensaje.Text = "Error al actualizar el cliente: " & ex.Message
            lblMensaje.ForeColor = Drawing.Color.Red
        End Try
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)


        Dim connStr As String = ConfigurationManager.ConnectionStrings("ClientesConnetionString").ConnectionString

        Using conn As New SqlConnection(connStr)

            Dim query As String = "INSERT INTO Clientes (Nombre, Apellido1, Apellido2, Email, Telefono) VALUES (@Nombre, @Apellido1, @Apellido2,  @Email,  @Telefono)"

            Using cmd As New SqlCommand(query, conn)


                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text)
                cmd.Parameters.AddWithValue("@Apellido1", txtApellido1.Text)
                cmd.Parameters.AddWithValue("@Apellido2", txtApellido2.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text)
                ' Abre la conexión y ejecuta la instrucción SQL
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarFormulario()
    End Sub

    ' Método para limpiar los controles del formulario
    Private Sub LimpiarFormulario()
        txtNombre.Text = ""
        txtApellido1.Text = ""
        txtApellido2.Text = ""
        txtEmail.Text = ""
        txtTelefono.Text = ""

    End Sub

End Class


