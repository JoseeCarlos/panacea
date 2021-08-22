using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Dosificacion
    {
        public int IdDosificacion { get; set; }
        public string NroAutorizacion { get; set; }
        public DateTime FechaLimite { get; set; }
        public string LlaveDosificacion { get; set; }
        public int NroInicialFactura { get; set; }
        public int NroFinalFactura { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public Dosificacion(int idDosificacion, string nroAutorizacion, DateTime fechaLimite, string llaveDosificacion, int nroInicialFactura, int nroFinalFactura, string estado, DateTime fechaRegistro, DateTime fechaActualizacion)
        {
            this.IdDosificacion = idDosificacion;
            this.NroAutorizacion = nroAutorizacion;
            this.FechaLimite = fechaLimite;
            this.LlaveDosificacion = llaveDosificacion;
            this.NroInicialFactura = nroInicialFactura;
            this.NroFinalFactura = nroFinalFactura;
            this.Estado = estado;
            this.FechaRegistro = fechaRegistro;
            this.FechaActualizacion = fechaActualizacion;
        }

        public Dosificacion(int idDosificacion, string nroAutorizacion, string llaveDosificacion)
        {
            this.IdDosificacion = idDosificacion;
            this.NroAutorizacion = nroAutorizacion;
            this.LlaveDosificacion = llaveDosificacion;
           
        }
        public Dosificacion()
        {

        }
        public Dosificacion( string nroAutorizacion, DateTime fechaLimite, string llaveDosificacion)
        {
           
            this.NroAutorizacion = nroAutorizacion;
            this.FechaLimite = fechaLimite;
            this.LlaveDosificacion = llaveDosificacion;
            
        }
    }
}
