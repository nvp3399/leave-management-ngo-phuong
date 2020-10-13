using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class AddEmployeeEditedAndTimeEditedToHopDongLaoDongTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaNhanVienChinhSuaLanCuoi",
                table: "HopDongLaoDongs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianChinhSuaLanCuoi",
                table: "HopDongLaoDongs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_HopDongLaoDongs_MaNhanVienChinhSuaLanCuoi",
                table: "HopDongLaoDongs",
                column: "MaNhanVienChinhSuaLanCuoi");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongLaoDongs_AspNetUsers_MaNhanVienChinhSuaLanCuoi",
                table: "HopDongLaoDongs",
                column: "MaNhanVienChinhSuaLanCuoi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDongLaoDongs_AspNetUsers_MaNhanVienChinhSuaLanCuoi",
                table: "HopDongLaoDongs");

            migrationBuilder.DropIndex(
                name: "IX_HopDongLaoDongs_MaNhanVienChinhSuaLanCuoi",
                table: "HopDongLaoDongs");

            migrationBuilder.DropColumn(
                name: "MaNhanVienChinhSuaLanCuoi",
                table: "HopDongLaoDongs");

            migrationBuilder.DropColumn(
                name: "ThoiGianChinhSuaLanCuoi",
                table: "HopDongLaoDongs");
        }
    }
}
