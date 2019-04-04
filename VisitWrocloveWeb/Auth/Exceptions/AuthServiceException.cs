using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitWrocloveWeb.Auth.Exceptions
{
    public class AuthServiceException : Exception
    {
        public string Details { get; set; }

        public AuthServiceException(string message, string details) : base(message)
        {
            Details = details;
        }
    }
}
