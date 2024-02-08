using GroupTest.Entities.Subjects;

namespace GroupTest.Factories.Subjects;

public interface ISubjectFactory
{
    Subject Create(SubjectModel model);
}