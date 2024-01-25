namespace GroupTest.Entities;

public class StudyGroup : Group
{
    public int ComponentId { get; set; }
    public override ICollection<Student>? Students { get; set; }
}