using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitWrocloveWeb.Auth.Models;

namespace VisitWrocloveWeb.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<JsonWebToken> LoginByCredentialsAsync(string email, string password);
        Task<JsonWebToken> LoginByRefreshToken(string refreshToken, int userId);
        Task ChangePassword(int userId, string oldPassword, string newPassword);
    }
}
