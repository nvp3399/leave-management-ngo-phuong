using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class jwerjwer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {






            migrationBuilder.DropPrimaryKey(
                name: "PK_NhatKyLamViecs",
                table: "NhatKyLamViecs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhatKyLamViecs",
                table: "NhatKyLamViecs",
                columns: new[] { "MaNhanVien", "ThoiGianBatDau" });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_NhatKyLamViecs_AspNetUsers_MaNhanVien",
            //    table: "NhatKyLamViecs",
            //    column: "MaNhanVien",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyLamViecs_AspNetUsers_MaNhanVien",
                table: "NhatKyLamViecs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhatKyLamViecs",
                table: "NhatKyLamViecs");

            migrationBuilder.DropColumn(
                name: "MaNhanVien",
                table: "NhatKyLamViecs");

            migrationBuilder.AddColumn<string>(
                name: "NhanVienId",
                table: "NhatKyLamViecs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyLamViecs_NhanVienId",
                table: "NhatKyLamViecs",
                column: "NhanVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyLamViecs_AspNetUsers_NhanVienId",
                table: "NhatKyLamViecs",
                column: "NhanVienId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
