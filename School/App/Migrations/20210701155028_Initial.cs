using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassOf = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseName = table.Column<string>(type: "TEXT", nullable: true),
                    grade = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "ClassOf", "FirstName", "LastName" },
                values: new object[] { 1, 13, 0, "Laurie", "Logger" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "ClassOf", "FirstName", "LastName" },
                values: new object[] { 2, 15, 1, "Margert", "Mury" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "ClassOf", "FirstName", "LastName" },
                values: new object[] { 3, 16, 2, "Peter", "Piemont" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "ClassOf", "FirstName", "LastName" },
                values: new object[] { 4, 17, 3, "Frank", "Folly" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "grade" },
                values: new object[] { 1, "Cooking With Gas", 1, 0.69999999999999996 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "grade" },
                values: new object[] { 2, "Cooking With Gas", 2, 0.89000000000000001 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "grade" },
                values: new object[] { 3, "Cooking With Gas", 3, 0.75 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "grade" },
                values: new object[] { 4, "Wood Shop", 3, 0.75 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "grade" },
                values: new object[] { 5, "Data Base Design", 3, 0.75 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseName", "StudentId", "grade" },
                values: new object[] { 6, "Introduction to C# ", 3, 0.75 });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
