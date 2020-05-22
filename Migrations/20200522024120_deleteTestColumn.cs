using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreHomework.Migrations
{
    public partial class deleteTestColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestColumn",
                table: "Course");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Department",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Department");

            migrationBuilder.AddColumn<string>(
                name: "TestColumn",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
