using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTNP.API.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "123", 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "123123");

            migrationBuilder.UpdateData(
                table: "Vocabulary",
                keyColumn: "id",
                keyValue: 1,
                column: "created",
                value: new DateTime(2023, 3, 29, 13, 42, 49, 428, DateTimeKind.Utc).AddTicks(3236));

            migrationBuilder.UpdateData(
                table: "Vocabulary",
                keyColumn: "id",
                keyValue: 2,
                column: "created",
                value: new DateTime(2023, 3, 29, 13, 42, 49, 428, DateTimeKind.Utc).AddTicks(3238));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Vocabulary",
                keyColumn: "id",
                keyValue: 1,
                column: "created",
                value: new DateTime(2023, 3, 1, 16, 11, 46, 374, DateTimeKind.Utc).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "Vocabulary",
                keyColumn: "id",
                keyValue: 2,
                column: "created",
                value: new DateTime(2023, 3, 1, 16, 11, 46, 374, DateTimeKind.Utc).AddTicks(2037));
        }
    }
}
