using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class randomAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaNhanVienChinhSuaLanCuoi",
                table: "GiayToTuyThans",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ThoiGianChinhSuaLanCuoi",
                table: "GiayToTuyThans",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_GiayToTuyThans_MaNhanVienChinhSuaLanCuoi",
                table: "GiayToTuyThans",
                column: "MaNhanVienChinhSuaLanCuoi");

            migrationBuilder.AddForeignKey(
                name: "FK_GiayToTuyThans_AspNetUsers_MaNhanVienChinhSuaLanCuoi",
                table: "GiayToTuyThans",
                column: "MaNhanVienChinhSuaLanCuoi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiayToTuyThans_AspNetUsers_MaNhanVienChinhSuaLanCuoi",
                table: "GiayToTuyThans");

            migrationBuilder.DropIndex(
                name: "IX_GiayToTuyThans_MaNhanVienChinhSuaLanCuoi",
                table: "GiayToTuyThans");

            migrationBuilder.DropColumn(
                name: "MaNhanVienChinhSuaLanCuoi",
                table: "GiayToTuyThans");

            migrationBuilder.DropColumn(
                name: "ThoiGianChinhSuaLanCuoi",
                table: "GiayToTuyThans");
        }
    }
}
