using DomainLayer.Common.Contracts;
using DomainLayer.Models;
using InfrastuctureLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class CategoryRepository :  GenericeRepository<Category>, ICategoryRepository 
    {
        public CategoryRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            
        }

        public async Task UpdateAsync(Category category)
        {
            _dbContext.Update(category);
             await _dbContext.SaveChangesAsync();



        }
    }
}

