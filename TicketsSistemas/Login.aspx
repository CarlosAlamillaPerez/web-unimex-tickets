<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TicketsSistemas.Login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="<%: ResolveUrl("~/Content/MasterPage/css/login-tickets.css") %>" rel="stylesheet" />
    <script src="<%: ResolveUrl("~/Content/MasterPage/js/jquery-3.3.1.min.js") %>" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <title>Sistemas de Tickets</title>

</head>
<body style="background-image: url(Imagenes/Login/bg-01.png);">
    <div class="container">
        <img src="Imagenes/Login/LogoUnimex.png" alt="Imagen de título">
        <form>
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
        </form>
    </div>
</body>
<script src="<%: ResolveUrl("~/Content/MasterPage/js/login-tickets.js") %>" type="text/javascript"></script>
<script src="https://code.jquery.com/jquery-3.7.1.js" type="text/javascript"></script>

</html>
