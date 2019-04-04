using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitWrocloveWeb.Auth.Models;

namespace VisitWrocloveWeb.Auth.Interfaces
{
    public interface IJwtProvider
    {
        Task<JsonWebToken> GenerateAccessAndRefreshTokenAsync(string email, string password);
        Task<JsonWebToken> GenerateAccessAndRefreshTokenAsync(int userId, string refreshToken);
    }
}
