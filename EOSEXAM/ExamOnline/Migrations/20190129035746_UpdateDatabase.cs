using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamOnline.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Option_Question_QuestionID",
                table: "Option");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Option",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Answer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Question_QuestionID",
                table: "Option",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Option_Question_QuestionID",
                table: "Option");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Option",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Question_QuestionID",
                table: "Option",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
