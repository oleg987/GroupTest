using GroupTest.DbViews;
using GroupTest.Entities;
using GroupTest.Entities.Students;
using GroupTest.Entities.StudyUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupTest.EfConfigurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder
            .HasMany(e => e.GroupStudents)
            .WithMany()
            .UsingEntity(nameof(StudentGroupView),
                l => l.HasOne(typeof(Student)).WithMany().HasForeignKey(nameof(StudentGroupView.StudentId)),
                r => r.HasOne(typeof(Group)).WithMany().HasForeignKey(nameof(StudentGroupView.GroupId)));
    }
}