using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApsiyonKasif.Repository.Migrations
{
    /// <inheritdoc />
    public partial class TryCreateDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "BuildingComplexes");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "BuildingComplexes");

            migrationBuilder.AddColumn<int>(
                name: "BathromCount",
                table: "Homes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Direction",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DoorNumber",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GrossArea",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasBalcony",
                table: "Homes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasFurnished",
                table: "Homes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Homes",
                type: "decimal(8,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Homes",
                type: "decimal(8,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NetArea",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConnectedBlock",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Dues",
                table: "Apartments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "HasElevator",
                table: "Apartments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasGarage",
                table: "Apartments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFloor",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BathromCount",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "DoorNumber",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "GrossArea",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "HasBalcony",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "HasFurnished",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "NetArea",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ConnectedBlock",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Dues",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "HasElevator",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "HasGarage",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "NumberOfFloor",
                table: "Apartments");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "BuildingComplexes",
                type: "decimal(8,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "BuildingComplexes",
                type: "decimal(8,6)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
