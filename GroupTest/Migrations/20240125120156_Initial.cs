using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GroupTest.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudyUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    InstituteId = table.Column<int>(type: "integer", nullable: true),
                    ComponentId = table.Column<int>(type: "integer", nullable: true),
                    ParentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyUnits_StudyUnits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "StudyUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowGroup",
                columns: table => new
                {
                    FlowsId = table.Column<int>(type: "integer", nullable: false),
                    GroupsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowGroup", x => new { x.FlowsId, x.GroupsId });
                    table.ForeignKey(
                        name: "FK_FlowGroup_StudyUnits_FlowsId",
                        column: x => x.FlowsId,
                        principalTable: "StudyUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowGroup_StudyUnits_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "StudyUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AcademicGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_StudyUnits_AcademicGroupId",
                        column: x => x.AcademicGroupId,
                        principalTable: "StudyUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_FlowGroup_GroupsId",
                table: "FlowGroup",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudyGroup_StudyGroupsId",
                table: "StudentStudyGroup",
                column: "StudyGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubGroup_SubGroupsId",
                table: "StudentSubGroup",
                column: "SubGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AcademicGroupId",
                table: "Students",
                column: "AcademicGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyUnits_ParentId",
                table: "StudyUnits",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowGroup");

            migrationBuilder.DropTable(
                name: "StudentStudyGroup");

            migrationBuilder.DropTable(
                name: "StudentSubGroup");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudyUnits");
        }
    }
}
