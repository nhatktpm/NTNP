using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NTNP.API.Migrations
{
    public partial class add_vocabulary_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vocabulary",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    transcript = table.Column<string>(type: "varchar(255)", nullable: false),
                    deleted = table.Column<bool>(type: "boolean", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocabulary", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Vocabulary",
                columns: new[] { "id", "comment", "created", "deleted", "name", "path", "transcript" },
                values: new object[,]
                {
                    { 1, "this is a comment", new DateTime(2023, 3, 1, 16, 11, 46, 374, DateTimeKind.Utc).AddTicks(2035), false, "hello", "", "xin chao" },
                    { 2, "this is a comment", new DateTime(2023, 3, 1, 16, 11, 46, 374, DateTimeKind.Utc).AddTicks(2037), false, "what", "", "cai gi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vocabulary");
        }
    }
}
