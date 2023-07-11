using Microsoft.EntityFrameworkCore;
using Ozone.Application.Interfaces;
using Ozone.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
//using COI.Domain.Entities;

namespace Ozone.Application.Repository
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly OzoneContext _dbContext;

        public GenericRepositoryAsync(OzoneContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetPagedAdvancedReponseAsync(int pageNumber, int pageSize, string orderBy, string fields)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select<T>("new(" + fields + ")")
                .OrderBy(orderBy)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            //await _dbContext.SaveChangesAsync();
            return entity;
        }


        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;            
            //await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
           // await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext
                 .Set<T>()
                 .ToListAsync();
        }

        public async Task CloseAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public void CloseAll(ICollection<T> entities)
        {
            foreach(var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            //await _dbContext.SaveChangesAsync();
            return;
        }
    }
}
