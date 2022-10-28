<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="height: 39px">-- Menú --</h1>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Button ID="btnUsuarios" runat="server" Text="Usuarios" OnClick="btnUsuario_Click" Width="146px" />
            <br />
            <br />
            <asp:Button ID="btnMaterias" runat="server" Text="Materias" Width="146px" OnClick="btnMaterias_Click" />
            <br />
            <br />
            <asp:Button ID="btnComisiones" runat="server" Text="Comisiones" Width="146px" OnClick="btnComisiones_Click" />
            <br />
            <br />
            <asp:Button ID="btnCursos" runat="server" Text="Cursos" Width="146px" OnClick="btnCursos_Click" />
        </asp:Panel>
    </form>
</body>
</html>
