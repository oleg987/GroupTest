using GroupTest.Entities.Components;

namespace GroupTest.Entities.Subjects;

public abstract class Subject
{
    protected Component? _component;
    
    public int Id { get; set; }
    public int Semester { get; set; }
    public int StudyPlanId { get; set; }
    public int SelfHours { get; set; }
    public int ComponentId { get; set; }
    public virtual Component? Component { get => _component; }
}