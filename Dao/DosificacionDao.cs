using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao
{
    public interface DosificacionDao:IDao<Dosificacion>
    {
        Dosificacion GetSelect();

        int NumFactura();

        void InsertTransac( Dosificacion d);
    }
}
