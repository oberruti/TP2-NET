<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="gridPanel" runat="server" AutoHeight="true">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="White"
                DataKeyNames="ID" Height="21px" OnSelectedIndexChanged="GridView_SelectedIndexChanged" Width="674px" >
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="EMail" DataField="EMail" />
                    <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                    <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server" Height="191px">
            <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="nombreTextBox" runat="server" ValidateRequestMode="Disabled" ValidationGroup="Validation"></asp:TextBox>
            <asp:RequiredFieldValidator id="validatorNombre" ControlToValidate="nombreTextBox" ErrorMessage="Debe ingresar un nombre." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="apellidoTextBox" runat="server" ValidateRequestMode="Enabled" ValidationGroup="Validation"></asp:TextBox>
            <asp:RequiredFieldValidator id="validatorApellido" ControlToValidate="apellidoTextBox" ErrorMessage="Debe ingresar un apellido." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
            <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="validatorEmail" ControlToValidate="emailTextBox" ErrorMessage="Debe ingresar un email." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="validatorFormatoEmail" runat="server" ControlToValidate="emailTextBox" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*Formato de e-mail inválido.</asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="habilitadoCheckBox" runat="server" Text=" " />
            <br />
            <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="validatorNombreUsuario" ControlToValidate="nombreUsuarioTextBox" ErrorMessage="Debe ingresar un nombre de usuario." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="claveTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator id="validatorClave" ControlToValidate="claveTextBox" ErrorMessage="Debe ingresar una clave." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="repetirClaveTextBox" runat="server" TextMode="Password" ValidationGroup="Validation"></asp:TextBox>
            <asp:RequiredFieldValidator id="validatorRepetirClave" ControlToValidate="repetirClaveTextBox" ErrorMessage="Debe ingresar la clave nuevamente." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="validatorComparacionClaves" runat="server" ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" ForeColor="Red">*Las claves no coinciden.</asp:CompareValidator>
            <br />
        </asp:Panel>
        <asp:Panel ID="gridActionsPanel" runat="server" Height="85px">
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menu Principal" Width="167px" OnClick="btnMenuPrincipal_Click" />
        </asp:Panel>
        <asp:Panel ID="formActionsPanel" runat="server" Height="36px">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
            <br />
            <br />
        </asp:Panel>
        <asp:ValidationSummary ID="ValidationFormPanel" runat="server" ForeColor="Red" />
    </form>
</body>
</html>
