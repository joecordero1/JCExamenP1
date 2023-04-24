using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JCExamenP1.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JCordero",
                columns: table => new
                {
                    JCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JCModelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    JCPrecio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JCRemanofacturado = table.Column<bool>(type: "bit", nullable: false),
                    FechaFabriacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JCordero", x => x.JCId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JCordero");
        }
    }
}
