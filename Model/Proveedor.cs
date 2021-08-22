using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Proveedor
    {
        public int Idproveedor { get; set; }
        public string Nombreproveedor { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int Idciudad { get; set; }
        public byte Foto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public byte Estado { get; set; }
        public int UsuarioId { get; set; }


        public Proveedor(int idprove,string nombrepro,string telefono,string direccion,double latitud,double longitud,int idciudad,byte foto,DateTime fechacreacion,DateTime fechaactualizacion,byte estado,int usuarioid)
        {
            this.Idproveedor = idprove;
            this.Nombreproveedor = Nombreproveedor;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Latitud = latitud;
            this.Longitud = longitud;
            this.Idciudad = idciudad;
            this.Foto = foto;
            this.FechaCreacion = fechacreacion;
            this.FechaActualizacion = fechaactualizacion;
            this.Estado = estado;
            this.UsuarioId = usuarioid;
        }

        public Proveedor( string nombrepro, string telefono, string direccion, double latitud, double longitud, int idciudad,  int usuarioid)
        {
            
            this.Nombreproveedor = nombrepro;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Latitud = latitud;
            this.Longitud = longitud;
            this.Idciudad = idciudad;
            this.UsuarioId = usuarioid;
        }
        public Proveedor(int idproveedor,string nombrepro, string telefono, string direccion, double latitud, double longitud, int idciudad, int usuarioid)
        {
            this.Idproveedor = idproveedor;
            this.Nombreproveedor = nombrepro;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Latitud = latitud;
            this.Longitud = longitud;
            this.Idciudad = idciudad;
            this.UsuarioId = usuarioid;
        }

        public string VIEWINFO()
        {
            return Nombreproveedor + " " + Telefono;
        }




    }
}
