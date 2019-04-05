using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitWrocloveWeb.Auth.Extension
{
    internal static class JwtExtension
    {
        internal static void ConfigureJwt(this IServiceCollection services)//, IConfiguration configuration)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JwtKeydasdsad123123dasdasda_TOKEN"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            services.Configure<JwtOptions>(options =>
            {
                options.Audience = "Warning";// configuration[ConfigKey.JwtAudienceSource];
                options.Issuer = "Warning";//configuration[ConfigKey.JwtIssuerSource];
                options.SigningCredentials = signingCredentials;
                options.ValidFor = TimeSpan.FromMinutes(50);
                    //TimeSpan.FromMinutes(Convert.ToDouble(configuration[ConfigKey.JwtTokenExpiryTimeInMinutesSource]));
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingCredentials.Key,
                ValidateIssuer = true,
                ValidIssuer = "Warning", //configuration[ConfigKey.JwtIssuerSource],
                ValidateAudience = true,
                ValidAudience = "Warning", //configuration[ConfigKey.JwtAudienceSource],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero   
            };

            services.AddAuthentication(o => { o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    //Convert.ToBoolean(configuration[ConfigKey.RequireHttpsMetadataSource]);
                    options.IncludeErrorDetails = true;// Convert.ToBoolean(configuration[ConfigKey.IncludeErrorDetailsSource]);
                    options.TokenValidationParameters = tokenValidationParameters;
                });

            //services.AddAuthorizationWithRoles();
        }
    }
}
