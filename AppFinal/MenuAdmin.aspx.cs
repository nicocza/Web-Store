using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppFinal
{
    public partial class MenuAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Model.Usuario)Session["usuario"]).TipoUsuario == Model.TipoUsuario.ADMIN))
            {
                Session.Add("error", "No tienes acceso a esta página. Solo administradores.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}