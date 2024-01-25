namespace GroupTest.Entities;

public abstract class Group : StudyUnit
{
    public abstract ICollection<Student>? Students { get; set; }
    public virtual IEnumerable<Flow>? Flows { get; set; }
}