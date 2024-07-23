using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApsiyonKasif.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityApartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_BuildingComplexes_BuildingComplexId",
                table: "Apartments");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingComplexId",
                table: "Apartments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_BuildingComplexes_BuildingComplexId",
                table: "Apartments",
                column: "BuildingComplexId",
                principalTable: "BuildingComplexes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_BuildingComplexes_BuildingComplexId",
                table: "Apartments");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingComplexId",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_BuildingComplexes_BuildingComplexId",
                table: "Apartments",
                column: "BuildingComplexId",
                principalTable: "BuildingComplexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
