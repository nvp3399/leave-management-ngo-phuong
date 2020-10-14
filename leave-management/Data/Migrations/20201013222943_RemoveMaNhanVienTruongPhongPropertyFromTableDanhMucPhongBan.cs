using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class RemoveMaNhanVienTruongPhongPropertyFromTableDanhMucPhongBan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhongBans_AspNetUsers_MaNhanVienTruongPhong",
                table: "DanhMucPhongBans");

            migrationBuilder.DropIndex(
                name: "IX_DanhMucPhongBans_MaNhanVienTruongPhong",
                table: "DanhMucPhongBans");

            migrationBuilder.DropColumn(
                name: "MaNhanVienTruongPhong",
                table: "DanhMucPhongBans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaNhanVienTruongPhong",
                table: "DanhMucPhongBans",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucPhongBans_MaNhanVienTruongPhong",
                table: "DanhMucPhongBans",
                column: "MaNhanVienTruongPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhongBans_AspNetUsers_MaNhanVienTruongPhong",
                table: "DanhMucPhongBans",
                column: "MaNhanVienTruongPhong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
