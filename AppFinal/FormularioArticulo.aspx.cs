using Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.EnterpriseServices;
using System.Web.Services.Discovery;

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
                    cargarListasDDL();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (Request.QueryString["Id"] != null)
            {
                int Id = int.Parse(Request.QueryString["Id"].ToString());
                List<Articulo> temporal = (List<Articulo>)Session["ListaArticulos"];
                Articulo seleccionado = temporal.Find(x =>  x.Id == Id);
                txtId.Text = seleccionado.Id.ToString();
                txtId.ReadOnly = true;
                txtCodigo.Text = seleccionado.Codigo;
                txtNombre.Text = seleccionado.Nombre;
                //MARCA...
                //CATEGORIA...
                txtDescripcion.Text = seleccionado.Descripcion;
                txtURLImagen.Text = seleccionado.UrlImagen;
                txtPrecio.Text = seleccionado.Precio.ToString();

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
            ddlCategoria.DataValueField= "Id";
            ddlCategoria.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo art = new Articulo();
            art.Id = int.Parse(txtId.Text);
            art.Codigo = txtCodigo.Text;
            art.Nombre = txtNombre.Text;
            //art.Marca = ddlMarca.SelectedValue;
            //art.Categoria = ddlCategoria.SelectedValue;
            art.Descripcion = txtDescripcion.Text;
            art.UrlImagen = txtURLImagen.Text;
            art.Precio = decimal.Parse(txtPrecio.Text);

            if (rbtnActivo.Checked)
                art.Activo = true;
            else art.Activo = false;

            //Llamo a la base de datos mediante algun metodo...

            ((List<Articulo>)Session["ListaArticulos"]).Add(art);

            Response.Redirect("Gestion.aspx");
        }
    }
}