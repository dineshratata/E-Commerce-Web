using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastuctureLayer.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            

        }



        public DbSet <Category> Category { get; set; }    
        public DbSet<Brand> Brands { get; set; }   
        
        public DbSet<Product> Products { get; set; }
    }
}
