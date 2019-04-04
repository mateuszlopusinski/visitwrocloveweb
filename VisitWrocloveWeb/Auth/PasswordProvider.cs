using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitWrocloveWeb.Auth.Interfaces;
using VisitWrocloveWeb.Models;

namespace VisitWrocloveWeb.Auth
{
    public class PasswordProvider : IPasswordProvider
    {
        private readonly VisitWrocloveWebContext _context;
        private readonly UserManager<User> _userManager;

        public PasswordProvider(VisitWrocloveWebContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> IsPasswordValid(int userId, string password)
        {
            var user = await _context.User.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            var user = await _context.User.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            return result.Succeeded;
        }
    }
}
