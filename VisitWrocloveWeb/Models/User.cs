using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitWrocloveWeb.Models
{
    public class User
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsPremium { get; set; }

        public virtual ICollection<PremiumPayment> Points { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Route> Routes{ get; set; }

        public virtual ICollection<SavedRoute> SavedRoutes { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }

    }
}
