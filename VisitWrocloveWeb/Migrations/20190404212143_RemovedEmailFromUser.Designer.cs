﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VisitWrocloveWeb.Models;

namespace VisitWrocloveWeb.Migrations
{
    [DbContext(typeof(VisitWrocloveWebContext))]
    [Migration("20190404212143_RemovedEmailFromUser")]
    partial class RemovedEmailFromUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VisitWrocloveWeb.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("FlatNumber");

                    b.Property<string>("HouseNumber");

                    b.Property<string>("Lat");

                    b.Property<string>("Lng");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlaceEventId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PlaceEventId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.PlaceEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressForeignKey");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("AddressForeignKey")
                        .IsUnique();

                    b.ToTable("PlaceEvent");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PlaceEvent");
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.PremiumPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<string>("Status");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PremiumPayment");
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Mark");

                    b.Property<int>("PlaceEventId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PlaceEventId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsPremium");

                    b.Property<bool>("IsPublic");

                    b.Property<double>("Length");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.RoutePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlaceEventId");

                    b.Property<int>("RouteId");

                    b.HasKey("Id");

                    b.HasIndex("PlaceEventId");

                    b.HasIndex("RouteId");

                    b.ToTable("RoutePoint");
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.SavedRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RouteId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.HasIndex("UserId");

                    b.ToTable("SavedRoute");
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsPremium");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Login");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("RefreshToken");

                    b.Property<DateTime>("RefreshTokenCreatedDate");

                    b.Property<DateTime>("RefreshTokenExpiryDate");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.Event", b =>
                {
                    b.HasBaseType("VisitWrocloveWeb.Models.PlaceEvent");

                    b.Property<DateTime>("EventDateTime");

                    b.Property<int>("Price");

                    b.ToTable("Event");

                    b.HasDiscriminator().HasValue("Event");
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.Place", b =>
                {
                    b.HasBaseType("VisitWrocloveWeb.Models.PlaceEvent");

                    b.Property<int>("MinPrice");

                    b.Property<string>("OpeningHours");

                    b.ToTable("Place");

                    b.HasDiscriminator().HasValue("Place");
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.Favorite", b =>
                {
                    b.HasOne("VisitWrocloveWeb.Models.PlaceEvent", "PlaceEvent")
                        .WithMany("Favorites")
                        .HasForeignKey("PlaceEventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VisitWrocloveWeb.Models.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.PlaceEvent", b =>
                {
                    b.HasOne("VisitWrocloveWeb.Models.Address", "Address")
                        .WithOne("PlaceEvent")
                        .HasForeignKey("VisitWrocloveWeb.Models.PlaceEvent", "AddressForeignKey")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.PremiumPayment", b =>
                {
                    b.HasOne("VisitWrocloveWeb.Models.User", "User")
                        .WithMany("Points")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.Review", b =>
                {
                    b.HasOne("VisitWrocloveWeb.Models.PlaceEvent", "PlaceEvent")
                        .WithMany()
                        .HasForeignKey("PlaceEventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VisitWrocloveWeb.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.Route", b =>
                {
                    b.HasOne("VisitWrocloveWeb.Models.User", "User")
                        .WithMany("Routes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.RoutePoint", b =>
                {
                    b.HasOne("VisitWrocloveWeb.Models.PlaceEvent", "PlaceEvent")
                        .WithMany("RoutePoints")
                        .HasForeignKey("PlaceEventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VisitWrocloveWeb.Models.Route", "Route")
                        .WithMany("RoutePoints")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("VisitWrocloveWeb.Models.SavedRoute", b =>
                {
                    b.HasOne("VisitWrocloveWeb.Models.Route")
                        .WithMany("SavedRoutes")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("VisitWrocloveWeb.Models.User")
                        .WithMany("SavedRoutes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
