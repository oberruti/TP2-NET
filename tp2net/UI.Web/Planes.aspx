<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h2>Planes</h2>
    <hr />


    <div class="form-label-input">
            <label class="form" style="width:100%">
                ID:
               <asp:TextBox CssClass="form-input" placeholder="ingresar ID del plan"  type="number" min="0"  ID="idIngresoTextBox" runat="server"></asp:TextBox>
         
            </label>
            <asp:Button class="btn btn-primary" ID="buscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
        </div>


    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            Width="100%"
            CssClass="table caption-top"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">

            <SelectedRowStyle BackColor="Black" ForeColor="White" />

            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                
                <asp:BoundField HeaderText="Descripcion Plan" DataField="Descripcion" />
                <asp:BoundField HeaderText="Id Especialidad" DataField="IDEspecialidad" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />

            </Columns>
        </asp:GridView>
    </asp:Panel>


    <asp:Panel ID="formPanel" CssClass="p-3" runat="server" Visible="false">
        <h4><asp:Label runat="server" ID="tituloForm" Text=""></asp:Label></h4>
        <hr />
        <asp:Label ID="descripcionEspecialidadLabel" runat="server" Text="Descripcion"></asp:Label>
        <br />
        <asp:TextBox ID="descripcionTextBox" CssClass="form-input" runat="server" Columns="60" Height="50px" MaxLength="50" Rows="2"></asp:TextBox>

        <div class="row py-3">
                    
                     <div class="col">
                        <label>Id Especialidad</label> <br />
                        <asp:TextBox ID="idEspecialidadTextBox"  CssClass="form-input" runat="server" Enabled="false"></asp:TextBox>
                        <asp:Button  cssClass="btn btn-primary" runat="server" text="Seleccionar especialidad" OnClick="seleccionarButton" />
                     </div>

                </div>

        <div class="row m-2 py-2" id="tablaEspecialidad" runat="server" visible="false">
                    <h3>Seleccionar especialidad</h3>

               <asp:Panel ID ="PanelEspecialidad" runat ="server" > 
                <asp:GridView ID="especialidadGridView" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White"
                       Width="100%"
                    CssClass="table caption-top"
                    DataKeynames ="ID" OnSelectedIndexChanged="especialidadGridView_SelectedIndexChanged">
 
                    <SelectedRowStyle BackColor="Black" ForeColor="White" />
                
                    <Columns>
                        <asp:BoundField HeaderText ="ID" DataField ="ID" />
        
                        <asp:BoundField HeaderText ="Descripcion" DataField ="Descripcion" />  
                        <asp:CommandField  HeaderText ="Seleccionar" ShowSelectButton ="True" />

                    </Columns>
            </asp:GridView>
            </asp:Panel>
                </div>


        <br />



        <br />
        <asp:Label ID="validacionDescripcionEspecialidad" runat="server" Visible="false" Text="Hay campos que faltan completar" ForeColor="#CC3300"></asp:Label>



        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:Button ID="aceptarLinkButton" class="btn btn-success" runat="server" Text="Aceptar" OnClick="aceptarLinkButton_Click" />
            <asp:Button ID="cancelarLinkButton" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="cancelarLinkButton_Click" />


        </asp:Panel>
    </asp:Panel>

    <asp:Panel CssClass="py-3" ID="gridActionsPanel" runat="server">
        <asp:Button ID="editarLinkButton" class="btn btn-dark" runat="server" Text="Editar" OnClick="editarLinkButton_Click" />
        <asp:Button ID="nuevoLinkButton" class="btn btn-success" runat="server" Text="Nuevo" OnClick="nuevoLinkButton_Click" />

    </asp:Panel>



</asp:Content>
