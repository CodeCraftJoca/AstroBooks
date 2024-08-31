using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroBooks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addColumDescription_publisherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Publishers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Publishers");
        }
    }
}
