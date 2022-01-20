using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Serwis.DataAccess.Migrations
{
    public partial class AddRegulation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegulationId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Regulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regulations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_RegulationId",
                table: "Documents",
                column: "RegulationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Regulations_RegulationId",
                table: "Documents",
                column: "RegulationId",
                principalTable: "Regulations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Regulations_RegulationId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Regulations");

            migrationBuilder.DropIndex(
                name: "IX_Documents_RegulationId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "RegulationId",
                table: "Documents");
        }
    }
}
