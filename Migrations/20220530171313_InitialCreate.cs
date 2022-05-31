using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnitOfWork.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alquileres",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alquileres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "peliculas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Alquilerid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peliculas", x => x.id);
                    table.ForeignKey(
                        name: "FK_peliculas_alquileres_Alquilerid",
                        column: x => x.Alquilerid,
                        principalTable: "alquileres",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_peliculas_Alquilerid",
                table: "peliculas",
                column: "Alquilerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "peliculas");

            migrationBuilder.DropTable(
                name: "alquileres");
        }
    }
}
