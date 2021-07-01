using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary.Data
{
    public interface IRepository<T>
    {
        int Create(T entity);

        T Read(int id);

        T Update(T entity);

        bool Delete(int id);
    }
}
