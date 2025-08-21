using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string URLImagenPerfil { get; set; }
        public bool Admin { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Usuario(string email, string pass, bool admin)
        {
            Email = email;
            Pass = pass;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
    }
}
