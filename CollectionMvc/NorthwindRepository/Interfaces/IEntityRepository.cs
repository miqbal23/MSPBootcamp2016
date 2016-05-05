using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindRepository.Interfaces
{
    public interface IEntityRepository<T, P> where T:class where P:IConvertible
    {
        IQueryable<T> GetAllData(); // return query values

        // these interfaces for CRUD operation
        T Search(P id);

        void Insert(T entity);

        void Delete(P id); 

        void Update(T entity);
    }
}
