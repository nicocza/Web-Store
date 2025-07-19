using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using System.Runtime.Remoting.Messaging;

namespace Control
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, C.Descripcion as Categoria, M.Descripcion as Marca, A.IdMarca, A.IdCategoria, A.Id FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE C.Id = A.IdCategoria And M.Id = A.IdMarca");
                datos.ejecutarLectura();
               
                while(datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los artículos de la base de datos.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria, ImagenUrl) VALUES ('"+nuevo.Codigo+"','"+nuevo.Nombre+"', '"+nuevo.Descripcion+"', '"+nuevo.Precio+"', @idMarca, @idCategoria, @ImagenUrl)");
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", nuevo.UrlImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update ARTICULOS Set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, IdMarca = @idmarca, IdCategoria = @idcategoria, IMagenUrl = @imagenUrl Where Id = @id");
                datos.setearParametro("@codigo", art.Codigo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("@precio", art.Precio);
                datos.setearParametro("@idMarca", art.Marca.Id);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
                datos.setearParametro("@imagenUrl", art.UrlImagen);
                datos.setearParametro("@id", art.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el artículo en la base de datos.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("Delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca, m.Descripcion AS Marca, a.IdCategoria, c.Descripcion AS Categoria, a.Precio, a.ImagenUrl FROM Articulos a JOIN Marcas m ON a.IdMarca = m.Id JOIN Categorias c ON a.IdCategoria = c.Id AND ";
                switch (campo)
                {
                    case "Codigo":
                        switch(criterio)
                        {
                            case "Comienza con":
                                consulta += "a.Codigo LIKE'" + filtro + "%' ";
                                break;
                            case "Termina con ":
                                consulta += "a.Codigo LIKE '%" + filtro + "'";
                                break;
                                default:
                                consulta += "a.Codigo LIKE '%" + filtro + "%' ";
                                break;

                        }    
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "a.Nombre LIKE'" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "a.Nombre LIKE '%" + filtro + "'";
                                break;
                            default:
                                consulta += "a.Nombre LIKE '%" + filtro + "%' ";
                                break;
                        }
                        break;
                    case "Descripcion":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "a.Descripcion LIKE'" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "a.Descripcion LIKE '%" + filtro + "'";
                                break;
                            default:
                                consulta += "a.Descripcion LIKE '%" + filtro + "%' ";
                                break;
                        }
                        break;
                    default:
                        throw new Exception("No se reconoce el campo de búsqueda.");

                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar los artículos en la base de datos.", ex);
            }
        }
    }
}
