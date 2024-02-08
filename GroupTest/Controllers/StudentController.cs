using GroupTest.Entities;
using GroupTest.Entities.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupTest.Controllers;

public record StudentModel(string Name, int AcademicGroupId);

[ApiController]
[Route("api/[controller]/[action]")]
public class StudentController : ControllerBase
{
    private readonly GroupContext _ctx;

    public StudentController(GroupContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public async Task<IEnumerable<Student>> List(CancellationToken cancellationToken)
    {
        return await _ctx.Students.ToListAsync(cancellationToken);
    }

    [HttpPost]
    public async Task<Student> Add(StudentModel model, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            Name = model.Name,
            AcademicGroupId = model.AcademicGroupId
        };

        _ctx.Students.Add(student);

        await _ctx.SaveChangesAsync(cancellationToken);
        
        return student;
    }
}