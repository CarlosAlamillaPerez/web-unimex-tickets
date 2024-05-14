using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using Entidades;
using Negocio;
using System;
using System.Web;
using System.Web.Services;

namespace TicketsSistemas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public class JsonTicketResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public string RedirectUrl { get; set; }
        }

        [WebMethod]
        public static JsonTicketResponse Btn_Enviar_Login(string user, string pass)
        {
            JsonTicketResponse response = new JsonTicketResponse();
            try
            {
                if (!string.IsNullOrEmpty(user))
                {
                    if (!string.IsNullOrEmpty(pass))
                    {

                        
                        Login login = new Login();
                        if (login.ValidaAcceso(user, pass))
                        {
                            string usuario = (string)HttpContext.Current.Session["Usuario"];
                            response.Success = true;
                            response.Message = "Bienvenido " + usuario;
                            response.RedirectUrl = "Presentacion/ControlTicketsSoporte.aspx";
                        }
                        else
                        {
                            response.Success = false;
                            response.Message = "Usuario o contraseña incorrectos";
                        }
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Escribe tu contraseña";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Escribe tu usuario";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error inesperado: '{ex.Message}'";
            }
            return response;
        }

        public bool ValidaAcceso(string _user, string Password)
        {
            Cls_Usuario User = new Cls_Usuario();
            ClsDesEncripta oDesEnc = new ClsDesEncripta();

            string _pass = oDesEnc.Encripta(Password);
            User = new Home_Neg().ValidaAcceso(_user, _pass, new Infraestructura.FactoryConection().GeneraConexion(7));
            if (User != null)
            {
                HttpContext.Current.Session["ClaveUsuario"] = User.ClaveUsuario;
                HttpContext.Current.Session["Usuario"] = User.Usuario;
                HttpContext.Current.Session["Nombre"] = User.Nombre;
                HttpContext.Current.Session["Ap_paterno"] = User.ap_paterno;
                HttpContext.Current.Session["Ap_materno"] = User.ap_materno;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}