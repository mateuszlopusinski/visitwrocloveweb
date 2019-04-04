namespace VisitWrocloveWeb.Models
{
    public class SavedRoute
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }
    }
}
