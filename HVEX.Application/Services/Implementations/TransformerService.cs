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

public class TransformerService : ITransformerService
{
    private readonly ITransformerRepository _repository;
    public TransformerService(ITransformerRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<TransformerViewModel>> GetTransformersAsync()
    {
        var entity = await _repository.GetAllAsync();

        return  entity
            .Select(e => new TransformerViewModel(e.TransformerId,e.Name,e.InternalNumber,e.Tension.ToString(),e.Potency,e.Current))
            .ToList();

    }

    public async Task<TransformerViewModel> GetTransformerByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return TransformerViewModel.FromEntity(entity);
    }
    public async Task AddTransformerAsync(AddTransformerInputModel model)
    {
        var transformerModel = model.ToEntity();
        await _repository.AddAsync(transformerModel);
    }  

    public async Task UpdateTransformerAsync(UpdateTransformerInputModel model)
    {
        var transformerModel = model.ToEntity();

        await _repository.UpdateAsync(transformerModel);
    }
}
