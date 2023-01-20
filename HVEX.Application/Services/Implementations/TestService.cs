using HVEX.Application.InputModels;
using HVEX.Application.Services.Interfaces;
using HVEX.Application.ViewModels;
using HVEX.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.Services.Implementations;

public class TestService : ITestService
{
    private readonly ITestRepository _repository;
    public TestService(ITestRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<TestViewModel>> GetTestsAsync()
    {
        var entity = await _repository.GetAllAsync();

        return entity
            .Select(e => new TestViewModel(e.TestId,e.Name,e.Status.ToString(),e.Duration))
            .ToList();
    }

    public async Task<TestViewModel> GetTestByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return TestViewModel.FromEntity(entity);
    }
    public async Task AddTestAsync(AddTestInputModel model)
    {
        var TestModel = model.ToEntity();
        await _repository.AddAsync(TestModel);
    }   
    public async Task UpdateTestAsync(UpdateTestInputModel model)
    {
        var TestModel = model
            .ToEntity();     

        await _repository.UpdateAsync(TestModel);
    }
}
