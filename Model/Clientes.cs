using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Clientes
    {
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Ci { get; set; }

        public int IdUsuario { get; set; }

        public Clientes()
        {

        }

        public Clientes(string nombre, string primerApellido, string segundoApellido, string ci,int idUsuario)
        {
           this.Nombre = nombre;
           this.PrimerApellido = primerApellido;
           this.SegundoApellido = segundoApellido;
           this.Ci = ci;
           this.IdUsuario = idUsuario;
        }

        public Clientes(string nombre)
        {
            this.Nombre = nombre;
            
        }
    }
}
