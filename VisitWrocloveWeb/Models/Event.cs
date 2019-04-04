using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitWrocloveWeb.Models
{
    public class Event : PlaceEvent
    {
        public DateTime EventDateTime { get; set; }

        public int Price { get; set; }
    }
}
