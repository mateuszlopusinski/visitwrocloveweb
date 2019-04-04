using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitWrocloveWeb.Auth.Interfaces;

namespace VisitWrocloveWeb.Auth.DI
{
    public static class AuthServiceProvider
    {
        public static IServiceCollection AddAuthService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IRefreshTokenProvider, RefreshTokenProvider>();
            services.AddScoped<IPasswordOptionsProvider, PasswordOptionsProvider>();
            services.AddScoped<IPasswordProvider, PasswordProvider>();
            return services;
        }
    }
}
