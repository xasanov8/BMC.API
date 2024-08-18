using BMC.Application.Services.AuthServices;
using BMC.Application.Services.PasswordHash;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BMC.Application
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IRestoranAuthService, RestoranAuthService>();
            services.AddScoped<IAboutWorkerAuthService, AboutWorkerAuthService>();
            services.AddScoped<IPasswordHashing, PasswordHashing>();

            return services;
        }
    }
}
