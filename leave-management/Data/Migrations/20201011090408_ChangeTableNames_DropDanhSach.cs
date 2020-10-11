using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class ChangeTableNames_DropDanhSach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_AspNetUsers_DanhSachDanhMucPhongBan_MaPhongBan",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachDanhMucPhongBan_AspNetUsers_MaNhanVienTruongPhong",
                table: "DanhSachDanhMucPhongBan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachGiayToTuyThan_DanhSachLoaiGiayToTuyThan_MaLoaiGiayTo",
                table: "DanhSachGiayToTuyThan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachGiayToTuyThan_AspNetUsers_MaNhanVien",
                table: "DanhSachGiayToTuyThan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachGiayToTuyThan_AspNetUsers_MaNhanVienGui",
                table: "DanhSachGiayToTuyThan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachHopDongLaoDong_DanhSachMauHopDong_MaMauHopDong",
                table: "DanhSachHopDongLaoDong");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachHopDongLaoDong_AspNetUsers_MaNhanVienChuTheHopDong",
                table: "DanhSachHopDongLaoDong");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachLuongTheoThang_AspNetUsers_MaNhanVien",
                table: "DanhSachLuongTheoThang");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachMauHopDong_DanhSachLoaiHopDong_MaLoaiHopDong",
                table: "DanhSachMauHopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachMauHopDong_AspNetUsers_MaNhanVienLuuMauHopDong",
                table: "DanhSachMauHopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachNhatKyLamViec_DanhSachLoaiLichBieu_MaLoaiLichBieu",
                table: "DanhSachNhatKyLamViec");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachNhatKyLamViec_AspNetUsers_MaNhanVien",
                table: "DanhSachNhatKyLamViec");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachPhieuChi_AspNetUsers_MaNhanVien",
                table: "DanhSachPhieuChi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachPhieuChi_AspNetUsers_MaNhanVienXuatPhieu",
                table: "DanhSachPhieuChi");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachYeuCauDatLuongCoBan_AspNetUsers_MaNhanVienDuocDatLuong",
                table: "DanhSachYeuCauDatLuongCoBan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachYeuCauDatLuongCoBan_AspNetUsers_MaNhanVienGuiYeuCau",
                table: "DanhSachYeuCauDatLuongCoBan");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhSachYeuCauTamUngLuong_AspNetUsers_MaNhanVienGuiYeuCau",
                table: "DanhSachYeuCauTamUngLuong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachYeuCauTamUngLuong",
                table: "DanhSachYeuCauTamUngLuong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachYeuCauDatLuongCoBan",
                table: "DanhSachYeuCauDatLuongCoBan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachPhieuChi",
                table: "DanhSachPhieuChi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachNhatKyLamViec",
                table: "DanhSachNhatKyLamViec");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachMauHopDong",
                table: "DanhSachMauHopDong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachLuongTheoThang",
                table: "DanhSachLuongTheoThang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachLoaiLichBieu",
                table: "DanhSachLoaiLichBieu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachLoaiHopDong",
                table: "DanhSachLoaiHopDong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachLoaiGiayToTuyThan",
                table: "DanhSachLoaiGiayToTuyThan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachHopDongLaoDong",
                table: "DanhSachHopDongLaoDong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachGiayToTuyThan",
                table: "DanhSachGiayToTuyThan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachDanhMucPhongBan",
                table: "DanhSachDanhMucPhongBan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachDanhMucChuyenMon",
                table: "DanhSachDanhMucChuyenMon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhSachDanhMucChucVu",
                table: "DanhSachDanhMucChucVu");

            migrationBuilder.RenameTable(
                name: "DanhSachYeuCauTamUngLuong",
                newName: "YeuCauTamUngLuongs");

            migrationBuilder.RenameTable(
                name: "DanhSachYeuCauDatLuongCoBan",
                newName: "YeuCauDatLuongCoBans");

            migrationBuilder.RenameTable(
                name: "DanhSachPhieuChi",
                newName: "PhieuChis");

            migrationBuilder.RenameTable(
                name: "DanhSachNhatKyLamViec",
                newName: "NhatKyLamViecs");

            migrationBuilder.RenameTable(
                name: "DanhSachMauHopDong",
                newName: "MauHopDongs");

            migrationBuilder.RenameTable(
                name: "DanhSachLuongTheoThang",
                newName: "LuongTheoThangs");

            migrationBuilder.RenameTable(
                name: "DanhSachLoaiLichBieu",
                newName: "LoaiLichBieus");

            migrationBuilder.RenameTable(
                name: "DanhSachLoaiHopDong",
                newName: "LoaiHopDongs");

            migrationBuilder.RenameTable(
                name: "DanhSachLoaiGiayToTuyThan",
                newName: "LoaiGiayToTuyThans");

            migrationBuilder.RenameTable(
                name: "DanhSachHopDongLaoDong",
                newName: "HopDongLaoDongs");

            migrationBuilder.RenameTable(
                name: "DanhSachGiayToTuyThan",
                newName: "GiayToTuyThans");

            migrationBuilder.RenameTable(
                name: "DanhSachDanhMucPhongBan",
                newName: "DanhMucPhongBans");

            migrationBuilder.RenameTable(
                name: "DanhSachDanhMucChuyenMon",
                newName: "DanhMucChuyenMons");

            migrationBuilder.RenameTable(
                name: "DanhSachDanhMucChucVu",
                newName: "DanhMucChucVus");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachYeuCauTamUngLuong_MaNhanVienGuiYeuCau",
                table: "YeuCauTamUngLuongs",
                newName: "IX_YeuCauTamUngLuongs_MaNhanVienGuiYeuCau");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachYeuCauDatLuongCoBan_MaNhanVienGuiYeuCau",
                table: "YeuCauDatLuongCoBans",
                newName: "IX_YeuCauDatLuongCoBans_MaNhanVienGuiYeuCau");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachYeuCauDatLuongCoBan_MaNhanVienDuocDatLuong",
                table: "YeuCauDatLuongCoBans",
                newName: "IX_YeuCauDatLuongCoBans_MaNhanVienDuocDatLuong");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachPhieuChi_MaNhanVienXuatPhieu",
                table: "PhieuChis",
                newName: "IX_PhieuChis_MaNhanVienXuatPhieu");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachNhatKyLamViec_MaLoaiLichBieu",
                table: "NhatKyLamViecs",
                newName: "IX_NhatKyLamViecs_MaLoaiLichBieu");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachMauHopDong_MaNhanVienLuuMauHopDong",
                table: "MauHopDongs",
                newName: "IX_MauHopDongs_MaNhanVienLuuMauHopDong");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachMauHopDong_MaLoaiHopDong",
                table: "MauHopDongs",
                newName: "IX_MauHopDongs_MaLoaiHopDong");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachHopDongLaoDong_MaNhanVienChuTheHopDong",
                table: "HopDongLaoDongs",
                newName: "IX_HopDongLaoDongs_MaNhanVienChuTheHopDong");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachHopDongLaoDong_MaMauHopDong",
                table: "HopDongLaoDongs",
                newName: "IX_HopDongLaoDongs_MaMauHopDong");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachGiayToTuyThan_MaNhanVienGui",
                table: "GiayToTuyThans",
                newName: "IX_GiayToTuyThans_MaNhanVienGui");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachGiayToTuyThan_MaLoaiGiayTo",
                table: "GiayToTuyThans",
                newName: "IX_GiayToTuyThans_MaLoaiGiayTo");

            migrationBuilder.RenameIndex(
                name: "IX_DanhSachDanhMucPhongBan_MaNhanVienTruongPhong",
                table: "DanhMucPhongBans",
                newName: "IX_DanhMucPhongBans_MaNhanVienTruongPhong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YeuCauTamUngLuongs",
                table: "YeuCauTamUngLuongs",
                column: "MaYeuCau");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YeuCauDatLuongCoBans",
                table: "YeuCauDatLuongCoBans",
                column: "MaYeuCau");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuChis",
                table: "PhieuChis",
                columns: new[] { "MaNhanVien", "ThoiGianXuatPhieuChi" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhatKyLamViecs",
                table: "NhatKyLamViecs",
                columns: new[] { "MaNhanVien", "ThoiGianBatDau", "ThoiGianKetThuc" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MauHopDongs",
                table: "MauHopDongs",
                column: "MaMauHopDong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LuongTheoThangs",
                table: "LuongTheoThangs",
                columns: new[] { "MaNhanVien", "Nam", "Thang" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiLichBieus",
                table: "LoaiLichBieus",
                column: "MaLoai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiHopDongs",
                table: "LoaiHopDongs",
                column: "MaLoaiHopDong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoaiGiayToTuyThans",
                table: "LoaiGiayToTuyThans",
                column: "MaLoaiGiayTo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HopDongLaoDongs",
                table: "HopDongLaoDongs",
                column: "MaHopDong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiayToTuyThans",
                table: "GiayToTuyThans",
                columns: new[] { "MaNhanVien", "MaLoaiGiayTo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucPhongBans",
                table: "DanhMucPhongBans",
                column: "MaPhongBan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucChuyenMons",
                table: "DanhMucChuyenMons",
                column: "MaChuyenMon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucChucVus",
                table: "DanhMucChucVus",
                column: "MaChucVu");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DanhMucChucVus_MaChucVu",
                table: "AspNetUsers",
                column: "MaChucVu",
                principalTable: "DanhMucChucVus",
                principalColumn: "MaChucVu",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DanhMucChuyenMons_MaChuyenMon",
                table: "AspNetUsers",
                column: "MaChuyenMon",
                principalTable: "DanhMucChuyenMons",
                principalColumn: "MaChuyenMon",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HopDongLaoDongs_MaHopDong",
                table: "AspNetUsers",
                column: "MaHopDong",
                principalTable: "HopDongLaoDongs",
                principalColumn: "MaHopDong",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DanhMucPhongBans_MaPhongBan",
                table: "AspNetUsers",
                column: "MaPhongBan",
                principalTable: "DanhMucPhongBans",
                principalColumn: "MaPhongBan",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucPhongBans_AspNetUsers_MaNhanVienTruongPhong",
                table: "DanhMucPhongBans",
                column: "MaNhanVienTruongPhong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GiayToTuyThans_LoaiGiayToTuyThans_MaLoaiGiayTo",
                table: "GiayToTuyThans",
                column: "MaLoaiGiayTo",
                principalTable: "LoaiGiayToTuyThans",
                principalColumn: "MaLoaiGiayTo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GiayToTuyThans_AspNetUsers_MaNhanVien",
                table: "GiayToTuyThans",
                column: "MaNhanVien",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GiayToTuyThans_AspNetUsers_MaNhanVienGui",
                table: "GiayToTuyThans",
                column: "MaNhanVienGui",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongLaoDongs_MauHopDongs_MaMauHopDong",
                table: "HopDongLaoDongs",
                column: "MaMauHopDong",
                principalTable: "MauHopDongs",
                principalColumn: "MaMauHopDong",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongLaoDongs_AspNetUsers_MaNhanVienChuTheHopDong",
                table: "HopDongLaoDongs",
                column: "MaNhanVienChuTheHopDong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LuongTheoThangs_AspNetUsers_MaNhanVien",
                table: "LuongTheoThangs",
                column: "MaNhanVien",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MauHopDongs_LoaiHopDongs_MaLoaiHopDong",
                table: "MauHopDongs",
                column: "MaLoaiHopDong",
                principalTable: "LoaiHopDongs",
                principalColumn: "MaLoaiHopDong",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MauHopDongs_AspNetUsers_MaNhanVienLuuMauHopDong",
                table: "MauHopDongs",
                column: "MaNhanVienLuuMauHopDong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyLamViecs_LoaiLichBieus_MaLoaiLichBieu",
                table: "NhatKyLamViecs",
                column: "MaLoaiLichBieu",
                principalTable: "LoaiLichBieus",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyLamViecs_AspNetUsers_MaNhanVien",
                table: "NhatKyLamViecs",
                column: "MaNhanVien",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuChis_AspNetUsers_MaNhanVien",
                table: "PhieuChis",
                column: "MaNhanVien",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuChis_AspNetUsers_MaNhanVienXuatPhieu",
                table: "PhieuChis",
                column: "MaNhanVienXuatPhieu",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YeuCauDatLuongCoBans_AspNetUsers_MaNhanVienDuocDatLuong",
                table: "YeuCauDatLuongCoBans",
                column: "MaNhanVienDuocDatLuong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YeuCauDatLuongCoBans_AspNetUsers_MaNhanVienGuiYeuCau",
                table: "YeuCauDatLuongCoBans",
                column: "MaNhanVienGuiYeuCau",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YeuCauTamUngLuongs_AspNetUsers_MaNhanVienGuiYeuCau",
                table: "YeuCauTamUngLuongs",
                column: "MaNhanVienGuiYeuCau",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DanhMucChucVus_MaChucVu",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DanhMucChuyenMons_MaChuyenMon",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_HopDongLaoDongs_MaHopDong",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DanhMucPhongBans_MaPhongBan",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucPhongBans_AspNetUsers_MaNhanVienTruongPhong",
                table: "DanhMucPhongBans");

            migrationBuilder.DropForeignKey(
                name: "FK_GiayToTuyThans_LoaiGiayToTuyThans_MaLoaiGiayTo",
                table: "GiayToTuyThans");

            migrationBuilder.DropForeignKey(
                name: "FK_GiayToTuyThans_AspNetUsers_MaNhanVien",
                table: "GiayToTuyThans");

            migrationBuilder.DropForeignKey(
                name: "FK_GiayToTuyThans_AspNetUsers_MaNhanVienGui",
                table: "GiayToTuyThans");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDongLaoDongs_MauHopDongs_MaMauHopDong",
                table: "HopDongLaoDongs");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDongLaoDongs_AspNetUsers_MaNhanVienChuTheHopDong",
                table: "HopDongLaoDongs");

            migrationBuilder.DropForeignKey(
                name: "FK_LuongTheoThangs_AspNetUsers_MaNhanVien",
                table: "LuongTheoThangs");

            migrationBuilder.DropForeignKey(
                name: "FK_MauHopDongs_LoaiHopDongs_MaLoaiHopDong",
                table: "MauHopDongs");

            migrationBuilder.DropForeignKey(
                name: "FK_MauHopDongs_AspNetUsers_MaNhanVienLuuMauHopDong",
                table: "MauHopDongs");

            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyLamViecs_LoaiLichBieus_MaLoaiLichBieu",
                table: "NhatKyLamViecs");

            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyLamViecs_AspNetUsers_MaNhanVien",
                table: "NhatKyLamViecs");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuChis_AspNetUsers_MaNhanVien",
                table: "PhieuChis");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuChis_AspNetUsers_MaNhanVienXuatPhieu",
                table: "PhieuChis");

            migrationBuilder.DropForeignKey(
                name: "FK_YeuCauDatLuongCoBans_AspNetUsers_MaNhanVienDuocDatLuong",
                table: "YeuCauDatLuongCoBans");

            migrationBuilder.DropForeignKey(
                name: "FK_YeuCauDatLuongCoBans_AspNetUsers_MaNhanVienGuiYeuCau",
                table: "YeuCauDatLuongCoBans");

            migrationBuilder.DropForeignKey(
                name: "FK_YeuCauTamUngLuongs_AspNetUsers_MaNhanVienGuiYeuCau",
                table: "YeuCauTamUngLuongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YeuCauTamUngLuongs",
                table: "YeuCauTamUngLuongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YeuCauDatLuongCoBans",
                table: "YeuCauDatLuongCoBans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuChis",
                table: "PhieuChis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhatKyLamViecs",
                table: "NhatKyLamViecs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MauHopDongs",
                table: "MauHopDongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LuongTheoThangs",
                table: "LuongTheoThangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiLichBieus",
                table: "LoaiLichBieus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiHopDongs",
                table: "LoaiHopDongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoaiGiayToTuyThans",
                table: "LoaiGiayToTuyThans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HopDongLaoDongs",
                table: "HopDongLaoDongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiayToTuyThans",
                table: "GiayToTuyThans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucPhongBans",
                table: "DanhMucPhongBans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucChuyenMons",
                table: "DanhMucChuyenMons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucChucVus",
                table: "DanhMucChucVus");

            migrationBuilder.RenameTable(
                name: "YeuCauTamUngLuongs",
                newName: "DanhSachYeuCauTamUngLuong");

            migrationBuilder.RenameTable(
                name: "YeuCauDatLuongCoBans",
                newName: "DanhSachYeuCauDatLuongCoBan");

            migrationBuilder.RenameTable(
                name: "PhieuChis",
                newName: "DanhSachPhieuChi");

            migrationBuilder.RenameTable(
                name: "NhatKyLamViecs",
                newName: "DanhSachNhatKyLamViec");

            migrationBuilder.RenameTable(
                name: "MauHopDongs",
                newName: "DanhSachMauHopDong");

            migrationBuilder.RenameTable(
                name: "LuongTheoThangs",
                newName: "DanhSachLuongTheoThang");

            migrationBuilder.RenameTable(
                name: "LoaiLichBieus",
                newName: "DanhSachLoaiLichBieu");

            migrationBuilder.RenameTable(
                name: "LoaiHopDongs",
                newName: "DanhSachLoaiHopDong");

            migrationBuilder.RenameTable(
                name: "LoaiGiayToTuyThans",
                newName: "DanhSachLoaiGiayToTuyThan");

            migrationBuilder.RenameTable(
                name: "HopDongLaoDongs",
                newName: "DanhSachHopDongLaoDong");

            migrationBuilder.RenameTable(
                name: "GiayToTuyThans",
                newName: "DanhSachGiayToTuyThan");

            migrationBuilder.RenameTable(
                name: "DanhMucPhongBans",
                newName: "DanhSachDanhMucPhongBan");

            migrationBuilder.RenameTable(
                name: "DanhMucChuyenMons",
                newName: "DanhSachDanhMucChuyenMon");

            migrationBuilder.RenameTable(
                name: "DanhMucChucVus",
                newName: "DanhSachDanhMucChucVu");

            migrationBuilder.RenameIndex(
                name: "IX_YeuCauTamUngLuongs_MaNhanVienGuiYeuCau",
                table: "DanhSachYeuCauTamUngLuong",
                newName: "IX_DanhSachYeuCauTamUngLuong_MaNhanVienGuiYeuCau");

            migrationBuilder.RenameIndex(
                name: "IX_YeuCauDatLuongCoBans_MaNhanVienGuiYeuCau",
                table: "DanhSachYeuCauDatLuongCoBan",
                newName: "IX_DanhSachYeuCauDatLuongCoBan_MaNhanVienGuiYeuCau");

            migrationBuilder.RenameIndex(
                name: "IX_YeuCauDatLuongCoBans_MaNhanVienDuocDatLuong",
                table: "DanhSachYeuCauDatLuongCoBan",
                newName: "IX_DanhSachYeuCauDatLuongCoBan_MaNhanVienDuocDatLuong");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuChis_MaNhanVienXuatPhieu",
                table: "DanhSachPhieuChi",
                newName: "IX_DanhSachPhieuChi_MaNhanVienXuatPhieu");

            migrationBuilder.RenameIndex(
                name: "IX_NhatKyLamViecs_MaLoaiLichBieu",
                table: "DanhSachNhatKyLamViec",
                newName: "IX_DanhSachNhatKyLamViec_MaLoaiLichBieu");

            migrationBuilder.RenameIndex(
                name: "IX_MauHopDongs_MaNhanVienLuuMauHopDong",
                table: "DanhSachMauHopDong",
                newName: "IX_DanhSachMauHopDong_MaNhanVienLuuMauHopDong");

            migrationBuilder.RenameIndex(
                name: "IX_MauHopDongs_MaLoaiHopDong",
                table: "DanhSachMauHopDong",
                newName: "IX_DanhSachMauHopDong_MaLoaiHopDong");

            migrationBuilder.RenameIndex(
                name: "IX_HopDongLaoDongs_MaNhanVienChuTheHopDong",
                table: "DanhSachHopDongLaoDong",
                newName: "IX_DanhSachHopDongLaoDong_MaNhanVienChuTheHopDong");

            migrationBuilder.RenameIndex(
                name: "IX_HopDongLaoDongs_MaMauHopDong",
                table: "DanhSachHopDongLaoDong",
                newName: "IX_DanhSachHopDongLaoDong_MaMauHopDong");

            migrationBuilder.RenameIndex(
                name: "IX_GiayToTuyThans_MaNhanVienGui",
                table: "DanhSachGiayToTuyThan",
                newName: "IX_DanhSachGiayToTuyThan_MaNhanVienGui");

            migrationBuilder.RenameIndex(
                name: "IX_GiayToTuyThans_MaLoaiGiayTo",
                table: "DanhSachGiayToTuyThan",
                newName: "IX_DanhSachGiayToTuyThan_MaLoaiGiayTo");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucPhongBans_MaNhanVienTruongPhong",
                table: "DanhSachDanhMucPhongBan",
                newName: "IX_DanhSachDanhMucPhongBan_MaNhanVienTruongPhong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachYeuCauTamUngLuong",
                table: "DanhSachYeuCauTamUngLuong",
                column: "MaYeuCau");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachYeuCauDatLuongCoBan",
                table: "DanhSachYeuCauDatLuongCoBan",
                column: "MaYeuCau");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachPhieuChi",
                table: "DanhSachPhieuChi",
                columns: new[] { "MaNhanVien", "ThoiGianXuatPhieuChi" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachNhatKyLamViec",
                table: "DanhSachNhatKyLamViec",
                columns: new[] { "MaNhanVien", "ThoiGianBatDau", "ThoiGianKetThuc" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachMauHopDong",
                table: "DanhSachMauHopDong",
                column: "MaMauHopDong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachLuongTheoThang",
                table: "DanhSachLuongTheoThang",
                columns: new[] { "MaNhanVien", "Nam", "Thang" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachLoaiLichBieu",
                table: "DanhSachLoaiLichBieu",
                column: "MaLoai");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachLoaiHopDong",
                table: "DanhSachLoaiHopDong",
                column: "MaLoaiHopDong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachLoaiGiayToTuyThan",
                table: "DanhSachLoaiGiayToTuyThan",
                column: "MaLoaiGiayTo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachHopDongLaoDong",
                table: "DanhSachHopDongLaoDong",
                column: "MaHopDong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachGiayToTuyThan",
                table: "DanhSachGiayToTuyThan",
                columns: new[] { "MaNhanVien", "MaLoaiGiayTo" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachDanhMucPhongBan",
                table: "DanhSachDanhMucPhongBan",
                column: "MaPhongBan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachDanhMucChuyenMon",
                table: "DanhSachDanhMucChuyenMon",
                column: "MaChuyenMon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhSachDanhMucChucVu",
                table: "DanhSachDanhMucChucVu",
                column: "MaChucVu");

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
                name: "FK_AspNetUsers_DanhSachDanhMucPhongBan_MaPhongBan",
                table: "AspNetUsers",
                column: "MaPhongBan",
                principalTable: "DanhSachDanhMucPhongBan",
                principalColumn: "MaPhongBan",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachDanhMucPhongBan_AspNetUsers_MaNhanVienTruongPhong",
                table: "DanhSachDanhMucPhongBan",
                column: "MaNhanVienTruongPhong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachGiayToTuyThan_DanhSachLoaiGiayToTuyThan_MaLoaiGiayTo",
                table: "DanhSachGiayToTuyThan",
                column: "MaLoaiGiayTo",
                principalTable: "DanhSachLoaiGiayToTuyThan",
                principalColumn: "MaLoaiGiayTo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachGiayToTuyThan_AspNetUsers_MaNhanVien",
                table: "DanhSachGiayToTuyThan",
                column: "MaNhanVien",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachGiayToTuyThan_AspNetUsers_MaNhanVienGui",
                table: "DanhSachGiayToTuyThan",
                column: "MaNhanVienGui",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachHopDongLaoDong_DanhSachMauHopDong_MaMauHopDong",
                table: "DanhSachHopDongLaoDong",
                column: "MaMauHopDong",
                principalTable: "DanhSachMauHopDong",
                principalColumn: "MaMauHopDong",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachHopDongLaoDong_AspNetUsers_MaNhanVienChuTheHopDong",
                table: "DanhSachHopDongLaoDong",
                column: "MaNhanVienChuTheHopDong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachLuongTheoThang_AspNetUsers_MaNhanVien",
                table: "DanhSachLuongTheoThang",
                column: "MaNhanVien",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachMauHopDong_DanhSachLoaiHopDong_MaLoaiHopDong",
                table: "DanhSachMauHopDong",
                column: "MaLoaiHopDong",
                principalTable: "DanhSachLoaiHopDong",
                principalColumn: "MaLoaiHopDong",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachMauHopDong_AspNetUsers_MaNhanVienLuuMauHopDong",
                table: "DanhSachMauHopDong",
                column: "MaNhanVienLuuMauHopDong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachNhatKyLamViec_DanhSachLoaiLichBieu_MaLoaiLichBieu",
                table: "DanhSachNhatKyLamViec",
                column: "MaLoaiLichBieu",
                principalTable: "DanhSachLoaiLichBieu",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachNhatKyLamViec_AspNetUsers_MaNhanVien",
                table: "DanhSachNhatKyLamViec",
                column: "MaNhanVien",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachPhieuChi_AspNetUsers_MaNhanVien",
                table: "DanhSachPhieuChi",
                column: "MaNhanVien",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachPhieuChi_AspNetUsers_MaNhanVienXuatPhieu",
                table: "DanhSachPhieuChi",
                column: "MaNhanVienXuatPhieu",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachYeuCauDatLuongCoBan_AspNetUsers_MaNhanVienDuocDatLuong",
                table: "DanhSachYeuCauDatLuongCoBan",
                column: "MaNhanVienDuocDatLuong",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachYeuCauDatLuongCoBan_AspNetUsers_MaNhanVienGuiYeuCau",
                table: "DanhSachYeuCauDatLuongCoBan",
                column: "MaNhanVienGuiYeuCau",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhSachYeuCauTamUngLuong_AspNetUsers_MaNhanVienGuiYeuCau",
                table: "DanhSachYeuCauTamUngLuong",
                column: "MaNhanVienGuiYeuCau",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
