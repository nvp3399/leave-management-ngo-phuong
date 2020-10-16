using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class add2propertiesToNhatKyLamViecs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "HeSoLuongCoBan",
                table: "NhatKyLamViecs",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "MucLuongCoBan",
                table: "NhatKyLamViecs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeSoLuongCoBan",
                table: "NhatKyLamViecs");

            migrationBuilder.DropColumn(
                name: "MucLuongCoBan",
                table: "NhatKyLamViecs");
        }
    }
}
