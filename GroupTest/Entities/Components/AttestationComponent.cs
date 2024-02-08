namespace GroupTest.Entities.Components;

public enum AttestationType
{
    QualificationWork = 1,
    NationalExam = 2
}

public class AttestationComponent : ControlComponent
{
    public override ComponentType ComponentType { get; protected set; } = ComponentType.Attestation;
    public AttestationType AttestationType { get; set; }
}