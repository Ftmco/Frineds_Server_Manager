using Microsoft.EntityFrameworkCore.Migrations;

namespace FSM.WPF.Entity.Migrations
{
    public partial class remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Forgrand",
                table: "ServerPings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Forgrand",
                table: "ServerPings",
                type: "TEXT",
                nullable: true);
        }
    }
}
