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
    public class CategoriaImpl : CategoriaDao
    {
        UsuarioImpl impl = new UsuarioImpl();
        public int delete(Categoria t)
        {
            throw new NotImplementedException();
        }

        public int insert(Categoria t)
        {
            throw new NotImplementedException();
        }

        public DataTable select()
        {
            throw new NotImplementedException();
        }

        public DataTable selectCategoriaId()
        {
            string query = @"SELECT idCategoria,nombreCategoria FROM categoria WHERE estado=1";
            try
            {
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Select en CategoriaModel", DateTime.Now));
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
              

                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                impl.Logs();
                Debug.WriteLine(string.Format("{0} Info:Metodo Select Iniciado Con Exito", DateTime.Now));
                return table;


            }
            catch (Exception ex)
            {
                impl.Erros();
                Debug.WriteLine(string.Format("{0} Info:Error en el Metodo Select ,{1} Exception", DateTime.Now,ex.Message));
                throw ex;
            }
        }

        public int update(Categoria t)
        {
            throw new NotImplementedException();
        }
    }
}
