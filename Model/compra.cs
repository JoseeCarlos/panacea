using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; }
        public DateTime FechachaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public byte Habilitado { get; set; }

        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public int NumeroFactura { get; set; }
        public int IdDosificacion { get; set; }

        public string CodigoControl { get; set; }



        public Compra()
        {

        }

        public Compra(int idCompra, int idCliente, int idUsuario, DateTime fecha, double total, string estado, DateTime fechachaRegistro, DateTime fechaActualizacion,byte habilitado)
        {
            this.IdCompra = idCompra;
            this.IdCliente = idCliente;
            this.IdUsuario = idUsuario;
            this.Fecha = fecha;
            this.Total = total;
            this.Estado = estado;
            this.FechachaRegistro = fechachaRegistro;
            this.FechaActualizacion = fechaActualizacion;
            this.Habilitado = habilitado;
        }

        public Compra(int idcliente, int idusuario, DateTime fecha, double total, string nit, string razonSocial, int idDosificacion, int numeroFactura, string codigoControl)
        {
            this.IdCliente = idcliente;
            this.IdUsuario = idusuario;
            this.Fecha = fecha;
            this.Total = total;
            this.Nit = nit;
            this.RazonSocial = razonSocial;
            this.IdDosificacion = idDosificacion;
            this.NumeroFactura = numeroFactura;
            this.CodigoControl = codigoControl;

        }

        public Compra(int idcompra)
        {
            this.IdCompra = idcompra;
            
        }
    }
}
