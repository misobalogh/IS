using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Grade = table.Column<int>(type: "INTEGER", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Tag = table.Column<string>(type: "TEXT", nullable: false),
                    Semester = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    TitleBefore = table.Column<int>(type: "INTEGER", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    TitleAfter = table.Column<int>(type: "INTEGER", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false),
                    Mark = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredSubjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Room = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    ActivityType = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    SubjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeacherId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaxPoints = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachingSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Year = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeacherId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachingSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachingSubjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActivityId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ActivityId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredActivities_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "Grade", "Image", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("789a3e3a-0d52-4cc6-b5b2-6e5819594380"), "xplagi00@email.com", "John", 0, null, "Doe", "113dDSas6H" },
                    { new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f"), "xmrkva01@email.com", "Jack", 0, null, "Mrkva", "9n1d8as" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "Semester", "Tag" },
                values: new object[,]
                {
                    { new Guid("6180b520-6119-4303-8496-ed568d684209"), "Jazyk C", 0, "IJC" },
                    { new Guid("e8b9f519-c2df-4c4c-8ce3-8dbfcf9557d4"), "Formalitka Jednoducha", 0, "IFJ" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "TitleAfter", "TitleBefore" },
                values: new object[,]
                {
                    { new Guid("45083d2e-a91f-43a3-9ff4-a1d48a30e06f"), "lienka@email.com", "Lenka", null, "Lienka", "#ASDld10981", null, null },
                    { new Guid("acce5c7a-2266-43ef-921b-c6b5e4c1390c"), "chrobak@email.com", "Roman", null, "Chrobak", "asdm9m1dm901", null, null }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ActivityType", "Capacity", "Description", "End", "MaxPoints", "Name", "Room", "Start", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("21adbcf5-f96d-4943-8249-d73401395a06"), 3, 1, null, new DateTime(2024, 5, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IJC Consultation", 1, new DateTime(2024, 5, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6180b520-6119-4303-8496-ed568d684209"), new Guid("acce5c7a-2266-43ef-921b-c6b5e4c1390c") },
                    { new Guid("fc6e2571-362d-47fd-8a61-fc3dc08d486f"), 4, 100, null, new DateTime(2024, 5, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), 10, "IFJ Midterm", 5, new DateTime(2024, 5, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8b9f519-c2df-4c4c-8ce3-8dbfcf9557d4"), new Guid("45083d2e-a91f-43a3-9ff4-a1d48a30e06f") }
                });

            migrationBuilder.InsertData(
                table: "RegisteredSubjects",
                columns: new[] { "Id", "Mark", "Points", "StudentId", "SubjectId", "Year" },
                values: new object[,]
                {
                    { new Guid("07671bf7-6690-42bc-8010-a94f66725f08"), 0, 0, new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f"), new Guid("6180b520-6119-4303-8496-ed568d684209"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("371a5d4a-c60d-4e45-b3a1-db2bca96b24e"), 0, 0, new Guid("789a3e3a-0d52-4cc6-b5b2-6e5819594380"), new Guid("e8b9f519-c2df-4c4c-8ce3-8dbfcf9557d4"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "TeachingSubjects",
                columns: new[] { "Id", "SubjectId", "TeacherId", "Year" },
                values: new object[,]
                {
                    { new Guid("323f2144-de33-4185-b20e-53764ff39956"), new Guid("e8b9f519-c2df-4c4c-8ce3-8dbfcf9557d4"), new Guid("45083d2e-a91f-43a3-9ff4-a1d48a30e06f"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("8c76cfde-f278-459b-8354-15f9c6dc68e1"), new Guid("6180b520-6119-4303-8496-ed568d684209"), new Guid("acce5c7a-2266-43ef-921b-c6b5e4c1390c"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Evaluations",
                columns: new[] { "Id", "ActivityId", "Note", "Points", "StudentId" },
                values: new object[] { new Guid("18bbc9de-444a-4099-9a3b-f77e44162f4a"), new Guid("fc6e2571-362d-47fd-8a61-fc3dc08d486f"), null, 10, new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f") });

            migrationBuilder.InsertData(
                table: "RegisteredActivities",
                columns: new[] { "Id", "ActivityId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("173e971f-b7a4-4eec-944d-c1ddea94c3c6"), new Guid("fc6e2571-362d-47fd-8a61-fc3dc08d486f"), new Guid("789a3e3a-0d52-4cc6-b5b2-6e5819594380") },
                    { new Guid("2a484e4f-c3d4-4a57-8f21-c8751cc16d2e"), new Guid("21adbcf5-f96d-4943-8249-d73401395a06"), new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SubjectId",
                table: "Activities",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TeacherId",
                table: "Activities",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ActivityId",
                table: "Evaluations",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StudentId",
                table: "Evaluations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredActivities_ActivityId",
                table: "RegisteredActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredActivities_StudentId",
                table: "RegisteredActivities",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredSubjects_StudentId",
                table: "RegisteredSubjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredSubjects_SubjectId",
                table: "RegisteredSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingSubjects_SubjectId",
                table: "TeachingSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingSubjects_TeacherId",
                table: "TeachingSubjects",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "RegisteredActivities");

            migrationBuilder.DropTable(
                name: "RegisteredSubjects");

            migrationBuilder.DropTable(
                name: "TeachingSubjects");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
