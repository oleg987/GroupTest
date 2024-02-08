namespace GroupTest.Entities.Components;

public enum ComponentType
{
    MainCommon = 1,
    MainProfessional = 2,
    AdditionalCommon = 3,
    AdditionalProfessional = 4,
    CourseProject = 5,
    Practice = 6,
    Attestation = 7
}

public abstract class Component
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int Hours { get; set; }
    public int Year { get; set; }
    public abstract ComponentType ComponentType { get; protected set; }
}