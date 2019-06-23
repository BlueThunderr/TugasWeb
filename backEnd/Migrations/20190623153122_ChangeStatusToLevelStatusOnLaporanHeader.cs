using Microsoft.EntityFrameworkCore.Migrations;

namespace backEnd.Migrations
{
    public partial class ChangeStatusToLevelStatusOnLaporanHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "LaporanHeaders",
                newName: "StatusLevel");

            migrationBuilder.CreateIndex(
                name: "IX_LaporanItems_LaporanHeaderId",
                table: "LaporanItems",
                column: "LaporanHeaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LaporanItems_LaporanHeaders_LaporanHeaderId",
                table: "LaporanItems",
                column: "LaporanHeaderId",
                principalTable: "LaporanHeaders",
                principalColumn: "LaporanHeaderId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaporanItems_LaporanHeaders_LaporanHeaderId",
                table: "LaporanItems");

            migrationBuilder.DropIndex(
                name: "IX_LaporanItems_LaporanHeaderId",
                table: "LaporanItems");

            migrationBuilder.RenameColumn(
                name: "StatusLevel",
                table: "LaporanHeaders",
                newName: "Status");
        }
    }
}
