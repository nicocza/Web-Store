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
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    cargarListasDDL();

                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                    if (id != "")
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo seleccionado = (negocio.listar(id))[0];

                        txtId.Text = id;
                        txtCodigo.Text = seleccionado.Codigo;
                        txtNombre.Text = seleccionado.Nombre;
                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtURLImagen.Text = seleccionado.UrlImagen;
                        if (!string.IsNullOrEmpty(seleccionado.UrlImagen))
                            imgArticulo.ImageUrl = seleccionado.UrlImagen;
                        txtPrecio.Text = seleccionado.Precio.ToString("N2", CultureInfo.GetCultureInfo("es-AR"));
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
                //Redireccion a pantalla de error...
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
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtURLImagen.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text.ToString());

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"].ToString());
                    negocio.modificarSP(nuevo);
                }
                else
                    negocio.agregarSP(nuevo);

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