using GroupTest.Entities.Students;

namespace GroupTest.Entities.StudyUnits;

public abstract class Group : StudyUnit
{
    public ICollection<Student>? Students { get; set; }
    public IEnumerable<Flow>? Flows { get; set; }
    public ICollection<Student>? GroupStudents { get; set; }
}