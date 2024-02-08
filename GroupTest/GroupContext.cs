using GroupTest.DbViews;
using GroupTest.Entities.Components;
using GroupTest.Entities.Students;
using GroupTest.Entities.StudyUnits;
using GroupTest.Entities.Subjects;
using Microsoft.EntityFrameworkCore;

namespace GroupTest;

public class GroupContext : DbContext
{
    public GroupContext(DbContextOptions<GroupContext> options) : base(options)
    {
        
    }
    
    public DbSet<Student> Students { get; set; }
    
    #region Study Unit
    
    #region Abstractions
    
    public DbSet<StudyUnit> StudyUnits { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Flow> Flows { get; set; }
    
    #endregion

    #region Concrete Types
    
    public DbSet<AcademicGroup> AcademicGroups { get; set; }
    public DbSet<SubGroup> SubGroups { get; set; }
    public DbSet<StudyGroup> StudyGroups { get; set; }
    public DbSet<AcademicFlow> AcademicFlows { get; set; }
    
    #endregion
    
    #endregion

    #region Component
    
    #region Abstractions
    
    public DbSet<Component> Components { get; set; }
    public DbSet<StudyComponent> StudyComponents { get; set; }
    public DbSet<MainComponent> MainComponents { get; set; }
    public DbSet<AdditionalComponent> AdditionalComponents { get; set; }
    public DbSet<ControlComponent> ControlComponents { get; set; }
    
    #endregion
    
    #region Concrete Types
    
    public DbSet<MainCommonComponent> MainCommonComponents { get; set; }
    public DbSet<MainProfessionalComponent> MainProfessionalComponents { get; set; }
    public DbSet<CommonAdditionalComponent> CommonAdditionalComponents { get; set; }
    public DbSet<ProfessionalAdditionalComponent> ProfessionalAdditionalComponents { get; set; }
    public DbSet<PracticeComponent> PracticeComponents { get; set; }
    public DbSet<CourseProjectComponent> CourseProjectComponents { get; set; }
    public DbSet<AttestationComponent> AttestationComponents { get; set; }
    
    #endregion
    
    #endregion
    
    #region Subject

    #region Abstractions

    public DbSet<Subject> Subjects { get; set; }
    public DbSet<StudySubject> StudySubjects { get; set; }
    public DbSet<ControlSubject> ControlSubjects { get; set; }
    public DbSet<MainSubject> MainSubjects { get; set; }
    public DbSet<AdditionalSubject> AdditionalSubjects { get; set; }
    
    #endregion

    #region Concrete Types
    
    public DbSet<MainCommonSubject> MainCommonSubjects { get; set; }
    public DbSet<MainProfessionalSubject> MainProfessionalSubjects { get; set; }
    public DbSet<AdditionalCommonSubject> AdditionalCommonSubjects { get; set; }
    public DbSet<AdditionalProfessionalSubject> AdditionalProfessionalSubjects { get; set; }
    public DbSet<AttestationSubject> AttestationSubjects { get; set; }
    public DbSet<PracticeSubject> PracticeSubjects { get; set; }
    public DbSet<CourseProjectSubject> CourseProjectSubjects { get; set; }

    #endregion

    #endregion

    #region Views

    public DbSet<StudentGroupView> StudentGroups { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}