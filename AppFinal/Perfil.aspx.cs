using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace AppFinal
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }

        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}