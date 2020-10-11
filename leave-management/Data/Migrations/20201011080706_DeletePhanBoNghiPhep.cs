using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class DeletePhanBoNghiPhep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhanBoNghiPhep");

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienChuTheHopDong",
                table: "DanhSachHopDongLaoDong",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachHopDongLaoDong_MaNhanVienChuTheHopDong",
                table: "DanhSachHopDongLaoDong",
                column: "MaNhanVienChuTheHopDong");

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachHopDongLaoDong_AspNetUsers_MaNhanVienChuTheHopDong",
                table: "DanhSachHopDongLaoDong",
                column: "MaNhanVienChuTheHopDong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachHopDongLaoDong_AspNetUsers_MaNhanVienChuTheHopDong",
                table: "DanhSachHopDongLaoDong");

            migrationBuilder.DropIndex(
                name: "IX_DanhSachHopDongLaoDong_MaNhanVienChuTheHopDong",
                table: "DanhSachHopDongLaoDong");

            migrationBuilder.AlterColumn<string>(
                name: "MaNhanVienChuTheHopDong",
                table: "DanhSachHopDongLaoDong",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PhanBoNghiPhep",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaLoaiNghiPhep = table.Column<int>(type: "int", nullable: false),
                    MaNhanVienPhanBo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NgayPhanBo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanBoNghiPhep", x => new { x.MaNhanVien, x.MaLoaiNghiPhep });
                    table.ForeignKey(
                        name: "FK_PhanBoNghiPhep_LeaveTypes_MaLoaiNghiPhep",
                        column: x => x.MaLoaiNghiPhep,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanBoNghiPhep_AspNetUsers_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanBoNghiPhep_AspNetUsers_MaNhanVienPhanBo",
                        column: x => x.MaNhanVienPhanBo,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhanBoNghiPhep_MaLoaiNghiPhep",
                table: "PhanBoNghiPhep",
                column: "MaLoaiNghiPhep");

            migrationBuilder.CreateIndex(
                name: "IX_PhanBoNghiPhep_MaNhanVienPhanBo",
                table: "PhanBoNghiPhep",
                column: "MaNhanVienPhanBo");
        }
    }
}
