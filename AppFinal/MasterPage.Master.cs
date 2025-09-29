using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control;
using Model;

namespace AppFinal
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is Default || Page is Registro || Page is Contacto))
            {
                if (!Seguridad.SesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }

            if (Seguridad.SesionActiva(Session["usuario"]))
            {
                imgPerfil.ImageUrl = "~/images/" + ((Usuario)Session["usuario"]).URLImagenPerfil;
            }
            else
                imgPerfil.ImageUrl = "https://openclipart.org/image/2000px/247319";
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}