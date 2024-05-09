﻿using System.Net;
using System.Net.Mail;
using Entidades.Tickets;
using Entidades;
using Negocio;
using Negocio.Tickets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using TicketsSistemas.Infraestructura;
using System.Web.UI.WebControls.Expressions;
using Newtonsoft.Json;
using File = System.IO.File;


namespace TicketsSistemas.Presentacion
{
    public partial class ControlTicketsSoporte : System.Web.UI.Page
    {

        #region [ Carga Pagina ]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Usuario"] != null)
            {
                Response.Cookies["Usuario"].Expires = DateTime.Now.AddDays(-1);
            }
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                Metodo_User_Access();
                Metodo_DDL_Plantel();
                Metodo_DDL_Soporte();
                Metodo_DDL_Concepto();

                Session.Timeout = 1440;
                this.Page.Form.Enctype = "multipart/form-data";
            }

        }
        #endregion

        #region[Acceso Para Aplicación]
        private void Metodo_User_Access()
        {
            try
            {
                Cls_aplicaciones_seguridad Nivel_Acceso_App = (from l in new Negocio_Usuario().ValidarUsarioAccesoApp(Convert.ToInt32(Session["ClaveUsuario"]), 184, new FactoryConection().GeneraConexion(7).ToString()) where l.Clave_aplicacion == 184 select l).FirstOrDefault();
                if (Nivel_Acceso_App == null)
                {
                    ControlTicketsSoporte.alert_general(this, "Error", "Este usuario no tiene un nivel de acceso.", "error");
                    return;
                }
                else
                {
                    switch (Convert.ToInt16(Nivel_Acceso_App.Clave_nivel_acceso))
                    {
                        case 1: break;
                        case 2: break;
                        case 3: break;
                        case 0: ControlTicketsSoporte.alert_general(this, "Error", "Este usuario no tiene un nivel de acceso.", "error"); break;
                        default: goto case 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ControlTicketsSoporte.alert_general(this, "Error", "Error inesperado: " + ex.Message, "error");
            }
        }
        #endregion

        #region [DDL Lista De Opciones (New Ticket) ]
        private void Metodo_DDL_Plantel()
        {
            try
            {
                ddlPlantel.DataSource = (new Negocio_Tickets()).Metodo_DDL_Plantel(Convert.ToInt32(Session["ClaveUsuario"]));
                ddlPlantel.DataTextField = "nombre_empresa";
                ddlPlantel.DataValueField = "id_empresa";
                ddlPlantel.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Metodo_DDL_Soporte()
        {
            try
            {
                ddlTipoSoporte.DataSource = (new Negocio_Tickets()).Metodo_DDL_Soporte();
                ddlTipoSoporte.DataTextField = "ds_tipo_soporte";
                ddlTipoSoporte.DataValueField = "id_tipo_soporte";
                ddlTipoSoporte.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Metodo_DDL_Concepto()
        {
            try
            {
                ddlConcepto.DataSource = (new Negocio_Tickets()).Metodo_DDL_Concepto(Convert.ToInt32(ddlTipoSoporte.SelectedValue));
                ddlConcepto.DataTextField = "ds_concepto";
                ddlConcepto.DataValueField = "id_concepto";
                ddlConcepto.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlTipoSoporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            Metodo_DDL_Concepto();
        }

        #endregion

        #region [ Estructura DataTable ]
        [WebMethod]
        public static DataTableTickets<Cls_Tickets> TicketsTable(string ClientParameters)
        {
            List<Cls_Tickets> ListaTickets = new List<Cls_Tickets>();
            DataTableParameter dtp = JsonConvert.DeserializeObject<DataTableParameter>(ClientParameters);
            int id = Convert.ToInt32(HttpContext.Current.Session["ClaveUsuario"]);
            ListaTickets = new Negocio_Tickets().Metodo_Obtener_TicketsDataTable(id, dtp.start, dtp.length, dtp.search.value);
            int total = new Negocio_Tickets().Metodo_Obtener_TotalDataTable(dtp.search.value, id);
            return new DataTableTickets<Cls_Tickets>() { draw = dtp.draw, recordsFiltered = total, recordsTotal = total, data = ListaTickets };
        }
        [WebMethod]
        public static DataTableTickets<Cls_Tickets> TicketsTable2(string ClientParameters)
        {
            List<Cls_Tickets> ListaTickets = new List<Cls_Tickets>();
            DataTableParameter dtp = JsonConvert.DeserializeObject<DataTableParameter>(ClientParameters);
            int id = Convert.ToInt32(HttpContext.Current.Session["ClaveUsuario"]);
            ListaTickets = new Negocio_Tickets().Metodo_Obtener_TicketsDataTable2(id, dtp.start, dtp.length, dtp.search.value);
            int total = new Negocio_Tickets().Metodo_Obtener_TotalDataTable2(dtp.search.value, id);
            return new DataTableTickets<Cls_Tickets>() { draw = dtp.draw, recordsFiltered = total, recordsTotal = total, data = ListaTickets };
        }
        public class DataTableParameter
        {
            public int draw { get; set; }
            public int length { get; set; }
            public int start { get; set; }
            public searchtxt search { get; set; }
        }
        public class searchtxt
        {
            public string value { get; set; }
        }
        public struct DataTableTickets<T>
        {
            public int draw;
            public int recordsTotal;
            public int recordsFiltered;
            public List<T> data;
        }
        #endregion

        #region [ Botones DataTable (Llamados por AJAX) ]
        public class JsonTicketResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
        }

        [WebMethod]
        public static JsonTicketResponse Btn_Agregar(int plantelId, int conceptoId, string detalle, string fileBytes, string fileName)
        {
            JsonTicketResponse response = new JsonTicketResponse();
            try
            {
                if (!string.IsNullOrEmpty(detalle))
                {
                    int id_ticket = new Negocio_Tickets().Btn_Agregar(plantelId, conceptoId, detalle, Convert.ToInt32(HttpContext.Current.Session["ClaveUsuario"]));

                    if (!string.IsNullOrEmpty(fileBytes))
                    {
                        byte[] bytes = Convert.FromBase64String(fileBytes);
                        string plantel = "";
                        switch (plantelId)
                        {
                            case 1: plantel = "Rectoria"; break;
                            case 2: plantel = "Izcalli"; break;
                            case 3: plantel = "Satelite"; break;
                            case 4: plantel = "Polanco"; break;
                            case 5: plantel = "Veracruz"; break;
                        }
                        string path = ConfigurationManager.AppSettings["RutaEvidenciasTickets"].ToString() + plantel + "\\" + id_ticket + "\\" + fileName;
                        if (!Directory.Exists(Path.GetDirectoryName(path)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(path));
                        }
                        File.WriteAllBytes(path, bytes);
                        (new Negocio_Tickets()).Metodo_Guardar_RutaArchivo(path, id_ticket);
                    }

                    string nombre_usuario = HttpContext.Current.Session["Nombre"].ToString() + " " + HttpContext.Current.Session["Ap_paterno"] + " " + HttpContext.Current.Session["Ap_materno"];
                    string incidencia = detalle;
                    int id_usuario = Convert.ToInt32(HttpContext.Current.Session["ClaveUsuario"]);
                    new Negocio_Tickets().Metodo_EnviarCorreos_TicketGenerado(id_ticket, nombre_usuario, incidencia, id_usuario);
                    response.Success = true;
                    response.Message = "Te notificaremos por correo cuando tu ticket se encuentre en proceso de atención.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Necesitas describir el problema que presentas.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error inesperado: '{ex.Message}'";
            }
            return response;
        }

        [WebMethod]
        public static JsonTicketResponse Btn_DataTable_Descargar(int id_ticket)
        {
            JsonTicketResponse response = new JsonTicketResponse();
            string rutaArchivo = new Negocio_Tickets().Metodo_Obtener_RutaArchivo(id_ticket);

            if (File.Exists(rutaArchivo))
            {
                try
                {
                    byte[] fileBytes = File.ReadAllBytes(rutaArchivo);
                    string fileName = Path.GetFileName(rutaArchivo);
                    string contentType = MimeMapping.GetMimeMapping(fileName);

                    response.Success = true;
                    response.Message = Convert.ToBase64String(fileBytes);
                    response.FileName = fileName;
                    response.ContentType = contentType;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Error al leer el archivo: " + ex.Message;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Sin archivos";
            }

            return response;
        }

        [WebMethod]
        public static void Btn_DataTable_Informacion(int id_ticket)
        {
            return;
        }

        [WebMethod]
        public static JsonTicketResponse Btn_DataTable_Eliminar(int id_ticket)
        {
            JsonTicketResponse response = new JsonTicketResponse();
            string rutaArchivo = new Negocio_Tickets().Metodo_Obtener_RutaArchivo(id_ticket);
            if (File.Exists(rutaArchivo))
            {
                response.Success = true;
                response.Message = "Ticket & Evidencia Eliminados";
                File.Delete(rutaArchivo);
            }
            else
            {
                response.Success = false;
                response.Message = "Ticket Eliminado";
            }
            new Negocio_Tickets().Btn_DataTable_Eliminar(id_ticket);
            return response;
        }

        [WebMethod]
        public static void Btn_DataTable_Calificacion_Success(int id_ticket, int calificacion)
        {
            new Negocio_Tickets().Btn_DataTable_Calificacion_Success(id_ticket, calificacion);
        }

        [WebMethod]
        public static void Btn_DataTable_Calificacion_Error(int id_ticket, string mensaje)
        {
            new Negocio_Tickets().Btn_DataTable_Calificacion_Error(id_ticket, mensaje);
        }
        #endregion



        public static void alert_general(Page page, string title, string subtitle, string type)
        {
            string script = $"Swal.fire({{title: '{title}', text: '{subtitle}', icon: '{type}'}});";
            ScriptManager.RegisterStartupScript(page, page.GetType(), "", script, true);
        }
    }
}