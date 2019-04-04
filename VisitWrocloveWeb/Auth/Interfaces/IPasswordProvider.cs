using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitWrocloveWeb.Auth.Interfaces
{
    public interface IPasswordProvider
    {
        Task<bool> IsPasswordValid(int userId, string password);
        Task<bool> UpdatePassword(int userId, string oldPassword, string newPassword);
    }
}
