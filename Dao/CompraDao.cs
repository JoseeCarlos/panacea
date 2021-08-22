using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao
{
    public interface CompraDao:IDao<Compra>
    {

        void Insert2(Compra c, List<Productos> p);

        DataTable serachDate(string f1, string f2);

        DataTable selectdelete();
        DataTable selectDadoBaja();

        


    }
}
