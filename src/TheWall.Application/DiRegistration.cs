using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TheWall.Application.Contracts;
using TheWall.Application.Implementations;

namespace TheWall.Application
{
    public static class DiRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<ILoginProvider, LoginProvider>();
            services.AddScoped<ILoginHandler<UsernamePasswordLoginModel>, UsernamePasswordLoginHandler>();
            services.AddSingleton<ITokenProvider, JwtTokenProvider>();

            services.AddScoped<IRegisterHandler, RegisterHandler>();

            return services;
        }
    }
}