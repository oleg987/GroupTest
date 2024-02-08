using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GroupTest.Migrations
{
    /// <inheritdoc />
    public partial class AddComponentSemester : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentSemester",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComponentId = table.Column<int>(type: "integer", nullable: false),
                    Semester = table.Column<int>(type: "integer", nullable: false),
                    EduFormId = table.Column<int>(type: "integer", nullable: false),
                    LectionsCount = table.Column<int>(type: "integer", nullable: false),
                    PracticCount = table.Column<int>(type: "integer", nullable: false),
                    LabourCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentSemester", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentSemester_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentSemester_ComponentId_Semester_EduFormId",
                table: "ComponentSemester",
                columns: new[] { "ComponentId", "Semester", "EduFormId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentSemester");
        }
    }
}
