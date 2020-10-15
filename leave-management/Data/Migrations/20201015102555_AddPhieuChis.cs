using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class AddPhieuChis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuChis");

            migrationBuilder.CreateTable(
                name: "PhieuChi_LuongCuoiThangs",
                columns: table => new
                {
                    MaPhieuChi = table.Column<string>(maxLength: 450, nullable: false),
                    ThoiGianXuatPhieuChi = table.Column<DateTime>(nullable: false),
                    MaNhanVienChiTien = table.Column<string>(nullable: true),
                    ThoiGianChiTien = table.Column<DateTime>(nullable: false),
                    MaNhanVienThuHoi = table.Column<string>(nullable: true),
                    ThoiGianThuHoi = table.Column<DateTime>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true),
                    MaNhanVienXuatLuong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuChi_LuongCuoiThangs", x => x.MaPhieuChi);
                    table.ForeignKey(
                        name: "FK_PhieuChi_LuongCuoiThangs_AspNetUsers_MaNhanVienChiTien",
                        column: x => x.MaNhanVienChiTien,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuChi_LuongCuoiThangs_AspNetUsers_MaNhanVienThuHoi",
                        column: x => x.MaNhanVienThuHoi,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuChi_LuongCuoiThangs_AspNetUsers_MaNhanVienXuatLuong",
                        column: x => x.MaNhanVienXuatLuong,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuChi_TamUngLuongs",
                columns: table => new
                {
                    MaPhieuChi = table.Column<string>(maxLength: 450, nullable: false),
                    ThoiGianXuatPhieuChi = table.Column<DateTime>(nullable: false),
                    MaNhanVienChiTien = table.Column<string>(nullable: true),
                    ThoiGianChiTien = table.Column<DateTime>(nullable: false),
                    MaNhanVienThuHoi = table.Column<string>(nullable: true),
                    ThoiGianThuHoi = table.Column<DateTime>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true),
                    MaYeuCauTamUngLuong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuChi_TamUngLuongs", x => x.MaPhieuChi);
                    table.ForeignKey(
                        name: "FK_PhieuChi_TamUngLuongs_AspNetUsers_MaNhanVienChiTien",
                        column: x => x.MaNhanVienChiTien,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuChi_TamUngLuongs_AspNetUsers_MaNhanVienThuHoi",
                        column: x => x.MaNhanVienThuHoi,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuChi_TamUngLuongs_YeuCauTamUngLuongs_MaYeuCauTamUngLuong",
                        column: x => x.MaYeuCauTamUngLuong,
                        principalTable: "YeuCauTamUngLuongs",
                        principalColumn: "MaYeuCau",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChi_LuongCuoiThangs_MaNhanVienChiTien",
                table: "PhieuChi_LuongCuoiThangs",
                column: "MaNhanVienChiTien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChi_LuongCuoiThangs_MaNhanVienThuHoi",
                table: "PhieuChi_LuongCuoiThangs",
                column: "MaNhanVienThuHoi");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChi_LuongCuoiThangs_MaNhanVienXuatLuong",
                table: "PhieuChi_LuongCuoiThangs",
                column: "MaNhanVienXuatLuong");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChi_TamUngLuongs_MaNhanVienChiTien",
                table: "PhieuChi_TamUngLuongs",
                column: "MaNhanVienChiTien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChi_TamUngLuongs_MaNhanVienThuHoi",
                table: "PhieuChi_TamUngLuongs",
                column: "MaNhanVienThuHoi");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChi_TamUngLuongs_MaYeuCauTamUngLuong",
                table: "PhieuChi_TamUngLuongs",
                column: "MaYeuCauTamUngLuong");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuChi_LuongCuoiThangs");

            migrationBuilder.DropTable(
                name: "PhieuChi_TamUngLuongs");

            migrationBuilder.CreateTable(
                name: "PhieuChis",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThoiGianXuatPhieuChi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LyDoChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaNhanVienChiTien = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaNhanVienXuatPhieu = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NamTinhLuong = table.Column<int>(type: "int", nullable: false),
                    SoTienChi = table.Column<int>(type: "int", nullable: false),
                    ThangTinhLuong = table.Column<byte>(type: "tinyint", nullable: false),
                    TrangThaiPhieuChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuChis", x => new { x.MaNhanVien, x.ThoiGianXuatPhieuChi });
                    table.ForeignKey(
                        name: "FK_PhieuChis_AspNetUsers_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuChis_AspNetUsers_MaNhanVienChiTien",
                        column: x => x.MaNhanVienChiTien,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuChis_AspNetUsers_MaNhanVienXuatPhieu",
                        column: x => x.MaNhanVienXuatPhieu,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChis_MaNhanVienChiTien",
                table: "PhieuChis",
                column: "MaNhanVienChiTien");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChis_MaNhanVienXuatPhieu",
                table: "PhieuChis",
                column: "MaNhanVienXuatPhieu");
        }
    }
}
