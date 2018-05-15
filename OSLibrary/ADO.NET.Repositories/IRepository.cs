using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLibrary.ADO.NET.Repositories
{
    public interface IRepository<T> where T :class
    {
        void Create(T model);
        void Update(T model);
        IEnumerable<T> GetAll();

    }
}
