using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Repository
{
    public interface ICRUD<T> where T:class
    {
        void Add(T item);

        void Delete(Guid id);

        void Update(Guid id, T item);

        T GetItem(Guid id);

        List<T> GetItens();
    }
}
