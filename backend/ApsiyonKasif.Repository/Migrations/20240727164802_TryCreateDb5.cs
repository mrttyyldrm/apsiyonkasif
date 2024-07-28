using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApsiyonKasif.Repository.Migrations
{
    /// <inheritdoc />
    public partial class TryCreateDb5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_AdvertTypes_AdvertTypeId",
                table: "Adverts",
                column: "AdvertTypeId",
                principalTable: "AdvertTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
    }
}
