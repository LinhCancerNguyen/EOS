using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamCore.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Subject_SubjectId",
                table: "Question");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Question",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Subject_SubjectId",
                table: "Question",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Subject_SubjectId",
                table: "Question");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Question",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Subject_SubjectId",
                table: "Question",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
