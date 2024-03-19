using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastuctureLayer.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            

        }



        public DbSet <Category> Category { get; set; }    
    }
}
