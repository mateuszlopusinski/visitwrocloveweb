namespace VisitWrocloveWeb.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual PlaceEvent PlaceEvent { get; set; }
        public int PlaceEventId { get; set; }
    }
}