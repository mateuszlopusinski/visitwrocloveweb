using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitWrocloveWeb.Auth.Models
{
    public class JsonWebToken
    {
        public string AccessToken { get; set; }
        public JsonWebTokenUser User { get; set; }
        public DateTime ExpiresIn { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
