using DomainLayer.Common.Contracts;
using DomainLayer.Models;
using InfrastuctureLayer.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{


    public class BrandRepository : GenericeRepository<Brand>, IBrandRepository
    {


        public BrandRepository(ApplicationDbContext _dbContext) : base(_dbContext) 
        {
            
        }


        public async Task UpdateAsync(Brand brand)
        {
            _dbContext.Update(brand);

           await _dbContext.SaveChangesAsync();



        }
    }
}
