using GroupTest.Entities;
using GroupTest.Entities.Students;
using GroupTest.Entities.StudyUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupTest.EfConfigurations;

public class SubGroupConfiguration : IEntityTypeConfiguration<SubGroup>
{
    public void Configure(EntityTypeBuilder<SubGroup> builder)
    {
        builder
            .HasOne(e => e.Parent)
            .WithMany(e => e.SubGroups)
            .HasForeignKey(e => e.ParentId);

        builder
            .HasMany(e => e.Students)
            .WithMany(e => e.SubGroups)
            .UsingEntity("GroupStudent",
                l => l.HasOne(typeof(Student)).WithMany().HasForeignKey("StudentId"),
                r => r.HasOne(typeof(SubGroup)).WithMany().HasForeignKey("GroupId"),
                j => j.HasKey("StudentId", "GroupId"));
    }
}