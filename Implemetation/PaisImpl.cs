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
    
     public class PaisImpl : PaisDao
    {
        UsuarioImpl impl = new UsuarioImpl();
        public int delete(pais t)
        {
            throw new NotImplementedException();
        }

        public int insert(pais t)
        {
            throw new NotImplementedException();
        }

        public DataTable select()
        {
            throw new NotImplementedException();
        }

        public DataTable SelectIdName()
        {

            string query = @"SELECT idpais,nombrePais FROM pais WHERE estado=1";
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

        public int update(pais t)
        {
            throw new NotImplementedException();
        }
    }
}
