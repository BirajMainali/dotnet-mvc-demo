using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcDemo.Migrations
{
    public partial class stuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientLogs_Clients_ClientId",
                table: "ClientLogs");

            migrationBuilder.DropIndex(
                name: "IX_ClientLogs_ClientId",
                table: "ClientLogs");

            migrationBuilder.AlterColumn<long>(
                name: "ClientId",
                table: "ClientLogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId1",
                table: "ClientLogs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientLogs_ClientId1",
                table: "ClientLogs",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientLogs_Clients_ClientId1",
                table: "ClientLogs",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientLogs_Clients_ClientId1",
                table: "ClientLogs");

            migrationBuilder.DropIndex(
                name: "IX_ClientLogs_ClientId1",
                table: "ClientLogs");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "ClientLogs");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "ClientLogs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLogs_ClientId",
                table: "ClientLogs",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientLogs_Clients_ClientId",
                table: "ClientLogs",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
