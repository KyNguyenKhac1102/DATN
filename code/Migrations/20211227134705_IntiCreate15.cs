using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class IntiCreate15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_MaDoiTuong",
                table: "StudentInfos");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_MaDoiTuong",
                table: "StudentInfos",
                column: "MaDoiTuong");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_MaDoiTuong",
                table: "StudentInfos");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_MaDoiTuong",
                table: "StudentInfos",
                column: "MaDoiTuong",
                unique: true,
                filter: "[MaDoiTuong] IS NOT NULL");
        }
    }
}
