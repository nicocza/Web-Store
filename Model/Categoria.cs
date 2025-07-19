using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
