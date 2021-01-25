using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

namespace EF5.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestObjects",
                columns: table => new
                {
                    Key = table.Column<Guid>(nullable: false),
                    ADate = table.Column<Instant>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestObjects", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestObjects");
        }
    }
}
