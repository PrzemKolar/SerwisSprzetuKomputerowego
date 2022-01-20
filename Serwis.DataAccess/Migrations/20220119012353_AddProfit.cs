using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Serwis.DataAccess.Migrations
{
    public partial class AddProfit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistory_Employees_EmployeeId",
                table: "OrderHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistory_Orders_OrderId",
                table: "OrderHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHistory",
                table: "OrderHistory");

            migrationBuilder.RenameTable(
                name: "OrderHistory",
                newName: "OrderHistories");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistory_OrderId",
                table: "OrderHistories",
                newName: "IX_OrderHistories_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistory_EmployeeId",
                table: "OrderHistories",
                newName: "IX_OrderHistories_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHistories",
                table: "OrderHistories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Profits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profits_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profits_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profits_EmployeeId",
                table: "Profits",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profits_OrderId",
                table: "Profits",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_Employees_EmployeeId",
                table: "OrderHistories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_Orders_OrderId",
                table: "OrderHistories",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_Employees_EmployeeId",
                table: "OrderHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_Orders_OrderId",
                table: "OrderHistories");

            migrationBuilder.DropTable(
                name: "Profits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHistories",
                table: "OrderHistories");

            migrationBuilder.RenameTable(
                name: "OrderHistories",
                newName: "OrderHistory");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistories_OrderId",
                table: "OrderHistory",
                newName: "IX_OrderHistory_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHistories_EmployeeId",
                table: "OrderHistory",
                newName: "IX_OrderHistory_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHistory",
                table: "OrderHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistory_Employees_EmployeeId",
                table: "OrderHistory",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistory_Orders_OrderId",
                table: "OrderHistory",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
