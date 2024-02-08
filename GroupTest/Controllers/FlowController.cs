using GroupTest.Entities;
using GroupTest.Entities.StudyUnits;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupTest.Controllers;

public record AcademicFlowModel(string Title, IEnumerable<int> GroupIds);

[ApiController]
[Route("api/[controller]/[action]")]
public class FlowController : ControllerBase
{
    private readonly GroupContext _ctx;

    public FlowController(GroupContext ctx)
    {
        _ctx = ctx;
    }

    [HttpPost]
    public async Task<AcademicFlow> AddAcademicFlow(AcademicFlowModel model, CancellationToken cancellationToken)
    {
        var groups = await _ctx.Groups
            .Where(g => model.GroupIds.Any(x => x == g.Id))
            .ToListAsync(cancellationToken);

        var flow = new AcademicFlow()
        {
            Title = model.Title,
            Groups = groups
        };

        _ctx.AcademicFlows.Add(flow);

        await _ctx.SaveChangesAsync(cancellationToken);

        return flow;
    }
}