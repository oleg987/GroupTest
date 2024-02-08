using GroupTest.Entities.Components;

namespace GroupTest.Factories.Components;

public interface IComponentFactory
{
    Component Create(ComponentModel model);
}