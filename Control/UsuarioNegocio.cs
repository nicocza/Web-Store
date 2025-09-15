using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Control
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS Where email = @email And pass = @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.TipoUsuario = Convert.ToBoolean(datos.Lector["admin"]) == true ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    return true;
                }
                return false;
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
    }
}
