using Microsoft.EntityFrameworkCore.Migrations;

namespace project.Migrations
{
    public partial class IntiCreate16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_MaKhuVuc",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_Tinh10Id",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_Tinh11Id",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_Tinh12Id",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_TruongLop10Id",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_TruongLop11Id",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_TruongLop12Id",
                table: "StudentInfos");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_MaKhuVuc",
                table: "StudentInfos",
                column: "MaKhuVuc");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_Tinh10Id",
                table: "StudentInfos",
                column: "Tinh10Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_Tinh11Id",
                table: "StudentInfos",
                column: "Tinh11Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_Tinh12Id",
                table: "StudentInfos",
                column: "Tinh12Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_TruongLop10Id",
                table: "StudentInfos",
                column: "TruongLop10Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_TruongLop11Id",
                table: "StudentInfos",
                column: "TruongLop11Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_TruongLop12Id",
                table: "StudentInfos",
                column: "TruongLop12Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_MaKhuVuc",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_Tinh10Id",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_Tinh11Id",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_Tinh12Id",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_TruongLop10Id",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_TruongLop11Id",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_TruongLop12Id",
                table: "StudentInfos");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_MaKhuVuc",
                table: "StudentInfos",
                column: "MaKhuVuc",
                unique: true,
                filter: "[MaKhuVuc] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_Tinh10Id",
                table: "StudentInfos",
                column: "Tinh10Id",
                unique: true,
                filter: "[Tinh10Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_Tinh11Id",
                table: "StudentInfos",
                column: "Tinh11Id",
                unique: true,
                filter: "[Tinh11Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_Tinh12Id",
                table: "StudentInfos",
                column: "Tinh12Id",
                unique: true,
                filter: "[Tinh12Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_TruongLop10Id",
                table: "StudentInfos",
                column: "TruongLop10Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_TruongLop11Id",
                table: "StudentInfos",
                column: "TruongLop11Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_TruongLop12Id",
                table: "StudentInfos",
                column: "TruongLop12Id",
                unique: true);
        }
    }
}
