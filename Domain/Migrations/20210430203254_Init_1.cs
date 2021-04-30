using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class Init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumerDateofBirth = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumers");
        }
    }
}
