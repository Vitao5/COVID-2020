using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codiv19.API.Repositories.Interfaces.Base
{
    public interface IRepositoryBase<T> where T: class
    {
        void Create(T ent);
        void Delete(int id);
        T Update(T ent);
        IEnumerable<T> PegarTodos();
        T GetOne(int id);
    }
}
