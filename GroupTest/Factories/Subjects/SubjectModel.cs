using GroupTest.Entities.Components;

namespace GroupTest.Factories.Subjects;

public record SubjectModel(
    ComponentType ComponentType,
    int StudyPlanId,
    int Semester,
    int SelfHours,
    int ComponentId,
    RgrTypes? Rgr,
    GradingTypes? GradingType,
    CwTypes? Cw);