using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public byte Foto { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }

        public DateTime FechaVencimiento { get; set; }
        public string Presentacion { get; set; }
        public int Idusuario { get; set; }
        public byte Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int Idproveedor { get; set; }

        public int Cantidad { get; set; }



       public Productos()
        {

        }

        public Productos(string nombreProducto, double precio, string descripcion, byte foto, int stock, int idcategoria, DateTime fechaVencimiento, string presentacion, int idusuario, int idproveedor)
        {

            this.NombreProducto = nombreProducto;
            this.Precio = precio;
            this.Descripcion = descripcion;
            this.Foto = foto;
            this.Stock = stock;
            this.IdCategoria = idcategoria;
            this.FechaVencimiento = fechaVencimiento;
            this.Presentacion = presentacion;
            this.Idusuario = idusuario;
            this.Idproveedor = idproveedor;
        }


        public Productos(int idproducto,string nombre,double precio,string descripcion,byte foto,int stock,int idcategoria,DateTime fechaVencimiento,int idproveedor)
        {
            this.IdProducto = idproducto;
            this.NombreProducto = nombre;
            this.Precio = precio;
            this.Descripcion = descripcion;
            this.Foto = foto;
            this.Stock = stock;
            this.IdCategoria = idcategoria;
            this.FechaVencimiento = fechaVencimiento;
           
            this.Idproveedor = idproveedor;
        }

        public Productos(int idProducto, string nombreProducto, double precio, string descripcion, byte foto, int stock, int idCategoria, DateTime fechaVencimiento, string presentacion, int idusuario, byte estado, DateTime fechaCreacion, DateTime fechaActualizacion, int idproveedor)
        {
            this.IdProducto = idProducto;
            this.NombreProducto = nombreProducto;
            this.Precio = precio;
            this.Descripcion = descripcion;
            this.Foto = foto;
            this.Stock = stock;
            this.IdCategoria = idCategoria;
            this.FechaVencimiento = fechaVencimiento;
            this.Presentacion = presentacion;
            this.Idusuario = idusuario;
            this.Estado = estado;
            this.FechaCreacion = fechaCreacion;
            this.FechaActualizacion = fechaActualizacion;
            this.Idproveedor = idproveedor;
        }
       

        public Productos(int IdProducto, string NombreProducto, double Precio, int Cantidad)
        {
            this.IdProducto = IdProducto;
            this.NombreProducto = NombreProducto;
            this.Precio = Precio;
            this.Cantidad = Cantidad;
        }
        public Productos(int IdProducto, int Cantidad)
        {
            this.IdProducto = IdProducto;
            this.Cantidad = Cantidad;
        }
    }
}
