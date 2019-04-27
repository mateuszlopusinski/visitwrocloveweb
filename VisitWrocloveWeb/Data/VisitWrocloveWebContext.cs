using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitWrocloveWeb.Models;

namespace VisitWrocloveWeb.Models
{
    //"VisitWrocloveWebContext": "Server=.;Database=VisitWrocloveWebContext-069b0bfc-df05-4239-9fc3-5ed9dfd42fc8;Trusted_Connection=True;MultipleActiveResultSets=true",
    public class VisitWrocloveWebContext : DbContext
    {
        public VisitWrocloveWebContext (DbContextOptions<VisitWrocloveWebContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(a => a.PlaceEvent)
                .WithOne(p => p.Address)
                .HasForeignKey<PlaceEvent>(p => p.AddressForeignKey);

            modelBuilder.Entity<Event>();
            modelBuilder.Entity<Place>();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<VisitWrocloveWeb.Models.Route> Route { get; set; }
        public DbSet<VisitWrocloveWeb.Models.User> User { get; set; }
        public object Users { get; internal set; }
        public DbSet<VisitWrocloveWeb.Models.Event> Event { get; set; }
        public DbSet<VisitWrocloveWeb.Models.Place> Place { get; set; }
        public DbSet<VisitWrocloveWeb.Models.RoutePoint> RoutePoint { get; set; }
        public DbSet<VisitWrocloveWeb.Models.Address> Address { get; set; }
        public DbSet<VisitWrocloveWeb.Models.Favorite> Favorite { get; set; }
        public DbSet<VisitWrocloveWeb.Models.Review> Review { get; set; }
        public DbSet<VisitWrocloveWeb.Models.PremiumPayment> PremiumPayment { get; set; }
        public DbSet<VisitWrocloveWeb.Models.SavedRoute> SavedRoute { get; set; }
    }
}
