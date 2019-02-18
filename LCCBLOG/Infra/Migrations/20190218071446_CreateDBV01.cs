using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class CreateDBV01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlSlug",
                table: "Post",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedOn",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 18, 14, 14, 46, 254, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 18, 14, 11, 48, 568, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Post",
                nullable: true,
                defaultValue: new DateTime(2019, 2, 18, 14, 14, 46, 256, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2019, 2, 18, 14, 11, 48, 570, DateTimeKind.Local));

            migrationBuilder.AlterColumn<string>(
                name: "Meta",
                table: "Post",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Contact",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Contact",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlSlug",
                table: "Post",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PostedOn",
                table: "Post",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 18, 14, 11, 48, 568, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 18, 14, 14, 46, 254, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                table: "Post",
                nullable: true,
                defaultValue: new DateTime(2019, 2, 18, 14, 11, 48, 570, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2019, 2, 18, 14, 14, 46, 256, DateTimeKind.Local));

            migrationBuilder.AlterColumn<string>(
                name: "Meta",
                table: "Post",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Contact",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Contact",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
