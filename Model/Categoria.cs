using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Categoria
    {

        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public byte Estado { get; set; }

        public Categoria(int idCategoria, string nombreCategoria, byte estado)
        {
           this.IdCategoria = idCategoria;
           this.NombreCategoria = nombreCategoria;
           this.Estado = estado;
        }
    }
}
