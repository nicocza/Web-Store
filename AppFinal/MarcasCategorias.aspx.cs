using Control;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppFinal
{
    public partial class MarcasCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                Marca nueva = new Marca();
                MarcaCategoria negocio = new MarcaCategoria();
                nueva.Descripcion = txtAgregarMarca.Text;

                negocio.agregarMarcaSP(nueva);
                Response.Redirect("MarcasCategorias.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria nueva = new Categoria();
                MarcaCategoria negocio = new MarcaCategoria();
                nueva.Descripcion = txtAgregarCategoria.Text;

                negocio.agregarCategoriaSP(nueva);
                Response.Redirect("MarcasCategorias.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void btnEliminarMarca_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminarCategoria_Click(object sender, EventArgs e)
        {

        }
    }
}