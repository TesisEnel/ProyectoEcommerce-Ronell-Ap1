using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEcommerceAP1.Migrations
{
    /// <inheritdoc />
    public partial class Agregandomascosasparaqueelcarritofuncione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Carrito_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.AlterColumn<int>(
                name: "CarritoId",
                table: "ItemsCarrito",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Carrito_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Carrito_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.AlterColumn<int>(
                name: "CarritoId",
                table: "ItemsCarrito",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Carrito_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId");
        }
    }
}
