using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupTest.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceCW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComponentType",
                table: "Components",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComponentType",
                table: "Components");
        }
    }
}
