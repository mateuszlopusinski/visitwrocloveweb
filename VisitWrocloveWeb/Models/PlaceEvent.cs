using System.Collections.Generic;

namespace VisitWrocloveWeb.Models
{
    public class PlaceEvent
    { 
        public int Id { get; set; }
        
        public string Description { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }

        public string Website { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<RoutePoint> RoutePoints { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}