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
    public class ClientesImpl : ClientesDao
    {
        UsuarioImpl impl = new UsuarioImpl();
        public string Cicliente(int id)
        {
            string query = @"SELECT ci FROM cliente
                            WHERE idcliente=:idcliente";
            try
            {
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":idcliente", id);
                return DBImplementation2.ExecuteScalarCommand(cmd).ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int delete(Clientes t)
        {
            throw new NotImplementedException();
        }

        public int insert(Clientes t)
        {
            string query = @"INSERT INTO Cliente(nombre,primerApellido,segundoApellido,ci,idUsuario,fechaActualizacion)
                            VALUES(:nombre, :primerApellido, :segundoApellido, :ci, :idUsuario,CURRENT_TIMESTAMP)";


            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo insert en Cliente", DateTime.Now));

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":nombre", t.Nombre);
                cmd.Parameters.Add(":primerApellido", t.PrimerApellido);
                cmd.Parameters.Add(":segundoApellido", t.SegundoApellido);
                cmd.Parameters.Add(":ci", t.Ci);
                cmd.Parameters.Add(":idUsuario", t.IdUsuario);
               




                int res = DBImplementation2.ExecuteBasicCommand(cmd);
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Cliente Registrado con Exito,{1} Datos", DateTime.Now,t.Nombre+""+t.PrimerApellido));
                return res;
            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1}, User ID: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }

        public DataTable select()
        {
            string query = "SELECT IdCliente , nombre||' '||primerApellido||' '||segundoApellido AS NOMBRE,ci AS CI FROM Cliente WHERE estado=1";
            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Select en ClienteModel", DateTime.Now));


                OracleDataAdapter adapter = DBImplementation2.executeselect(DBImplementation2.CreateBasicCommand(query));
                DataTable table = new DataTable();
                adapter.Fill(table);
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Metodo Select Iniciado con Exito", DateTime.Now));
                return table;


            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Error: {1}, User ID: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }

        public DataTable SelectIdName(string nom)
        {
            string query = @"SELECT IdCliente,nombre||' '||primerApellido||' '||segundoApellido||' ' as nombre, ci FROM Cliente
                               WHERE ci LIKE :nom  AND estado=1";
            try
            {

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":nom", "%"+nom+"%");
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

        public Clientes getnombre(int id)
        {

            Clientes a = null;
            string query = @"SELECT NOMBRE||' '||PRIMERAPELLIDO||' '||SEGUNDOAPELLIDO AS NOMBRE
                            FROM CLIENTE 
                            WHERE IDCLIENTE=:IDCLIENTE";

            impl.Logs();
            Debug.WriteLine(string.Format("{0} Info: Inicio del GetFull en UsuarioModel, {1} Id Usuario", DateTime.Now, Session.SessionId));
            OracleDataReader dr = null;
            OracleCommand cmd = null;
            try
            {

                cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":IDCLIENTE", id);
                dr = DBImplementation2.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    a = new Clientes(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {

                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info: Error en Metodo GetFull UsuarioModel, {1} Id Usuario,{2} Exception", DateTime.Now, Session.SessionId, ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }
            return a;
        }
        public int update(Clientes t)
        {
            throw new NotImplementedException();
        }
    }
}
