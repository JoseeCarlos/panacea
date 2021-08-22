using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao
{
    public interface PaisDao:IDao<pais>
    {
        DataTable SelectIdName();
    }
}
