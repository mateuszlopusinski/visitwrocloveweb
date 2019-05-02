using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitWrocloveWeb.Migrations
{
    public partial class reviewsRatingForPlaceEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "PlaceEvent",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "PlaceEvent");
        }
    }
}
