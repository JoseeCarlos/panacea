using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Model;
using Oracle.DataAccess.Client;

namespace Implemetation
{
    public class ProductoImpl : ProductoDao
    {
        UsuarioImpl impl = new UsuarioImpl(); 
        public int delete(Productos t)
        {
            throw new NotImplementedException();
        }

        public Productos Get(int id)
        {
            Productos a = null;
            string query = @"SELECT idproducto,nombreProducto,precio,descripcion,foto,stock,idCategoria,fechaVencimiento,presentacion,idUsuario,estado,fechaCreacion,fechaActualizacion,idProveedor
                             FROM producto
                             WHERE idproducto=:idproducto";
            OracleDataReader dr = null;
            OracleCommand cmd = null;
            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo GET en Producto Model", DateTime.Now));
                cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":idproducto", id);
                dr = DBImplementation2.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    a = new Productos(int.Parse(dr[0].ToString()), dr[1].ToString(),double.Parse(dr[2].ToString()), dr[3].ToString(),byte.Parse(dr[4].ToString()),int.Parse(dr[5].ToString()),int.Parse(dr[6].ToString()),DateTime.Parse(dr[7].ToString()),dr[8].ToString(),int.Parse(dr[9].ToString()),byte.Parse(dr[10].ToString()),DateTime.Parse(dr[11].ToString()),DateTime.Parse(dr[12].ToString()),int.Parse(dr[13].ToString()));
                }
            }
            catch (Exception ex)
            {

                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error  {1},Excepcion ", DateTime.Now, ex.Message));
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }
            return a;
        }

        public int getIndentity()
        {
            try
            {
                return DBImplementation2.GetIdentityFromTable("producto","idproducto");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int insert(Productos t)
        {
            string query = @"INSERT INTO producto(nombreProducto,precio,descripcion,foto,stock,idCategoria,fechaVencimiento,presentacion,idUsuario,idProveedor,fechaActualizacion)
                            VALUES(:nombreProducto, :precio, :descripcion, :foto, :stock, :idCategoria, :fechaVencimiento, :presentacion, :idUsuario, :idProveedor, CURRENT_TIMESTAMP)";


            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo insert en Producto Model", DateTime.Now));

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add("@nombreProducto", t.NombreProducto);
                cmd.Parameters.Add("@precio", t.Precio);
                cmd.Parameters.Add("@descripcion", t.Descripcion);
                cmd.Parameters.Add("@foto", t.Foto);
                cmd.Parameters.Add("@stock", t.Stock);
                cmd.Parameters.Add("@idCategoria", t.IdCategoria);
                cmd.Parameters.Add("@fechaVencimiento", t.FechaVencimiento);
                cmd.Parameters.Add("@presentacion", t.Presentacion);
                cmd.Parameters.Add("@idUsuario", t.Idusuario);
                cmd.Parameters.Add("@idProveedor", t.Idproveedor);


                int res = DBImplementation2.ExecuteBasicCommand(cmd);
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Producto Insertado con Exito en ProdutoModel", DateTime.Now));
                return res;
            }
            catch (Exception ex)
            {

                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error en Metodo Inser de ProductoModel,{1} Exeception:", DateTime.Now,ex.Message));
                throw ex;
            }
        }

        public DataTable SearchProduct(string nom)
        {
            string query = @"SELECT P.idproducto,P.nombreProducto as Producto,P.precio as Precio,P.stock as Cantidad, P.fechaVencimiento as vencimiento,C.nombreCategoria AS CATEGORIA,PR.nombreProveedor AS PROVEDOR FROM producto P
                              INNER JOIN categoria C ON C.idCategoria=P.idCategoria
                              INNER JOIN proveedor PR ON PR.idProveedor=P.idProveedor
                              WHERE C.nombreCategoria LIKE :text OR P.nombreProducto LIKE :text OR PR.nombreProveedor LIKE :text";
            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo SelectShearchProducto en Producto Model", DateTime.Now));
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":text", "%" + nom + "%");

                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error en Metodo SelectSeachr de ProductoModel,{1} Exeception:", DateTime.Now, ex.Message));
                throw ex;
            }
        }

        public DataTable select()
        {
            throw new NotImplementedException();
        }

        public DataTable selectfoto(int id)
        {
            string query = @"SELECT foto FROM producto WHERE idproducto=:idproducto";
            try
            {

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":idproducto", id);

                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable SlectIdnom(int id)
        {
            string query = @"SELECT idproducto,nombreProducto,precio FROM producto WHERE idproducto=:idproducto ";
            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo SelectIdnom en Producto Model", DateTime.Now));
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":idproducto", id);

                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error en Metodo SelectIdnom de ProductoModel,{1} Exeception:", DateTime.Now, ex.Message));
                throw;
            }
        }

        public DataTable productoDetalle(int id )
        {
            string query = @"SELECT P.IDPRODUCTO as IDPRODUCTO, P.NOMBREPRODUCTO as NOMBREPRODUCTO,VD.CANTIDAD AS CANTIDAD ,VD.PRESIOUNITARIO AS PRECIOUNITARIO FROM PRODUCTO P
                                INNER JOIN VENTADETALLE VD ON VD.IDPRODUCTO=P.IDPRODUCTO
                                WHERE VD.IDVENTAFACTURA=:IDVENTAFACTURA";
            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo SelectIdnom en Producto Model", DateTime.Now));
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":IDVENTAFACTURA", id);

                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error en Metodo SelectIdnom de ProductoModel,{1} Exeception:", DateTime.Now, ex.Message));
                throw;
            }
        }
        public int update(Productos t)
        {
            string query = @"UPDATE producto SET nombreProducto=:nombreProducto, precio=:precio,descripcion=:descripcion,stock=:stock,idCategoria=:idCategoria,fechaVencimiento=:fechaVencimiento,idProveedor=:idProveedor,fechaActualizacion=CURRENT_TIMESTAMP,idUsuario=:idUsuario 
                             WHERE idproducto = :idproducto";


            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Update en Producto Model", DateTime.Now));
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":nombreProducto", t.NombreProducto);
                cmd.Parameters.Add(":precio", t.Precio);
                cmd.Parameters.Add(":descripcion", t.Descripcion);
                cmd.Parameters.Add(":stock", t.Stock);
                cmd.Parameters.Add(":idCategoria", t.IdCategoria);
                cmd.Parameters.Add(":fechaVencimiento", t.FechaVencimiento);
                cmd.Parameters.Add(":idProveedor", t.Idproveedor);
                cmd.Parameters.Add(":idUsuario", Session.SessionId);
                cmd.Parameters.Add(":idproducto", t.IdProducto);


                int res= DBImplementation2.ExecuteBasicCommand(cmd);
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Modificacion Exitosa en ProductoModel", DateTime.Now));
                return res;
            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error en el Metodo Update de ProductoModel,{1} Exeception", DateTime.Now,ex.Message));
                throw ex;
            }
        }

        public void updatepro(List<Productos> producto)
        {
            string query = @"UPDATE producto SET stock=stock-:stock  WHERE idproducto=:idproducto";


            try
            {

                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Update en Venta", DateTime.Now));

                List<OracleCommand> cmds = DBImplementation2.CreateNBasicCommand(producto.Count);
               
                for (int i = 0; i < cmds.Count; i++)
                {

                    cmds[i].CommandText = query;

                    cmds[i].Parameters.Add(":stock", producto[i].Cantidad); 
                    cmds[i].Parameters.Add(":idproducto", producto[i].IdProducto);
                   
                  
                }
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Modificacion exitosa Realizada", DateTime.Now));
                DBImplementation2.ExecuteNBasicCommand(cmds);

            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error en el Metodo venta ", DateTime.Now));
                throw ex;
            }
        }
    }
}
