using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Students_StudentId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_StudentId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Assignments");

            migrationBuilder.AddColumn<string>(
                name: "StudentGroupId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentGroupId",
                table: "Courses",
                column: "StudentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentGroups_StudentGroupId",
                table: "Courses",
                column: "StudentGroupId",
                principalTable: "StudentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentGroups_StudentGroupId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentGroupId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentGroupId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Assignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_StudentId",
                table: "Assignments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Students_StudentId",
                table: "Assignments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
