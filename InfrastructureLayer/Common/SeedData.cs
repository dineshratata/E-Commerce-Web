using DomainLayer.Models;
using InfrastuctureLayer.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Common
{
    public class SeedData
    {

        public static async Task RoleSeed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


            var roles = new List<IdentityRole>
            {



                new IdentityRole { Name = "ADMIN", NormalizedName = "ADMIN" },
            new IdentityRole { Name = "CUSTOMER", NormalizedName = "CUSTOMER" }


        };

        foreach(var role in roles)
            {

                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                         await roleManager.CreateAsync(role);

                }


          
            }

        








    }


        public static async Task SeedDataAsync(ApplicationDbContext _dbContext)
        {

            if (!_dbContext.Brands.Any())
            {

                await _dbContext.AddRangeAsync(

                    new Brand
                    {
                        Name = "Lenevo",
                        EstablisedYear = "2000"

                    },

                    new Brand
                    {
                        Name = "Samsung",
                        EstablisedYear = "1992"

                    },

                    new Brand
                    {
                        Name = "google",
                        EstablisedYear = "1500"

                    },

                    new Brand
                    {
                        Name = "Lenevo",
                        EstablisedYear = "1998"

                    },


                    new Brand
                    {
                        Name = "philips",
                        EstablisedYear = "2010"

                    }
                    ,


                    new Brand
                    {
                        Name = "Roshon",
                        EstablisedYear = "2000"

                    }


                    );



                await _dbContext.SaveChangesAsync();

            }



        }


    }
}
