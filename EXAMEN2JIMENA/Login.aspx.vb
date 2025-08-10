Imports System.Data.SqlClient

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Examen2ConnectionString").ConnectionString

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM LOGIN WHERE Usuario = @Usuario AND Contraseña = @Contraseña"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Usuario", txtMail.Text)
                cmd.Parameters.AddWithValue("@Contraseña", txtContraseña.Text)

                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If count > 0 Then
                    Response.Redirect("Clientes.aspx")
                Else
                    lblMensaje.Text = "Usuario o contraseña incorrectos."
                End If
            End Using
        End Using
    End Sub


End Class