using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Control;

namespace AppFinal
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                string ruta = Server.MapPath("./Images/");
                Usuario user = (Usuario)Session["usuario"];
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");

                user.URLImagenPerfil = "perfil-" + user.Id + ".jpg";               
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                negocio.Actualizar(user);

                Image img = (Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/images/" + user.URLImagenPerfil;

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}