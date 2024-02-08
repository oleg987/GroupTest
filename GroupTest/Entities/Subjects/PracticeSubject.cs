using GroupTest.Entities.Components;

namespace GroupTest.Entities.Subjects;

public class PracticeSubject : ControlSubject
{
    public override PracticeComponent? Component { get => _component as PracticeComponent; }
}