using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class AddNhanVienChinhSuaVaThoiGianChinhSuaLanCuoiVaoMauHopDongLaoDong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaNhanVienChinhSuaLanCuoi",
                table: "MauHopDongs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianChinhSuaLanCuoi",
                table: "MauHopDongs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_MauHopDongs_MaNhanVienChinhSuaLanCuoi",
                table: "MauHopDongs",
                column: "MaNhanVienChinhSuaLanCuoi");

            migrationBuilder.AddForeignKey(
                name: "FK_MauHopDongs_AspNetUsers_MaNhanVienChinhSuaLanCuoi",
                table: "MauHopDongs",
                column: "MaNhanVienChinhSuaLanCuoi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MauHopDongs_AspNetUsers_MaNhanVienChinhSuaLanCuoi",
                table: "MauHopDongs");

            migrationBuilder.DropIndex(
                name: "IX_MauHopDongs_MaNhanVienChinhSuaLanCuoi",
                table: "MauHopDongs");

            migrationBuilder.DropColumn(
                name: "MaNhanVienChinhSuaLanCuoi",
                table: "MauHopDongs");

            migrationBuilder.DropColumn(
                name: "ThoiGianChinhSuaLanCuoi",
                table: "MauHopDongs");
        }
    }
}
