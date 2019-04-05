using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitWrocloveWeb.Auth.ViewModels
{
    public class LoginByRefreshTokenViewModel
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; }
    }
}
