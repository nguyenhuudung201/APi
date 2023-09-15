using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApi.Migrations
{
    /// <inheritdoc />
    public partial class booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChecKOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Adult = table.Column<int>(type: "int", nullable: false),
                    Child = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
