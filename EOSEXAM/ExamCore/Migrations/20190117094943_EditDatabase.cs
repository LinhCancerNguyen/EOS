using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamCore.Migrations
{
    public partial class EditDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Option_Subject_SubjectId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultDetail_Subject_SubjectId",
                table: "ResultDetail");

            migrationBuilder.DropIndex(
                name: "IX_ResultDetail_SubjectId",
                table: "ResultDetail");

            migrationBuilder.DropIndex(
                name: "IX_Option_SubjectId",
                table: "Option");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "ResultDetail");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Option");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "ResultDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Option",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResultDetail_SubjectId",
                table: "ResultDetail",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_SubjectId",
                table: "Option",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Subject_SubjectId",
                table: "Option",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultDetail_Subject_SubjectId",
                table: "ResultDetail",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
