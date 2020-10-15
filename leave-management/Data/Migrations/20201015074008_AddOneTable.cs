using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class AddOneTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuChi_NKLVs",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    NhanVien_PhieuChiId = table.Column<string>(nullable: true),
                    MaNhanVien_PhieuChi = table.Column<string>(nullable: true),
                    ThoiGianXuatPhieuChi_PhieuChi = table.Column<DateTime>(nullable: false),
                    NhanVien_NKLVId = table.Column<string>(nullable: true),
                    MaNhanVien_NKLV = table.Column<string>(nullable: true),
                    ThoiGianBatDau_NKLV = table.Column<DateTime>(nullable: false),
                    PhieuChiMaNhanVien = table.Column<string>(nullable: true),
                    PhieuChiThoiGianXuatPhieuChi = table.Column<DateTime>(nullable: true),
                    NhatKyLamViecMaNhanVien = table.Column<string>(nullable: true),
                    NhatKyLamViecThoiGianBatDau = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuChi_NKLVs", x => x.Id);
                    
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuChi_NKLVs");
        }
    }
}
