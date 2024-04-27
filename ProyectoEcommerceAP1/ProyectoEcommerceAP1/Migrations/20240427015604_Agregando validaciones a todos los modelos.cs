using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEcommerceAP1.Migrations
{
    /// <inheritdoc />
    public partial class Agregandovalidacionesatodoslosmodelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioOferta",
                table: "Productos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Productos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "ItemsCarrito",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Carrito",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PrecioOferta",
                table: "Productos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "Precio",
                table: "Productos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "SubTotal",
                table: "ItemsCarrito",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "Total",
                table: "Carrito",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
