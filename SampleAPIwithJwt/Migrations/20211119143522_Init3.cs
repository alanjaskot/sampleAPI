using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPIwithJwt.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Figures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SideOne = table.Column<decimal>(type: "TEXT", nullable: false),
                    FigureName = table.Column<string>(type: "TEXT", nullable: false),
                    SideTwo = table.Column<decimal>(type: "TEXT", nullable: true),
                    Heigh = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Figures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Figures_FigureName",
                table: "Figures",
                column: "FigureName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Figures");
        }
    }
}
