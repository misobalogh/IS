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
using project.DAL.Entities;
using System.Reflection;

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

    [Theory]
    [InlineData("2024-05-15", "2024-05-16")]  
    [InlineData("2025-01-01", "2025-12-31")]  
    public async Task FilterBySubjects_ReturnsCorrectActivities(DateTime startDate, DateTime endDate)
    {
        Guid subjectId = ActivitySeeds.IFJMidterm.SubjectId;  // Assuming this is seeded

        ActivitySeeds.SeedActivitiesForTesting();
        // Act
        var results = await _activitytFacadeSUT.FilterBySubjects(subjectId, startDate, endDate);

        // Assert
        Assert.All(results, activity =>
        Assert.True(activity.SubjectId == subjectId &&
                    activity.Start >= startDate &&
                    activity.End <= endDate,
            "Activity should match subject and date criteria"));
    }

    [Theory]
    [InlineData("Name", true)]  // Descending sort by name
    [InlineData("Start", false)] // Ascending sort by start date
    public async Task GetSortedActivities_ReturnsSortedResults(string sortBy, bool descending)
    {
        // Arrange
        ActivitySeeds.SeedActivitiesForTesting();

        // Act
        var results = await _activitytFacadeSUT.GetSortedActivities(sortBy, descending);

        // Use reflection correctly here:
        PropertyInfo? propInfo = typeof(ActivityListModel).GetProperty(sortBy);
        if (propInfo == null)
        {
            throw new ArgumentException($"'{sortBy}' is not a valid property of ActivityListModel");
        }

        var expected = descending
            ? results.OrderByDescending(a => propInfo.GetValue(a, null))
            : results.OrderBy(a => propInfo.GetValue(a, null));

        Assert.True(results.SequenceEqual(expected), "Activities should be sorted correctly based on the provided property.");
    }

    [Fact]
    public async Task GetSortedActivities_WithInvalidProperty_ThrowsArgumentException()
    {
        // Arrange
        string invalidProperty = "NonexistentProperty";

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _activitytFacadeSUT.GetSortedActivities(invalidProperty));
    }
}
