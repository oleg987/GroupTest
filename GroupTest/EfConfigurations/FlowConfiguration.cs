using GroupTest.Entities;
using GroupTest.Entities.StudyUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupTest.EfConfigurations;

public class FlowConfiguration : IEntityTypeConfiguration<Flow>
{
    public void Configure(EntityTypeBuilder<Flow> builder)
    {
        builder
            .HasMany(e => e.Groups)
            .WithMany(e => e.Flows);
    }
}