using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backEnd.Migrations
{
    public partial class LaporanHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaporanHeaders",
                columns: table => new
                {
                    LaporanHeaderId = table.Column<Guid>(nullable: false),
                    JudulLaporan = table.Column<string>(nullable: true),
                    Keterangan = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    TglBuat = table.Column<DateTime>(nullable: false),
                    TglSelesai = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaporanHeaders", x => x.LaporanHeaderId);
                    table.ForeignKey(
                        name: "FK_LaporanHeaders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaporanHeaders_UserId",
                table: "LaporanHeaders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaporanHeaders");
        }
    }
}
