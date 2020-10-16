using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class jkfgalk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuChi_NKLVs",
                table: "PhieuChi_NKLVs");

            

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuChi_NKLVs",
                table: "PhieuChi_NKLVs",
                columns: new[] { "MaNhanVien_NKLV", "MaPhieuChi", "ThoiGianBatDau_NKLV" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuChi_NKLVs",
                table: "PhieuChi_NKLVs");

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVien_NKLV",
                table: "PhieuChi_NKLVs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuChi_NKLVs",
                table: "PhieuChi_NKLVs",
                column: "MaPhieuChi");
        }
    }
}
