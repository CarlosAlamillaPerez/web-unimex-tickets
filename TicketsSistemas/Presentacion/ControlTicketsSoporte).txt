<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE/MasterPage.Master" AutoEventWireup="true" CodeBehind="ControlTicketsSoporte.aspx.cs" Inherits="TicketsSistemas.Presentacion.ControlTicketsSoporte" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControl/Message.ascx" TagPrefix="UCMessageBox" TagName="Msgbox" %>

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
                            <asp:DropDownList ID="ddlTipoSoporte" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoSoporte_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="form-group col-lg-12">
                            <asp:Label ID="lblConcepto" runat="server" Text="Concepto" class="new-ticket-subtitle "></asp:Label>
                            <asp:DropDownList ID="ddlConcepto" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group col-lg-12">
                            <asp:Label ID="lblDetalle" runat="server" Text="Detalle" class="new-ticket-subtitle "></asp:Label>
                            <asp:TextBox ID="txtDetalle" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
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
                        <button class="btn-title-item" id="ticket-inicio" data-target="ticket-inicio">Historial de Ticket</button>&nbsp;&nbsp;&nbsp;&nbsp;
                        <button class="btn-title-item" id="ticket-fin" data-target="ticket-fin">Calificar Asistente</button>
                    </div>
                    <div id="buttons_container"></div>
                    <div id="ticket-history" class="display" style="width: 100%">
                        <table id="TicketsTable" class="display TicketsTable" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>CONCEPTO</th>
                                    <th>INCIDENCIA</th>
                                    <th>GENERADO</th>
                                    <th>INICIO</th>
                                    <th>FIN</th>
                                    <th>CALIFICADO</th>
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
                    <div id="ticket-calificacion" class="display" style="display: none;">
                        <table id="TicketsTable2" class="display TicketsTable" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>CONCEPTO</th>
                                    <th>INCIDENCIA</th>
                                    <th>GENERADO</th>
                                    <th>INICIO</th>
                                    <th>FIN</th>
                                    <th>ESTATUS</th>
                                    <th>ASISTENTE</th>
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
    </contenttemplate>
</asp:Content>
