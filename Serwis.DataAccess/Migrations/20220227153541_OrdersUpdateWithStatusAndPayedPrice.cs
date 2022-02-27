using Microsoft.EntityFrameworkCore.Migrations;

namespace Serwis.DataAccess.Migrations
{
    public partial class OrdersUpdateWithStatusAndPayedPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PayedPrice",
                table: "Orders",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "RepairStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayedPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RepairStatus",
                table: "Orders");
        }
    }
}
