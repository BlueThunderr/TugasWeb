using Microsoft.EntityFrameworkCore.Migrations;

namespace backEnd.Migrations
{
    public partial class ChangeStatusLevelToStatusLaporanOnLaporanHeaders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusLevel",
                table: "LaporanHeaders",
                newName: "StatusLaporan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusLaporan",
                table: "LaporanHeaders",
                newName: "StatusLevel");
        }
    }
}
