namespace GroupTest.Entities.StudyUnits;

public class AcademicGroup : Group
{
    public int InstituteId { get; set; }
    
    public IEnumerable<SubGroup>? SubGroups { get; set; }
    
}