using GroupTest.Entities.Subjects;
using GroupTest.Factories.Subjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupTest.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SubjectController : ControllerBase
{
    private readonly GroupContext _ctx;
    private readonly ISubjectFactory _subjectFactory;

    public SubjectController(GroupContext ctx, ISubjectFactory subjectFactory)
    {
        _ctx = ctx;
        _subjectFactory = subjectFactory;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMainProfessional(SubjectModel model, CancellationToken cancellationToken)
    {
        var subject = _subjectFactory.Create(model);

        _ctx.Subjects.Add(subject);

        await _ctx.SaveChangesAsync(cancellationToken);
        
        return Ok(subject);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var model = await _ctx.Subjects
            .Include(s => s.Component)
            .ToListAsync(cancellationToken);
        
        var projection = model.OfType<MainProfessionalSubject>();
        
        return Ok(projection);
    }
}