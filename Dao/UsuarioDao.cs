using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao
{
     public interface UsuarioDao:IDao<Usuario>
     {
        DataTable Login(string nombreUsuario, string password);

        int updatePassword(int usuarioid,Usuario u);

        int updatePasseord2(int usuarioid, Usuario u, string pas);

        Usuario get(int id);

        int updateRecuperarPass(string email, string nomuser,Usuario u);

        int getIndentity();


        DataTable selectUsername(string username);
     }
}
