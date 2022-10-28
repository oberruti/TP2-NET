<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="gridPanel" runat="server" AutoHeight="true">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="White"
                DataKeyNames="ID" Height="21px" OnSelectedIndexChanged="GridView_SelectedIndexChanged" Width="674px" >
                <Columns>
                    <asp:BoundField HeaderText="Descripcion" DataField="desc_comision" />
                    <asp:BoundField HeaderText="Año Especialidad" DataField="anio_especialidad" />
                    <asp:BoundField HeaderText="ID Plan" DataField="id_plan" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server" Height="93px">
            <asp:Label ID="desc_comisionLabel" runat="server" Text="Descripcion: "></asp:Label>
            <asp:TextBox ID="desc_comisionTextBox" runat="server" ValidateRequestMode="Disabled" ValidationGroup="Validation"></asp:TextBox>
            <asp:RequiredFieldValidator ID="desc_comisionValidator" ControlToValidate="desc_comisionTextBox" ErrorMessage="Debe ingresar una descripcion." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="anio_especialidadLabel" runat="server" Text="Año de Especialidad: "></asp:Label>
            <asp:TextBox ID="anio_especialidadTextBox" runat="server" ValidateRequestMode="Disabled" ValidationGroup="Validation"></asp:TextBox>
            <asp:RequiredFieldValidator ID="anio_especialidadValidator" ControlToValidate="anio_especialidadTextBox" ErrorMessage="Debe ingresar el año de especialidad." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="id_planLabel" runat="server" Text="ID de Plan: "></asp:Label>
            <asp:TextBox ID="id_planTextBox" runat="server" ValidateRequestMode="Disabled" ValidationGroup="Validation"></asp:TextBox>
            <asp:RequiredFieldValidator ID="id_planValidator" ControlToValidate="id_planTextBox" ErrorMessage="Debe ingresar un ID de plan." Display="Static" InitialValue="" Width="1%" runat="server" ForeColor="Red">*</asp:RequiredFieldValidator>
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
