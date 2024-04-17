using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEcommerceAP1.Migrations
{
    /// <inheritdoc />
    public partial class AgregandomodeloproductosymodeloCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Existencia",
                table: "Productos");

            migrationBuilder.AlterColumn<string>(
                name: "ImagenProducto",
                table: "Productos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEntrada",
                table: "Productos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaEntrada",
                table: "Productos");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImagenProducto",
                table: "Productos",
                type: "BLOB",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Existencia",
                table: "Productos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
