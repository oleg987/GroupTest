using GroupTest.Entities;
using GroupTest.Entities.StudyUnits;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupTest.Controllers;

public record AcademicModel(string Title, int InstituteId);
public record SubGroupModel(string Title, int ParentId, int[] StudentIds);
public record StudyGroupModel(string Title, int ComponentId, int[] StudentIds);

[ApiController]
[Route("api/[controller]/[action]")]
public class GroupController : ControllerBase
{
    private readonly GroupContext _ctx;

    public GroupController(GroupContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public async Task<IEnumerable<StudyUnit>> ListUnits(CancellationToken cancellationToken)
    {
        return await _ctx.StudyUnits.ToListAsync(cancellationToken);
    }
    
    [HttpGet]
    public async Task<IEnumerable<Group>> ListGroups(CancellationToken cancellationToken)
    {
        return await _ctx.Groups
            .Where(g => g.GroupStudents.Any(s => s.Id == 1))
            .Include(g => g.GroupStudents)
            .ToListAsync(cancellationToken);
    }
    
    [HttpGet]
    public async Task<IEnumerable<AcademicGroup>> ListAcademicGroups(CancellationToken cancellationToken)
    {
        return await _ctx.AcademicGroups
            .Include(g => g.Students)
            .ToListAsync(cancellationToken);
    }
    
    [HttpGet]
    public async Task<IEnumerable<SubGroup>> ListSubGroups(CancellationToken cancellationToken)
    {
        return await _ctx.SubGroups
            .Include(g => g.Students)
            .ToListAsync(cancellationToken);
    }
    
    [HttpGet]
    public async Task<IEnumerable<StudyGroup>> ListStudyGroups(CancellationToken cancellationToken)
    {
        return await _ctx.StudyGroups.Include(g => g.Students).ToListAsync(cancellationToken);
    }

    [HttpPost]
    public async Task<AcademicGroup> AddAcademicGroup(AcademicModel model, CancellationToken cancellationToken)
    {
        var group = new AcademicGroup()
        {
            Title = model.Title,
            InstituteId = model.InstituteId
        };

        _ctx.AcademicGroups.Add(group);

        await _ctx.SaveChangesAsync(cancellationToken);

        return group;
    }
    
    [HttpPost]
    public async Task<SubGroup> AddSubGroup(SubGroupModel model, CancellationToken cancellationToken)
    {
        var group = new SubGroup()
        {
            Title = model.Title,
            ParentId = model.ParentId
        };

        var students = await _ctx.Students
            .Where(s => model.StudentIds.Any(x => x == s.Id))
            .ToListAsync(cancellationToken);

        group.Students = students;

        _ctx.SubGroups.Add(group);

        await _ctx.SaveChangesAsync(cancellationToken);

        return group;
    }
    
    [HttpPost]
    public async Task<StudyGroup> AddStudyGroup(StudyGroupModel model, CancellationToken cancellationToken)
    {
        var group = new StudyGroup()
        {
            Title = model.Title,
            ComponentId = model.ComponentId
        };
        
        var students = await _ctx.Students
            .Where(s => model.StudentIds.Any(x => x == s.Id))
            .ToListAsync(cancellationToken);

        group.Students = students;

        _ctx.StudyGroups.Add(group);

        await _ctx.SaveChangesAsync(cancellationToken);

        return group;
    }
}