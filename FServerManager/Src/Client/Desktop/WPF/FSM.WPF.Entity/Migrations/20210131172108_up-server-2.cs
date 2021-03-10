using Microsoft.EntityFrameworkCore.Migrations;

namespace FSM.WPF.Entity.Migrations
{
    public partial class upserver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "ServerPings",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "ServerPings");
        }
    }
}
