using GroupTest.Entities.Components;

namespace GroupTest.Factories.Components;

public class ComponentFactory : IComponentFactory
{
    public Component Create(ComponentModel model)
    {
        return model.ComponentType switch
        {
            ComponentType.MainCommon => new MainCommonComponent()
            {
                Title = model.Title,
                Hours = model.Hours,
                Year = model.Year,
                DepartmentId = (int)model.DepartmentId!,
                GradingType = (GradingTypes)model.GradingType!,
                Rgr = (RgrTypes)model.Rgr!,
                Cw = (CwTypes)model.Cw!
            },
            ComponentType.MainProfessional => new MainProfessionalComponent()
            {
                Title = model.Title,
                Hours = model.Hours,
                Year = model.Year,
                DepartmentId = (int)model.DepartmentId!,
                GradingType = (GradingTypes)model.GradingType!,
                Rgr = (RgrTypes)model.Rgr!,
                Cw = (CwTypes)model.Cw!
            },
            ComponentType.AdditionalCommon => new CommonAdditionalComponent()
            {
                Title = model.Title,
                Hours = model.Hours,
                Year = model.Year,
                DepartmentId = (int)model.DepartmentId!,
                GradingType = (GradingTypes)model.GradingType!,
                Rgr = (RgrTypes)model.Rgr!,
                MaxStudentsCount = (int)model.MaxStudentsCount!
            },
            ComponentType.AdditionalProfessional => new ProfessionalAdditionalComponent()
            {
                Title = model.Title,
                Hours = model.Hours,
                Year = model.Year,
                DepartmentId = (int)model.DepartmentId!,
                GradingType = (GradingTypes)model.GradingType!,
                Rgr = (RgrTypes)model.Rgr!,
                MaxStudentsCount = (int)model.MaxStudentsCount!
            },
            ComponentType.CourseProject => new CourseProjectComponent()
            {
                Title = model.Title,
                Hours = model.Hours,
                Year = model.Year
            },
            ComponentType.Practice => new PracticeComponent()
            {
                Title = model.Title,
                Hours = model.Hours,
                Year = model.Year,
                PracticeType = (PracticeType)model.PracticeType!
            },
            ComponentType.Attestation => new AttestationComponent()
            {
                Title = model.Title,
                Hours = model.Hours,
                Year = model.Year,
                AttestationType = (AttestationType)model.AttestationType!
            },
            _ => throw new ArgumentException($"Unsupported component type. {model.ComponentType}.")
        };
    }
}