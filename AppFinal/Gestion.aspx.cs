using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control;
using Model;

namespace AppFinal
{
    public partial class Gestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("ListaArticulos", negocio.listarSP());
            dgvArticulos.DataSource = Session["ListaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + Id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void btnIrAFormulario_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioArticulo.aspx");
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["ListaArticulos"];
            List<Articulo>listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Codigo.ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Marca.ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()) || x.Categoria.ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource= listaFiltrada;
            dgvArticulos.DataBind();
        }
    }
}