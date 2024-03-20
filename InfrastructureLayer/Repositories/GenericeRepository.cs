using DomainLayer.Common.Contracts;
using DomainLayer.Models;
using InfrastuctureLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class GenericeRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _dbContext;

        public GenericeRepository(ApplicationDbContext dbContext)
        {

            _dbContext = dbContext; 
            
        }


        public async Task<T> CreateAsync(T entity)
        {
            var createdEntity = await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return createdEntity.Entity;

              
        }

        public async Task DeleteAsync(T condition)
        {
            _dbContext.Set<T>().Remove(condition);
            _dbContext.SaveChangesAsync();
          



        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
          var categories   = await _dbContext.Set<T>().AsNoTracking().ToListAsync();
          
            return categories;  

        }

        public Task<T> GetByIdAsync(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }
    }
}
