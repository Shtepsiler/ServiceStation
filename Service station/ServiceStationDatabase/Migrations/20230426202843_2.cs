using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceStationDatabase.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "Vendors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PartId",
                table: "Parts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "Models",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MechanicId",
                table: "Mechanics",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Jobs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Clients",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vendors",
                newName: "VendorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Parts",
                newName: "PartId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Models",
                newName: "ModelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mechanics",
                newName: "MechanicId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Jobs",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "ClientId");
        }
    }
}
