namespace GroupTest.Entities.StudyUnits;

public class SubGroup : Group
{
    public int ParentId { get; set; }
    public AcademicGroup? Parent { get; set; }
    
    
}