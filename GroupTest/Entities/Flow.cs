namespace GroupTest.Entities;

public abstract class Flow : StudyUnit
{
    public IEnumerable<Group>? Groups { get; set; }
}