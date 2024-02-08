using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupTest.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var drop = @"drop view if exists ""StudentGroupView"";";

            migrationBuilder.Sql(drop);
            
            migrationBuilder.DropTable(
                name: "StudentStudyGroup");

            migrationBuilder.DropTable(
                name: "StudentSubGroup");

            migrationBuilder.CreateTable(
                name: "GroupStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudent", x => new { x.StudentId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_GroupStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupStudent_StudyUnits_GroupId",
                        column: x => x.GroupId,
                        principalTable: "StudyUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudent_GroupId",
                table: "GroupStudent",
                column: "GroupId");
            
            var view = @"create or replace view ""StudentGroupView""
                                as
                                select st.""Id"" as ""StudentId"", st.""AcademicGroupId"" as ""GroupId""
                                from ""Students"" as st

                                union

                                select st.""StudentId"" as ""StudentId"", st.""GroupId"" as ""GroupId""
                                from ""GroupStudent"" as st;";

            migrationBuilder.Sql(view);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var drop = @"drop view if exists ""StudentGroupView"";";

            migrationBuilder.Sql(drop);
            
            migrationBuilder.DropTable(
                name: "GroupStudent");

            migrationBuilder.CreateTable(
                name: "StudentStudyGroup",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "integer", nullable: false),
                    StudyGroupsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStudyGroup", x => new { x.StudentsId, x.StudyGroupsId });
                    table.ForeignKey(
                        name: "FK_StudentStudyGroup_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStudyGroup_StudyUnits_StudyGroupsId",
                        column: x => x.StudyGroupsId,
                        principalTable: "StudyUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubGroup",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "integer", nullable: false),
                    SubGroupsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubGroup", x => new { x.StudentsId, x.SubGroupsId });
                    table.ForeignKey(
                        name: "FK_StudentSubGroup_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubGroup_StudyUnits_SubGroupsId",
                        column: x => x.SubGroupsId,
                        principalTable: "StudyUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudyGroup_StudyGroupsId",
                table: "StudentStudyGroup",
                column: "StudyGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubGroup_SubGroupsId",
                table: "StudentSubGroup",
                column: "SubGroupsId");
            
            var view = @"create or replace view ""StudentGroupView""
                                as
                                select st.""Id"" as ""StudentId"", st.""AcademicGroupId"" as ""GroupId""
                                from ""Students"" as st

                                union

                                select st.""StudentsId"" as ""StudentId"", st.""StudyGroupsId"" as ""GroupId""
                                from ""StudentStudyGroup"" as st

                                union

                                select st.""StudentsId"" as ""StudentId"", st.""SubGroupsId"" as ""GroupId""
                                from ""StudentSubGroup"" as st;";

            migrationBuilder.Sql(view);
        }
    }
}
