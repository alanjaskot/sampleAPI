using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPIwithJwt.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[] { new Guid("158a8ce5-903a-4a56-9a43-2445128b7949"), "User1", "123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("158a8ce5-903a-4a56-9a43-2445128b7949"));
        }
    }
}
