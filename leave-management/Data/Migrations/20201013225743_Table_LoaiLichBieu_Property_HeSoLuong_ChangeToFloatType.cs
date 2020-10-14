using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class Table_LoaiLichBieu_Property_HeSoLuong_ChangeToFloatType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "HeSoLuongCoBan",
                table: "LoaiLichBieus",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "HeSoLuongCoBan",
                table: "LoaiLichBieus",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
