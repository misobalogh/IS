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
                    { new Guid("214af588-69ab-43b4-baa1-4973b1a6eda9"), "xkolar51@email.com", "Karel", 0, null, "Kolar", "random_pass" },
                    { new Guid("44ca97c3-1a70-42dd-9e37-0e3c74ef7301"), "xstude00@email.com", "Eva", 0, null, "Studena", "password123" },
                    { new Guid("789a3e3a-0d52-4cc6-b5b2-6e5819594380"), "xplagi00@email.com", "John", 0, null, "Doe", "113dDSas6H" },
                    { new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f"), "xmrkva01@email.com", "Jack", 0, null, "Mrkva", "9n1d8as" },
                    { new Guid("962dbc44-3ec6-41f1-9b27-ddd06016f0c6"), "xjozef01@email.com", "Erik", 0, null, "Jozefcak", "very_hard_123" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "Semester", "Tag" },
                values: new object[,]
                {
                    { new Guid("46e9b926-7e8d-4edc-a0c7-707dd7f26fac"), "Informacne Systemy", 0, "IIS" },
                    { new Guid("6180b520-6119-4303-8496-ed568d684209"), "Jazyk C", 0, "IJC" },
                    { new Guid("d7e6fb03-6425-49f6-8667-6ecf862a6fcc"), "Databazove Systemy", 0, "IDS" },
                    { new Guid("e8b9f519-c2df-4c4c-8ce3-8dbfcf9557d4"), "Formalitka Jednoducha", 0, "IFJ" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "TitleAfter", "TitleBefore" },
                values: new object[,]
                {
                    { new Guid("45083d2e-a91f-43a3-9ff4-a1d48a30e06f"), "lienka@email.com", "Lenka", null, "Lienka", "#ASDld10981", null, null },
                    { new Guid("49b9f640-99ec-446a-95a1-ba837dd18016"), "honza@novak.cz", "Honza", null, "Novák", "secret_pass_hardcore123", null, null },
                    { new Guid("acce5c7a-2266-43ef-921b-c6b5e4c1390c"), "chrobak@email.com", "Roman", null, "Chrobak", "asdm9m1dm901", null, null }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ActivityType", "Capacity", "Description", "End", "MaxPoints", "Name", "Room", "Start", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("07d710b6-f888-4544-9699-1b8351b2f5ef"), 1, 100, null, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), null, "IIS Lecture", 6, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), new Guid("46e9b926-7e8d-4edc-a0c7-707dd7f26fac"), new Guid("49b9f640-99ec-446a-95a1-ba837dd18016") },
                    { new Guid("21adbcf5-f96d-4943-8249-d73401395a06"), 4, 1, null, new DateTime(2024, 5, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "IJC Consultation", 1, new DateTime(2024, 5, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6180b520-6119-4303-8496-ed568d684209"), new Guid("acce5c7a-2266-43ef-921b-c6b5e4c1390c") },
                    { new Guid("d43acf95-447d-4169-9de0-10df4fbf1222"), 3, 10, null, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), 100, "IDS Project", 8, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), new Guid("d7e6fb03-6425-49f6-8667-6ecf862a6fcc"), new Guid("acce5c7a-2266-43ef-921b-c6b5e4c1390c") },
                    { new Guid("fbade23f-82ee-4895-9ba3-cdad7de473c9"), 3, 10, null, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), 100, "IIS Project", 8, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), new Guid("46e9b926-7e8d-4edc-a0c7-707dd7f26fac"), new Guid("49b9f640-99ec-446a-95a1-ba837dd18016") },
                    { new Guid("fc6e2571-362d-47fd-8a61-fc3dc08d486f"), 5, 100, null, new DateTime(2024, 5, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), 10, "IFJ Midterm", 5, new DateTime(2024, 5, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8b9f519-c2df-4c4c-8ce3-8dbfcf9557d4"), new Guid("45083d2e-a91f-43a3-9ff4-a1d48a30e06f") }
                });

            migrationBuilder.InsertData(
                table: "RegisteredSubjects",
                columns: new[] { "Id", "Mark", "Points", "StudentId", "SubjectId", "Year" },
                values: new object[,]
                {
                    { new Guid("07671bf7-6690-42bc-8010-a94f66725f08"), 0, 0, new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f"), new Guid("6180b520-6119-4303-8496-ed568d684209"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("269b4a0e-f07f-45ce-8586-81761dd599e0"), 0, 10, new Guid("214af588-69ab-43b4-baa1-4973b1a6eda9"), new Guid("d7e6fb03-6425-49f6-8667-6ecf862a6fcc"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("36f96027-6267-4342-ac10-f8d51c41c610"), 0, 0, new Guid("44ca97c3-1a70-42dd-9e37-0e3c74ef7301"), new Guid("d7e6fb03-6425-49f6-8667-6ecf862a6fcc"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("371a5d4a-c60d-4e45-b3a1-db2bca96b24e"), 0, 0, new Guid("789a3e3a-0d52-4cc6-b5b2-6e5819594380"), new Guid("e8b9f519-c2df-4c4c-8ce3-8dbfcf9557d4"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("f6d72f38-f33e-4246-942a-ced94ba8b485"), 0, 0, new Guid("962dbc44-3ec6-41f1-9b27-ddd06016f0c6"), new Guid("46e9b926-7e8d-4edc-a0c7-707dd7f26fac"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "TeachingSubjects",
                columns: new[] { "Id", "SubjectId", "TeacherId", "Year" },
                values: new object[,]
                {
                    { new Guid("323f2144-de33-4185-b20e-53764ff39956"), new Guid("e8b9f519-c2df-4c4c-8ce3-8dbfcf9557d4"), new Guid("45083d2e-a91f-43a3-9ff4-a1d48a30e06f"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("53efaa78-9c02-4139-b0df-e11264390bca"), new Guid("46e9b926-7e8d-4edc-a0c7-707dd7f26fac"), new Guid("49b9f640-99ec-446a-95a1-ba837dd18016"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("8c76cfde-f278-459b-8354-15f9c6dc68e1"), new Guid("6180b520-6119-4303-8496-ed568d684209"), new Guid("acce5c7a-2266-43ef-921b-c6b5e4c1390c"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("a6c9a9f0-64ce-4096-b5ba-3a2942c76aa6"), new Guid("d7e6fb03-6425-49f6-8667-6ecf862a6fcc"), new Guid("acce5c7a-2266-43ef-921b-c6b5e4c1390c"), new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Evaluations",
                columns: new[] { "Id", "ActivityId", "Note", "Points", "StudentId" },
                values: new object[,]
                {
                    { new Guid("18bbc9de-444a-4099-9a3b-f77e44162f4a"), new Guid("fc6e2571-362d-47fd-8a61-fc3dc08d486f"), null, 10, new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f") },
                    { new Guid("2f7a84d3-bce6-46ad-88c0-252662c7d21f"), new Guid("d43acf95-447d-4169-9de0-10df4fbf1222"), null, 30, new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f") },
                    { new Guid("50fcc755-0509-4869-9775-20cc913f956d"), new Guid("fbade23f-82ee-4895-9ba3-cdad7de473c9"), null, 20, new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f") }
                });

            migrationBuilder.InsertData(
                table: "RegisteredActivities",
                columns: new[] { "Id", "ActivityId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("173e971f-b7a4-4eec-944d-c1ddea94c3c6"), new Guid("fc6e2571-362d-47fd-8a61-fc3dc08d486f"), new Guid("789a3e3a-0d52-4cc6-b5b2-6e5819594380") },
                    { new Guid("2a484e4f-c3d4-4a57-8f21-c8751cc16d2e"), new Guid("21adbcf5-f96d-4943-8249-d73401395a06"), new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f") },
                    { new Guid("397c4f82-dbfd-4687-8d40-720d79a0b678"), new Guid("fbade23f-82ee-4895-9ba3-cdad7de473c9"), new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f") },
                    { new Guid("845aab54-8a3e-4d83-82b0-f83db7a41695"), new Guid("fc6e2571-362d-47fd-8a61-fc3dc08d486f"), new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f") },
                    { new Guid("eadf7a13-db18-4be6-bc2a-302a21df5bee"), new Guid("d43acf95-447d-4169-9de0-10df4fbf1222"), new Guid("86b94a78-c900-473d-9e57-f1b93cc9819f") }
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
