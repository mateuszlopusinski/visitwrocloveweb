using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitWrocloveWeb.Models
{
    public class Place : PlaceEvent
    {
        public int MinPrice { get; set; }

        public string OpeningHours { get; set; }
    }
}
