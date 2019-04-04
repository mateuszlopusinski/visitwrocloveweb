using System;

namespace VisitWrocloveWeb.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int PlaceEventId { get; set; }
        public virtual PlaceEvent PlaceEvent { get; set; }
    }
}