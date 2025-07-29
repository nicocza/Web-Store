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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ListaArticulos"] ==  null)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("ListaArticulos", negocio.listar());
            }

            if (!IsPostBack)
            {
                Repetidor.DataSource = Session["ListaArticulos"];
                Repetidor.DataBind();
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}