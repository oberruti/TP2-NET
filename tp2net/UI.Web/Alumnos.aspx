<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="UI.Web.Alumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h2>Alumnos</h2>
    <hr />

    <div class="form-label-input">

        <asp:Label ID="IDbuscadorLabel" runat="server" CssClass="form" Width="100%" Text="ID: ">

        </asp:Label>
            <asp:TextBox CssClass="form-input" type="number" min="0" placeholder="ingresar ID " ID="idAlumnoIngresoTextBox" runat="server"></asp:TextBox>

        <asp:Button class="btn btn-primary" ID="buscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
    </div>

    <br />
    <asp:Panel ID="alumnosPanel" runat="server" CssClass="tabla" >
        <asp:GridView ID="AlumnosGridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            Width="1000px"
             CssClass="table caption-top"
            AllowPaging="True" OnPageIndexChanging="AlumnosGridView_PageIndexChanging"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">

            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />

            <SelectedRowStyle BackColor="Black" ForeColor="White" />

            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />

                <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="FechaNacimiento" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />

            </Columns>
        </asp:GridView>
    </asp:Panel>

    <br />


    <%--<asp:Button class="btn btn-info" ID="cursosAlumnoButton" runat="server" Text="Ver cursos" />--%>
    <asp:Button class="btn btn-dark" ID="modificarAlumnoButton" runat="server" Text="Modificar" OnClick="modificarAlumnoButton_Click1" />
    <asp:Button ID="agregarAlumnoButton" class="btn btn-success" runat="server" Text="Nuevo alumno" OnClick="agregarAlumnoButton_Click" />

    <section id="cursos_alumno" runat="server" visible="false">
        <asp:Panel ID="cursoPanel" runat="server">
        </asp:Panel>
    </section>




    <section class="container modificar-alumno" id="form_alumno" visible="false" runat="server">

        <h4>
            <asp:Label runat="server" ID="tituloForm" Text=""></asp:Label></h4>
        <hr />
        <form method="post" action="">
            <div class="row">
                <label>Legajo: </label>
                
                <asp:TextBox Width="200px" CssClass="form-input" type="number"  placeholder="Legajo" ID="legajoTextBox" runat="server"></asp:TextBox>

            </div>

            <div class="row mx-2 my-1">
                <div class="col ">
                    <label>Nombre: </label>
                    <asp:TextBox CssClass="form-input" AutoCompleteType="FirstName" placeholder="Nombre" ID="nombreAlumnoTextBox" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <label>Apellido: </label>
                    <asp:TextBox CssClass="form-input" AutoCompleteType="LastName" placeholder="Apellido" ID="apellidoAlumnoTextBox" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row my-1">
                <div class="col">
                    <label>Direccion: </label>
                    <asp:TextBox CssClass="form-input" placeholder="Direccion" AutoCompleteType="HomeStreetAddress" ID="direccionAlumnoTextBox" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <label>Telefono: </label>
                    <asp:TextBox CssClass="form-input" placeholder="Telefono" AutoCompleteType="Cellular" ID="telefonoTextBox" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row my-1 mx-2">
                <label>Fecha de Nacimiento: </label>
                <asp:TextBox CssClass="form-input" Width="200px" type="date"  placeholder="yyyy-mm-dd" ID="fechaNacimientoTextBox" runat="server"></asp:TextBox>
            </div>

            <div class="row my-1">
                <div class="col">
                    <label>Email: </label>
                    <asp:TextBox CssClass="form-input" placeholder="Email" AutoCompleteType="Email" ID="emailAlumnoTextBox" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <label>Id Plan: </label>
                    <asp:TextBox ID="idPlanTextBox" runat="server" CssClass="form-input" Enabled="false"></asp:TextBox>
                    <asp:Button ID="seleccionarButton" runat="server" CssClass="btn btn-primary" Text="Seleccionar Plan" OnClick="seleccionarButton_Click" />
                </div>

            </div>

            <div id="tablaPlan" runat="server" class="row m-2 py-2" visible="false">
                <h3>Seleccionar plan</h3>
                <asp:GridView ID="planGridView" runat="server" 
                     CssClass="table caption-top"
                    AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="planGridView_SelectedIndexChanged" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" Width="100%">
                    <SelectedRowStyle BackColor="Black" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="DescPlan" HeaderText="Descripcion Plan" />
                        <asp:BoundField DataField="DescEspecialidad" HeaderText="Especialidad" />
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </div>



            <asp:Button ID="formAlumnoButton" class="btn btn-success" runat="server" Text="Guardar" OnClick="formAlumnoButton_Click" />
            <asp:Button ID="cancelarFormAlumnoButton" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="cancelarFormAlumnoButton_Click" />
        </form>
    </section>




    <div runat="server" id="div_mensaje_error">
        <svg xmlns="http://www.w3.org/2000/svg" style="display: none;">
            <symbol id="check-circle-fill" fill="currentColor" viewBox="0 0 16 16">
                <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-3.97-3.03a.75.75 0 0 0-1.08.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-.01-1.05z" />
            </symbol>
            <symbol id="info-fill" fill="currentColor" viewBox="0 0 16 16">
                <path d="M8 16A8 8 0 1 0 8 0a8 8 0 0 0 0 16zm.93-9.412-1 4.705c-.07.34.029.533.304.533.194 0 .487-.07.686-.246l-.088.416c-.287.346-.92.598-1.465.598-.703 0-1.002-.422-.808-1.319l.738-3.468c.064-.293.006-.399-.287-.47l-.451-.081.082-.381 2.29-.287zM8 5.5a1 1 0 1 1 0-2 1 1 0 0 1 0 2z" />
            </symbol>
            <symbol id="exclamation-triangle-fill" fill="currentColor" viewBox="0 0 16 16">
                <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" />
            </symbol>
        </svg>


        <div class="alert alert-warning d-flex align-items-center" role="alert">
            <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Warning:">
                <use xlink:href="#exclamation-triangle-fill" />
            </svg>
            <div>
                <asp:Label ID="mensaje_error" runat="server" Text="Error"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
