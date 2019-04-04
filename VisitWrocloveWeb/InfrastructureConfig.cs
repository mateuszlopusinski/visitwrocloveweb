using Microsoft.Extensions.Configuration;
using System;
using VisitWrocloveWeb.Auth.Interfaces;

namespace VisitWrocloveWeb
{
    public class InfrastructureConfig : IInfrastructureConfig
    {
        private readonly IConfiguration _configuration;

        public InfrastructureConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public double RefreshTokenExpiryInMinutes => Convert.ToDouble(_configuration["JsonWebToken:TokenOptions:RefreshTokenExpiryTimeInMinutes"]);
    }
}