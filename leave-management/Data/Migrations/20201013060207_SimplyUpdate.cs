using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class SimplyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_HopDongLaoDongs_MaHopDong",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MaHopDong",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaHopDong",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienPheDuyet",
                table: "YeuCauTamUngLuongs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienPheDuyet",
                table: "YeuCauDatLuongCoBans",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienChiTien",
                table: "PhieuChis",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauTamUngLuongs_MaNhanVienPheDuyet",
                table: "YeuCauTamUngLuongs",
                column: "MaNhanVienPheDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauDatLuongCoBans_MaNhanVienPheDuyet",
                table: "YeuCauDatLuongCoBans",
                column: "MaNhanVienPheDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChis_MaNhanVienChiTien",
                table: "PhieuChis",
                column: "MaNhanVienChiTien");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuChis_AspNetUsers_MaNhanVienChiTien",
                table: "PhieuChis",
                column: "MaNhanVienChiTien",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YeuCauDatLuongCoBans_AspNetUsers_MaNhanVienPheDuyet",
                table: "YeuCauDatLuongCoBans",
                column: "MaNhanVienPheDuyet",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YeuCauTamUngLuongs_AspNetUsers_MaNhanVienPheDuyet",
                table: "YeuCauTamUngLuongs",
                column: "MaNhanVienPheDuyet",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuChis_AspNetUsers_MaNhanVienChiTien",
                table: "PhieuChis");

            migrationBuilder.DropForeignKey(
                name: "FK_YeuCauDatLuongCoBans_AspNetUsers_MaNhanVienPheDuyet",
                table: "YeuCauDatLuongCoBans");

            migrationBuilder.DropForeignKey(
                name: "FK_YeuCauTamUngLuongs_AspNetUsers_MaNhanVienPheDuyet",
                table: "YeuCauTamUngLuongs");

            migrationBuilder.DropIndex(
                name: "IX_YeuCauTamUngLuongs_MaNhanVienPheDuyet",
                table: "YeuCauTamUngLuongs");

            migrationBuilder.DropIndex(
                name: "IX_YeuCauDatLuongCoBans_MaNhanVienPheDuyet",
                table: "YeuCauDatLuongCoBans");

            migrationBuilder.DropIndex(
                name: "IX_PhieuChis_MaNhanVienChiTien",
                table: "PhieuChis");

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienPheDuyet",
                table: "YeuCauTamUngLuongs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienPheDuyet",
                table: "YeuCauDatLuongCoBans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienChiTien",
                table: "PhieuChis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaHopDong",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MaHopDong",
                table: "AspNetUsers",
                column: "MaHopDong");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HopDongLaoDongs_MaHopDong",
                table: "AspNetUsers",
                column: "MaHopDong",
                principalTable: "HopDongLaoDongs",
                principalColumn: "MaHopDong",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
