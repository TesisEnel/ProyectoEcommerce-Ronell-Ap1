using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEcommerceAP1.Migrations
{
    /// <inheritdoc />
    public partial class EliminandolaspropiedadesdelclienteenelmodeloCarrito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUsers_Carrito_CarritoId",
            //    table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Clientes_ClienteId",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Carrito_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.DropIndex(
                name: "IX_Carrito_ClienteId",
                table: "Carrito");

            //migrationBuilder.DropIndex(
            //    name: "IX_AspNetUsers_CarritoId",
            //    table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Carrito");

            //migrationBuilder.DropColumn(
            //    name: "CarritoId",
            //    table: "AspNetUsers");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AspNetUsers_Carrito_CarritoId",
            //    table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Clientes_ClienteId",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Carrito_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.DropIndex(
                name: "IX_Carrito_ClienteId",
                table: "Carrito");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Carrito");

            //migrationBuilder.DropColumn(
            //    name: "CarritoId",
            //    table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CarritoId",
                table: "ItemsCarrito",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            // Elimina esta línea que intenta eliminar el índice IX_AspNetUsers_CarritoId
            // migrationBuilder.DropIndex(
            //     name: "IX_AspNetUsers_CarritoId",
            //     table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Carrito_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId");
        }
    }
}
