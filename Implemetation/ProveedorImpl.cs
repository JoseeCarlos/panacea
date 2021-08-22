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
    public class ProveedorImpl : ProveedorDao
    {
        UsuarioImpl impl = new UsuarioImpl();
        public int delete(Proveedor t)
        {
            string query = @"UPDATE proveedor SET estado=0 ,usuarioId=:usuarioId,fechaActualizacion=CURRENT_TIMESTAMP 
                            WHERE idProveedor = :idProveedor";


            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Deshabilitar en Proveedor", DateTime.Now));

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);

                cmd.Parameters.Add(":idProveedor", t.Idproveedor);
                cmd.Parameters.Add(":usuarioId", t.UsuarioId);



                int res= DBImplementation2.ExecuteBasicCommand(cmd);
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Eliminacion Exitosa en provedorModel,Objeto {1},user Id: {2}", DateTime.Now, t.VIEWINFO(), Session.SessionId));
                return res;
            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1},Objeto Enviado: {2}, User ID: {3}", DateTime.Now, ex.Message, t.VIEWINFO(), Session.SessionId));
                throw ex;
            }
        }

        public Proveedor get(int id)
        {
            Proveedor a = null;
            string query = @"SELECT idProveedor,nombreProveedor,telefono,direccion,latitud,longitud,idCiudad,usuarioId 
                          FROM proveedor
                          WHERE idProveedor=:idProveedor ";


            OracleDataReader dr = null;
            OracleCommand cmd = null;
            try
            {
                cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":idProveedor", id);
                dr = DBImplementation2.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    a = new Proveedor(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),double.Parse(dr[4].ToString()),double.Parse(dr[5].ToString()),int.Parse(dr[6].ToString()),int.Parse(dr[7].ToString()));
                }
            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1},Excepcion:", DateTime.Now, ex.Message));
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }
            return a;
        }

        public int insert(Proveedor t)
        {
            string query = @"INSERT INTO proveedor(nombreProveedor,telefono,direccion,latitud,longitud,idCiudad,usuarioId) 
                            VALUES(:nombreProveedor, :telefono, :direccion, :latitud, :longitud, :idCiudad, :usuarioId)";


            try
            {

                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo insert en Proveedor", DateTime.Now));

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":nombreProveedor", t.Nombreproveedor);
                cmd.Parameters.Add(":telefono", t.Telefono);
                cmd.Parameters.Add(":direccion", t.Direccion);
                cmd.Parameters.Add(":latitud", t.Latitud);
                cmd.Parameters.Add(":longitud", t.Longitud);
                cmd.Parameters.Add(":idCiudad", t.Idciudad);
                cmd.Parameters.Add(":usuarioId", t.UsuarioId);
               



                int res= DBImplementation2.ExecuteBasicCommand(cmd);
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Insercion Exitosa en provedorModel,Objeto {1},user Id: {2}", DateTime.Now,t.VIEWINFO(),Session.SessionId));
                return res;
            }
            catch (Exception ex)
            {

                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1},Objeto Enviado: {2}, User ID: {3}", DateTime.Now,ex.Message,t.VIEWINFO(),Session.SessionId));
                throw ex;
            }
        }

        public DataTable select()
        {
            string query = "SELECT * FROM proveedor ";
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
                Debug.WriteLine(string.Format("{0} Error: {1}Excepcion, User ID: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }

        public DataTable SelectIdName()
        {
            string query = @"SELECT idProveedor,nombreProveedor FROM proveedor WHERE estado=1";
            try
            {

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);


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

        public int update(Proveedor t)
        {
            string query = @"UPDATE proveedor SET nombreProveedor=:nombreProveedor,telefono=:telefono,direccion=:direccion,latitud=:latitud,longitud=:longitud,idCiudad=:idCiudad,fechaActualizacion=CURRENT_TIMESTAMP,usuarioId=:usuarioId 
                               WHERE idProveedor = :idProveedor";


            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Update en Proveedor", DateTime.Now));

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":nombreProveedor", t.Nombreproveedor);
                cmd.Parameters.Add(":telefono", t.Telefono);
                cmd.Parameters.Add(":direccion", t.Direccion);
                cmd.Parameters.Add(":latitud", t.Latitud);
                cmd.Parameters.Add(":longitud", t.Longitud);
                cmd.Parameters.Add(":idCiudad", t.Idciudad);
                cmd.Parameters.Add(":usuarioId", t.UsuarioId);
                cmd.Parameters.Add(":idProveedor", t.Idproveedor);



                int res= DBImplementation2.ExecuteBasicCommand(cmd);
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Modificacion Exitosa en ProvedorModelObjeto {1},user Id: {2}", DateTime.Now, t.VIEWINFO(), Session.SessionId));
                return res;
            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error  {1},Excepcion ", DateTime.Now, ex.Message));
                throw ex;
            }
        }
    }
}
