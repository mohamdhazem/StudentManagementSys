using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcDay2Task.Migrations
{
    /// <inheritdoc />
    public partial class CourseIdNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_courses_courseId",
                table: "instructors");

            migrationBuilder.AlterColumn<int>(
                name: "courseId",
                table: "instructors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_courses_courseId",
                table: "instructors",
                column: "courseId",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull); // Here you set the 'OnDelete' behavior to 'SetNull'
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_courses_courseId",
                table: "instructors");

            migrationBuilder.AlterColumn<int>(
                name: "courseId",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_courses_courseId",
                table: "instructors",
                column: "courseId",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
