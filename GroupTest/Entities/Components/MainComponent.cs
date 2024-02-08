using System.ComponentModel.DataAnnotations;
using GroupTest.Entities.ComponentSemesters;

namespace GroupTest.Entities.Components;

public enum CwTypes
{
    [Display(Name = "Немає")]
    None = 1,
    [Display(Name = "КР")]
    CW = 2
}

public abstract class MainComponent : StudyComponent
{
    public CwTypes Cw { get; set; }
    
    public ICollection<ComponentSemester>? ComponentSemesters { get; set; }
}