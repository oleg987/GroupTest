using GroupTest.Entities.Components;
using GroupTest.Entities.Subjects;

namespace GroupTest.Factories.Subjects;

public class SubjectFactory : ISubjectFactory
{
    public Subject Create(SubjectModel model)
    {
        return model.ComponentType switch
        {
            ComponentType.MainCommon => new MainCommonSubject()
            {
                StudyPlanId = model.StudyPlanId,
                Semester = model.Semester,
                ComponentId = model.ComponentId,
                SelfHours = model.SelfHours,
                GradingType = (GradingTypes)model.GradingType!,
                Rgr = (RgrTypes)model.Rgr!,
                Cw = (CwTypes)model.Cw!
            },
            ComponentType.MainProfessional => new MainProfessionalSubject()
            {
                StudyPlanId = model.StudyPlanId,
                Semester = model.Semester,
                ComponentId = model.ComponentId,
                SelfHours = model.SelfHours,
                GradingType = (GradingTypes)model.GradingType!,
                Rgr = (RgrTypes)model.Rgr!,
                Cw = (CwTypes)model.Cw!
            },
            ComponentType.AdditionalCommon => new AdditionalCommonSubject()
            {
                StudyPlanId = model.StudyPlanId,
                Semester = model.Semester,
                ComponentId = model.ComponentId,
                SelfHours = model.SelfHours,
                GradingType = (GradingTypes)model.GradingType!,
                Rgr = (RgrTypes)model.Rgr!
            },
            ComponentType.AdditionalProfessional => new AdditionalProfessionalSubject()
            {
                StudyPlanId = model.StudyPlanId,
                Semester = model.Semester,
                ComponentId = model.ComponentId,
                SelfHours = model.SelfHours,
                GradingType = (GradingTypes)model.GradingType!,
                Rgr = (RgrTypes)model.Rgr!
            },
            ComponentType.CourseProject => new CourseProjectSubject()
            {
                StudyPlanId = model.StudyPlanId,
                Semester = model.Semester,
                ComponentId = model.ComponentId,
                SelfHours = model.SelfHours
            },
            ComponentType.Practice => new PracticeSubject()
            {
                StudyPlanId = model.StudyPlanId,
                Semester = model.Semester,
                ComponentId = model.ComponentId,
                SelfHours = model.SelfHours
            },
            ComponentType.Attestation => new AttestationSubject()
            {
                StudyPlanId = model.StudyPlanId,
                Semester = model.Semester,
                ComponentId = model.ComponentId,
                SelfHours = model.SelfHours
            },
            _ => throw new ArgumentException($"Unsupported component type. {model.ComponentType}.")
        };
    }
}