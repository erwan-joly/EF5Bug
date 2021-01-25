using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

namespace EF3._1.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<LocalDate>(
                name: "ADate",
                table: "TestObjects",
                nullable: true,
                oldClrType: typeof(Instant));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Instant>(
                name: "ADate",
                table: "TestObjects",
                nullable: false,
                oldClrType: typeof(LocalDate),
                oldNullable: true);
        }
    }
}
