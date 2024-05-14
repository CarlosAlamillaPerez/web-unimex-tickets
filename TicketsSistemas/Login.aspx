<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TicketsSistemas.Login" %>

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