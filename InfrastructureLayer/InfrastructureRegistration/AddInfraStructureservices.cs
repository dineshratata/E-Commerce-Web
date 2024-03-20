using DomainLayer.Common.Contracts;
using InfrastructureLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.InfrastructureRegistration
{
    public static class AddInfraStructureservices
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>),typeof (GenericeRepository<>));
            services.AddScoped <ICategoryRepository,CategoryRepository>();



            return services;
                }

    }
}
