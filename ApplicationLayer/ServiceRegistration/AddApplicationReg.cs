﻿using ApplicationLayer.Common;
using ApplicationLayer.Services;
using ApplicationLayer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ServiceRegistration
{
    public static class ApplicationRegistration
    {
       public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
           services.AddAutoMapper(typeof(MappingProfile));

            ///services Container for Required Services
            ///



            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();
              


            return services;

        }

    }
}
