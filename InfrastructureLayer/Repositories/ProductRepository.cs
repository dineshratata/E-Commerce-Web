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
    public class ProductRepository : GenericeRepository<Product>, IProductRepositry
    {
        public ProductRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _dbContext.Products.AsNoTracking().Include(x => x.Category).Include(x => x.Brand).ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {

            _dbContext.Products.Update(product);
           await _dbContext.SaveChangesAsync();
           


        }
    }
}