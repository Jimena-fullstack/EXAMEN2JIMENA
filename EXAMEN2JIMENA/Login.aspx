<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="EXAMEN2JIMENA.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
</head>
<body>
<form id="form1" runat="server">

    <h2>Iniciar Sesión</h2>

    Email: <asp:TextBox ID="txtMail" runat="server" /><br />
    Contraseña: <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" /><br />
    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" /><br />
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />

</form>
</body>
</html>
</asp:Content>

