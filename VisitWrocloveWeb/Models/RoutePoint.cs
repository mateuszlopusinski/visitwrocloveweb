namespace VisitWrocloveWeb.Models
{
    public class RoutePoint
    {
        public int Id { get; set; }

        public virtual PlaceEvent PlaceEvent { get; set; }

        public int PlaceEventId { get; set; }

        public virtual Route Route { get; set; }

        public int RouteId { get; set; }
    }
}