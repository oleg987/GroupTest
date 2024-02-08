namespace GroupTest.Entities.Components;

public class CommonAdditionalComponent : AdditionalComponent
{
    public override ComponentType ComponentType { get; protected set; } = ComponentType.AdditionalCommon;
}