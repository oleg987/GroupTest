namespace GroupTest.Entities;

public class SubGroup : Group
{
    public int ParentId { get; set; }
    public AcademicGroup? Parent { get; set; }
    public override ICollection<Student>? Students { get; set; }
}