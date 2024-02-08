using GroupTest.Entities.Components;

namespace GroupTest.Factories.Components;

public record ComponentModel(
    ComponentType ComponentType, 
    string Title,
    int Hours,
    int Year,
    int? DepartmentId,
    GradingTypes? GradingType,
    RgrTypes? Rgr,
    CwTypes? Cw,
    int? MaxStudentsCount,
    PracticeType? PracticeType,
    AttestationType? AttestationType);