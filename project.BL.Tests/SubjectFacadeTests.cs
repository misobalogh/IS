using project.BL.Facades;
using project.BL.Models;
using project.Common.Tests;
using project.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using project.DAL.Entities;
using project.DAL.Enums;
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
    
    [Fact]
    public async Task GetById_SeededSubject()
    {
        var subject = await _subjectFacadeSUT.GetAsync(SubjectSeeds.IJC.Id);

        DeepAssert.Equal(SubjectModelMapper.MapToDetailModel(SubjectSeeds.IJC), subject);
    }
    
    [Fact]
    public async Task GetById_NonExistent()
    {
        var subject = await _subjectFacadeSUT.GetAsync(SubjectSeeds.EmptySubject.Id);
    
        Assert.Null(subject);
    }
    
    [Fact]
    public async Task SeededIJC_DeleteById_Deleted()
    {
        await _subjectFacadeSUT.DeleteAsync(SubjectSeeds.IJC.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Subjects.AnyAsync(i => i.Id == SubjectSeeds.IJC.Id));
    }
    
    [Fact]
    public async Task NewSubject_InsertOrUpdate_SubjectAdded()
    {
        //Arrange
        var subject = new SubjectModel()
        {
            Id = Guid.Empty,
            Name = "Subject Name",
            Tag = "ISN",
            LectureHours = null,
            LecturePlan = null,
            ProjectHours = 20,
            ProjectInfo = "Project Informations",
            Semester = Semester.Winter,
            SubjectDescription = null,
            TotalPoints = 49.5
        };
    
        //Act
        subject = await _subjectFacadeSUT.SaveAsync(subject);
    
        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var subjectFromDb = await dbxAssert.Subjects.SingleAsync(i => i.Id == subject.Id);
        DeepAssert.Equal(subject, SubjectModelMapper.MapToDetailModel(subjectFromDb));
    }
    
    [Fact]
    public async Task SeededIFJ_InsertOrUpdate_SubjectUpdated()
    {
        //Arrange
        var subject = new SubjectModel()
        {
            Id = SubjectSeeds.IFJ.Id,
            Name = SubjectSeeds.IFJ.Name,
            Tag = SubjectSeeds.IFJ.Tag,
            Semester = SubjectSeeds.IFJ.Semester,
        };
        subject.Name += "updated";
        subject.Tag += "updated";

        //Act
        await _subjectFacadeSUT.SaveAsync(subject);

        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var ingredientFromDb = await dbxAssert.Subjects.SingleAsync(i => i.Id == subject.Id);
        DeepAssert.Equal(subject, SubjectModelMapper.MapToDetailModel(ingredientFromDb));
    }

    [Theory]
    [InlineData("math")]
    [InlineData("History")]
    [InlineData("bio")] 
    public async Task SearchSubject_ReturnsFilteredSubjects(string searchTerm)
    {
        // Arrange
        var seededSubjects = new List<SubjectEntity>
        {
            new SubjectEntity { Id = Guid.NewGuid(), Name = "Mathematics", Tag = "MATH101" },
            new SubjectEntity { Id = Guid.NewGuid(), Name = "History", Tag = "HIST202" },
            new SubjectEntity { Id = Guid.NewGuid(), Name = "Biology", Tag = "BIO303" }
        };

        await using (var dbx = await DbContextFactory.CreateDbContextAsync())
        {
            dbx.Subjects.AddRange(seededSubjects);
            await dbx.SaveChangesAsync();
        }

        // Act
        var results = await _subjectFacadeSUT.SearchSubject(searchTerm);

        // Assert
        Assert.NotEmpty(results);
        Assert.All(results, subject => Assert.True(
            subject.SubjectName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            subject.SubjectTag.Contains(searchTerm, StringComparison.OrdinalIgnoreCase),
            $"SearchTerm: {searchTerm}"));
    }
}
