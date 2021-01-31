using Microsoft.EntityFrameworkCore.Migrations;

namespace FSM.WPF.Entity.Migrations
{
    public partial class upping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Avrage",
                table: "ServerPings",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avrage",
                table: "ServerPings");
        }
    }
}
