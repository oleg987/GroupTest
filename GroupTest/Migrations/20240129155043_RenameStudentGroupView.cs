using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupTest.Migrations
{
    /// <inheritdoc />
    public partial class RenameStudentGroupView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var drop = @"drop view if exists ""GroupStudentsView"";";

            migrationBuilder.Sql(drop);
            
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var drop = @"drop view if exists ""StudentGroupView"";";

            migrationBuilder.Sql(drop);
            
            var view = @"create or replace view ""GroupStudentsView""
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
