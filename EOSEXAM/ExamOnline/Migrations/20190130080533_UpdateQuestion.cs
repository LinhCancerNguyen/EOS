using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class UpdateQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Subject_SubjectId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Question",
                newName: "QuestionID");

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
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Subject_SubjectId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "QuestionID",
                table: "Question",
                newName: "QuestionId");

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
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
