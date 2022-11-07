<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="UI.Web.LogOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
        
                      
            <h3 class="text text-center pb-3">¿Está seguro de querer cerrar su sesion?</h3>

            <div class="row d-flex justify-content-center">
                <div class="col-2 px-2">
                    <asp:Button CssClass=" btn btn-primary" ID="aceptarButton" Text="Cerrar sesion" runat="server" OnClick="aceptarButton_Click" />
                </div>
                <div class="col-2 px-2 ">
                    <asp:Button CssClass="btn btn-danger" ID="cancelarButton" Text="Volver" runat="server" OnClick="cancelarButton_Click" />
                </div>
            </div>
      
</asp:Content>
