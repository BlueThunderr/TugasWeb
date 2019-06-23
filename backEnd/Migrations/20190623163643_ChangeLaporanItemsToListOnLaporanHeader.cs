using Microsoft.EntityFrameworkCore.Migrations;

namespace backEnd.Migrations
{
    public partial class ChangeLaporanItemsToListOnLaporanHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LaporanItems_LaporanHeaderId",
                table: "LaporanItems");

            migrationBuilder.CreateIndex(
                name: "IX_LaporanItems_LaporanHeaderId",
                table: "LaporanItems",
                column: "LaporanHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LaporanItems_LaporanHeaderId",
                table: "LaporanItems");

            migrationBuilder.CreateIndex(
                name: "IX_LaporanItems_LaporanHeaderId",
                table: "LaporanItems",
                column: "LaporanHeaderId",
                unique: true);
        }
    }
}
