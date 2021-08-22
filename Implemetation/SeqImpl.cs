using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;


namespace Implemetation
{
    public class SeqImpl
    {
        public void secuencia()
        {
            try
            {
                string[] secuencia = new string[9] { "SEQ_ID_CATEGORIA", "SEQ_ID_CLIENTE", "SEQ_ID_DOCIFICACION", "SEQ_ID_PAIS", "SEQ_ID_PRODUCTO", "SEQ_ID_PROVEEDOR", "SEQ_ID_USUARIO", "SQ_ID_PAIS", "SEQ_ID_VENTAFACTURA" };
                for (int i = 0; i < 9; i++)
                {
                    string consul = "SELECT " + secuencia[i] + ".NEXTVAL FROM dual";
                    OracleCommand cmd = DBImplementation2.CreateBasicCommand(consul);
                    DBImplementation2.ExecuteDataTableCommand(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
