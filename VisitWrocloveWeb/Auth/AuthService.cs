using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitWrocloveWeb.Auth.Exceptions;
using VisitWrocloveWeb.Auth.Interfaces;
using VisitWrocloveWeb.Auth.Models;

namespace VisitWrocloveWeb.Auth
{
    public class AuthService
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IRefreshTokenProvider _refreshTokenProvider;
        private readonly IPasswordProvider _passwordProvider;

        public AuthService(IJwtProvider jwtProvider, IRefreshTokenProvider refreshTokenProvider, IPasswordProvider passwordProvider)
        {
            _jwtProvider = jwtProvider;
            _refreshTokenProvider = refreshTokenProvider;
            _passwordProvider = passwordProvider;
        }

        public async Task<JsonWebToken> LoginByCredentialsAsync(string email, string password)
        {
            if (email == null || password == null)
            {
                throw new UnauthorizedException(email);
            }

            var token = await _jwtProvider.GenerateAccessAndRefreshTokenAsync(email, password);

            if (token == null)
            {
                throw new UnauthorizedException(email);
            }

            return token;
        }

        public async Task<JsonWebToken> LoginByRefreshToken(string refreshToken, int userId)
        {
            var isTokeValid = await _refreshTokenProvider.ValidateRefreshTokenAsync(userId, refreshToken);

            if (!isTokeValid)
            {
                throw new UnauthorizedException(userId);
            }

            var token = await _jwtProvider.GenerateAccessAndRefreshTokenAsync(userId, refreshToken);

            if (token == null)
            {
                throw new UnauthorizedException(userId);
            }

            return token;
        }

        public async Task ChangePassword(int userId, string oldPassword, string newPassword)
        {
            if (!await _passwordProvider.IsPasswordValid(userId, oldPassword))
            {
                throw new UnauthorizedException(userId);
            }

            if (!await _passwordProvider.UpdatePassword(userId, oldPassword, newPassword))
            {
                throw new UnauthorizedException(userId);
            }
        }
    }
}
