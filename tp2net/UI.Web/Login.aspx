<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Iniciar Sesion</title>
    <link href="https://fonts.googleapis.com/css?family=Roboto&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.css" rel="stylesheet">
    <script src="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.js"></script>
    <style>
        * {
            font-family: Roboto;
            font-weight: normal;
            margin: 0;
            padding: 0;
        }

        body {
            height: 100vh;
            width: 100%;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        #cartelErrorLabel, #cartelErrorIcon {
            color: red;
        }

        #contenedor {
            position: relative;
            margin: 40px;
        }

        #form1 {
            text-align: left;
            width: 400px;
            background-color: white;
            padding: 5%;
            margin: -25px 0 0 -25px;
            -webkit-box-shadow: 0px 0px 15px 0px rgba(0, 0, 0, .45);
            box-shadow: 0px 0px 15px 0px rgba(0, 0, 0, .45);
        }

        .textbox {
            width: 100%;
            height: 30px;
            text-align: left;
            font-size: 16px;
            margin-bottom: 10px;
            border: none;
            outline: none;
            border-bottom: 1px solid #aaa;
        }


        #ingresarButton {
            height: 50px;
            width: 100%;
            border-radius: 3px;
            border: rgba(0,0,0,.3) 0px solid;
            box-sizing: border-box;
            padding: 10px;
            margin-bottom: 30px;
            margin-top: 30px;
            background: #514C85;
            color: #FFF;
            font-weight: bold;
            font-size: 12pt;
            transition: background .4s;
            cursor: pointer;
        }

            #ingresarButton:hover {
                background: #514C88;
            }

        .label {
            font-size: 1em;
            color: #aaa;
        }

        .icon-label {
            display: flex;
            align-items: center;
        }
    </style>
</head>
<body class="body" style="background-color: #f4f4f4;">

    <form id="form1" runat="server">

        <label runat="server" style="text-align: center; font-size: 50px; display: block; margin-bottom: 60px">Iniciar Sesion</label>

        <div class="icon-label">
            <span class="material-icons" style="opacity: 0.2;" runat="server">person</span>
            <asp:Label class="label" ID="usuarioLabel" runat="server" Text="Usuario"></asp:Label>
        </div>

        <br />
        <asp:TextBox class="textbox" ID="usuarioTextBox" runat="server"></asp:TextBox>
        <br />
        <div class="icon-label">
            <span class="material-icons" style="opacity: 0.2;" runat="server">lock</span>
            <asp:Label class="label" ID="contraseniaLabel" runat="server" Width="80%" Text="Contraseña"></asp:Label>
        </div>
        <br />
        <asp:TextBox class="textbox" ID="contraseniaTextBox" runat="server" type="password"></asp:TextBox>
        <br />
        <asp:Button ID="ingresarButton" runat="server" Text="Ingresar" OnClick="ingresarButton_Click" />

        <br />
        <div class="icon-label">

            <span class="material-icons" id="cartelErrorIcon" runat="server">warning</span>
            <asp:Label ID="cartelErrorLabel" runat="server" Text=""></asp:Label>

        </div>
    </form>
    </section>
        
</body>
</html>
