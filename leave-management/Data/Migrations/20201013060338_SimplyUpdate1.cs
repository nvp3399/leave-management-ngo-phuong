using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class SimplyUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienHuyHopDong",
                table: "HopDongLaoDongs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDongLaoDongs_MaNhanVienHuyHopDong",
                table: "HopDongLaoDongs",
                column: "MaNhanVienHuyHopDong");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongLaoDongs_AspNetUsers_MaNhanVienHuyHopDong",
                table: "HopDongLaoDongs",
                column: "MaNhanVienHuyHopDong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDongLaoDongs_AspNetUsers_MaNhanVienHuyHopDong",
                table: "HopDongLaoDongs");

            migrationBuilder.DropIndex(
                name: "IX_HopDongLaoDongs_MaNhanVienHuyHopDong",
                table: "HopDongLaoDongs");

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienHuyHopDong",
                table: "HopDongLaoDongs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
