using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public interface IDao<T>
    {
        int insert(T t);
        int update(T t);
        int delete(T t);

        DataTable select();

    }
}
