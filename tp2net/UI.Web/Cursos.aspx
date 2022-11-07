<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h2>Cursos</h2>
    <hr />


    <asp:Panel class="form-label-input" runat="server" ID="buscadorPorID">
        <label class="form" style="width: 100%">
            ID:
               <asp:TextBox CssClass="form-input" placeholder="ingresar ID del curso" ID="ingresoTextBox" type="number" min="0" runat="server"></asp:TextBox>

        </label>
        <asp:Button class="btn btn-primary" ID="buscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
    </asp:Panel>


    <asp:Panel ID="gridPanel" runat="server" CssClass="py-3">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            Width="100%"
            AllowPaging="True" OnPageIndexChanging="gridView_PageIndexChanging"
            CssClass="table caption-top"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">

            <SelectedRowStyle BackColor="Black" ForeColor="White" />

            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />

                <%--   <asp:BoundField HeaderText="ID Materia" DataField="id_materia" />
                <asp:BoundField HeaderText="ID Comision" DataField="id_comision" />
                --%>
                <asp:BoundField HeaderText="ID Materia" DataField="IDMateria" />
                <asp:BoundField HeaderText="ID Comision" DataField="IDComision" />
                <asp:BoundField HeaderText="Año Calendario" DataField="Año_calendario" />
                <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />

            </Columns>
        </asp:GridView>
    </asp:Panel>
    

    <asp:Panel ID="formPanel" CssClass="p-3" runat="server" Visible="false">
        <h4>
            <asp:Label runat="server" ID="tituloForm" Text=""></asp:Label>
        </h4>
        <hr />
        <label>Cupo</label>
        <br />
        <asp:TextBox ID="cupoTextBox" type="number" min="0" CssClass="form-input" runat="server"></asp:TextBox>

        <div class="row py-3">
            <div class="col">
                <label>Año Calendario</label>
                <br />
                <asp:TextBox ID="anioCalendarioTextBox" type="number" CssClass="form-input" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <label>Id Materia</label>
                <br />
                <asp:TextBox ID="idMateriaTextBox" CssClass="form-input" runat="server" Enabled="false"></asp:TextBox>
                <asp:Button cssClass="btn btn-primary" runat="server" ID="selecMateriaButton" text="Seleccionar" OnClick="seleccionarMateriaButton" />
            </div>
            <div class="col">
                <label>Id Comision</label>
                <br />
                <asp:TextBox ID="idComisionTextBox" CssClass="form-input" runat="server" Enabled="false"></asp:TextBox>
                <asp:Button cssClass="btn btn-primary" runat="server" ID="selecComisionButton" text="Seleccionar" OnClick="seleccionarComisionButton" />
            </div>

        </div>



        <br />
        <div class="row m-2 py-2" id="tablaMateria" runat="server" visible="false">
            <h3>Seleccionar materia</h3>
            <asp:Panel ID="materiaPanel" runat="server">
                <asp:GridView ID="materiaGridView" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White"
                    Width="100%"
                    CssClass="table caption-top"
                    DataKeyNames="ID" OnSelectedIndexChanged="materiaGridView_SelectedIndexChanged">

                    <selectedrowstyle backcolor="Black" forecolor="White" />

                    <columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />

                        <asp:BoundField HeaderText="Descripcion materia" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Horas Semanales" DataField="HSSemanales" />
                        <asp:BoundField HeaderText="Horas Totales" DataField="HSTotales" />
                        <asp:BoundField HeaderText="ID Plan" DataField="IDPlan" />
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />

                    </columns>
                </asp:GridView>
            </asp:Panel>

        </div>
        <div id="tablaComision" runat="server" class="row m-2 py-2" visible="false">
            <h3>Seleccionar comision</h3>
            <asp:Panel ID="comisionPanel" CssClass="py-3" runat="server">
                <asp:GridView ID="comisionGridView" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White"
                    Width="100%"
                    CssClass="table caption-top"
                    DataKeynames="ID" OnSelectedIndexChanged="comisionGridView_SelectedIndexChanged">

                    <selectedrowstyle backcolor="Black" forecolor="White" />

                    <columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="Descripcion" DataField="Desc_Comision" />
                        <asp:BoundField HeaderText="Anio Especialidad" DataField="Anio_especialidad" />
                        <asp:BoundField HeaderText="ID Plan" DataField="IDPlan" />
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                    </columns>

                </asp:GridView>
            </asp:Panel>



            <br />
        </div>


        <asp:Label ID="mensajeDeValidacionDeCampo" runat="server" Visible="false" ForeColor="#CC3300" Text="Hay campos que faltan completar"></asp:Label>
        <br />
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:Button ID="aceptarLinkButton" runat="server" class="btn btn-success" OnClick="aceptarLinkButton_Click" Text="Aceptar" />
            <asp:Button ID="cancelarLinkButton" runat="server" class="btn btn-danger" OnClick="cancelarLinkButton_Click" Text="Cancelar" />
        </asp:Panel>
    </asp:Panel>

    <asp:Panel ID="alumnosDelCursoPanel" runat="server" Visible="false" CssClass=" px-2 py-3">
        <h3>Listado de alumnos</h3>
        <asp:GridView ID="AlumnosDelCursoGridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            CssClass="table caption-top"
            Width="100%"
            DataKeyNames="ID" OnSelectedIndexChanged="AlumnosDelCursoGridView_SelectedIndexChanged">

            <SelectedRowStyle BackColor="Black" ForeColor="White" />

            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="ID Alumno" DataField="IdAlumno" />
                <asp:BoundField HeaderText="Condición" DataField="Condicion" />
                <asp:BoundField HeaderText="Nota" DataField="Nota" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <label>Condicion</label>
        <br />
        <%--<asp:TextBox ID="condicionTextBox" CssClass="form-input" runat="server" Enabled="false"></asp:TextBox>--%>
        <asp:DropDownList ID="condicionDropDownList" runat="server"   OnSelectedIndexChanged="condicionDropDownList_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem></asp:ListItem> 
            <asp:ListItem>Cursando</asp:ListItem>
            <asp:ListItem>Regular</asp:ListItem>
            <asp:ListItem>Aprobado</asp:ListItem>
            <asp:ListItem>Libre</asp:ListItem>

        </asp:DropDownList>
        <br />
        <label>Nota</label>
        <br />
        <asp:TextBox ID="notaTextBox" CssClass="form-input" type="number" min="6" max="10"  runat="server" Enabled="false"></asp:TextBox>
        <br />
        <asp:Button ID="asignarleNotaButton" class="btn btn-success my-3" runat="server" Text="Asignar condicion" OnClick="asignarleNotaButton_Click" />
    </asp:Panel>
    <asp:Panel CssClass="py-3" ID="gridActionsPanel" runat="server">
        <asp:Button ID="editarLinkButton" class="btn btn-dark" runat="server" Text="Editar" OnClick="editarLinkButton_Click" />
        <asp:Button ID="nuevoLinkButton" class="my-3 btn btn-success" runat="server" Text="Nuevo" OnClick="nuevoLinkButton_Click" />

    </asp:Panel>
    


</asp:Content>
