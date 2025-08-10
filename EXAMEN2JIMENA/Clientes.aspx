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
            DataKeyNames="ClienteId"
            OnSelectedIndexChanged="gvClientes_SelectedIndexChanged"
            OnRowDeleting="gvClientes_RowDeleting">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ShowEditButton="True" ShowDeleteButton="True" />
                <asp:BoundField DataField="ClienteId" HeaderText="ClienteId" InsertVisible="False" ReadOnly="True" SortExpression="ClienteId" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido1" HeaderText="Apellido1" SortExpression="Apellido1" />
                <asp:BoundField DataField="Apellido2" HeaderText="Apellido2" SortExpression="Apellido2" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSourceClientes" runat="server"
            ConnectionString="<%$ ConnectionStrings:ClientesConnectionString %>"
            ProviderName="<%$ ConnectionStrings:ClientesConnectionString.ProviderName %>"
            SelectCommand="SELECT * FROM [Clientes]"
            UpdateCommand="UPDATE Clientes 
                           SET Nombre=@Nombre, 
                               Apellido1=@Apellido1, 
                               Apellido2=@Apellido2, 
                               Email=@Email, 
                               Telefono=@Telefono 
                           WHERE ClienteId=@ClienteId"
            DeleteCommand="DELETE FROM Clientes WHERE ClienteId=@ClienteId">
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ClientesConnectionString %>" 
            SelectCommand="SELECT * FROM [Datoscliente]">
        </asp:SqlDataSource>

        <hr />

        <h3>Formulario</h3>
        <asp:HiddenField ID="hfClienteId" runat="server" />

        Nombre: <asp:TextBox ID="txtNombre" runat="server" /><br />
        Apellido 1: <asp:TextBox ID="txtApellido1" runat="server" /><br />
        Apellido 2: <asp:TextBox ID="txtApellido2" runat="server" /><br />
        Email: <asp:TextBox ID="txtEmail" runat="server" /><br />
        Teléfono: <asp:TextBox ID="txtTelefono" runat="server" /><br />

        Alerta: <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />

    </form>
</body>
</html>
