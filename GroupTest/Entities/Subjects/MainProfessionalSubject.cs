using GroupTest.Entities.Components;

namespace GroupTest.Entities.Subjects;

public class MainProfessionalSubject : MainSubject
{
    public override MainProfessionalComponent? Component { get => _component as MainProfessionalComponent; }
}