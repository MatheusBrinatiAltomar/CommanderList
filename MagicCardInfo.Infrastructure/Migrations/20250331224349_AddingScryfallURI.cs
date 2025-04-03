using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicCardInfo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingScryfallURI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScryfallURI",
                table: "Cards",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScryfallURI",
                table: "Cards");
        }
    }
}
