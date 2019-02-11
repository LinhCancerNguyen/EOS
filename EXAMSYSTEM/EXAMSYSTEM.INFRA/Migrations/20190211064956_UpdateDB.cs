using Microsoft.EntityFrameworkCore.Migrations;

namespace EXAMSYSTEM.INFRA.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "User",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
