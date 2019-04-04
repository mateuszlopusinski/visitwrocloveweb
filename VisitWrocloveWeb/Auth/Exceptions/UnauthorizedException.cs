using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitWrocloveWeb.Auth.Exceptions;

namespace VisitWrocloveWeb.Auth.Exceptions
{
    public class UnauthorizedException : AuthServiceException
    {
        public UnauthorizedException(string email) : base("Unauthorized",
            $"User with email: {email} has been unauthorized")
        {

        }

        public UnauthorizedException(int userId) : base("Unauthorized",
            $"User with id: {userId} has been unauthorized")
        {

        }
    }
}
