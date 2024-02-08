using GroupTest.Entities;
using GroupTest.Entities.StudyUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupTest.EfConfigurations;

public class AcademicGroupConfiguration : IEntityTypeConfiguration<AcademicGroup>
{
    public void Configure(EntityTypeBuilder<AcademicGroup> builder)
    {
        builder
            .HasMany(e => e.Students)
            .WithOne(e => e.AcademicGroup)
            .HasForeignKey(e => e.AcademicGroupId);
    }
}