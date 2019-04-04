using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VisitWrocloveWeb.Models
{
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
        }
        public DbSet<VisitWrocloveWeb.Models.Route> Route { get; set; }
    }
}
