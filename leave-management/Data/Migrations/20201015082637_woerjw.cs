using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class woerjw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuChi_NKLVs",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 450, nullable: false),
                    MaNhanVien_PhieuChi = table.Column<string>(maxLength: 450, nullable: true),
                    ThoiGianXuatPhieuChi_PhieuChi = table.Column<DateTime>(nullable: false),
                    MaNhanVien_NKLV = table.Column<string>(maxLength: 450, nullable: true),
                    ThoiGianBatDau_NKLV = table.Column<DateTime>(nullable: false)
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
