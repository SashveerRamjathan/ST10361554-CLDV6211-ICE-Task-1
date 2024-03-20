using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLDV6211_ICE_Task_1.Migrations
{
    /// <inheritdoc />
    public partial class AddIsFavoritedToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorited",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorited",
                table: "Book");
        }
    }
}
