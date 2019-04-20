using Microsoft.EntityFrameworkCore.Migrations;

namespace BCUniversity.Infrastructure.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "uni",
                table: "student",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "c15cef22-35db-4ccb-a725-8bb127b8dcb1", "Student 1" },
                    { "2ea37cfc-72b5-4898-a768-b20f9aa354b9", "Student 2" },
                    { "7bb294f6-a199-4197-bdbd-f010283e7a74", "Student 3" }
                });

            migrationBuilder.InsertData(
                schema: "uni",
                table: "subject",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "81b6ec83-e8b4-4ad5-8893-1f763200393d", "Subject 1" },
                    { "a9a5db84-7de3-40a0-b464-a9cfd7c60a06", "Subject 2" },
                    { "9ee3209c-2333-4cd1-ae13-84039e5b8e35", "Subject 3" }
                });

            migrationBuilder.InsertData(
                schema: "uni",
                table: "theatre",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { "180c5352-2a8b-4941-9728-2790ab5e15af", 10, "Theatre 1" },
                    { "dd01bbdf-26b8-43db-8d4c-7d394fbddaac", 1, "Theatre 2" }
                });

            migrationBuilder.InsertData(
                schema: "uni",
                table: "lecture",
                columns: new[] { "Id", "Name", "SubjectId" },
                values: new object[,]
                {
                    { "d33ea94a-b2c7-435a-ad8b-0b75f33189cc", "Lecture 1", "81b6ec83-e8b4-4ad5-8893-1f763200393d" },
                    { "9735bdc7-79ca-4728-b2dc-ba4ab4f70d1d", "Lecture 2", "a9a5db84-7de3-40a0-b464-a9cfd7c60a06" },
                    { "86b20947-e7f2-4c25-845b-652b74c0a103", "Lecture 3", "a9a5db84-7de3-40a0-b464-a9cfd7c60a06" },
                    { "ca24c626-873b-4d27-8e30-bfd26e760b13", "Lecture 4", "9ee3209c-2333-4cd1-ae13-84039e5b8e35" }
                });

            migrationBuilder.InsertData(
                schema: "uni",
                table: "lecture_theatre_relationship",
                columns: new[] { "LectureId", "TheatreId", "DayOfWeek", "EndHour", "StartHour" },
                values: new object[,]
                {
                    { "d33ea94a-b2c7-435a-ad8b-0b75f33189cc", "180c5352-2a8b-4941-9728-2790ab5e15af", 1, 18, 10 },
                    { "9735bdc7-79ca-4728-b2dc-ba4ab4f70d1d", "180c5352-2a8b-4941-9728-2790ab5e15af", 2, 16, 14 },
                    { "86b20947-e7f2-4c25-845b-652b74c0a103", "180c5352-2a8b-4941-9728-2790ab5e15af", 3, 12, 10 },
                    { "ca24c626-873b-4d27-8e30-bfd26e760b13", "dd01bbdf-26b8-43db-8d4c-7d394fbddaac", 5, 11, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "uni",
                table: "lecture_theatre_relationship",
                keyColumns: new[] { "LectureId", "TheatreId" },
                keyValues: new object[] { "86b20947-e7f2-4c25-845b-652b74c0a103", "180c5352-2a8b-4941-9728-2790ab5e15af" });

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "lecture_theatre_relationship",
                keyColumns: new[] { "LectureId", "TheatreId" },
                keyValues: new object[] { "9735bdc7-79ca-4728-b2dc-ba4ab4f70d1d", "180c5352-2a8b-4941-9728-2790ab5e15af" });

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "lecture_theatre_relationship",
                keyColumns: new[] { "LectureId", "TheatreId" },
                keyValues: new object[] { "ca24c626-873b-4d27-8e30-bfd26e760b13", "dd01bbdf-26b8-43db-8d4c-7d394fbddaac" });

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "lecture_theatre_relationship",
                keyColumns: new[] { "LectureId", "TheatreId" },
                keyValues: new object[] { "d33ea94a-b2c7-435a-ad8b-0b75f33189cc", "180c5352-2a8b-4941-9728-2790ab5e15af" });

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "student",
                keyColumn: "Id",
                keyValue: "2ea37cfc-72b5-4898-a768-b20f9aa354b9");

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "student",
                keyColumn: "Id",
                keyValue: "7bb294f6-a199-4197-bdbd-f010283e7a74");

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "student",
                keyColumn: "Id",
                keyValue: "c15cef22-35db-4ccb-a725-8bb127b8dcb1");

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "lecture",
                keyColumn: "Id",
                keyValue: "86b20947-e7f2-4c25-845b-652b74c0a103");

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "lecture",
                keyColumn: "Id",
                keyValue: "9735bdc7-79ca-4728-b2dc-ba4ab4f70d1d");

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "lecture",
                keyColumn: "Id",
                keyValue: "ca24c626-873b-4d27-8e30-bfd26e760b13");

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "lecture",
                keyColumn: "Id",
                keyValue: "d33ea94a-b2c7-435a-ad8b-0b75f33189cc");

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "theatre",
                keyColumn: "Id",
                keyValue: "180c5352-2a8b-4941-9728-2790ab5e15af");

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "theatre",
                keyColumn: "Id",
                keyValue: "dd01bbdf-26b8-43db-8d4c-7d394fbddaac");

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "subject",
                keyColumn: "Id",
                keyValue: "81b6ec83-e8b4-4ad5-8893-1f763200393d");

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "subject",
                keyColumn: "Id",
                keyValue: "9ee3209c-2333-4cd1-ae13-84039e5b8e35");

            migrationBuilder.DeleteData(
                schema: "uni",
                table: "subject",
                keyColumn: "Id",
                keyValue: "a9a5db84-7de3-40a0-b464-a9cfd7c60a06");
        }
    }
}
