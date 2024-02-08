using GroupTest.Entities;
using GroupTest.Entities.StudyUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupTest.EfConfigurations;

public class AcademicFlowConfiguration : IEntityTypeConfiguration<AcademicFlow>
{
    public void Configure(EntityTypeBuilder<AcademicFlow> builder)
    {
        builder
            .HasMany(e => e.Groups)
            .WithMany(e => e.Flows as IEnumerable<AcademicFlow>);
    }
}