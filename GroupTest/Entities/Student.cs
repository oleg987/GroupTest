namespace GroupTest.Entities;

public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int AcademicGroupId { get; set; }

    public AcademicGroup? AcademicGroup { get; set; }
    public IEnumerable<SubGroup>? SubGroups { get; set; }
    public IEnumerable<StudyGroup>? StudyGroups { get; set; }
}