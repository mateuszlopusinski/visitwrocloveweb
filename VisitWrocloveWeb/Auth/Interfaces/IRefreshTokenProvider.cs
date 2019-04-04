using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitWrocloveWeb.Auth.Models;

namespace VisitWrocloveWeb.Auth.Interfaces
{
    public interface IRefreshTokenProvider
    {
        Task<bool> ValidateRefreshTokenAsync(int userId, string refreshToken);
        Task SaveRefreshTokenAsync(int userId, string userEmail, RefreshToken refreshToken);
        RefreshToken GenerateRefreshToken(int userId, string userEmail);
    }
}
