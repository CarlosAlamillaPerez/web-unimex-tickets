//using Entidades;
//using Negocio;
//using Negocio.Tickets;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using TicketsSistemas.Infraestructura;
//using static TicketsSistemas.UserControl.Message;

//namespace TicketsSistemas.Presentacion
//{
//    public partial class ControlTicketsSoporte : System.Web.UI.Page
//    {
//        #region [ Variables Globales ]
//        decimal CLAVE_APP = 184;
//        FactoryConection ConGen = new FactoryConection();
//        Negocio_Tickets obj = new Negocio_Tickets();
//        #endregion

//        #region [ Carga Pagina ]
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (Request.Cookies["Usuario"] != null)
//            {
//                Response.Cookies["Usuario"].Expires = DateTime.Now.AddDays(-1);
//            }
//            if (Session["Usuario"] == null)
//            {
//                Response.Redirect("~/Login.aspx");
//            }
//            if (!IsPostBack)
//            {
//                Aplica_Niveles_Acceso();

//                Session.Timeout = 1440;

//                Llena_ddlPlantel();
//                Metodo_DDL_Soporte();
//                Metodo_DDL_Concepto();
//                Llena_ddlCalificacion();

//                Llena_gv_CerrarTicket();
//                Recorre_gv_CerrarTicket();
//                this.Page.Form.Enctype = "multipart/form-data";
//            }

//            string script = "$('#" + fileUpEvidencia.ClientID + "').change(function() {var path=this.value; path=path.substring(12); $('#mensaje').text(path) });";
//            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(ControlTicketsSoporte), Guid.NewGuid().ToString(), script, true);
//        }

//        #endregion

//        #region [ Mensajes ] *******************************************************************************************************

//        protected void MostrarMensajeAceptar(String Aceptar)
//        {
//            clsMsg mensaje = new clsMsg("Agregado", Aceptar.ToString());
//            Msgbox.widthMessage = 300;
//            Msgbox.heightMessage = 200;
//            Msgbox.Show(mensaje, EnumBotones.OK, EnumImages.Aceptar);
//        }
//        protected void MostrarMensajeError(String Cancelar)
//        {
//            clsMsg mensaje = new clsMsg("Error", Cancelar.ToString());
//            Msgbox.widthMessage = 300;
//            Msgbox.heightMessage = 200;
//            Msgbox.Show(mensaje, EnumBotones.OK, EnumImages.Cancelar);
//        }
//        protected void MostrarMensajeAviso(String Aviso)
//        {
//            clsMsg mensaje = new clsMsg("Aviso", Aviso.ToString());
//            Msgbox.widthMessage = 300;
//            Msgbox.heightMessage = 200;
//            Msgbox.Show(mensaje, EnumBotones.OK, EnumImages.Aviso);
//        }
//        protected void MostrarMensajePregunta(String Pregunta)
//        {
//            clsMsg mensaje = new clsMsg("Pregunta", Pregunta.ToString());
//            Msgbox.widthMessage = 300;
//            Msgbox.heightMessage = 200;
//            Msgbox.Show(mensaje, EnumBotones.YesNo, EnumImages.Preguntar);
//        }

//        #endregion

//        # region Lee el Nivel de Acceso de la Aplicación ---------------------------------
//        private void Aplica_Niveles_Acceso()
//        {

//            try
//            {
//                Cls_aplicaciones_seguridad Nivel_Acceso_App = (from l in (new Negocio_Usuario()).ValidarUsarioAccesoApp(Convert.ToInt32(Session["ClaveUsuario"]), CLAVE_APP, ConGen.GeneraConexion(7).ToString())
//                                                               where l.Clave_aplicacion == CLAVE_APP
//                                                               select l).FirstOrDefault();
//                if (Nivel_Acceso_App == null)
//                {
//                    MostrarMensajeAviso("Hubo un problema al momento de leer el nivel de acceso del usuario");
//                    return;
//                }
//                else
//                {
//                    // Aplica restricciones del nivel de acceso
//                    switch (Convert.ToInt16(Nivel_Acceso_App.Clave_nivel_acceso))
//                    {
//                        case 1:
//                            break;

//                        case 2:
//                            break;

//                        case 3:
//                            break;
//                        case 0:
//                            Session["mensaje_error_inicio_pagina"] = string.Format("No cuenta con permisos para acceder  a la  aplicación, favor de comunicarse con el área de sistemas.");
//                            Response.Redirect("~/MensajeError.aspx", true);
//                            break;
//                        default: goto case 0;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MostrarMensajeError("Procedimiento: Aplica_Niveles_Acceso (" + ex.Message.ToString() + ")");
//            }
//        }
//        #endregion

//        #region [ Carga Información Controles ]

//        private void Llena_ddlPlantel()
//        {
//            try
//            {
//                ddlPlantel.DataSource = (new Negocio_Tickets()).Metodo_DDL_Plantel(Convert.ToInt32(Session["ClaveUsuario"]));
//                ddlPlantel.DataTextField = "nombre_empresa";
//                ddlPlantel.DataValueField = "id_empresa";
//                ddlPlantel.DataBind();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        private void Metodo_DDL_Soporte()
//        {
//            try
//            {
//                ddlTipoSoporte.DataSource = (new Negocio_Tickets()).Metodo_DDL_Soporte();
//                ddlTipoSoporte.DataTextField = "ds_tipo_soporte";
//                ddlTipoSoporte.DataValueField = "id_tipo_soporte";
//                ddlTipoSoporte.DataBind();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        private void Metodo_DDL_Concepto()
//        {
//            try
//            {
//                ddlConcepto.DataSource = (new Negocio_Tickets()).MuestraCatConceptos(Convert.ToInt32(ddlTipoSoporte.SelectedValue));
//                ddlConcepto.DataTextField = "ds_concepto";
//                ddlConcepto.DataValueField = "id_concepto";
//                ddlConcepto.DataBind();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        private void Llena_ddlCalificacion()
//        {
//            try
//            {
//                ddlCalificacion.DataSource = (new Negocio_Tickets()).Muestra_CatCalificaciones();
//                ddlCalificacion.DataTextField = "ds_calificacion";
//                ddlCalificacion.DataValueField = "id_calificacion";
//                ddlCalificacion.DataBind();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        private void Llena_gv_CerrarTicket()
//        {
//            try
//            {
//                gv_CerrarTicket.DataSource = "";
//                gv_CerrarTicket.DataBind();
//                gv_CerrarTicket.DataSource = (new Negocio_Tickets()).CerrarTickets(Convert.ToInt32(Session["ClaveUsuario"]));
//                gv_CerrarTicket.DataBind();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        protected void btnCerrarCancelar_Click(object sender, EventArgs e)
//        {
//            txtObsCerrado.Text = "";
//            ddlCalificacion.Visible = false;
//            lblCalificacion.Visible = false;
//            txtObsCerrado.Visible = false;
//            lblObsCerrado.Visible = false;
//            btnCerrarCancelar.Visible = false;
//            btnCerrarAceptar.Visible = false;
//            Recorre_gv_CerrarTicket();
//        }

//        protected void btnCerrarAceptar_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                obj.ActualizaCerrarTicket(Convert.ToInt32(ddlCalificacion.SelectedValue), txtObsCerrado.Text,
//                Convert.ToInt32(Session["id_ticket_cerrado"]));

//                EnviaCorreo(Session["correo_atiende"].ToString(), Session["usuario_atiende"].ToString(), Convert.ToString(Session["id_ticket_cerrado"]),
//                    Session["Nombre"].ToString() + " " + Session["Ap_paterno"] + " " + Session["Ap_materno"]);

//                Llena_gv_CerrarTicket();
//                Recorre_gv_CerrarTicket();

//                txtObsCerrado.Text = "";
//                ddlCalificacion.Visible = false;
//                lblCalificacion.Visible = false;
//                txtObsCerrado.Visible = false;
//                lblObsCerrado.Visible = false;
//                btnCerrarCancelar.Visible = false;
//                btnCerrarAceptar.Visible = false;
//                MostrarMensajeAceptar("Ticket Cerrado.");
//            }
//            catch (Exception ex) { throw ex; }
//        }

//        #endregion

//        #region [ Eventos ]
//        protected void btnAgregarNuevoTicket_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (txtDetalle.Text != "")
//                {
//                    int id_ticket = obj.InsertaNuevoTicket(Convert.ToInt32(ddlPlantel.SelectedValue), Convert.ToInt32(ddlConcepto.SelectedValue),
//                    txtDetalle.Text, Convert.ToInt32(Session["ClaveUsuario"]));

//                    if (fileUpEvidencia.HasFile)
//                    {
//                        string path = null;
//                        byte[] bytes = fileUpEvidencia.FileBytes;
//                        string nameFile = fileUpEvidencia.FileName;

//                        string plantel = "";
//                        switch (ddlPlantel.SelectedValue)
//                        {
//                            case "1":
//                                plantel = "Rectoria";
//                                break;
//                            case "2":
//                                plantel = "Izcalli";
//                                break;
//                            case "3":
//                                plantel = "Satelite";
//                                break;
//                            case "4":
//                                plantel = "Polanco";
//                                break;
//                            case "5":
//                                plantel = "Veracruz";
//                                break;
//                            default:
//                                break;
//                        }
//                        path = ConfigurationManager.AppSettings["RutaEvidenciasTickets"].ToString() + plantel + "\\" + id_ticket + "\\";

//                        if (!Directory.Exists(path))
//                        {
//                            Directory.CreateDirectory(path);
//                        }
//                        path = path + nameFile;
//                        using (FileStream fs = File.Create(path))
//                        {
//                            fs.Write(bytes, 0, bytes.Length);
//                        }
//                        obj.ActualizaRutaEvidencia(path, id_ticket);
//                    }

//                    txtDetalle.Text = "";
//                    Llena_gv_CerrarTicket();
//                    Recorre_gv_CerrarTicket();

//                    MostrarMensajeAceptar("Ticket Agregado.");
//                }
//                else
//                {
//                    MostrarMensajeAviso("Debes completar todos los campos");
//                }
//            }
//            catch (Exception ex) { throw ex; }



//        }

//        protected void Recorre_gv_CerrarTicket()
//        {
//            foreach (GridViewRow row in gv_CerrarTicket.Rows)
//            {
//                Label lbl_cerrar_id_calificacion = (Label)row.FindControl("lbl_cerrar_id_calificacion");

//                if (Convert.ToInt32(lbl_cerrar_id_calificacion.Text) > 0)
//                {
//                    ImageButton ImageSelectTicket = (ImageButton)row.FindControl("ImageSelectTicket");
//                    ImageButton ImageSelectEliminaTicket = (ImageButton)row.FindControl("ImageSelectEliminaTicket");
//                    ImageSelectTicket.Visible = false;
//                    ImageSelectEliminaTicket.Visible = false;
//                }

//                Label lbl_cerrar_fecha_iniciado = (Label)row.FindControl("lbl_fecha_atendido");
//                Label lbl_fecha_proceso = (Label)row.FindControl("lbl_fecha_proceso");
//                Label lbl_fecha_atendido = (Label)row.FindControl("lbl_fecha_atendido");


//                if (lbl_cerrar_fecha_iniciado.Text.Equals("") || lbl_fecha_proceso.Text.Equals("") || lbl_fecha_atendido.Text.Equals(""))
//                {
//                    ImageButton ImageSelectTicket = (ImageButton)row.FindControl("ImageSelectTicket");
//                    ImageSelectTicket.Visible = false;
//                }


//                ImageButton ImageSelect3 = (ImageButton)row.FindControl("ImageSelect3");
//                string ruta = ImageSelect3.CommandArgument;
//                if (ruta.Equals(""))
//                {
//                    ImageSelect3.Visible = false;
//                }
//            }
//        }

//        protected void gv_CerrarTicket_RowCommand(object sender, GridViewCommandEventArgs e)
//        {
//            if (e.CommandName == "ObtenerTicket")
//            {
//                string[] set = e.CommandArgument.ToString().Split(new char[] { ',', ',', ',', ',', ',' });
//                Session["id_ticket_cerrado"] = set[0];
//                Session["usuario_atiende"] = set[10];
//                Session["correo_atiende"] = set[11];

//                if (Session["usuario_atiende"].ToString() == "")
//                {
//                    MostrarMensajeAviso("Aun no puedes cerrar el ticket, ya se esta atendiendo.");
//                }
//                else
//                {
//                    ddlCalificacion.Visible = true;
//                    lblCalificacion.Visible = true;
//                    txtObsCerrado.Visible = true;
//                    lblObsCerrado.Visible = true;
//                    btnCerrarCancelar.Visible = true;
//                    btnCerrarAceptar.Visible = true;
//                }
//            }

//            if (e.CommandName == "EliminaTicket")
//            {
//                string[] set = e.CommandArgument.ToString().Split(new char[] { ',', ',', ',', ',', ',' });
//                Session["Eliminar_id_ticket"] = set[0];
//                Session["cerrar_fecha_proceso"] = set[6];

//                if (Session["cerrar_fecha_proceso"].ToString() != "")
//                {
//                    MostrarMensajeAviso("No puedes eliminar el ticket, ya se esta atendiendo.");
//                }
//                else
//                {
//                    obj.EliminaTicket(Convert.ToInt32(Session["Eliminar_id_ticket"]));
//                    Llena_gv_CerrarTicket();
//                    Recorre_gv_CerrarTicket();
//                    MostrarMensajeAceptar("Ticket eliminado.");
//                }

//                Session["Eliminar_id_ticket"] = null;
//                Session["cerrar_fecha_proceso"] = null;
//            }

//            if (e.CommandName.Equals("DescargarEvidencia"))
//            {
//                string path = e.CommandArgument.ToString();
//                string nambreArchivo = Path.GetFileName(path);
//                System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
//                Response.BufferOutput = true;
//                HttpContext.Current.Response.ClearContent();
//                HttpContext.Current.Response.Clear();
//                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + toDownload.Name);
//                HttpContext.Current.Response.AddHeader("Content-Length", toDownload.Length.ToString());
//                HttpContext.Current.Response.ContentType = "application/octet-stream";
//                HttpContext.Current.Response.TransmitFile(path);
//                Response.Flush();
//                HttpContext.Current.ApplicationInstance.CompleteRequest();
//            }

//            if (e.CommandName.Equals("VerDetalle"))
//            {
//                string[] set = e.CommandArgument.ToString().Split(new char[] { '|', '|', '|', '|', '|' });

//                lblid_ticket.Text = set[0] + " - " + set[1];

//                lblFechIncid.Text = set[2];
//                lblDescIncid.Text = set[3];

//                if (set[4] != "")
//                {
//                    lblFechProcs.Text = set[4];
//                    lblStdProcs.Visible = true;

//                    if (set[5] != "" && set[6] != "")
//                    {

//                        lblFechAten.Text = set[5];
//                        lblStdAten.Visible = true;
//                        lblDescAten.Text = set[6];

//                        if (set[7] != "" && set[8] != "")
//                        {

//                            lblFechCerrd.Text = set[7];
//                            lblStdCerrd.Visible = true;
//                            lblDescCerrd.Text = set[8];

//                            lblCalf.Visible = true;
//                            lblCalf.Text = "Calificación: " + set[9];
//                            lblTimp.Visible = true;
//                            lblTimp.Text = formatTiempoResp(Convert.ToString(set[10]));
//                        }
//                        else
//                        {

//                            lblFechCerrd.Text = String.Empty;
//                            lblStdCerrd.Visible = false;
//                            lblDescCerrd.Text = String.Empty;

//                            lblCalf.Visible = false;
//                            lblTimp.Visible = false;
//                        }

//                    }
//                    else
//                    {
//                        lblFechAten.Text = String.Empty;
//                        lblStdAten.Visible = false;
//                        lblDescAten.Text = String.Empty;

//                        lblFechCerrd.Text = String.Empty;
//                        lblStdCerrd.Visible = false;
//                        lblDescCerrd.Text = String.Empty;

//                        lblCalf.Visible = false;
//                        lblTimp.Visible = false;
//                    }
//                }
//                else
//                {
//                    lblFechProcs.Text = String.Empty;
//                    lblStdProcs.Visible = false;

//                    lblFechAten.Text = String.Empty;
//                    lblStdAten.Visible = false;
//                    lblDescAten.Text = String.Empty;

//                    lblFechCerrd.Text = String.Empty;
//                    lblStdCerrd.Visible = false;
//                    lblDescCerrd.Text = String.Empty;

//                    lblCalf.Visible = false;
//                    lblTimp.Visible = false;
//                }
//                cargaModal();
//            }

//        }
//        #endregion

//        protected void ddlTipoSoporte_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            Metodo_DDL_Concepto();
//        }

//        //Necesario para utilizar un uploadFile dentro de un updatePanel
//        protected void fileUpEvidencia_PreRender(object sender, EventArgs e)
//        {
//            base.OnPreRender(e);

//            if ((this.Page.Form != null) && (this.Page.Form.Enctype.Length == 0))
//            {
//                this.Page.Form.Enctype = "multipart/form-data";
//            }
//        }

//private void cargaModal()
//{
//    string script = "$('#mdDetalleTick').modal('show');";
//    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
//}

//        private string formatTiempoResp(string cad)
//        {
//            string[] set = cad.ToString().Split(new char[] { ':' });
//            return "Tiempo de Respuesta: " + set[0] + " horas " + set[1] + " minutos";
//        }

//        public bool EnviaCorreo(string correo_atiende, string userAtiende, string id_ticket, string userLevanta)
//        {
//            try
//            {
//                String Emisor = ConfigurationManager.AppSettings["EmisorEmail"].ToString();
//                String pass = ConfigurationManager.AppSettings["EmisorEmailPsw"].ToString();

//                //Clase para el contenido del Email
//                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

//                message.From = new System.Net.Mail.MailAddress(Emisor, "Administrador Unimex");
//                message.Bcc.Add(new System.Net.Mail.MailAddress(correo_atiende.Trim()));

//                //Cuerpo del Email
//                message.Subject = "Control de Tickets Sistemas";
//                message.Priority = System.Net.Mail.MailPriority.High;

//                var body = "Estimado(a) " + userAtiende + ".  <br/><br/>" +
//                    "Te informamos que el Ticket #" + id_ticket + " ya fue calificado por " + userLevanta + ". <br/><br/>" +
//                    "Para ver los detalles de el ticket por favor ingresa al PORTAL DE SISTEMAS a la opción CONTROL DE TICKETS DE SOPORTE. <br/><br/>" +
//                    "Atentamente: Gerencia Corporativa de Sistemas. <br/><br/><br/>" +
//                    "Por favor no respondas este correo.";

//                message.Body = body.ToString();
//                message.IsBodyHtml = true;

//                System.Net.Mail.SmtpClient ClienteSmtp = new System.Net.Mail.SmtpClient();
//                ClienteSmtp.Host = ConfigurationManager.AppSettings["Host"].ToString();
//                ClienteSmtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
//                System.Net.NetworkCredential Credenciales = new System.Net.NetworkCredential();
//                Credenciales.UserName = Emisor;
//                Credenciales.Password = pass;
//                ClienteSmtp.Credentials = Credenciales;
//                ClienteSmtp.EnableSsl = true;
//                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

//                ClienteSmtp.Send(message);
//                message.Dispose();

//                ClienteSmtp.Dispose();
//                return true;
//            }
//            catch (Exception ex) { return false; }
//        }

//    }
//}