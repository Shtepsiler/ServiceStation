using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceStation.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addphotourl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Mechanics");
        }
    }
}
