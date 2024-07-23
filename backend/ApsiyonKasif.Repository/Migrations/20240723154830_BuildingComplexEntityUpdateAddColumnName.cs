using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApsiyonKasif.Repository.Migrations
{
    /// <inheritdoc />
    public partial class BuildingComplexEntityUpdateAddColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BuildingComplexes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "BuildingComplexes");
        }
    }
}
