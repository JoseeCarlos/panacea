using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class pais
    {
        public int Idpais { get; set; }
        public  string NombrePais { get; set; }
        public byte Estado { get; set; }

        public pais(int idpais,string nombrepais,byte estado)
        {
            this.Idpais = idpais;
            this.NombrePais = nombrepais;
            this.Estado = estado;
        }
        public pais(string nombrepais)
        {
            this.NombrePais = nombrepais;
        }
    }
}
