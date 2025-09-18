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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario(txtEmail.Text, txtPass.Text, false);
                UsuarioNegocio negocio = new UsuarioNegocio();
                EmailService service = new EmailService();
                int id = negocio.insertarNuevo(user);

                service.armarCorreo(user.Email, "Bienvenido/a", "Te damos la bienvenida a Nicocza Store");
                service.enviarEmail();

                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}