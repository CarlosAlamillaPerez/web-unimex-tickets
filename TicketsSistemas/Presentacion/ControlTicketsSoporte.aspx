<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE/MasterPage.Master" AutoEventWireup="true" CodeBehind="ControlTicketsSoporte.aspx.cs" Inherits="TicketsSistemas.Presentacion.ControlTicketsSoporte" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <contenttemplate>
        <div class="container mt-2">
            <div class="row">
                <div class="col-3 new-ticket">
                    <h2 class="new-ticket-title">Nuevo Ticket</h2>
                    <div class="row">
                        <div class="form-group col-lg-12">
                            <asp:Label ID="lblPlantel" runat="server" Text="Plantel" class="new-ticket-subtitle "></asp:Label>
                            <asp:DropDownList ID="ddlPlantel" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group col-lg-12">
                            <asp:Label ID="lblTipoSoporte" runat="server" Text="TIPO DE SOPORTE" class="new-ticket-subtitle "></asp:Label>
                            <asp:DropDownList ID="ddlTipoSoporte" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group col-lg-12">
                            <asp:Label ID="lblConcepto" runat="server" Text="Concepto" class="new-ticket-subtitle "></asp:Label>
                            <asp:DropDownList ID="ddlConcepto" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-lg-12">
                            <asp:Label ID="lblDetalle" runat="server" Text="Detalle" class="new-ticket-subtitle "></asp:Label>
                            <asp:TextBox ID="txtDetalle" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                            <label id="contador">Caracteres restantes: 200</label>
                        </div>
                        <div class="col-12" id="ContenedorUpload" runat="server" visible="true">
                            <div class="wrapper">
                                <div class="file-upload">
                                    <asp:FileUpload ID="fileUpEvidencia" runat="server" Visible="true" onchange="mostrarNombreArchivo(this)" />
                                    <span><i class="fa-solid fa-file-arrow-up"></i>&nbsp;Selecciona un archivo...</span>
                                </div>
                            </div>
                        </div>
                        <div class="col-12">
                            <label id="nombre_file"></label>
                        </div>
                        <div class="col-12">
                            <button id="btnAgregarNuevoTicket" class="btn btn-primary btn-block">ACEPTAR</button>
                        </div>
                    </div>
                </div>
                <div class="col-9">
                    <div class="row btn-title">
                        <button class="btn-title-item" id="ticket-inicio" data-target="ticket-inicio" title="RECARGAR TABLA">Historial de Tickets&nbsp;&nbsp;<i class="fa-solid fa-rotate-right"></i></button>
                    </div>
                    <div id="buttons_container"></div>
                    <div id="ticket-history" class="display" style="width: 100%">
                        <table id="TicketsTable" class="display TicketsTable" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>CONCEPTO</th>
                                    <th>DETALLE</th>
                                    <th>INICIADO</th>
                                    <th>EN PROGRESO</th>
                                    <th>ATENDIDO</th>
                                    <th>CERRADO</th>
                                    <th>ASISTENTE</th>
                                    <th>CALIF.</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                            <tfoot>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>


        <div id="modal-informacion" style="display: none;">
            <div id="modal-titulo">Ticket #<span id="id_ticket"></span></div>
            <div id="modal-contenido">
                <div class="table-responsive">
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <td>Asistente:<br />
                                    <span id="asistente"></span></td>
                                <td>Soporte:<br />
                                    <span id="soporte"></span></td>
                                <td>Concepto:<br />
                                    <span id="concepto"></span></td>
                            </tr>
                        </tbody>
                    </table>
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <td><span id="incidencia"></span></td>
                            </tr>
                        </tbody>
                    </table>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Fecha</th>
                                <th scope="col">Usuario</th>
                                <th scope="col">Mensaje</th>
                                <th scope="col">Estatus</th>
                            </tr>
                        </thead>
                        <tbody id="tabla-detalle"></tbody>
                    </table>
                    <table class="table table-striped">
                        <tbody>
                            <tr>
                                <td>Calificación:<br />
                                    <span id="calificacion"></span></td>
                                <td>Tiempo de solución:<br />
                                    <span id="tiempo_respuesta"></span></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </contenttemplate>
</asp:Content>
