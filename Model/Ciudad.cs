using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ciudad
    {
        public int Idciudad { get; set; }
        public string NombreCiudad { get; set; }
        public int Idpais { get; set; }
        public byte Estado { get; set; }

        public Ciudad(int idciudad, string nombreciudad, int idpais, byte estado)
        {
            this.Idciudad = idciudad;
            this.NombreCiudad = nombreciudad;
            this.Idpais = idpais;
            this.Estado = estado;
        } 
    }
}
