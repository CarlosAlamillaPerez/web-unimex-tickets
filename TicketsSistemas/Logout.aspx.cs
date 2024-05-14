using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketsSistemas
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Elimina todas las variables de sesión
            Session.Clear();

            // Invalida la sesión actual
            Session.Abandon();

            // Redirige al usuario a la página de login
            Response.Redirect("~/Login.aspx");
        }
    }
}