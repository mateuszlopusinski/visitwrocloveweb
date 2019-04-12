using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitWrocloveWeb.Migrations
{
    public partial class ImageChangedToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "PlaceEvent",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "PlaceEvent",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
