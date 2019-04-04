using System.Collections.Generic;

namespace VisitWrocloveWeb.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string Name { get; set; }
        public bool IsPremium { get; set; }
        public bool IsPublic { get; set; }

        public double Length{ get; set; }

        public string Type { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<SavedRoute> SavedRoutes { get; set; }

        public virtual ICollection<RoutePoint> RoutePoints{ get; set; }

    }
}