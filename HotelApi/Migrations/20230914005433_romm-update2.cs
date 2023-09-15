using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApi.Migrations
{
    /// <inheritdoc />
    public partial class rommupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageDetai",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDetai",
                table: "Rooms");
        }
    }
}
