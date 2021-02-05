using Microsoft.EntityFrameworkCore.Migrations;

namespace FSM.WPF.Entity.Migrations
{
    public partial class upservers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Servers",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "Descriptiion",
                table: "Servers",
                newName: "ServerIpAddress");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Servers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Servers");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Servers",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ServerIpAddress",
                table: "Servers",
                newName: "Descriptiion");
        }
    }
}
