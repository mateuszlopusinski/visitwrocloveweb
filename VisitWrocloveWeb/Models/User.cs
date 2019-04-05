using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitWrocloveWeb.Models
{
    public class User : IdentityUser<int>
    {
        public DateTime CreationDate { get; set; }

        public string RefreshToken { get; set; }
        
        public string Login { get; set; }
        public override string NormalizedEmail { get => base.NormalizedEmail; set => base.NormalizedEmail = Email; }
        public bool IsAdmin { get; set; }

        public bool IsPremium { get; set; }
        public DateTime RefreshTokenCreatedDate { get; set; }
        public DateTime RefreshTokenExpiryDate { get; set; }

        public virtual ICollection<PremiumPayment> Points { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Route> Routes{ get; set; }

        public virtual ICollection<SavedRoute> SavedRoutes { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }

    }
}
