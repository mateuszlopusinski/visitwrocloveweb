using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        public virtual Address Address { get; set; }

        public int AddressForeignKey { get; set; }

        public double Rating { get; set; }

        public virtual ICollection<RoutePoint> RoutePoints { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}