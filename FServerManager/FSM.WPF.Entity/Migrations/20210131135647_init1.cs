using Microsoft.EntityFrameworkCore.Migrations;

namespace FSM.WPF.Entity.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServerId",
                table: "Servers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PingId",
                table: "ServerPings",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Servers",
                newName: "ServerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ServerPings",
                newName: "PingId");
        }
    }
}
