using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FacturaAnulada
    {
        public int IdFacturaAnulada { get; set; }
        public int IdVentaFactura { get; set; }
        public string Motivo { get; set; }
        public byte Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public FacturaAnulada()
        {

        }

        public FacturaAnulada(int idFacturaAnulada, int idVentaFactura, string motivo, byte estado, DateTime fechaRegistro, DateTime fechaActualizacion)
        {
            IdFacturaAnulada = idFacturaAnulada;
            IdVentaFactura = idVentaFactura;
            Motivo = motivo;
            Estado = estado;
            FechaRegistro = fechaRegistro;
            FechaActualizacion = fechaActualizacion;
        }

        public FacturaAnulada( int idVentaFactura, string motivo)
        {
           
            IdVentaFactura = idVentaFactura;
            Motivo = motivo;
          
        }
    }
}
