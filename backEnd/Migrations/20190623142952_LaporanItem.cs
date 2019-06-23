using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backEnd.Migrations
{
    public partial class LaporanItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaporanItems",
                columns: table => new
                {
                    LaporanItemId = table.Column<Guid>(nullable: false),
                    LaporanHeaderId = table.Column<Guid>(nullable: false),
                    Keterangan = table.Column<string>(nullable: true),
                    TglBuat = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    IsDeteled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaporanItems", x => x.LaporanItemId);
                    table.ForeignKey(
                        name: "FK_LaporanItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaporanItems_UserId",
                table: "LaporanItems",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaporanItems");
        }
    }
}
