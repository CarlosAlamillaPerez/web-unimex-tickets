<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Message.ascx.cs" Inherits="TicketsSistemas.UserControl.Message" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .titulo {font-weight:bold;font-family:Arial;font-size:18px;text-align:center;}
    .mensaje {font-weight:normal;font-family:Arial;font-size:12px;text-align:center; }
    .detalle {font-weight:lighter;font-family:Arial;font-size:12px;font-style:italic;text-align:center;}
    .FondoAplicacion{background-color: Gray;filter: alpha(opacity=70);opacity: 0.9;}
    .tabla {padding:10px; border:solid 4px #000000}
</style>

<script>
    function habilitar(estado) {
        
        var inicio = document.getElementById("ImgbtnInicio");
        var menus = document.getElementById("ImgBotonMenu");
        var pass = document.getElementById("ImgBtnPass");
        var salir = document.getElementById("ImgbtnSalir");
        var regresar = document.getElementById("ImgbtnCancelMtsr");
        var txtCriterio = document.getElementById("txtCriterio");
        

        if (estado) {
           
            inicio.src = '<%= ResolveUrl("../Imagenes/Botones/Navigation/house.svg")%>';
            menus.src = '<%= ResolveUrl("../Imagenes/Botones/Navigation/house.svg")%>';
            pass.src = '<%= ResolveUrl("../Imagenes/Botones/Navigation/password.svg")%>';
            salir.src = '<%= ResolveUrl("../Imagenes/Botones/Navigation/close.svg")%>';
            regresar.src = '<%= ResolveUrl("../Imagenes/Botones/Navigation/multi-tab.svg")%>';
        } else {
           
            inicio.src = '<%= ResolveUrl("../Imagenes/Botones/Navigation/house.svg")%>';
            menus.src = '<%= ResolveUrl("../Imagenes/Botones/Navigation/house.svg")%>';
            pass.src = '<%= ResolveUrl("../Imagenes/Botones/Navigation/password.svg")%>';
            salir.src = '<%= ResolveUrl("../Imagenes/Botones/Navigation/close.svg")%>';
            regresar.src = '<%= ResolveUrl("../Imagenes/Botones/Navigation/multi-tab.svg")%>';
          
        }

        inicio.disabled = estado;
        menus.disabled = estado;
        pass.disabled = estado;
        salir.disabled = estado;
        regresar.disabled = estado;

    }



</script>  
        <asp:ImageButton ID="btnimg" runat="server" Width="1" Height="1" style="position:relative;left:-10000px"/>
        <asp:Panel ID="pnlMessagebox" runat="server" BackColor="White">
           <asp:Table ID="tblMessage" runat="server" CellSpacing="1" BorderStyle="Solid" BorderWidth="1" CssClass="tabla"> 
               <asp:TableRow ID="Row1" runat="server">
                   <asp:TableCell ID="CelImagen" runat="server" VerticalAlign="Middle" HorizontalAlign="Center" Width="125px" Height="125px">
                       <asp:Image ID="imgIcon" runat="server" Width="100" Height="100" />
                   </asp:TableCell>
                   <asp:TableCell ID="CelMensaje" runat="server" VerticalAlign="Middle" >
                        <asp:Label ID="lblTitulo" runat="server"  CssClass="titulo"/><br /><br />
                        <asp:Label ID="lblMensaje" runat="server"  CssClass="Mensaje"/><br /><br />
                       <asp:Panel ID="pnlDetalle" runat="server" ScrollBars="Vertical"  BorderWidth="1" BorderStyle="Solid">
                            <asp:Label ID="lblDetalle" runat="server" CssClass="detalle"/>
                       </asp:Panel>
                   </asp:TableCell>
               </asp:TableRow>
               <asp:TableRow ID="Row2" runat="server">
                   <asp:TableCell ID="CelBotones" runat="server" ColumnSpan="2"  HorizontalAlign="Center" VerticalAlign="Middle">
                       <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btn_Click" width="100" ForeColor="Black"/>&nbsp;
                       <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btn_Click" width="100"/>&nbsp;
                       <asp:Button ID="btnSi" runat="server" Text="Si" OnClick="btn_Click" width="100"/>&nbsp;
                       <asp:Button ID="btnNo" runat="server" Text="No" OnClick="btn_Click" width="100"/>&nbsp;
                       <asp:Button ID="btnReintentar" runat="server" Text="Reintentar" OnClick="btn_Click" width="100"/>&nbsp;
                       <asp:Button ID="btnAnular" runat="server" Text="Anular" OnClick="btn_Click" width="100"/>&nbsp;
                       <asp:Button ID="btnOmitir" runat="server" Text="Omitir" OnClick="btn_Click" width="100"/>  
                   </asp:TableCell>
               </asp:TableRow>
           </asp:Table> 
        </asp:Panel>
        <asp:ModalPopupExtender ID="mpeSeleccion" runat="server" 
                    TargetControlID="btnimg"
                    PopupControlID="pnlMessagebox" 
                    BackgroundCssClass="FondoAplicacion" 
                    DropShadow="true"/>
