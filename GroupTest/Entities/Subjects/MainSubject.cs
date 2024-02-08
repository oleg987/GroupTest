using GroupTest.Entities.Components;

namespace GroupTest.Entities.Subjects;

public abstract class MainSubject : StudySubject
{
    public CwTypes Cw { get; set; }

    public override MainComponent? Component { get => _component as MainComponent; }
}
