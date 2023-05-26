using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceStation.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addIsOrderedPropperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOrdered",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOrdered",
                table: "Orders");
        }
    }
}
