using project.BL.Facades;
using project.BL.Models;
using project.Common.Tests;
using project.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using project.BL.Facades.Interfaces;
using project.DAL.Enums;
using Xunit;
using Xunit.Abstractions;
using StudentSeeds = project.DAL.Seeds.StudentSeeds;

namespace project.BL.Tests;

public sealed class ActivityFacadeTests : FacadeTestsBase
{
    private readonly IActivityFacade _activitytFacadeSUT;

    public ActivityFacadeTests(ITestOutputHelper output) : base(output)
    {
        _activitytFacadeSUT = new ActivityFacade(UnitOfWorkFactory, ActivityModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new ActivityModel
        {
            Id = Guid.Parse("5bb5f586-11ec-4b9f-97d9-4f0dfe111fcc"),
            SubjectId = ActivitySeeds.IJCConsultation.SubjectId,
            SubjectName = ActivitySeeds.IJCConsultation.Subject.Name,
            Name = "MA",
            ActivityType = ActivityType.Lecture,
            TeacherName = ActivitySeeds.IJCConsultation.Teacher.LastName,
            Start = default,
            End = default,
            Room = Room.B01,
            Capacity = 0,
            MaxPoints = 0,
            TeacherId = ActivitySeeds.IJCConsultation.TeacherId,

        };

        await _activitytFacadeSUT.SaveAsync(model, model.SubjectId, model.TeacherId);
    }
    
    [Fact]
    public async Task GetById_NonExistent()
    {
        var activity = await _activitytFacadeSUT.GetAsync(ActivitySeeds.EmptyActivity.Id);
    
        Assert.Null(activity);
    }
    
    [Fact]
    public async Task IFJMidterm_DeleteById_Deleted()
    {
        await _activitytFacadeSUT.DeleteAsync(ActivitySeeds.IFJMidterm.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Activities.AnyAsync(i => i.Id == ActivitySeeds.IFJMidterm.Id));
    }
}
