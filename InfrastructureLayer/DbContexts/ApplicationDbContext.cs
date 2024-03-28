using ApplicationLayer.Common;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfrastuctureLayer.DbContexts
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            

        }



        public DbSet <Category> Category { get; set; }    
        public DbSet<Brand> Brands { get; set; }   
        
        public DbSet<Product> Products { get; set; }
    }
}
