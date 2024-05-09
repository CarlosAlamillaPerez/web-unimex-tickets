using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketsSistemas
{
    public partial class MensajeError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtmensaje.Text = string.Empty;
            if (Session["mensaje_error_inicio_pagina"] != null)
            {
                StringBuilder detalle = new StringBuilder();
                detalle.AppendLine("                SENTIMOS EL INCONVENIENTE, ESTAMOS TRABAJANDO PARA BRINDARTE UN MEJOR SERVICIO.   ");
                detalle.AppendLine();
                detalle.AppendLine();
                detalle.AppendLine();
                detalle.AppendLine(Session["mensaje_error_inicio_pagina"].ToString());
                txtmensaje.Text = detalle.ToString();

            }
        }
    }
}