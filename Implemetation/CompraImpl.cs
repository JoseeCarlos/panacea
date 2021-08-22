using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dao;
using System.Data;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using System.Diagnostics;

namespace Implemetation
{
    public class CompraImpl : CompraDao
    {
        UsuarioImpl impl = new UsuarioImpl();
        public int delete(Compra t)
        {
            string query = @"UPDATE venta SET estado=0 WHERE Idcompra=@Idcompra";


            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo delete en Venta Model", DateTime.Now));
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add("@Idcompra", t.IdCompra);



                int res = DBImplementation2.ExecuteBasicCommand(cmd);
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Eliminacion Exitosa en Venta Model,{1} Id de la venta", DateTime.Now,t.IdCliente));
                return res;
            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error en el Metodo Update de VentaModel,{1} Exeception", DateTime.Now, ex.Message));
                throw ex;
            }
        }

        public int insert(Compra t)
        {
            throw new NotImplementedException();
        }

        public void Insert2(Compra c, List<Productos> p)
        {
            string query = @"INSERT INTO ventaFactura (Idcliente,idUsuario,nit,razonSocial,fecha,total,iddosificacion,codigocontrol,fechaActualizacion)
                             VALUES(:Idcliente,:idUsuario,:nit,:razonSocial,:fecha,:total,:iddosificacion,:codigocontrol, CURRENT_TIMESTAMP)";

            string query2 = @"INSERT INTO ventaDetalle(idVentaFactura,idProducto,cantidad,presioUnitario,descripcion)
                            VALUES(:idVentaFactura, :idProducto, :cantidad, :precioUnitario,:descripcion)";

            

            try
            {

                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo insert en Venta", DateTime.Now));

                List< OracleCommand> cmds = DBImplementation2.CreateNBasicCommand(1+p.Count);
                int id = DBImplementation2.GetIdentityFromTable2("VENTAFACTURA")+1;

                for (int i = 0; i < cmds.Count; i++)
                {
                    if (i==0)
                    {
                        cmds[i].CommandText = query;
                        cmds[i].Parameters.Add(":Idcliente", c.IdCliente);
                        cmds[i].Parameters.Add(":idUsuario", c.IdUsuario);
                        cmds[i].Parameters.Add(":nit", c.Nit);
                        cmds[i].Parameters.Add(":razonSocial", c.RazonSocial);
                        cmds[i].Parameters.Add(":fecha", c.Fecha);
                        cmds[i].Parameters.Add(":total", c.Total);
                        cmds[i].Parameters.Add(":iddosificacion", c.IdDosificacion);
                        cmds[i].Parameters.Add(":codigocontrol", c.CodigoControl);
                        

                    }
                    else
                    {
                        cmds[i].CommandText = query2;
                        cmds[i].Parameters.Add(":idVentaFactura", id);
                        cmds[i].Parameters.Add(":idProducto", p[i - 1].IdProducto);
                        cmds[i].Parameters.Add(":cantidad", p[i - 1].Cantidad);
                        cmds[i].Parameters.Add(":precioUnitario", p[i - 1].Precio);
                        cmds[i].Parameters.Add(":descripcion", p[i - 1].NombreProducto);



                    }
                }






                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Venta Exitosa Realizada,{1}id de venta", DateTime.Now,c.IdCompra));
                DBImplementation2.ExecuteNBasicCommand(cmds);
              
               
            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error en el Metodo venta ,{1} Exception", DateTime.Now,ex.Message));
                throw ex;
            }
        }

        public DataTable select()
        {
            string query = @"SELECT V.IDVENTAFACTURA,V.NROFACTURA,V.NIT,V.RAZONSOCIAL,V.FECHA,V.TOTAL 
                            FROM VENTAFACTURA V
                            WHERE V.ESTADO='V'
                            ORDER BY V.FECHA ";
            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Select en Venta", DateTime.Now));


                OracleDataAdapter adapter = DBImplementation2.executeselect(DBImplementation2.CreateBasicCommand(query));
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;


            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1}, User ID: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }

        public DataTable selectDadoBaja()
        {
            string query = "SELECT C.Idcompra,CL.nombre,U.nombre,C.fecha,total,D.cantidad,D.precioUnitario FROM venta C INNER JOIN ventaDetalle D ON D.idCompra = C.Idcompra INNER JOIN Cliente CL ON CL.IdCliente = C.Idcliente INNER JOIN usuario U ON U.idUsuario = C.idUsuario WHERE C.estado=0";
            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Select en Proveedor", DateTime.Now));


                OracleDataAdapter adapter = DBImplementation2.executeselect(DBImplementation2.CreateBasicCommand(query));
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1}, User ID: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }

        public DataTable selectdelete()
        {
            string query = "SELECT C.Idcompra,CL.nombre,U.nombre,C.fecha,total,D.cantidad,D.precioUnitario FROM venta C INNER JOIN ventaDetalle D ON D.idCompra = C.Idcompra INNER JOIN Cliente CL ON CL.IdCliente = C.Idcliente INNER JOIN usuario U ON U.idUsuario = C.idUsuario WHERE C.habilitado=0";
            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Select en Proveedor", DateTime.Now));


                OracleDataAdapter adapter = DBImplementation2.executeselect(DBImplementation2.CreateBasicCommand(query));
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1}, User ID: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }

        public DataTable serachDate(string f1, string f2)
        {

            string query = @"SELECT * FROM venta WHERE fecha BETWEEN @fecha1 AND @fecha2";
            try
            {

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add("@fecha1", f1+" "+ "00:00:00");
                cmd.Parameters.Add("@fecha2", f2+" "+ "23:59:59");

                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable serachNum(int num)
        {

            string query = @"SELECT V.idventaFactura,V.nrofactura, V.fecha, V.total, V.razonSocial,V.estado,U.nombreUsuario
                             FROM ventaFactura V
                             INNER JOIN usuario U on U.idusuario=V.idusuario
                            WHERE V.estado='V' AND V.nroFactura=:nroFactura";
            try
            {

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":nroFactura", num);
                

                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public int update(Compra t)
        {
            string query = @"UPDATE venta SET habilitado=0 WHERE Idcompra=@Idcompra";


            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Update en Venta Model", DateTime.Now));
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add("@Idcompra", t.IdCompra);
               


                int res = DBImplementation2.ExecuteBasicCommand(cmd);
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Anulacion Exitosa en VentaModel,{1} Id de la venta", DateTime.Now,t.IdCompra));
                return res;
            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error en el Metodo Update de VentaModel  ,{1} Exeception", DateTime.Now, ex.Message));
                throw ex;
            }
        }
        public DataTable FacturaDatos(int idventa)
        {
            string query = @"SELECT NIT,RAZONSOCIAL,FECHA,TOTAL,NROFACTURA,CODIGOCONTROL
                            FROM VENTAFACTURA
                            WHERE idventafactura=:idventafactura AND ESTADO='V' ";
            try
            {
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":idventafactura", idventa);
                

                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1}, User ID: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }
        public DataTable FacturaDetalles(int idventa)
        {
            string query = @"SELECT DV.cantidad, DV.descripcion, DV.presioUnitario
                            FROM VentaDetalle DV
                            INNER JOIN VentaFactura V ON V.idventafactura = DV.idventafactura
                            WHERE V.estado='V' AND DV.idventafactura = :idventafactura ";
            try
            {
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":idventafactura", idventa);


                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;

            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1}, User ID: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }

        public DataTable vetasGeneral(DateTime time1, DateTime time2)
        {
            string query = @"SELECT NIT,RAZONSOCIAL,NROFACTURA,total,fecha FROM VENTAFACTURA
                                WHERE estado='V' AND fecha BETWEEN :fecha AND :fechas 
                                ORDER BY 4 DESC";
            try
            {
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":fecha", time1.Date);
                cmd.Parameters.Add(":fechas", time2.Date);


                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;

            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1}, User ID: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }

        public DataTable vetasTopProductos(int num)
        {
            string query = @"SELECT DV.descripcion as DESCRIPCION, SUM(DV.cantidad) AS CANTIDAD , dv.preSiounitario AS PRESIOUNITARIO
                                FROM VENTADETALLE DV
                                INNER JOIN VENTAFACTURA V ON V.IDVENTAFACTURA = DV.IDVENTAFACTURA
                                GROUP BY dv.descripcion, dv.preSiounitario
                                ORDER BY 2 DESC FETCH FIRST :num ROWS ONLY";
            try
            {
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":num", num);
                


                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;

            }
            catch (Exception ex)
            {

                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1}, Excepcion: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }
    }
}
