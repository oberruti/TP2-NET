<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones_Docentes.aspx.cs" Inherits="UI.Web.Inscripciones_Docentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
 
        <h2>Inscripciones</h2>
        <hr />
        

         <asp:Panel class="form-label-input" runat="server" ID="buscadorPorID">
            <label class="form" style="width: 100%">
                ID:
               <asp:TextBox CssClass="form-input" placeholder="ingresar ID de la inscripcion"  type="number" min="0"  ID="ingresoTextBox" runat="server"></asp:TextBox>

            </label>
            <asp:Button class="btn btn-primary" ID="buscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
        </asp:Panel>



        <asp:Panel ID="gridPanel" runat="server" CssClass="py-3">
            <asp:GridView ID="gridView" runat="server" DataKeyNames="ID"  CssClass="table caption-top" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="White"
                 AllowPaging="true"
                OnPageIndexChanging ="gridView_PageIndexChanging"
                Width="100%"
                OnSelectedIndexChanged="gridView_SelectedIndexChanged">

                <SelectedRowStyle BackColor="Black" ForeColor="White" />

                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="ID Curso" DataField="IDCurso" Visible="True" />
                    <asp:BoundField HeaderText="ID Docente" DataField="IDDocente" Visible="True" />
                    <asp:BoundField HeaderText="Cargo" DataField="Cargo" />
                    <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </asp:Panel>


        <asp:Panel ID="formPanel" CssClass="p-3" runat="server" Visible="false">
            <h4>
                <asp:Label runat="server" ID="tituloForm" Text=""></asp:Label>
            </h4>
            <hr />
            <div class="row py-3">

                <div class="col">
                    <asp:Label ID="idPersonaLabel" runat="server" Text=" Id Persona"></asp:Label>
                    <br />
                    <asp:TextBox ID="idPersonaTextBox" runat="server" CssClass="form-input" Enabled="false"></asp:TextBox>
                    <asp:Button ID="seleccionarPersonaButton" runat="server" cssClass="btn btn-primary" OnClick="seleccionarPersonaButton_Click" text="Seleccionar" />
            </div>
            <div class="col">
                <label>
                Id Curso</label>
                <br />
                <asp:TextBox ID="idCursoTextBox" runat="server" CssClass="form-input" Enabled="false"></asp:TextBox>
                <asp:Button ID="seleccionarCursoButton" runat="server" cssClass="btn btn-primary" OnClick="seleccionarCursoButton_Click" text="Seleccionar" />
            </div>
            <div class="col">
                <asp:Label ID="cargoLabel" runat="server" Text="Cargo"></asp:Label>
                <%-- <asp:TextBox ID="cargoTextBox" runat="server" CssClass="form-input " max="3" min="1" step="1" type="number"></asp:TextBox>--%>
                <asp:DropDownList ID="cargoDropDownList" runat="server" cssClass="form-input" OnSelectedIndexChanged="cargoDropDownList_SelectedIndexChanged">
                    <asp:ListItem Value="0">Jefe</asp:ListItem>
                    <asp:ListItem Value="1">Docente</asp:ListItem>
                    <asp:ListItem Value="2">Ayudante</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Panel ID="tablaCurso" runat="server" visible="false">
                <h3>Seleccionar curso</h3>
                <asp:GridView ID="cursoGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table caption-top" DataKeyNames="ID" OnPageIndexChanging="cursoGridView_PageIndexChanging" OnSelectedIndexChanged="cursoGridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" Width="100%">
                    <selectedrowstyle backcolor="Black" forecolor="White" />
                    <columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="IDMateria" HeaderText="ID Materia" />
                        <asp:BoundField DataField="IDComision" HeaderText="ID Comision" />
                        <asp:BoundField DataField="Año_calendario" HeaderText="Año Calendario" />
                        <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                    </columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="alumnosPanel" runat="server" CssClass="tabla">
                <asp:GridView ID="AlumnosGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table caption-top" DataKeynames="ID" OnPageIndexChanging="AlumnosGridView_PageIndexChanging" OnSelectedIndexChanged="AlumnosGridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" Width="1000px">
                    <selectedrowstyle backcolor="Black" forecolor="White" />
                    <columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Email" HeaderText="Direccion" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                    </columns>
                </asp:GridView>
            </asp:Panel>
            <br />
            <br />
            <asp:Label ID="mensajeDeValidacionDeCampo" runat="server" ForeColor="#CC3300" Text="Hay campos que faltan completar" Visible="false"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:Button ID="aceptarLinkButton" runat="server" class="btn btn-success" OnClick="aceptarLinkButton_Click" Text="Aceptar" />
                <asp:Button ID="cancelarLinkButton" runat="server" class="btn btn-danger" OnClick="cancelarLinkButton_Click" Text="Cancelar" />
            </asp:Panel>
        </asp:Panel>

        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:Button ID="editarLinkButton" class="btn btn-dark" runat="server" Text="Editar" OnClick="editarLinkButton_Click" />

            <asp:Button ID="nuevoLinkButton" class="btn btn-success" runat="server" Text="Nuevo" OnClick="nuevoLinkButton_Click" />

        </asp:Panel>

 

</asp:Content>
