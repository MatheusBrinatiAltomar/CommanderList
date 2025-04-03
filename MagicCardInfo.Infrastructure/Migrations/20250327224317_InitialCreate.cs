using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicCardInfo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OracleText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ManaCost = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TypeLine = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageURI_Normal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
