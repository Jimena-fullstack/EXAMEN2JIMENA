<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Clientes.aspx.vb" Inherits="EXAMEN2JIMENA.Clientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Clientes</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Clientes</h2>

        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False"
              DataKeyNames="Id"
              OnSelectedIndexChanged="gvClientes_SelectedIndexChanged"
              OnRowDeleting="gvClientes_RowDeleting"
              DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" SortExpression="PrimerApellido" />
                <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" SortExpression="SegundoApellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:CommandField ShowSelectButton="True" SelectText="Editar" />
                <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
            SelectCommand="SELECT * FROM [clientes]">
        </asp:SqlDataSource>

        <hr />

        <h3>Formulario</h3>
        <asp:HiddenField ID="hfClienteId" runat="server" />

        Nombre: <asp:TextBox ID="txtNombre" runat="server" /><br />
        Apellido 1: <asp:TextBox ID="txtApellido1" runat="server" /><br />
        Apellido 2: <asp:TextBox ID="txtApellido2" runat="server" /><br />
        Email: <asp:TextBox ID="txtEmail" runat="server" /><br />
        Teléfono: <asp:TextBox ID="txtTelefono" runat="server" /><br />

        Alerta:<asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

    </form>
</body>
</html>
