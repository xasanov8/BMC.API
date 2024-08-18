using BMC.Application.Abstraction;
using BMC.Infrostructure.References;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Infrostructure
{
    public static class InfrostructureDI
    {
        public static IServiceCollection AddInfrostructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IBMCProjDbContext, BMCProjDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("BMCProj"));
            });

            return services;
        }
    }
}
