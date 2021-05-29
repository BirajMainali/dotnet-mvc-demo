using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcDemo.Migrations
{
    public partial class stuffX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClientLogId",
                table: "Clients",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientLogId",
                table: "Clients");
        }
    }
}
