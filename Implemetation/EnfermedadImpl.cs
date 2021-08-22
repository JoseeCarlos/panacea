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
    public class EnfermedadImpl : EnfermedadesDao
    {
        public int delete(Enfermedad a)
        {
            string query = "UPDATE enfermedad SET estado=0  WHERE idEnfermedad=@idEnfermedad";

            try
            {
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add("@idEnfermedad", a.Idenfermedad);
                return DBImplementation2.ExecuteBasicCommand(cmd);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int insert(Enfermedad a)
        {
            string query = "INSERT INTO enfermedad(nombre,descripcion,ramaMedica,idUsuario) VALUES(@nombre, @descripcion, @ramaMedica, @idUsuario)";


            try
            {
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add("@nombre", a.Nombre);
                cmd.Parameters.Add("@descripcion", a.Descripcion);
                cmd.Parameters.Add("@ramaMedica", a.Ramamedica);
                cmd.Parameters.Add("@idUsuario", a.Userid);

                return DBImplementation2.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable select()
        {
            string query = "SELECT * FROM enfermedad WHERE estado=1";
            try
            {
               

                OracleDataAdapter adapter = DBImplementation2.executeselect(DBImplementation2.CreateBasicCommand(query));
                DataTable table =new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public int update(Enfermedad a)
        {
            string query = "UPDATE enfermedad SET nombre=@nombre, descripcion=@descripcion, ramaMedica=@ramaMedica, idUsuario=@idUsuario  WHERE idEnfermedad=@idEnfermedad";
            try
            {
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add("@idEnfermedad", a.Idenfermedad);
                cmd.Parameters.Add("@nombre", a.Nombre);
                cmd.Parameters.Add("@descripcion", a.Descripcion);
                cmd.Parameters.Add("@ramaMedica", a.Ramamedica);
                cmd.Parameters.Add("@idUsuario", a.Userid);
                return DBImplementation2.ExecuteBasicCommand(cmd);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
