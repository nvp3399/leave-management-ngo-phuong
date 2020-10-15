using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class wjerjwer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "PhieuChi_NKLVs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuChi_NKLVs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    MaNhanVien_NKLV = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    MaNhanVien_PhieuChi = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    NhanVien_NKLVId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NhanVien_PhieuChiId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ThoiGianBatDau_NKLV = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianXuatPhieuChi_PhieuChi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuChi_NKLVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhieuChi_NKLVs_AspNetUsers_NhanVien_NKLVId",
                        column: x => x.NhanVien_NKLVId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhieuChi_NKLVs_AspNetUsers_NhanVien_PhieuChiId",
                        column: x => x.NhanVien_PhieuChiId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChi_NKLVs_NhanVien_NKLVId",
                table: "PhieuChi_NKLVs",
                column: "NhanVien_NKLVId");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuChi_NKLVs_NhanVien_PhieuChiId",
                table: "PhieuChi_NKLVs",
                column: "NhanVien_PhieuChiId");
        }
    }
}
