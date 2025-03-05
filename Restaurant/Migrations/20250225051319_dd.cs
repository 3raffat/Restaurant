using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class dd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "contactUsEmail",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contactUsLocation",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contactUsPhone",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contactUsEmail",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "contactUsLocation",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "contactUsPhone",
                table: "SystemSettings");
        }
    }
}
