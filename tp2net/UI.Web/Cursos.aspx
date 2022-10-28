<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cursos</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="gridPanel" runat="server" AutoHeight="true">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="White"
                DataKeyNames="ID" Height="21px" OnSelectedIndexChanged="GridView_SelectedIndexChanged" Width="674px">
                <Columns>
                    <asp:BoundField HeaderText="Id Materia" DataField="id_materia" />
                    <asp:BoundField HeaderText="Id Comision" DataField="id_comision" />
                    <asp:BoundField HeaderText="Año Calendario" DataField="año_calendario" />
                    <asp:BoundField HeaderText="Cupo" DataField="cupo" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server" Height="116px">
            <asp:Label ID="IdMateriaLabel" runat="server" Text="ID Materia: "></asp:Label>
            <asp:TextBox ID="IdMateriaTextBox" runat="server" ValidateRequestMode="Disabled" ValidationGroup="Validation"></asp:TextBox>
            <asp:RequiredFieldValidator id="validatorIdMateria" ControlToValidate="IdMateriaTextBox" ErrorMessage="Debe ingresar un ID de materia." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="IdComisionLabel" runat="server" Text="ID Comision: "></asp:Label>
            <asp:TextBox ID="IdComisionTextBox" runat="server" ValidateRequestMode="Enabled" ValidationGroup="Validation"></asp:TextBox>
            <asp:RequiredFieldValidator id="validatorIdComision" ControlToValidate="IdComisionTextBox" ErrorMessage="Debe ingresar un ID de comisión." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="AnioCalendarioLabel" runat="server" Text="Año de Calendario: "></asp:Label>
            <asp:TextBox ID="AnioCalendarioTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="validatorAnioCalendario" ControlToValidate="AnioCalendarioTextBox" ErrorMessage="Debe ingresar un año." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="CupoLabel" runat="server" Text="Cupo: "></asp:Label>
            <asp:TextBox ID="CupoTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="validatorCupo" ControlToValidate="CupoTextBox" ErrorMessage="Debe ingresar un cupo." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
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
