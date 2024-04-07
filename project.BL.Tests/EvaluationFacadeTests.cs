using project.BL.Facades;
using project.BL.Models;
using project.Common.Tests;
using project.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using project.DAL.Enums;
using Xunit;
using Xunit.Abstractions;
using StudentSeeds = project.DAL.Seeds.StudentSeeds;

namespace project.BL.Tests;

public sealed class EvaluationFacadeTests : FacadeTestsBase
{
    private readonly IEvaluationFacade _evalutationtFacadeSUT;

    public EvaluationFacadeTests(ITestOutputHelper output) : base(output)
    {
        _evalutationtFacadeSUT = new EvaluationFacade(UnitOfWorkFactory, EvaluationModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new EvaluationModel
        {
            Id = Guid.Parse("56aaa586-11ec-4b9f-97d9-4f0dfe111fcc"),
            Points = 10,
            StudentId = StudentSeeds.Xmrkva01.Id,
            ActivityId = ActivitySeeds.IFJMidterm.Id,

        };

        var _ = await _evalutationtFacadeSUT.SaveAsync(model);
    }
    
    [Fact]
    public async Task GetAll_Single_SeededEvaluation()
    {
        var evaluations = await _evalutationtFacadeSUT.GetAsync();
        var evaluation = evaluations.Single(i => i.Id == EvaluationSeeds.IFJMidterm.Id);

        DeepAssert.Equal(EvaluationModelMapper.MapToListModel(EvaluationSeeds.IFJMidterm), evaluation);
    }
    
    [Fact]
    public async Task GetById_SeededEvaluation()
    {
        var evaluation = await _evalutationtFacadeSUT.GetAsync(EvaluationSeeds.IFJMidterm.Id);

        DeepAssert.Equal(EvaluationModelMapper.MapToDetailModel(EvaluationSeeds.IFJMidterm), evaluation);
    }
    
    [Fact]
    public async Task GetById_NonExistent()
    {
        var evaluation = await _evalutationtFacadeSUT.GetAsync(EvaluationSeeds.EmptyEvaluation.Id);
    
        Assert.Null(evaluation);
    }
    
    [Fact]
    public async Task IFJMidterm_DeleteById_Deleted()
    {
        await _evalutationtFacadeSUT.DeleteAsync(EvaluationSeeds.IFJMidterm.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Evaluations.AnyAsync(i => i.Id == EvaluationSeeds.IFJMidterm.Id));
    }
    
    [Fact]
    public async Task NewEvaluation_InsertOrUpdate_EvaluationAdded()
    {
        //Arrange
        var evaluation = new EvaluationModel
        {
            Id = Guid.Parse("95afbd8d-0603-4399-b7a6-2fd53baaf1da"),
            Points = 200,
            StudentId = StudentSeeds.Xmrkva01.Id,
            ActivityId = ActivitySeeds.IJCConsultation.Id,

        };
    
        //Act
        evaluation = await _evalutationtFacadeSUT.SaveAsync(evaluation);
    
        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var evaluationFromDb = await dbxAssert.Evaluations.SingleAsync(i => i.Id == evaluation.Id);
        DeepAssert.Equal(evaluation, EvaluationModelMapper.MapToDetailModel(evaluationFromDb));
    }
    
    // [Fact]
    // public async Task SeededIFJMidterm_InsertOrUpdate_EvaluationUpdated()
    // {
    //     //Arrange
    //     var evaluation = new EvaluationModel
    //     {
    //         Id = EvaluationSeeds.IFJMidterm.Id,
    //         Points = EvaluationSeeds.IFJMidterm.Points,
    //         StudentId = EvaluationSeeds.IFJMidterm.StudentId,
    //         ActivityId = EvaluationSeeds.IFJMidterm.ActivityId,
    //         Note = EvaluationSeeds.IFJMidterm.Note
    //     };
    //     evaluation.Points += 10;
    //     evaluation.Note = "updated";
    //
    //     //Act
    //     await _evalutationtFacadeSUT.SaveAsync(evaluation);
    //
    //     //Assert
    //     await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
    //     var evaluationFromDb = await dbxAssert.Evaluations.SingleAsync(i => i.Id == evaluation.Id);
    //     DeepAssert.Equal(evaluation, EvaluationModelMapper.MapToDetailModel(evaluationFromDb));
    // }
}
