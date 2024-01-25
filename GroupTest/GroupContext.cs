using GroupTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroupTest;

public class GroupContext : DbContext
{
    public GroupContext(DbContextOptions<GroupContext> options) : base(options)
    {
        
    }
    
    public DbSet<Student> Students { get; set; }
    
    
    public DbSet<StudyUnit> StudyUnits { get; set; }
    // Groups.
    public DbSet<Group> Groups { get; set; }
    
    public DbSet<AcademicGroup> AcademicGroups { get; set; }
    public DbSet<SubGroup> SubGroups { get; set; }
    public DbSet<StudyGroup> StudyGroups { get; set; }
    
    // Flows.
    public DbSet<Flow> Flows { get; set; }

    public DbSet<AcademicFlow> AcademicFlows { get; set; }
    
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Group configuration.
        
        // Academic.
        modelBuilder.Entity<AcademicGroup>()
            .HasMany(e => e.Students)
            .WithOne(e => e.AcademicGroup)
            .HasForeignKey(e => e.AcademicGroupId);
        
        // SubGroup.
        modelBuilder.Entity<SubGroup>()
            .HasOne(e => e.Parent)
            .WithMany(e => e.SubGroups)
            .HasForeignKey(e => e.ParentId);

        modelBuilder.Entity<SubGroup>()
            .HasMany(e => e.Students)
            .WithMany(e => e.SubGroups);
        
        // StudyGroup.
        modelBuilder.Entity<StudyGroup>()
            .HasMany(e => e.Students)
            .WithMany(e => e.StudyGroups);
        
        // Flow configuration.
        modelBuilder.Entity<Flow>()
            .HasMany(e => e.Groups)
            .WithMany(e => e.Flows);
        
        modelBuilder.Entity<AcademicFlow>()
            .HasMany(e => e.Groups)
            .WithMany(e => e.Flows as IEnumerable<AcademicFlow>);
        
        base.OnModelCreating(modelBuilder);
    }
}