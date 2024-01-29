namespace GroupTest.Entities;

public abstract class Group : StudyUnit
{
    public ICollection<Student>? Students { get; set; }
    public IEnumerable<Flow>? Flows { get; set; }
}