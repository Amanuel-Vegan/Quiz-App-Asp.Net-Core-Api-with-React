using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLogic.IRepository
{
    public interface IRepository<T> 
    {
       Task<T> CreateAsync(T entity);
       Task<T> UpdateAsync(T entity);
       Task<IEnumerable<T>> GetAllAsync();
       Task<T> GetAsync(Guid id);
       void Delete(Guid id);
    }
}
