using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitWrocloveWeb.Auth.Interfaces;
using VisitWrocloveWeb.Models;

namespace VisitWrocloveWeb.Auth
{
    internal class PasswordOptionsProvider : IPasswordOptionsProvider
    {
        private readonly UserManager<User> _userManager;

        public PasswordOptionsProvider(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public PasswordOptions GetPasswordOptions()
        {
            return _userManager.Options.Password;
        }
    }
}
