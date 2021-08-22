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
    public class UsuarioImpl : UsuarioDao
    {
        public int delete(Usuario t)
        {
            string query = @"UPDATE usuario SET estado=0 ,UsuarioId=:UsuarioId,fechaActualizacion=CURRENT_TIMESTAMP 
                             WHERE idUsuario = :idUsuario";


            try
            {
                Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el Delete en UsuarioModel", DateTime.Now));

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
               
                cmd.Parameters.Add(":UsuarioId", t.UserId);
                cmd.Parameters.Add(":idUsuario", t.IdUsuario);



                int res= DBImplementation2.ExecuteBasicCommand(cmd);
                if (res>0)
                {
                    Logs();
                    Debug.WriteLine(string.Format("{0} Info:Eliminacion de Usuario Exitoso, {1} Id Usuario que realizo la Operacion ", DateTime.Now, Session.SessionId));
                }
                else
                {
                    Erros();
                    Debug.WriteLine(string.Format("{0} Info:Eliminacion de Usuario no realizada, {1} Id Usuario que realizo la Operacion ", DateTime.Now, Session.SessionId));
                }
                return res;
            }
            catch (Exception ex)
            {
                Erros();
                Debug.WriteLine(string.Format("{0} Info: Error, {1} Id Usuario,{2}Exeption: ", DateTime.Now, Session.SessionId,ex.Message));
                throw ex;
            }
        }

        public Usuario get(int id)
        {
            Usuario a = null;
            string query = @"SELECT idUsuario,nombre,primerApellido,segundoApellido,fechaNacimiento,genero,email,role,UsuarioId
                       FROM usuario
                       WHERE idUsuario=:idUsuario ";

            Logs();
            Debug.WriteLine(string.Format("{0} Info: Inicio del GetFull en UsuarioModel, {1} Id Usuario", DateTime.Now, Session.SessionId));
            OracleDataReader dr = null;
            OracleCommand cmd = null;
            try
            {

                cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add("idUsuario",id);
                dr = DBImplementation2.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    a = new Usuario(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),DateTime.Parse(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(),int.Parse(dr[8].ToString()));
                }
            }
            catch (Exception ex)
            {
                Erros();
                Debug.WriteLine(string.Format("{0} Info: Error en Metodo GetFull UsuarioModel, {1} Id Usuario,{2} Exception", DateTime.Now, Session.SessionId,ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }
            return a;
        }

        public int getIndentity()
        {

            try
            {

                return DBImplementation2.GetIdentityFromTable2("USUARIO");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int insert(Usuario t)
        {
            string query = @"INSERT INTO usuario(nombre,primerapellido,segundoapellido,fechanacimiento,genero,email,nombreusuario,password,role,usuarioid)
                            VALUES (:nombre,:primerapellido,:segundoapellido,:fechanacimiento,:genero,:email,:nombreusuario,:password,:role,1)";


            try
            {
                Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo insert en UsuarioMoel", DateTime.Now));


                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                OracleParameter[] parametros = new OracleParameter[]
                {
                    new OracleParameter(":nombre",t.Nombre),
                    new OracleParameter(":primerapellido",t.PriApellido),
                    new OracleParameter(":segundoapellido",t.SeguApellido),
                    new OracleParameter(":fechanacimiento",t.FechaNacimiento),
                    new OracleParameter(":genero",t.Genero),
                    new OracleParameter(":email",t.Email),
                    new OracleParameter(":nombreusuario",t.NombreUsuario),
                    new OracleParameter(":password",t.Password),
                    new OracleParameter(":role",t.Role)

                };

                cmd.Parameters.AddRange(parametros);


                int res = DBImplementation2.ExecuteBasicCommand(cmd);
                if (res>0)
                {
                    Logs();
                    Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo insert en UsuarioMoel", DateTime.Now));
                }
                return res;
            }
            catch (Exception ex)
            {
                Erros();
                Debug.WriteLine(string.Format("{0} Info:Error,{1}Consulta,{2} Exception,{3}Id Usuario.", DateTime.Now,query,ex.Message,Session.SessionId));
                throw ex;
                
            }
        }

        public DataTable Login(string nombreUsuario, string password)
        {
            string query = "SELECT idUsuario,nombreUsuario,password,role,primerInicio,foto FROM usuario WHERE estado = 1 AND nombreUsuario = :nombreUsuario AND password = :password";
            try
            {
                
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Login ", DateTime.Now));
                DataTable dt;
                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":nombreUsuario", nombreUsuario);
                cmd.Parameters.Add(":password", password);
                OracleDataAdapter adapter = DBImplementation2.executeselect(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dt=table;
                if (dt.Rows.Count > 0)
                {
                    
                    Debug.WriteLine(string.Format("{0} Info:Inicio de Session Correcto, {1} Id Usuario que intento Ingresar", DateTime.Now,dt.Rows[0][0].ToString()));
                }
                else
                {
                    
                    Debug.WriteLine(string.Format("{0} Info:Inicio de Session Incorrecto, {1}  Usuario y Cotraseña Utilizados ", DateTime.Now,nombreUsuario+" y "+password));
                }
                return dt;


            }
            catch (Exception ex)
            {
                
                Debug.WriteLine(string.Format("{0} Info:Error , {1} Exception,{2} Consulta ", DateTime.Now, ex.Message,query));
                throw;
            }
        }

        public DataTable select()
        {
            string query = "SELECT * FROM usuario";
            try
            {
                Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el Select en Usuario Model", DateTime.Now));

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);

                DataTable res = DBImplementation2.ExecuteDataTableCommand(cmd);

                if (res.Rows.Count>0)
                {
                    Logs();
                     Debug.WriteLine(string.Format("{0} Info:Select correcto sobre UsuarioModel,{1} Id del Usuario ", DateTime.Now,Session.SessionId));
                }
                else
                {
                    Erros();
                    Debug.WriteLine(string.Format("{0} Info:Select incorrecto sobre UsuarioModel,{1} Id del Usuario ", DateTime.Now, Session.SessionId));
                }
                return res;


            }
            catch (Exception ex)
            {
                Erros();
                Debug.WriteLine(string.Format("{0} Info:Select incorrecto sobre UsuarioModel,{1} Exepcion ", DateTime.Now, ex.Message));
                throw;
            }
        }

        public DataTable selectUsername(string username)
        {
            string query = "SELECT nombreUsuario FROM usuario WHERE nombreUsuario = :nombreUsuario";
            try
            {
                try
                {

                    OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                    cmd.Parameters.Add(":nombreUsuario", username);

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
            catch (Exception ex)
            {
                Erros();
                Debug.WriteLine(string.Format("{0} Info:Select incorrecto sobre UsuarioModel,{1} Excepcion ", DateTime.Now, ex.Message));
                throw;
            }
        }

        public int update(Usuario t)
        {
            string query = @"UPDATE usuario SET nombre=:nombre,primerApellido=:primerApellido,segundoApellido=:segundoApellido,fechaNacimiento=:fechaNacimiento,genero=:genero,email=:email,role=:role,fechaActualizacion=CURRENT_TIMESTAMP,UsuarioId=:UsuarioId 
                            WHERE idUsuario = :idUsuario";


            try
            {
                Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el Update en Usuario Model", DateTime.Now));

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":nombre", t.Nombre);
                cmd.Parameters.Add(":primerApellido", t.PriApellido);
                cmd.Parameters.Add(":segundoApellido", t.SeguApellido);
                cmd.Parameters.Add(":fechaNacimiento", t.FechaNacimiento);
                cmd.Parameters.Add(":genero", t.Genero);
                cmd.Parameters.Add(":email", t.Email);
                cmd.Parameters.Add(":role", t.Role);
                cmd.Parameters.Add(":UsuarioId", t.UserId);
                cmd.Parameters.Add(":idUsuario", t.IdUsuario);

                int res = DBImplementation2.ExecuteBasicCommand(cmd);

                if (res>0)
                {
                    Logs();
                    Debug.WriteLine(string.Format("{0} Info: Modificacion Exitosa,{1} id del Usuario", DateTime.Now,Session.SessionId));
                }
                else
                {
                   Erros();
                   Debug.WriteLine(string.Format("{0} Info:Modificacion no realizada en UsuarioImpl,{1} Id del Usuario", DateTime.Now,Session.SessionId));
                }

                return res;
            }
            catch (Exception ex)
            {
                Erros();
                Debug.WriteLine(string.Format("{0} Info:Update incorrecto sobre UsuarioModel,{1} Id del Usuario,{2}Exception. ", DateTime.Now, Session.SessionId,ex.Message));
                throw ex;
            }
        }

        public int updatePasseord2(int usuarioid, Usuario u, string pas)
        {
            string query = "UPDATE usuario SET password=:password  WHERE idUsuario=:idUsuario AND password=:password";
            try
            {
                Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Cambio de Password en Usuario Model", DateTime.Now));

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
                cmd.Parameters.Add(":idUsuario", usuarioid);
                cmd.Parameters.Add(":password", u.Password);
                cmd.Parameters.Add(":prepas", pas);
                int res = DBImplementation2.ExecuteBasicCommand(cmd);

                if (res>0)
                {
                    Logs();
                    Debug.WriteLine(string.Format("{0} Info:Cambio de password correcto ,{1}Id del usuario que cambio la contraseña", DateTime.Now,Session.SessionId));
                }
                else
                {
                    Erros();
                    Debug.WriteLine(string.Format("{0} Info:Cambio de password incorrecto ,{1}Id del usuario que intento cambiar la contraseña", DateTime.Now, Session.SessionId));
                }
                return res;

            }
            catch (Exception ex)
            {
                Erros();
                Debug.WriteLine(string.Format("{0} Info: Error,{1} Id del Usuario,{2}Exception.,{3} Query", DateTime.Now, Session.SessionId, ex.Message,query));
                throw ex;
            }
        }

        public int updatePassword(int usuarioid, Usuario u)
        {
            string query = @"UPDATE usuario SET password=:password, primerInicio=:primerInicio  
                                WHERE idUsuario=:idUsuario";
            try
            {
                Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Cambio de de Password al Primer Inicio de session en Usuario Model", DateTime.Now));

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
               
                cmd.Parameters.Add(":password", u.Password);
                cmd.Parameters.Add(":primerInicio", u.PrimerInicio);
                cmd.Parameters.Add(":idUsuario", usuarioid);

                int res= DBImplementation2.ExecuteBasicCommand(cmd);
                if (res>0)
                {
                    Logs();
                    Debug.WriteLine(string.Format("{0} Info:Cambio de password correcto ,{1}Id del usuario que cambio la contraseña", DateTime.Now, Session.SessionId));
                }
                else
                {
                    Erros();
                    Debug.WriteLine(string.Format("{0} Info:Cambio de password incorrecto ,{1}Id del usuario que intento cambiar la contraseña", DateTime.Now, Session.SessionId));
                }
                return res;
                   
            }
            catch (Exception ex)
            {
                Erros();
                Debug.WriteLine(string.Format("{0} Info: Error,{1} Id del Usuario,{2}Exception.,{3} Query", DateTime.Now, Session.SessionId, ex.Message, query));
                throw ex;
            }
        }

        public int updateRecuperarPass(string email, string nomuser, Usuario u)
        {
            string query = "UPDATE usuario SET password=:password, primerInicio=:primerInicio  WHERE email=:email AND nombreUsuario=:nombreUsusario";
            try
            {
                Logs();
                Debug.WriteLine(string.Format("{0} Info:Iniciando el metodo Cambio de Recuperacion de Password al Primer Inicio de session en Usuario Model", DateTime.Now));

                OracleCommand cmd = DBImplementation2.CreateBasicCommand(query);
               
                cmd.Parameters.Add(":password", u.Password);  
                cmd.Parameters.Add(":primerInicio", u.PrimerInicio);
                cmd.Parameters.Add(":email", email);
                cmd.Parameters.Add(":nombreUsusario", nomuser);

                int res= DBImplementation2.ExecuteBasicCommand(cmd);
                if (res>0)
                {
                    Logs();
                    Debug.WriteLine(string.Format("{0} Info:Recuperacion  de password correcto ,{1}Correo del Usuario", DateTime.Now,email ));
                }
                else
                {
                    Erros();
                    Debug.WriteLine(string.Format("{0} Info:Recuperacion  de password incorrecto ,{1}Correo del Usuario", DateTime.Now, email));
                }
                return res;

            }
            catch (Exception ex)
            {
                Erros();
                Debug.WriteLine(string.Format("{0} Info: Error,{1} ,{1}Exception.,{2} Query", DateTime.Now, ex.Message, query));
                throw ex;
            }
        }

        public void Erros()
        {
            Debug.Listeners.Clear();
            Debug.Listeners.Add(Session.log);
        }
        public void Logs()
        {
            Debug.Listeners.Clear();
            Debug.Listeners.Add(Session.logError);
        }
    }
}
