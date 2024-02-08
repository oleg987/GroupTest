namespace GroupTest.Entities.Components;

public enum PracticeType
{
    Factory = 1,
    PreDiploma = 2
}

public class PracticeComponent : ControlComponent
{
    public override ComponentType ComponentType { get; protected set; } = ComponentType.Practice;

    public PracticeType PracticeType { get; set; }
}