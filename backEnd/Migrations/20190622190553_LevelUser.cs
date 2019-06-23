using Microsoft.EntityFrameworkCore.Migrations;

namespace backEnd.Migrations
{
    public partial class LevelUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "level",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "level",
                table: "Users");
        }
    }
}
