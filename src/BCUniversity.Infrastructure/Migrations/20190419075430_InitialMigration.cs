using Microsoft.EntityFrameworkCore.Migrations;

namespace BCUniversity.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lecture",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lecture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "student",
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
                name: "subject_student_relationship",
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
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subject_student_relationship_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lecture_schedule",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    StartHour = table.Column<int>(nullable: false),
                    EndHour = table.Column<int>(nullable: false),
                    TheatreId = table.Column<string>(nullable: true),
                    LectureId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lecture_schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lecture_schedule_lecture_LectureId",
                        column: x => x.LectureId,
                        principalTable: "lecture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lecture_schedule_theatre_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "theatre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lecture_schedule_LectureId",
                table: "lecture_schedule",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_lecture_schedule_TheatreId",
                table: "lecture_schedule",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_subject_student_relationship_StudentId",
                table: "subject_student_relationship",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lecture_schedule");

            migrationBuilder.DropTable(
                name: "subject_student_relationship");

            migrationBuilder.DropTable(
                name: "lecture");

            migrationBuilder.DropTable(
                name: "theatre");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "subject");
        }
    }
}
