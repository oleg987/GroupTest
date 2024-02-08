using GroupTest.Entities.Components;

namespace GroupTest.Entities.ComponentSemesters;

public class ComponentSemester
{
    public int Id { get; init; }
    public int ComponentId { get; set; }
    public int Semester { get; set; }
    public int EduFormId { get; set; }
    public int LectionsCount { get; set; }
    public int PracticCount { get; set; }
    public int LabourCount { get; set; }

    public MainComponent? Component { get; private set; }

    public ComponentSemester(
        int componentId, 
        int semester, 
        int eduFormId, 
        int lectionsCount, 
        int practicCount, 
        int labourCount)
    {
        ComponentId = componentId;
        Semester = semester;
        EduFormId = eduFormId;
        LectionsCount = lectionsCount;
        PracticCount = practicCount;
        LabourCount = labourCount;
    }
}