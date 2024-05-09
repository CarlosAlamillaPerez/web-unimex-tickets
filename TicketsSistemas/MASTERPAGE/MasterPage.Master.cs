﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketsSistemas.MASTERPAGE
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Usuario"] != null)
            {
                Response.Cookies["Usuario"].Expires = DateTime.Now.AddDays(-1);
            }
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Home.aspx");
            }
            if (!IsPostBack)
            {
                lblCerrarSesion.Text = "Bienvenido " + Session["Nombre"].ToString() + " " + Session["Ap_paterno"] + " " + Session["Ap_materno"];
            }
        }
    }
}