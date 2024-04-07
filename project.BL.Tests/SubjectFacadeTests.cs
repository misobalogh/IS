using project.BL.Facades;
using project.BL.Models;
using project.Common.Tests;
using project.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace project.BL.Tests;

public sealed class SubjectFacadeTests : FacadeTestsBase
{
    private readonly ISubjectFacade _subjectFacadeSUT;

    public SubjectFacadeTests(ITestOutputHelper output) : base(output)
    {
        _subjectFacadeSUT = new SubjectFacade(UnitOfWorkFactory, SubjectModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new SubjectModel
        {
            Id = Guid.Parse("5685f586-11ec-4b9f-97d9-4f0dfe4c7fcc"),
            Name = @"Subject 1",
            Tag = "S1",
        };

        var _ = await _subjectFacadeSUT.SaveAsync(model);
    }
    
    [Fact]
    public async Task GetAll_Single_SeededSubject()
    {
        var subjects = await _subjectFacadeSUT.GetAsync();
        var subject = subjects.Single(i => i.Id == SubjectSeeds.IJC.Id);

        DeepAssert.Equal(SubjectModelMapper.MapToListModel(SubjectSeeds.IJC), subject);
    }
}
