namespace GroupTest.Entities.StudyUnits;

public abstract class Flow : StudyUnit
{
    public IEnumerable<Group>? Groups { get; set; }
}