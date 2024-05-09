<%--<%@ Page Title="" Language="C#" MasterPageFile="~/MASTERPAGE/MasterPage.Master" AutoEventWireup="true" CodeBehind="ControlTicketsSoporte.aspx.cs" Inherits="TicketsSistemas.Presentacion.ControlTicketsSoporte" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UserControl/Message.ascx" TagPrefix="UCMessageBox" TagName="Msgbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ColumnHeader {
            background-color: #004F93;
            color: white;
            font-size: medium;
        }

        .BorderGridView {
            -webkit-border-radius: 12px;
            box-shadow: 0px 0px 8px transparent;
            -moz-box-shadow: 0px 0px 8px transparent;
            -webkit-box-shadow: 0px 0px 8px transparent;
        }

        .textbox {
            border: 1px solid #ccc;
            font-size: 12px;
            height: 30px;
            -webkit-border-radius: 4px;
            box-shadow: 0px 0px 8px #ccc;
            -moz-box-shadow: 0px 0px 8px #ccc;
            -webkit-box-shadow: 0px 0px 8px #ccc;
            margin-bottom: 1%;
        }
    </style>

    <link href="../Content/ControlUpload.css" rel="stylesheet" />
    <link href="../Content/MasterPage/css/bootstrap.min.css" rel="stylesheet" />

    <script src="../Content/MasterPage/js/jquery-3.3.1.min.js"></script>
    <script src="../Content/MasterPage/js/bootstrap.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
       
    </asp:ScriptManager>

    <asp:UpdatePanel ID="updGeneralNuevoTicket" UpdateMode="Conditional" runat="server" Visible="true">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-3" style="border-right: solid; border-right-color: #ccc;">
                        <div class="tm-bg-primary-dark tm-block-settings">
                            <h2 class="tm-block-title">Nuevo Ticket</h2>
                            <div class="row">
                                <div class="form-group col-lg-12">
                                    <asp:Label ID="lblPlantel" runat="server" Text="Plantel" class="text-xs font-weight-bold text-dark text-uppercase mb-1"></asp:Label>
                                    <asp:DropDownList ID="ddlPlantel" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group col-lg-12">
                                    <asp:Label ID="lblTipoSoporte" runat="server" Text="TIPO DE SOPORTE" class="text-xs font-weight-bold text-dark text-uppercase mb-1"></asp:Label>
                                    <asp:DropDownList ID="ddlTipoSoporte" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoSoporte_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="form-group col-lg-12">
                                    <asp:Label ID="lblConcepto" runat="server" Text="Concepto" class="text-xs font-weight-bold text-dark text-uppercase mb-1"></asp:Label>
                                    <asp:DropDownList ID="ddlConcepto" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group col-lg-12">
                                    <asp:Label ID="lblDetalle" runat="server" Text="Detalle" class="text-xs font-weight-bold text-dark text-uppercase mb-1"></asp:Label>
                                    <asp:TextBox ID="txtDetalle" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group col-lg-12" id="ContenedorUpload" runat="server" visible="true">
                                    
                                    <div class="wrapper">
                                      <div class="file-upload">
                                        <asp:FileUpload ID="fileUpEvidencia" runat="server" Visible="true" OnPreRender="fileUpEvidencia_PreRender" />
                                        <i class="fa fa-arrow-up" id="mensaje2">      Seleccionar archivo...</i>
                                          <label class="file-return" >Seleccionar archivo...</label>
                                      </div>
                                       
                                    </div>             
                                </div>
                                <div class="col-md-10 col-5">
                                    <label class="file-return" id="mensaje"></label>
                                </div>
                                <div class="col-12">
                                    <asp:Button ID="btnAgregarNuevoTicket" runat="server" Text="Aceptar" CssClass="btn btn-primary btn-block text-uppercase" OnClick="btnAgregarNuevoTicket_Click" />                  
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-9">
                        <div class="tm-bg-primary-dark tm-block-avatar">
                            <h2 class="tm-block-title">Cerrar Ticket</h2>

                            <asp:Panel ID="Panel1" runat="server" ScrollBars="auto" Height="330px" CssClass="BorderGridView">
                                <asp:GridView ID="gv_CerrarTicket" runat="server"
                                    DataKeyNames="cerrar_id_ticket,cerrar_nombre_empresa,cerrar_ds_concepto,cerrar_detalle,
                                    cerrar_fecha_iniciado,cerrar_id_calificacion,ds_calificacion,cerrar_fecha_proceso,cerrar_fecha_atendido,
                                    cerrar_obs_atendido,cerrar_fecha_cerrado,cerrar_obs_cerrado,usuario_levanta,usuario_atiende, tiempo_respuesta, correo_atiende,id_estatus"
                                    Font-Size="10pt" CssClass="textbox"
                                    AllowSorting="True"
                                    OnRowCommand="gv_CerrarTicket_RowCommand"
                                    AutoGenerateColumns="False" ForeColor="#333333"
                                    GridLines="None"
                                    EmptyDataText="Sin Tickets Registrados" EmptyDataRowStyle-BackColor="White"
                                    EmptyDataRowStyle-Font-Bold="true" EmptyDataRowStyle-Font-Size="Large"
                                    EmptyDataRowStyle-ForeColor="#004F93" HeaderStyle-Font-Size="10px"
                                    ShowHeaderWhenEmpty="True" Width="100%"
                                    HeaderStyle-HorizontalAlign="Center" CellPadding="4">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="ColumnHeader" ControlStyle-Width="25px" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageSelectTicket" runat="server" ImageUrl="~/Imagenes/select-row.png" Width="10%"
                                                    CommandName="ObtenerTicket" ToolTip="Calificar Ticket"
                                                    CommandArgument='<%# Eval("cerrar_id_ticket") + "," + Eval("cerrar_nombre_empresa")
                                                                 + "," + Eval("cerrar_ds_concepto") + "," + Eval("cerrar_detalle")
                                                                 + "," + Eval("cerrar_fecha_iniciado") + "," + Eval("cerrar_id_calificacion")  
                                                                 + "," + Eval("cerrar_fecha_proceso") + "," + Eval("cerrar_fecha_atendido") 
                                                                 + "," + Eval("cerrar_fecha_cerrado") + "," + Eval("usuario_levanta")
                                                                  + "," + Eval("usuario_atiende") + "," + Eval("correo_atiende")%>' />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="ColumnHeader" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="ColumnHeader" ControlStyle-Width="25px" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageSelectEliminaTicket" runat="server" ImageUrl="~/Imagenes/delete-row.png" Width="10%"
                                                    CommandName="EliminaTicket" ToolTip="Eliminar Ticket"
                                                    CommandArgument='<%# Eval("cerrar_id_ticket") + "," + Eval("cerrar_nombre_empresa")
                                                                 + "," + Eval("cerrar_ds_concepto") + "," + Eval("cerrar_detalle")
                                                                 + "," + Eval("cerrar_fecha_iniciado") + "," + Eval("cerrar_id_calificacion")  
                                                                 + "," + Eval("cerrar_fecha_proceso") + "," + Eval("cerrar_fecha_atendido") 
                                                                 + "," + Eval("cerrar_fecha_cerrado") + "," + Eval("usuario_levanta")
                                                                  + "," + Eval("usuario_atiende")%>' />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="ColumnHeader" />
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="ColumnHeader" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_cerrar_id_ticket" runat="server" Text='<%#Bind("cerrar_id_ticket") %>' Enabled="false" Visible="true" CssClass="label" />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Levanta Ticket" HeaderStyle-CssClass="ColumnHeader" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_UsuarioLevanta" runat="server" Text='<%#Bind("usuario_levanta") %>' Enabled="false" Visible="true" CssClass="label" />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="ColumnHeader" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Concepto" HeaderStyle-CssClass="ColumnHeader" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_cerrar_ds_concepto" runat="server" Text='<%#Bind("cerrar_ds_concepto") %>' Enabled="false" Visible="true" CssClass="label" />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="ColumnHeader" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Incidencia" HeaderStyle-CssClass="ColumnHeader" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_cerrar_detalle" runat="server" Text='<%#Bind("cerrar_detalle") %>' Enabled="false" Visible="true" CssClass="label" />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="ColumnHeader" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Iniciado" HeaderStyle-CssClass="ColumnHeader" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_cerrar_fecha_iniciado" runat="server" Text='<%#Bind("cerrar_fecha_iniciado") %>' Enabled="false" Visible="true" CssClass="label" />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="ColumnHeader" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Proceso" HeaderStyle-CssClass="ColumnHeader" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_fecha_proceso" runat="server" Text='<%#Bind("cerrar_fecha_proceso") %>' Enabled="false" Visible="true" CssClass="label" />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="ColumnHeader" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Atendido" HeaderStyle-CssClass="ColumnHeader" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_fecha_atendido" runat="server" Text='<%#Bind("cerrar_fecha_atendido") %>' Enabled="false" Visible="true" CssClass="label" />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="ColumnHeader" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha Cerrado" HeaderStyle-CssClass="ColumnHeader" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_fecha_cerrado" runat="server" Text='<%#Bind("cerrar_fecha_cerrado") %>' Enabled="false" Visible="true" CssClass="label" />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="ColumnHeader" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Atiende Ticket" HeaderStyle-CssClass="ColumnHeader" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_UsuarioAtiende" runat="server" Text='<%#Bind("usuario_atiende") %>' Enabled="false" Visible="true" CssClass="label" />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="ColumnHeader" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Calificacion" HeaderStyle-CssClass="ColumnHeader" FooterStyle-HorizontalAlign="Center" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_cerrar_id_calificacion" runat="server" Text='<%#Bind("cerrar_id_calificacion") %>' Enabled="false" Visible="true" CssClass="label" />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="ColumnHeader" />
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Evidencia" HeaderStyle-CssClass="ColumnHeader" ControlStyle-Width="30px" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                            <asp:ImageButton ID="ImageSelect3" runat="server" ImageUrl="~/Imagenes/CargarArchivo.png" Width="10%"
                                                                CommandName="DescargarEvidencia" ToolTip="Descargar Evidencia"
                                                                CommandArgument='<%# Eval("gv_ruta_evidencia") %>' />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                         </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Detalle" HeaderStyle-CssClass="ColumnHeader" ControlStyle-Width="30px" FooterStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                            <asp:ImageButton ID="ImageSelect4" runat="server" ImageUrl="~/Imagenes/Detalle.png" Width="10%"
                                                                CommandName="VerDetalle" ToolTip="Ver Detalle"
                                                                CommandArgument='<%# Eval("cerrar_id_ticket") + "|" + Eval("cerrar_ds_concepto")  
                                                                            + "|" + Eval("cerrar_fecha_iniciado") + "|" + Eval("cerrar_detalle") 
                                                                            + "|" + Eval("cerrar_fecha_proceso")  
                                                                            + "|" + Eval("cerrar_fecha_atendido") + "|" + Eval("cerrar_obs_atendido") 
                                                                            + "|" + Eval("cerrar_fecha_cerrado") + "|" + Eval("cerrar_obs_cerrado")
                                                                            + "|" + Eval("ds_calificacion")+ "|" + Eval("tiempo_respuesta")%>' />
                                            </ItemTemplate>
                                            <ControlStyle ForeColor="Black" />
                                         </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle HorizontalAlign="Center" BackColor="#EFF3FB" Height="20" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </asp:Panel>

                            <br />
                            <asp:Label ID="lblCalificacion" runat="server" Text="Calificación" class="text-xs font-weight-bold text-dark text-uppercase mb-1" Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddlCalificacion" runat="server" Width="12%" AutoPostBack="true" CssClass="textbox" Visible="false"></asp:DropDownList>
                            <asp:Label ID="lblObsCerrado" runat="server" Text="Observaciones" class="text-xs font-weight-bold text-dark text-uppercase mb-1" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtObsCerrado" runat="server" MaxLength="199" Width="57%" CssClass="textbox" Visible="false"></asp:TextBox>
                            <br />
                            <div style="text-align: right">
                                <asp:Button ID="btnCerrarCancelar" runat="server" Text="Cancelar" class="d-none d-sm-inline-block btn btn-sm btn-danger shadow-sm" OnClick="btnCerrarCancelar_Click" Visible="false" />
                                <asp:Button ID="btnCerrarAceptar" runat="server" Text="Aceptar" class="d-none d-sm-inline-block btn btn-sm btn-success shadow-sm" OnClick="btnCerrarAceptar_Click" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>    
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="gv_CerrarTicket" />
            <asp:PostBackTrigger ControlID="btnAgregarNuevoTicket" />
            <asp:PostBackTrigger ControlID="btnCerrarCancelar" />
            <asp:PostBackTrigger ControlID="btnCerrarAceptar" />
        </Triggers>
    </asp:UpdatePanel>

    <div class="modal fade" id="mdDetalleTick" aria-labelledby="CenterTitle" aria-hidden="true">
      <div class="modal-dialog modal-dialog-scrollable modal-lg">
        <div class="modal-content">
          <div class="modal-header bg-gradient-primary">
            <h5 class="modal-title" id="exampleModalLabel">DETALLE TICKET # <asp:Label ID="lblid_ticket" runat="server" Text="0"></asp:Label></h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> 
          </div>
          <div class="modal-body">
            <table class="table table-hover">
                <tbody>
                    <tr class="table-primary">
                        <td class="text-dark text-center font-weight-bold">
                            <asp:Label ID="lblFechIncid" runat="server" Text="Fecha"></asp:Label></td>
                        <td class="text-dark text-center">
                            <asp:Label ID="lblStdIncid" runat="server" Text="Incidencia"></asp:Label></td>
                        <td colspan="2" class="text-dark text-center text-break">
                            <asp:Label ID="lblDescIncid" runat="server" Text="Descripcion"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="text-dark text-center font-weight-bold">
                            <asp:Label ID="lblFechProcs" runat="server" Text="Sin Fecha"></asp:Label></td>
                        <td class="text-dark text-center">
                            <asp:Label ID="lblStdProcs" runat="server" Text="Ticket en Proceso" Visible="false"></asp:Label></td>
                        <td colspan="2" class="text-dark text-center text-break">
                            <asp:Label ID="lblDescProcs" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr class="table-primary">
                        <td class="text-dark text-center font-weight-bold">
                            <asp:Label ID="lblFechAten" runat="server" Text="Sin Fecha"></asp:Label></td>
                        <td class="text-dark text-center">
                            <asp:Label ID="lblStdAten" runat="server" Text="Ticket Atendido" Visible="false"></asp:Label></td>
                        <td colspan="2" class="text-dark text-center text-break">
                            <asp:Label ID="lblDescAten" runat="server" Text="Sin Descripción"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="text-dark text-center font-weight-bold">
                            <asp:Label ID="lblFechCerrd" runat="server" Text="Sin Fecha"></asp:Label></td>
                        <td class="text-dark text-center">
                            <asp:Label ID="lblStdCerrd" runat="server" Text="Ticket Cerrado" Visible="false"></asp:Label></td>
                        <td colspan="2" class="text-dark text-center text-break">
                            <asp:Label ID="lblDescCerrd" runat="server" Text="Sin Descripción"></asp:Label></td>
                    </tr>
                    <tr class="table-primary">
                        <td colspan="2" class="text-dark text-center font-weight-bold"><asp:Label ID="lblCalf" runat="server" Text="Sin Calificar" Visible="false"></asp:Label></td>
                        <td colspan="2" class="text-dark text-center font-weight-bold"><asp:Label ID="lblTimp" runat="server" Text="00 horas 00 minutos" Visible="false"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
          </div>
          <div class="modal-footer">

              <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
          </div>
        </div> 
      </div>
    </div>

    <div class="ref-div">
        <UCMessageBox:Msgbox ID="Msgbox" runat="server" EnableViewState="true" />
    </div>

    <script>
        $("#ContentPlaceHolder1_fileUpEvidencia").change(function () {
            var path = this.value
            path = path.substring(12);
            $("#mensaje").text(path)
        });
    </script>
</asp:Content>--%>
