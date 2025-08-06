using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices;
using System.Web.Services.Discovery;
using System.Globalization;
using Control;
using Model;

namespace AppFinal
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (!IsPostBack)
                {
                    txtId.Enabled = false;
                    cargarListasDDL();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
                //Redireccion a pantalla de error...
            }

            if (Request.QueryString["Id"] != null)
            {
                int Id = int.Parse(Request.QueryString["Id"].ToString());
                List<Articulo> temporal = (List<Articulo>)Session["ListaArticulos"];
                Articulo seleccionado = temporal.Find(x => x.Id == Id);
                txtId.Text = seleccionado.Id.ToString();
                txtCodigo.Text = seleccionado.Codigo;
                txtNombre.Text = seleccionado.Nombre;
                ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                txtDescripcion.Text = seleccionado.Descripcion;
                txtURLImagen.Text = seleccionado.UrlImagen;
                txtPrecio.Text = seleccionado.Precio.ToString("N2", CultureInfo.GetCultureInfo("es-AR"));
            }
        }

        private void cargarListasDDL()
        {
            MarcaCategoria marcaNegocio = new MarcaCategoria();
            ddlMarca.DataSource = marcaNegocio.obtenerMarcas();
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataBind();

            MarcaCategoria categoriaNegocio = new MarcaCategoria();
            ddlCategoria.DataSource = categoriaNegocio.obtenerCategorias();
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo art = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                art.Codigo = txtCodigo.Text;
                art.Nombre = txtNombre.Text;
                art.Marca = new Marca();
                art.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                art.Categoria = new Categoria();
                art.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                art.Descripcion = txtDescripcion.Text;
                art.UrlImagen = txtURLImagen.Text;
                art.Precio = decimal.Parse(txtPrecio.Text.ToString());

                ((List<Articulo>)Session["ListaArticulos"]).Add(art);

                negocio.agregarSP(art);
                Response.Redirect("Gestion.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void txtURLImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtURLImagen.Text;
        }
    }
}