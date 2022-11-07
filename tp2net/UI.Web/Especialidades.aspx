<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
      <div class="container">
            <h2>Especialidades</h2>  
        <hr/>
    
             
       <div class ="form-label-input">
            <label class="form" style="width:100%">
                ID:
               <asp:TextBox CssClass="form-input" placeholder="ingresar ID de la especialidad"  type="number" min="0" ID="especialidadIngresoTextBox" runat="server"></asp:TextBox>
         
            </label>
            <asp:Button class="btn btn-primary" ID="buscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
        </div>
    

            <asp:Panel ID ="gridPanel" runat ="server" > 
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="White"
                   Width="800px"
                DataKeynames ="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
 
                <SelectedRowStyle BackColor="Black" ForeColor="White" />
                
                <Columns>
                    <asp:BoundField HeaderText ="ID" DataField ="ID" />
        
                    <asp:BoundField HeaderText ="Descripcion" DataField ="Descripcion" />  
                    <asp:CommandField HeaderText ="Seleccionar" ShowSelectButton ="True" />

                </Columns>
            </asp:GridView>
            </asp:Panel>


            <asp:Panel ID="formPanel"  CssClass="p-3" runat="server" Visible ="false">
                <h4><asp:Label runat="server" ID="tituloForm" Text=""></asp:Label></h4>
        <hr/>
                <asp:Label ID="descripcionEspecialidadLabel" runat="server" Text="Descripcion"></asp:Label>
                      <br />
                <asp:TextBox ID ="descripcionTextBox" runat="server" Columns="60" Height="50px" MaxLength="50" Rows="2"></asp:TextBox>
                
                <asp:Label ID="descripcionEspecialidadValidacion" runat="server" Text="*" ForeColor="#CC3300"></asp:Label>
                <br />
                <br />
                <br />

                
                  <br />
                <asp:Label ID="validacionDescripcionEspecialidad" runat="server" Visible="false" Text="* La descripcion no puede estar vacia" ForeColor="#CC3300"></asp:Label>
                <br />

                
                <br />
                <br />
                <br />
              

                     <asp:Panel ID="formActionsPanel" runat="server">
                        <asp:Button ID="aceptarLinkButton" class="btn btn-success" runat="server" Text="Aceptar" OnClick="aceptarLinkButton_Click" />
                        <asp:Button ID="cancelarLinkButton" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="cancelarLinkButton_Click" />
              

                    </asp:Panel>
            </asp:Panel>

            <asp:Panel ID="gridActionsPanel" runat="server">
                <asp:Button ID="editarLinkButton" class="btn btn-dark" runat="server" Text="Editar" OnClick="editarLinkButton_Click" />
 
                <asp:Button ID="nuevoLinkButton"  class="btn btn-success" runat="server" Text="Nuevo" OnClick="nuevoLinkButton_Click" />

            </asp:Panel>
    
        </div>

</asp:Content>
