using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitWrocloveWeb.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EventDateTime",
                table: "PlaceEvent",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "PlaceEvent",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinPrice",
                table: "PlaceEvent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningHours",
                table: "PlaceEvent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PlaceEvent",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDateTime",
                table: "PlaceEvent");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PlaceEvent");

            migrationBuilder.DropColumn(
                name: "MinPrice",
                table: "PlaceEvent");

            migrationBuilder.DropColumn(
                name: "OpeningHours",
                table: "PlaceEvent");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PlaceEvent");
        }
    }
}
