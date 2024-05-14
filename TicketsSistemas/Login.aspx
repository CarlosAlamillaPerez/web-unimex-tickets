﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TicketsSistemas.Login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <link href="~/Content/MasterPage/css/login-tickets.css" rel="stylesheet" />
    
    <script src="../Content/MasterPage/js/jquery-3.3.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    
    <title>Sistemas de Solicitudes</title>

</head>
<body style="background-image: url(Imagenes/Login/bg-01.png);">
    <div class="container">
        <img src="Imagenes/Login/LogoUnimex.png" alt="Imagen de título">
        <div class="row">
            <br />
            <div class="col">
                <h2>Usuario</h2>
                <input id="user" type="text" placeholder="Ingrese su usuario">
            </div>
            <br />
            <div class="col">
                <h2>Contraseña</h2>
                <input id="pass" type="password" placeholder="Ingrese su contraseña">
            </div>
            <br />
            <br />
            <div class="col">
                <button id="enviar" type="submit">Iniciar sesión</button>
            </div>
        </div>
    </div>
</body>
<script src="../Content/MasterPage/js/login-tickets.js"></script>
<script src="https://code.jquery.com/jquery-3.7.1.js" type="text/javascript"></script>

</html>


<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="~/Content/cssLogin/css/util.css" rel="stylesheet" />
    <link href="~/Content/cssLogin/css/Login.css" rel="stylesheet" />
    <link href="~/Content/cssLogin/css/main.css" rel="stylesheet" />
    
    <title>Tickets Sistemas</title>
    
    <style>
        .imgbackgr {
            background-image: url(Imagenes/Login/bg-01.png);
            background-position: center center;
            background-size: cover;
        }
    </style>

</head>
<body>
   <div class="limiter">
		<div class="container-login100 imgbackgr">
			<div class="wrap-login100 p-l-55 p-r-55 p-t-42 p-b-30">
				<form runat="server" class="container-fluid" >
					<span class="login100-form-title p-b-100">
						<asp:Image runat="server" ImageUrl="~/Imagenes/Login/LogoUnimex.png" Width="75%" />
					</span>

					<div class="wrap-input100 validate-input m-b-23" data-validate = "Matricula requerida">
						<asp:Label runat="server" ForeColor="Black" >Usuario</asp:Label>
						<asp:TextBox ID="txtUserName"  BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" runat="server" ForeColor="Black" ToolTip="15987436-10"></asp:TextBox>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Contraseña requerida">
						<asp:Label runat="server"  ForeColor="Black" >Contraseña</asp:Label>
						<asp:TextBox ID="txtPassword"  BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" runat="server" ForeColor="Black" TextMode="Password" ValidateRequestMode="Enabled" ToolTip="Contraseña"></asp:TextBox>
					</div>	
                    <div class="wrap-input100">
                    </div>

					<div class="text-right p-t-8 p-b-31">
						
					</div>				
					<div class="container-login100-form-btn">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"></div>
							<asp:Button ID="submit" runat="server" Text="Ingresar"  OnClick="submit_Click"/>
						</div>
					</div>

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
				</form>
			</div>
		</div>
	</div>
</body>--%>
