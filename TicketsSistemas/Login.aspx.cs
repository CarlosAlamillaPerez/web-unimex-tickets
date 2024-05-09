using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TicketsSistemas.Presentacion;


namespace TicketsSistemas
{
    public partial class Login : System.Web.UI.Page
    {
        Infraestructura.FactoryConection _FactoryConection = new Infraestructura.FactoryConection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Evento Click del Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text != "" || txtPassword.Text != "")
                {
                    ClsDesEncripta oDesEnc = new ClsDesEncripta();
                    string pass = oDesEnc.Encripta(txtPassword.Text.Trim());
                    if (ValidaAcceso(txtUserName.Text.Trim(),pass))
                    {
                        Response.Redirect(@"~\Presentacion\ControlTicketsSoporte.aspx", false);
                        //Response.Redirect(@"~\Presentacion\ControlPrueba.aspx", false);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "window.alert('" + "Error al iniciar sesión. Datos incorrectos" + "');", true);
                        //ControlTicketsSoporte.alert_general(this, "Error", "Datos Incorrectos", "error");
                    }
                }
                else
                {
                    txtUserName.Focus();
                    txtPassword.Focus();
                }
            }
            catch (Exception)
            {
                ControlTicketsSoporte.alert_general(this, "Error", "Este usuario no tiene un nivel de acceso", "error");
            }
        }


        public bool ValidaAcceso(string Usuario, string Password)
        {
            Cls_Usuario user = new Cls_Usuario();
            user = (new Home_Neg()).ValidaAcceso(Usuario, Password, _FactoryConection.GeneraConexion(7));
            if (user != null)
            {
                Session["ClaveUsuario"] = user.ClaveUsuario;
                Session["Usuario"] = user.Usuario;
                Session["Nombre"] = user.Nombre;
                Session["Ap_paterno"] = user.ap_paterno;
                Session["Ap_materno"] = user.ap_materno;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}