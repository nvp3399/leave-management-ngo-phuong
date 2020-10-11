using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class InstallFullDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaNhanVienTao",
                table: "LeaveTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaNhanVienPhanBo",
                table: "LeaveAllocations",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "DiaChiLienLac",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaChiTamTru",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GioiTinh",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiNhanVien",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaChucVu",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaChuyenMon",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaHopDong",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaNhanVienThemVaoHeThong",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaPhongBan",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaSoThue",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MucLuongCoBan",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiSinh",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ViTriLuuAnhDaiDien",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "DanhSachDanhMucChucVu",
                columns: table => new
                {
                    MaChucVu = table.Column<string>(nullable: false),
                    TenChucVu = table.Column<string>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachDanhMucChucVu", x => x.MaChucVu);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachDanhMucChuyenMon",
                columns: table => new
                {
                    MaChuyenMon = table.Column<string>(nullable: false),
                    TenChuyenMon = table.Column<string>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachDanhMucChuyenMon", x => x.MaChuyenMon);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachDanhMucPhongBan",
                columns: table => new
                {
                    MaPhongBan = table.Column<string>(nullable: false),
                    TenPhongBan = table.Column<string>(nullable: false),
                    MaNhanVienTruongPhong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachDanhMucPhongBan", x => x.MaPhongBan);
                    table.ForeignKey(
                        name: "FK_DanhSachDanhMucPhongBan_AspNetUsers_MaNhanVienTruongPhong",
                        column: x => x.MaNhanVienTruongPhong,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachLoaiGiayToTuyThan",
                columns: table => new
                {
                    MaLoaiGiayTo = table.Column<string>(nullable: false),
                    TenLoaiGiayTo = table.Column<string>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachLoaiGiayToTuyThan", x => x.MaLoaiGiayTo);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachLoaiHopDong",
                columns: table => new
                {
                    MaLoaiHopDong = table.Column<string>(nullable: false),
                    TenLoai = table.Column<string>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachLoaiHopDong", x => x.MaLoaiHopDong);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachLoaiLichBieu",
                columns: table => new
                {
                    MaLoai = table.Column<string>(nullable: false),
                    TenLoaiLichBieu = table.Column<string>(nullable: false),
                    HeSoLuongCoBan = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachLoaiLichBieu", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachLuongTheoThang",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(nullable: false),
                    Nam = table.Column<int>(nullable: false),
                    Thang = table.Column<byte>(nullable: false),
                    SoTienThuongThem = table.Column<int>(nullable: false),
                    SoTienPhuCap = table.Column<int>(nullable: false),
                    TongLuongCoBan = table.Column<int>(nullable: false),
                    TrangThaiXuatLuong = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachLuongTheoThang", x => new { x.MaNhanVien, x.Nam, x.Thang });
                    table.ForeignKey(
                        name: "FK_DanhSachLuongTheoThang_AspNetUsers_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachPhieuChi",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(nullable: false),
                    ThoiGianXuatPhieuChi = table.Column<DateTime>(nullable: false),
                    SoTienChi = table.Column<int>(nullable: false),
                    LyDoChi = table.Column<string>(nullable: false),
                    MaNhanVienXuatPhieu = table.Column<string>(nullable: true),
                    NamTinhLuong = table.Column<int>(nullable: false),
                    ThangTinhLuong = table.Column<byte>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true),
                    TrangThaiPhieuChi = table.Column<string>(nullable: false),
                    MaNhanVienChiTien = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachPhieuChi", x => new { x.MaNhanVien, x.ThoiGianXuatPhieuChi });
                    table.ForeignKey(
                        name: "FK_DanhSachPhieuChi_AspNetUsers_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhSachPhieuChi_AspNetUsers_MaNhanVienXuatPhieu",
                        column: x => x.MaNhanVienXuatPhieu,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachYeuCauDatLuongCoBan",
                columns: table => new
                {
                    MaYeuCau = table.Column<string>(nullable: false),
                    MaNhanVienGuiYeuCau = table.Column<string>(nullable: true),
                    MaNhanVienDuocDatLuong = table.Column<string>(nullable: true),
                    MucLuongCoBan = table.Column<int>(nullable: false),
                    ThoiGianGuiYeuCau = table.Column<DateTime>(nullable: false),
                    ThoiGianPheDuyet = table.Column<DateTime>(nullable: false),
                    MaNhanVienPheDuyet = table.Column<string>(nullable: true),
                    TinhTrangPheDuyet = table.Column<string>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachYeuCauDatLuongCoBan", x => x.MaYeuCau);
                    table.ForeignKey(
                        name: "FK_DanhSachYeuCauDatLuongCoBan_AspNetUsers_MaNhanVienDuocDatLuong",
                        column: x => x.MaNhanVienDuocDatLuong,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DanhSachYeuCauDatLuongCoBan_AspNetUsers_MaNhanVienGuiYeuCau",
                        column: x => x.MaNhanVienGuiYeuCau,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachYeuCauTamUngLuong",
                columns: table => new
                {
                    MaYeuCau = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVienGuiYeuCau = table.Column<string>(nullable: true),
                    NgayGuiYeuCau = table.Column<DateTime>(nullable: false),
                    MaNhanVienPheDuyet = table.Column<string>(nullable: true),
                    NgayPheDuyet = table.Column<DateTime>(nullable: false),
                    SoTienTamUng = table.Column<int>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true),
                    TinhTrangPheDuyet = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachYeuCauTamUngLuong", x => x.MaYeuCau);
                    table.ForeignKey(
                        name: "FK_DanhSachYeuCauTamUngLuong_AspNetUsers_MaNhanVienGuiYeuCau",
                        column: x => x.MaNhanVienGuiYeuCau,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhanBoNghiPhep",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(nullable: false),
                    MaLoaiNghiPhep = table.Column<int>(nullable: false),
                    MaNhanVienPhanBo = table.Column<string>(nullable: true),
                    NgayPhanBo = table.Column<DateTime>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "DanhSachGiayToTuyThan",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(nullable: false),
                    MaLoaiGiayTo = table.Column<string>(nullable: false),
                    NgayLuuVaoHeThong = table.Column<DateTime>(nullable: false),
                    MaNhanVienGui = table.Column<string>(nullable: true),
                    ViTriLuuBanScan = table.Column<string>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachGiayToTuyThan", x => new { x.MaNhanVien, x.MaLoaiGiayTo });
                    table.ForeignKey(
                        name: "FK_DanhSachGiayToTuyThan_DanhSachLoaiGiayToTuyThan_MaLoaiGiayTo",
                        column: x => x.MaLoaiGiayTo,
                        principalTable: "DanhSachLoaiGiayToTuyThan",
                        principalColumn: "MaLoaiGiayTo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhSachGiayToTuyThan_AspNetUsers_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhSachGiayToTuyThan_AspNetUsers_MaNhanVienGui",
                        column: x => x.MaNhanVienGui,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachMauHopDong",
                columns: table => new
                {
                    MaMauHopDong = table.Column<string>(nullable: false),
                    TenMauHopDong = table.Column<string>(nullable: false),
                    MaNhanVienLuuMauHopDong = table.Column<string>(nullable: true),
                    NgayGuiMauHopDong = table.Column<DateTime>(nullable: false),
                    ViTriLuuMauHopDong = table.Column<string>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true),
                    MaLoaiHopDong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachMauHopDong", x => x.MaMauHopDong);
                    table.ForeignKey(
                        name: "FK_DanhSachMauHopDong_DanhSachLoaiHopDong_MaLoaiHopDong",
                        column: x => x.MaLoaiHopDong,
                        principalTable: "DanhSachLoaiHopDong",
                        principalColumn: "MaLoaiHopDong",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DanhSachMauHopDong_AspNetUsers_MaNhanVienLuuMauHopDong",
                        column: x => x.MaNhanVienLuuMauHopDong,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachNhatKyLamViec",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(nullable: false),
                    MaLoaiLichBieu = table.Column<string>(nullable: true),
                    SoTienThuongThem = table.Column<int>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachNhatKyLamViec", x => new { x.MaNhanVien, x.ThoiGianBatDau, x.ThoiGianKetThuc });
                    table.ForeignKey(
                        name: "FK_DanhSachNhatKyLamViec_DanhSachLoaiLichBieu_MaLoaiLichBieu",
                        column: x => x.MaLoaiLichBieu,
                        principalTable: "DanhSachLoaiLichBieu",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DanhSachNhatKyLamViec_AspNetUsers_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanhSachHopDongLaoDong",
                columns: table => new
                {
                    MaHopDong = table.Column<string>(nullable: false),
                    NgayKyKet = table.Column<DateTime>(nullable: false),
                    NgayBatDau = table.Column<DateTime>(nullable: false),
                    NgayKetThuc = table.Column<DateTime>(nullable: false),
                    ViTriLuuBanScan = table.Column<string>(nullable: false),
                    NgayGuiBanScan = table.Column<DateTime>(nullable: false),
                    MaNhanVienGuiBanScan = table.Column<string>(nullable: true),
                    MaNhanVienChuTheHopDong = table.Column<string>(nullable: true),
                    MaMauHopDong = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    NgayHopDongBiHuy = table.Column<DateTime>(nullable: false),
                    MaNhanVienHuyHopDong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachHopDongLaoDong", x => x.MaHopDong);
                    table.ForeignKey(
                        name: "FK_DanhSachHopDongLaoDong_DanhSachMauHopDong_MaMauHopDong",
                        column: x => x.MaMauHopDong,
                        principalTable: "DanhSachMauHopDong",
                        principalColumn: "MaMauHopDong",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypes_MaNhanVienTao",
                table: "LeaveTypes",
                column: "MaNhanVienTao");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveAllocations_MaNhanVienPhanBo",
                table: "LeaveAllocations",
                column: "MaNhanVienPhanBo");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MaChucVu",
                table: "AspNetUsers",
                column: "MaChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MaChuyenMon",
                table: "AspNetUsers",
                column: "MaChuyenMon");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MaHopDong",
                table: "AspNetUsers",
                column: "MaHopDong");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MaNhanVienThemVaoHeThong",
                table: "AspNetUsers",
                column: "MaNhanVienThemVaoHeThong");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MaPhongBan",
                table: "AspNetUsers",
                column: "MaPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachDanhMucPhongBan_MaNhanVienTruongPhong",
                table: "DanhSachDanhMucPhongBan",
                column: "MaNhanVienTruongPhong");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachGiayToTuyThan_MaLoaiGiayTo",
                table: "DanhSachGiayToTuyThan",
                column: "MaLoaiGiayTo");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachGiayToTuyThan_MaNhanVienGui",
                table: "DanhSachGiayToTuyThan",
                column: "MaNhanVienGui");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachHopDongLaoDong_MaMauHopDong",
                table: "DanhSachHopDongLaoDong",
                column: "MaMauHopDong");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachMauHopDong_MaLoaiHopDong",
                table: "DanhSachMauHopDong",
                column: "MaLoaiHopDong");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachMauHopDong_MaNhanVienLuuMauHopDong",
                table: "DanhSachMauHopDong",
                column: "MaNhanVienLuuMauHopDong");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachNhatKyLamViec_MaLoaiLichBieu",
                table: "DanhSachNhatKyLamViec",
                column: "MaLoaiLichBieu");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachPhieuChi_MaNhanVienXuatPhieu",
                table: "DanhSachPhieuChi",
                column: "MaNhanVienXuatPhieu");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachYeuCauDatLuongCoBan_MaNhanVienDuocDatLuong",
                table: "DanhSachYeuCauDatLuongCoBan",
                column: "MaNhanVienDuocDatLuong");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachYeuCauDatLuongCoBan_MaNhanVienGuiYeuCau",
                table: "DanhSachYeuCauDatLuongCoBan",
                column: "MaNhanVienGuiYeuCau");

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachYeuCauTamUngLuong_MaNhanVienGuiYeuCau",
                table: "DanhSachYeuCauTamUngLuong",
                column: "MaNhanVienGuiYeuCau");

            migrationBuilder.CreateIndex(
                name: "IX_PhanBoNghiPhep_MaLoaiNghiPhep",
                table: "PhanBoNghiPhep",
                column: "MaLoaiNghiPhep");

            migrationBuilder.CreateIndex(
                name: "IX_PhanBoNghiPhep_MaNhanVienPhanBo",
                table: "PhanBoNghiPhep",
                column: "MaNhanVienPhanBo");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DanhSachDanhMucChucVu_MaChucVu",
                table: "AspNetUsers",
                column: "MaChucVu",
                principalTable: "DanhSachDanhMucChucVu",
                principalColumn: "MaChucVu",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DanhSachDanhMucChuyenMon_MaChuyenMon",
                table: "AspNetUsers",
                column: "MaChuyenMon",
                principalTable: "DanhSachDanhMucChuyenMon",
                principalColumn: "MaChuyenMon",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DanhSachHopDongLaoDong_MaHopDong",
                table: "AspNetUsers",
                column: "MaHopDong",
                principalTable: "DanhSachHopDongLaoDong",
                principalColumn: "MaHopDong",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_MaNhanVienThemVaoHeThong",
                table: "AspNetUsers",
                column: "MaNhanVienThemVaoHeThong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DanhSachDanhMucPhongBan_MaPhongBan",
                table: "AspNetUsers",
                column: "MaPhongBan",
                principalTable: "DanhSachDanhMucPhongBan",
                principalColumn: "MaPhongBan",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveAllocations_AspNetUsers_MaNhanVienPhanBo",
                table: "LeaveAllocations",
                column: "MaNhanVienPhanBo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveTypes_AspNetUsers_MaNhanVienTao",
                table: "LeaveTypes",
                column: "MaNhanVienTao",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DanhSachDanhMucChucVu_MaChucVu",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DanhSachDanhMucChuyenMon_MaChuyenMon",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DanhSachHopDongLaoDong_MaHopDong",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_MaNhanVienThemVaoHeThong",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DanhSachDanhMucPhongBan_MaPhongBan",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveAllocations_AspNetUsers_MaNhanVienPhanBo",
                table: "LeaveAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveTypes_AspNetUsers_MaNhanVienTao",
                table: "LeaveTypes");

            migrationBuilder.DropTable(
                name: "DanhSachDanhMucChucVu");

            migrationBuilder.DropTable(
                name: "DanhSachDanhMucChuyenMon");

            migrationBuilder.DropTable(
                name: "DanhSachDanhMucPhongBan");

            migrationBuilder.DropTable(
                name: "DanhSachGiayToTuyThan");

            migrationBuilder.DropTable(
                name: "DanhSachHopDongLaoDong");

            migrationBuilder.DropTable(
                name: "DanhSachLuongTheoThang");

            migrationBuilder.DropTable(
                name: "DanhSachNhatKyLamViec");

            migrationBuilder.DropTable(
                name: "DanhSachPhieuChi");

            migrationBuilder.DropTable(
                name: "DanhSachYeuCauDatLuongCoBan");

            migrationBuilder.DropTable(
                name: "DanhSachYeuCauTamUngLuong");

            migrationBuilder.DropTable(
                name: "PhanBoNghiPhep");

            migrationBuilder.DropTable(
                name: "DanhSachLoaiGiayToTuyThan");

            migrationBuilder.DropTable(
                name: "DanhSachMauHopDong");

            migrationBuilder.DropTable(
                name: "DanhSachLoaiLichBieu");

            migrationBuilder.DropTable(
                name: "DanhSachLoaiHopDong");

            migrationBuilder.DropIndex(
                name: "IX_LeaveTypes_MaNhanVienTao",
                table: "LeaveTypes");

            migrationBuilder.DropIndex(
                name: "IX_LeaveAllocations_MaNhanVienPhanBo",
                table: "LeaveAllocations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MaChucVu",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MaChuyenMon",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MaHopDong",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MaNhanVienThemVaoHeThong",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MaPhongBan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaNhanVienTao",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "MaNhanVienPhanBo",
                table: "LeaveAllocations");

            migrationBuilder.DropColumn(
                name: "DiaChiLienLac",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DiaChiTamTru",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GioiTinh",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LoaiNhanVien",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaChucVu",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaChuyenMon",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaHopDong",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaNhanVienThemVaoHeThong",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaPhongBan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaSoThue",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MucLuongCoBan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NoiSinh",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ViTriLuuAnhDaiDien",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
