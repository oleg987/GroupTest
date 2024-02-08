using GroupTest.Entities.Components;

namespace GroupTest.Entities.Subjects;

public abstract class StudySubject : Subject
{
    public GradingTypes GradingType { get; set; }
    public RgrTypes Rgr { get; set; }

    public override StudyComponent? Component { get => _component as StudyComponent; }
}