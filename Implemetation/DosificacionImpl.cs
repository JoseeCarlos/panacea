using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dao;
using System.Data;
using Oracle.DataAccess.Client;

namespace Implemetation
{
    public class DosificacionImpl : DosificacionDao
    {
        public int delete(Dosificacion t)
        {
            throw new NotImplementedException();
        }

        public Dosificacion GetSelect()
        {
            Dosificacion a = null;
            string query = @"SELECT iddosificacion, nroautorizacion, llavedosificacion 
                             FROM DOSIFICACION
                                WHERE estado=1";

            System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del GetFull en UsuarioModel, {1} Id Usuario", DateTime.Now, Session.SessionId));
            OracleDataReader dr = null;
            OracleCommand cmd = null;
            try
            {

                cmd = DBImplementation2.CreateBasicCommand(query);
                dr = DBImplementation2.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    a = new Dosificacion(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString());
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Error en Metodo GetFull UsuarioModel, {1} Id Usuario,{2} Exception", DateTime.Now, Session.SessionId, ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }
            return a;
        }

        public int insert(Dosificacion t)
        {
            throw new NotImplementedException();
        }

        public void InsertTransac(Dosificacion d)
        {
            string queryDosificacion = @"UPDATE Dosificacion D SET D.estado = 0, D.nroFinalFactura = (SELECT MAX(nroFactura) FROM ventaFactura WHERE D.idDosificacion = idDosificacion), D.fechaActualizacion = CURRENT_TIMESTAMP
                                             WHERE D.idDosificacion=(SELECT MAX(idDosificacion) FROM Dosificacion)";

            string queryInsert = @"alter SEQUENCE SEQ_NUM_FACTURA RESTART START WITH 1";

            string queryInsertDosificacion = @"INSERT INTO Dosificacion (nroAutorizacion, fechalimite, llaveDosificacion)
                                    VALUES(:nroAutorizacion, :fechalimite, :llaveDosificacion)";

            try
            {

                List<OracleCommand> cmds = DBImplementation2.CreateNBasicCommand(3);
                int idDosificacion = DBImplementation2.GetIdentityFromTable2("DOCIFICACION");

                cmds[0].CommandText = queryDosificacion;

                cmds[1].CommandText = queryInsertDosificacion;
                cmds[1].Parameters.Add(":nroAutorizacion", d.NroAutorizacion);
                cmds[1].Parameters.Add(":fechalimite", d.FechaLimite);
                cmds[1].Parameters.Add(":llaveDosificacion", d.LlaveDosificacion);

                cmds[2].CommandText = queryInsert;
                

                DBImplementation2.ExecuteNBasicCommand(cmds);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public int NumFactura()
        {
            string query = @"SELECT LAST_NUMBER FROM user_sequences WHERE sequence_name = 'SEQ_NUM_FACTURA'";
            try
            {
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                return int.Parse(DBImplementation2.ExecuteScalarCommand(cmd));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable select()
        {
            string query = @"SELECT IDDOSIFICACION, NROAUTORIZACION,FECHALIMITE, LLAVEDOSIFICACION FROM DOSIFICACION 
                              WHERE ESTADO = 1";
            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Select en Venta", DateTime.Now));


                OracleDataAdapter adapter = DBImplementation2.executeselect(DBImplementation2.CreateBasicCommand(query));
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}, User ID: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }

        public DataTable selectDosificacion(int id)
        {
            string query = @"SELECT D.NROAUTORIZACION,FECHALIMITE 
                             FROM DOSIFICACION D
                             INNER JOIN VENTAFACTURA V ON V.IDDOSIFICACION=D.IDDOSIFICACION
                              WHERE IDVENTAFACTURA=:IDVENTAFACTURA";
            try
            {
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":idventafactura", id);


                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Error: {1}, User ID: {2}", DateTime.Now, ex.Message, Session.SessionId));
                throw ex;
            }
        }

        public int update(Dosificacion t)
        {
            throw new NotImplementedException();
        }
    }
}
