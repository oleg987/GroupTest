namespace GroupTest.Entities.Components;

public class ProfessionalAdditionalComponent : AdditionalComponent
{
    public override ComponentType ComponentType { get; protected set; } = ComponentType.AdditionalProfessional;
}