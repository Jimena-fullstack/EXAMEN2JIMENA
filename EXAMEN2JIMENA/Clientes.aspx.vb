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
        Dim id As Integer = Convert.ToInt32(gvClientes.DataKeys(e.RowIndex).Value)
        Try
            repo.Delete(id)
            CargarClientes() ' Recargar después de eliminar
        Catch ex As Exception
            lblMensaje.Text = "Error al eliminar el cliente: " & ex.Message
            lblMensaje.ForeColor = Drawing.Color.Red
        End Try
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        ' Validaciones en servidor
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            lblMensaje.Text = "El nombre es obligatorio."
            lblMensaje.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtApellido1.Text) Then
            lblMensaje.Text = "El primer apellido es obligatorio."
            lblMensaje.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtApellido2.Text) Then
            lblMensaje.Text = "El segundo apellido es obligatorio."
            lblMensaje.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtTelefono.Text) Then
            lblMensaje.Text = "El teléfono es obligatorio."
            lblMensaje.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        ' Validar Email con expresión regular
        Dim patronEmail As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        If Not System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), patronEmail) Then
            lblMensaje.Text = "El correo electrónico no es válido."
            lblMensaje.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        Try
            repo.Insert(txtNombre.Text.Trim(),
                        txtApellido1.Text.Trim(),
                        txtApellido2.Text.Trim(),
                        txtEmail.Text.Trim(),
                        txtTelefono.Text.Trim())

            lblMensaje.Text = "Cliente guardado correctamente."
            lblMensaje.ForeColor = Drawing.Color.Green
            CargarClientes() ' Recargar lista después de insertar

        Catch ex As Exception
            lblMensaje.Text = "Error al guardar el cliente: " & ex.Message
            lblMensaje.ForeColor = Drawing.Color.Red
        End Try

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        Response.Redirect("Clientes.aspx")
    End Sub
End Class

