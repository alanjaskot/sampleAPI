using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPIwithJwt.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermitsName = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[] { new Guid("c1692909-24ef-4564-862d-94a146bc885b"), "Admin", "123" });

            migrationBuilder.InsertData(
                table: "Permits",
                columns: new[] { "Id", "PermitsName", "UserId" },
                values: new object[] { new Guid("bdad0bef-d83e-4dd8-b1fe-37fa8ded02d5"), "Users.Read", new Guid("c1692909-24ef-4564-862d-94a146bc885b") });

            migrationBuilder.InsertData(
                table: "Permits",
                columns: new[] { "Id", "PermitsName", "UserId" },
                values: new object[] { new Guid("6abc8cb9-6928-4052-8c5b-070cf54f80ac"), "Users.Write", new Guid("c1692909-24ef-4564-862d-94a146bc885b") });

            migrationBuilder.InsertData(
                table: "Permits",
                columns: new[] { "Id", "PermitsName", "UserId" },
                values: new object[] { new Guid("d3a5d315-2a04-43b6-afc0-039bf45f0234"), "Users.Update", new Guid("c1692909-24ef-4564-862d-94a146bc885b") });

            migrationBuilder.InsertData(
                table: "Permits",
                columns: new[] { "Id", "PermitsName", "UserId" },
                values: new object[] { new Guid("edcb1e7f-6e9e-4f31-8b26-84f1fc0a2107"), "User.Delete", new Guid("c1692909-24ef-4564-862d-94a146bc885b") });

            migrationBuilder.CreateIndex(
                name: "IX_Permits_UserId",
                table: "Permits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_Password",
                table: "Users",
                columns: new[] { "Id", "Password" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permits");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
