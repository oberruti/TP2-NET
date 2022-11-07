<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" MasterPageFile="~/Site.Master" Inherits="UI.Web.Home"  %>
   
      
 
 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    

    <br />
    
    <section class="container">
        <style>
            .label-top
            {
                display:block;
                margin-bottom:2px;
            }
        </style>
        <asp:Label ID="Label1" runat="server" Font-Size="24px" Height="29px">Bienvenido: </asp:Label>
        <asp:Label cssClass="label-top" runat="server" id="nombreAlumno" Font-Size="24px" Height="29px" >Bienvenido NombreAlumno</asp:Label>
        <br />
        

        

 
    
       
    </section>

  
    
      
</asp:Content>
