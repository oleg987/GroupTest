using GroupTest.Entities.Components;
using GroupTest.Entities.Subjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupTest.EfConfigurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasOne(e => e.Component)
            .WithMany()
            .HasForeignKey(e => e.ComponentId);

        builder
            .Navigation(e => e.Component)
            .HasField("_component");
    }
}