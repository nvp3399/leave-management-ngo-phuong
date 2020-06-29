using Microsoft.EntityFrameworkCore.Migrations;

namespace leave_management.Data.Migrations
{
    public partial class ModifyPreviousMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultDay",
                table: "LeaveTypes");

            migrationBuilder.AddColumn<int>(
                name: "DefaultDays",
                table: "LeaveTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultDays",
                table: "LeaveTypes");

            migrationBuilder.AddColumn<int>(
                name: "DefaultDay",
                table: "LeaveTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
