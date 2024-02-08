using GroupTest.Factories.Components;
using Microsoft.AspNetCore.Mvc;

namespace GroupTest.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ComponentController : ControllerBase
{
    private readonly GroupContext _ctx;
    private readonly IComponentFactory _componentFactory;

    public ComponentController(GroupContext ctx, IComponentFactory componentFactory)
    {
        _ctx = ctx;
        _componentFactory = componentFactory;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ComponentModel model, CancellationToken cancellationToken)
    {
        var component = _componentFactory.Create(model);

        _ctx.Components.Add(component);
        
        await _ctx.SaveChangesAsync(cancellationToken);
        
        return Ok(component);
    }
}