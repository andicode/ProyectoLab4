<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="index.usuarios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nuestros Usuarios</title>
</head>
<body>
<h1>Usuarios:</h1>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="tbBuscarAmigos" runat="server"></asp:TextBox>
    <asp:Button ID="btnBuscarAmigos" runat="server" Text="buscar" />
    <asp:TextBox ID="tbResultado" runat="server"></asp:TextBox>
    <asp:GridView ID="gusuarios" runat="server" AutoGenerateColumns="false">
    <Columns>
    <asp:BoundField DataField="IdUsuario" />
    <asp:BoundField DataField="Nombre" />
    <asp:BoundField DataField="Email" />
    </Columns>    
    </asp:GridView>
    </div>
    </form>
</body>
</html>
