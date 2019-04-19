using Microsoft.EntityFrameworkCore.Migrations;

namespace BCUniversity.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "uni");

            migrationBuilder.CreateTable(
                name: "student",
                schema: "uni",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                schema: "uni",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "theatre",
                schema: "uni",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theatre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lecture",
                schema: "uni",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SubjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lecture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lecture_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "uni",
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subject_student_relationship",
                schema: "uni",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    SubjectId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject_student_relationship", x => new { x.SubjectId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_subject_student_relationship_student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "uni",
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subject_student_relationship_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "uni",
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lecture_theatre_relationship",
                schema: "uni",
                columns: table => new
                {
                    TheatreId = table.Column<string>(nullable: false),
                    LectureId = table.Column<string>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    StartHour = table.Column<int>(nullable: false),
                    EndHour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lecture_theatre_relationship", x => new { x.LectureId, x.TheatreId });
                    table.ForeignKey(
                        name: "FK_lecture_theatre_relationship_lecture_LectureId",
                        column: x => x.LectureId,
                        principalSchema: "uni",
                        principalTable: "lecture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lecture_theatre_relationship_theatre_TheatreId",
                        column: x => x.TheatreId,
                        principalSchema: "uni",
                        principalTable: "theatre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lecture_SubjectId",
                schema: "uni",
                table: "lecture",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_lecture_theatre_relationship_TheatreId",
                schema: "uni",
                table: "lecture_theatre_relationship",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_subject_student_relationship_StudentId",
                schema: "uni",
                table: "subject_student_relationship",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lecture_theatre_relationship",
                schema: "uni");

            migrationBuilder.DropTable(
                name: "subject_student_relationship",
                schema: "uni");

            migrationBuilder.DropTable(
                name: "lecture",
                schema: "uni");

            migrationBuilder.DropTable(
                name: "theatre",
                schema: "uni");

            migrationBuilder.DropTable(
                name: "student",
                schema: "uni");

            migrationBuilder.DropTable(
                name: "subject",
                schema: "uni");
        }
    }
}
