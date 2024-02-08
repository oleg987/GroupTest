using GroupTest.Entities.ComponentSemesters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupTest.EfConfigurations;

public class ComponentSemesterConfiguration : IEntityTypeConfiguration<ComponentSemester>
{
    public void Configure(EntityTypeBuilder<ComponentSemester> builder)
    {
        builder
            .HasOne(e => e.Component)
            .WithMany(e => e.ComponentSemesters)
            .HasForeignKey(e => e.ComponentId);

        builder
            .HasIndex(e => new { e.ComponentId, e.Semester, e.EduFormId })
            .IsUnique();
    }
}