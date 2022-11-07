<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.Web.Comisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <div class="container">
        <h2>Comisiones</h2>
        <hr />

        <div class="form-label-input">
            <label class="form" style="width: 100%">
                ID:
               <asp:TextBox CssClass="form-input" type="number" min="0" placeholder="ingresar ID de la materia" ID="idIngresoTextBox" runat="server"></asp:TextBox>

            </label>
            <asp:Button class="btn btn-primary" ID="buscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
        </div>

        <asp:Panel ID="gridPanel" CssClass="py-3" runat="server">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="White"
                Width="100%"
                cssClass="table caption-top"
                AllowPaging="True" OnPageIndexChanging="gridView_PageIndexChanging"
                DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">

                <SelectedRowStyle BackColor="Black" ForeColor="White" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="id" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Desc_comision" />
                    <asp:BoundField HeaderText="Año Especialidad" DataField="Anio_especialidad" />
                    <asp:BoundField HeaderText="ID Plan" DataField="IDPlan" />
                    <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />

                </Columns>

            </asp:GridView>
        </asp:Panel>


        <asp:Panel ID="formPanel" runat="server" Visible="false">
            <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion"></asp:Label>
            <asp:Label ID="descripcionValidacion" runat="server" Text="*" ForeColor="#CC3300"></asp:Label>
            <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>


            <br />
            <asp:Label ID="anioEspecialidadLabel" runat="server" Text="Anio Especialidad"></asp:Label>
            <asp:Label ID="anioEspecialidadValidacion" runat="server" Text="*" ForeColor="#CC3300"></asp:Label>
            <asp:TextBox ID="anioEspecialidadTextBox" type="number" min="0" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="idPlanLabel" runat="server" Text="ID Plan"></asp:Label>
            <asp:Label ID="idPlanValidacion" runat="server" Text="*" ForeColor="#CC3300"></asp:Label>
            <asp:TextBox ID="idPlanTextBox" runat="server" Enabled="false"></asp:TextBox>
            <asp:Button CssClass="btn btn-primary" runat="server" Text="Seleccionar especialidad" OnClick="seleccionarButton" />

            <div class="row m-2 py-2" id="tablaPlan" runat="server" visible="false">
                <h3>Seleccionar plan</h3>


                <asp:GridView ID="planGridView" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White"
                    Width="100%"
                    cssClass="table caption-top"
                    DataKeynames="ID" OnSelectedIndexChanged="planGridView_SelectedIndexChanged">

                    <selectedrowstyle backcolor="Black" forecolor="White" />

                    <columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />

                        <asp:BoundField HeaderText="Descripcion Plan" DataField="Descripcion" />
                        <asp:BoundField HeaderText="ID Especialidad" DataField="IDEspecialidad" />
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />

                    </columns>
                </asp:GridView>

            </div>

            <br />


            <asp:Label ID="validacionCartelLabel" runat="server" Text="Hay campos que faltan por completar" Visible="false" ForeColor="#CC3300"></asp:Label>
            <br />
            <br />
            <br />
            <br />


            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:Button ID="aceptarLinkButton" CssClass="btn btn-success" runat="server" Text="Aceptar" OnClick="aceptarLinkButton_Click" />
                <asp:Button ID="cancelarLinkButton" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="cancelarLinkButton_Click" />


            </asp:Panel>
        </asp:Panel>

        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:Button ID="editarLinkButton" CssClass="btn btn-dark" runat="server" Text="Editar" OnClick="editarLinkButton_Click" Visible="false" />

            <asp:Button ID="nuevoLinkButton" CssClass="btn btn-success" runat="server" Text="Nuevo" OnClick="nuevoLinkButton_Click" Visible="false" />

        </asp:Panel>
    </div>

</asp:Content>
