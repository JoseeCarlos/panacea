using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dao
{
    public interface ProductoDao:IDao<Productos>
    {
        int getIndentity();

        DataTable SearchProduct(string nom);

        Productos Get(int id);

        DataTable SlectIdnom(int id);

        DataTable selectfoto(int id);

        void updatepro(List<Productos> producto);
    }
}
