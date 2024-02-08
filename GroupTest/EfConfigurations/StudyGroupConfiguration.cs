using GroupTest.Entities;
using GroupTest.Entities.Students;
using GroupTest.Entities.StudyUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupTest.EfConfigurations;

public class StudyGroupConfiguration : IEntityTypeConfiguration<StudyGroup>
{
    public void Configure(EntityTypeBuilder<StudyGroup> builder)
    {
        builder
            .HasMany(e => e.Students)
            .WithMany(e => e.StudyGroups)
            .UsingEntity("GroupStudent",
                l => l.HasOne(typeof(Student)).WithMany().HasForeignKey("StudentId"),
                r => r.HasOne(typeof(StudyGroup)).WithMany().HasForeignKey("GroupId"),
                j => j.HasKey("StudentId", "GroupId"));;
    }
}