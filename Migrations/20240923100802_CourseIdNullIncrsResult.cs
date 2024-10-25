using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcDay2Task.Migrations
{
    /// <inheritdoc />
    public partial class CourseIdNullIncrsResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_courses_courseId",
                table: "crsResults");

            migrationBuilder.AlterColumn<int>(
                name: "courseId",
                table: "crsResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_courses_courseId",
                table: "crsResults",
                column: "courseId",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_courses_courseId",
                table: "crsResults");

            migrationBuilder.AlterColumn<int>(
                name: "courseId",
                table: "crsResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_courses_courseId",
                table: "crsResults",
                column: "courseId",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
