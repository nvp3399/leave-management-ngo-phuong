using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class SimplyUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienGuiBanScan",
                table: "HopDongLaoDongs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDongLaoDongs_MaNhanVienGuiBanScan",
                table: "HopDongLaoDongs",
                column: "MaNhanVienGuiBanScan");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongLaoDongs_AspNetUsers_MaNhanVienGuiBanScan",
                table: "HopDongLaoDongs",
                column: "MaNhanVienGuiBanScan",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDongLaoDongs_AspNetUsers_MaNhanVienGuiBanScan",
                table: "HopDongLaoDongs");

            migrationBuilder.DropIndex(
                name: "IX_HopDongLaoDongs_MaNhanVienGuiBanScan",
                table: "HopDongLaoDongs");

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienGuiBanScan",
                table: "HopDongLaoDongs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
