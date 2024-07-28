using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApsiyonKasif.Repository.Migrations
{
    /// <inheritdoc />
    public partial class TryCreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_AdvertTypes_AdvertTypeId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Apartments_ApartmentId",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_ApartmentId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "Adverts");

            migrationBuilder.AlterColumn<int>(
                name: "AdvertTypeId",
                table: "Adverts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_AdvertTypes_AdvertTypeId",
                table: "Adverts",
                column: "AdvertTypeId",
                principalTable: "AdvertTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_AdvertTypes_AdvertTypeId",
                table: "Adverts");

            migrationBuilder.AlterColumn<int>(
                name: "AdvertTypeId",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_ApartmentId",
                table: "Adverts",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_AdvertTypes_AdvertTypeId",
                table: "Adverts",
                column: "AdvertTypeId",
                principalTable: "AdvertTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Apartments_ApartmentId",
                table: "Adverts",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
