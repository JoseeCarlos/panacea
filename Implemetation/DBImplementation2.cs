    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace Implemetation
{
    public class DBImplementation2
    {
        public static string connectionString = "DATA SOURCE = xe; PASSWORD=panacea; USER ID=panacea";

        #region Commands 
        public static OracleCommand CreateBasicCommand()
        {
            OracleConnection connection = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connection;
            return cmd;
        }

        public static OracleCommand CreateBasicCommand(string query)
        {
            OracleConnection connection = new OracleConnection(connectionString);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;
            return cmd;
        }

        public static List<OracleCommand> CreateNBasicCommand(int n)
        {
            List<OracleCommand> res = new List<OracleCommand>();
            OracleConnection connection = new OracleConnection(connectionString);

            for (int i = 0; i < n; i++)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = connection;
                res.Add(cmd);
            }


            return res;
        }

        #endregion

        #region  Commands Execute
        public static int ExecuteBasicCommand(OracleCommand cmd)
        {
            int res = -1;
            try
            {
                cmd.Connection.Open();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return res;
        }

        public static void ExecuteNBasicCommand(List<OracleCommand> cmds)
        {
            OracleTransaction tran = null;
            OracleCommand cmd1 = cmds[0];
            try
            {

                cmd1.Connection.Open();
                tran = cmd1.Connection.BeginTransaction();

                foreach (OracleCommand item in cmds)
                {
                    item.Transaction = tran;
                    item.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                cmd1.Connection.Close();
            }
        }

        public static DataTable ExecuteDataTableCommand(OracleCommand cmd)
        {
            DataTable res = new DataTable();
            try
            {
                cmd.Connection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                adapter.Fill(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return res;
        }
        /// <summary>
        /// OJO la conexion debe cerrarse una vez llamado al método
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static OracleDataReader ExecuteDataReaderCommand(OracleCommand cmd)
        {

            OracleDataReader res = null;
            try
            {
                cmd.Connection.Open();
                res = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }

        public static OracleDataAdapter executeselect(OracleCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                return adapter;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static string ExecuteScalarCommand(OracleCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        public static int GetIdentityFromTable(string tabla,string id)
        {
            string query = "SELECT MAX("+id+")+1 FROM "+tabla;
            try
            {
                OracleCommand cmd = CreateBasicCommand(query);
                return int.Parse(ExecuteScalarCommand(cmd));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static int GetIdentityFromTable2(string tabla)
        {
            string query = "SELECT SEQ_ID_"+tabla.ToUpper()+".CURRVAL FROM dual";
            try
            {
                OracleCommand cmd = CreateBasicCommand(query);
                return int.Parse(ExecuteScalarCommand(cmd));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

    }
}
