using GroupTest.DbViews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupTest.EfConfigurations;

public class StudentGroupViewConfiguration : IEntityTypeConfiguration<StudentGroupView>
{
    public void Configure(EntityTypeBuilder<StudentGroupView> builder)
    {
        builder
            .HasNoKey()
            .ToView("StudentGroupView");
    }
}