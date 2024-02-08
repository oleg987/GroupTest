using System.ComponentModel.DataAnnotations;

namespace GroupTest.Entities.Components;

public enum GradingTypes
{
    [Display(Name = "Екзамен")]
    Exam = 1,
    [Display(Name = "Залік")]
    Offset = 2
}

public enum RgrTypes
{
    [Display(Name = "Немає")]
    None = 1,
    [Display(Name = "РГР")]
    RGR = 2,
    [Display(Name = "РР")]
    RR = 3
}

public abstract class StudyComponent : Component
{
    public int DepartmentId { get; set; }
    public GradingTypes GradingType { get; set; }
    public RgrTypes Rgr { get; set; }
}