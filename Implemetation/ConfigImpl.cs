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

namespace Implemetation
{
    public class ConfigImpl : ConfigDao
    {
        public DataTable Get()
        {
            string query = "SELECT pathFotoUsuario,pathFotoProducto FROM Configuracion";
            try
            {


                OracleDataAdapter adapter = DBImplementation2.executeselect(DBImplementation2.CreateBasicCommand(query));
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
