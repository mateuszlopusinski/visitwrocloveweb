using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitWrocloveWeb.Auth.Interfaces;
using VisitWrocloveWeb.Auth.Models;
using VisitWrocloveWeb.Models;

namespace VisitWrocloveWeb.Auth
{
    internal class RefreshTokenProvider : IRefreshTokenProvider
    {
        private readonly VisitWrocloveWebContext _context;
        private readonly IInfrastructureConfig _refreshTokenConfig;

        public RefreshTokenProvider(IInfrastructureConfig refreshTokenConfig, VisitWrocloveWebContext context)
        {
            _refreshTokenConfig = refreshTokenConfig;
            _context = context;
        }

        public async Task<bool> ValidateRefreshTokenAsync(int userId, string refreshToken)
        {
            var originUser = await _context.User.FirstOrDefaultAsync(x => x.Id == userId);

            if (originUser == null)
            {
                return false;
            }

            return originUser.RefreshToken == refreshToken && originUser.RefreshTokenExpiryDate > DateTime.UtcNow;
            return false;
        }

        public async Task SaveRefreshTokenAsync(int userId, string userEmail, RefreshToken refreshToken)
        {
            var originUser = await _context.User.FirstOrDefaultAsync(x => x.Email == userEmail && x.Id == userId);

            originUser.RefreshToken = refreshToken.Token;
            originUser.RefreshTokenExpiryDate = refreshToken.ExpiresUtc;
            originUser.RefreshTokenCreatedDate = refreshToken.IssuedUtc;

            await _context.SaveChangesAsync();
        }

        public RefreshToken GenerateRefreshToken(int userId, string userEmail)
        {
            return new RefreshToken
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(_refreshTokenConfig.RefreshTokenExpiryInMinutes),
                Token = Guid.NewGuid().ToString().Replace("-", "")
            };
        }
    }
}
