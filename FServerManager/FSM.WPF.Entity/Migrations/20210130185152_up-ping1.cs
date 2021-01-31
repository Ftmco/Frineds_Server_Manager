using Microsoft.EntityFrameworkCore.Migrations;

namespace FSM.WPF.Entity.Migrations
{
    public partial class upping1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PingSum",
                table: "ServerPings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PingSum",
                table: "ServerPings");
        }
    }
}
