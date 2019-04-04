using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitWrocloveWeb.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string City { get; set; }

        public string FlatNumber { get; set; }

        public string HouseNumber { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public virtual PlaceEvent PlaceEvent { get; set; }

        public virtual int PlaceEventId {get; set; }
    }
}
