using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Dao
{
    public interface FacturaAnuladaDao:IDao<FacturaAnulada>
    {
         void insertFactura(FacturaAnulada fac,List<Productos> productos);
    }
}
