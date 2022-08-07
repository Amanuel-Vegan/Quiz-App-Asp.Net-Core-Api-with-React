using BussinessLogic.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLogic.Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _Dbcontext;
        public GenericRepository(AppDbContext context)
        {
            _Dbcontext = context;
        }
        public virtual async Task<T> CreateAsync(T entity)
        {
           var result = await _Dbcontext.AddAsync(entity);
                        await _Dbcontext.SaveChangesAsync();
           return result.Entity;
        }

        public virtual async void Delete(Guid id)
        {
          var result = _Dbcontext.FindAsync<T>(id);
                       _Dbcontext.Remove(result);
                 await _Dbcontext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _Dbcontext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
           return await _Dbcontext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {          
                 _Dbcontext.Update(entity);
           await _Dbcontext.SaveChangesAsync();
          return entity;
        }
    }
}
