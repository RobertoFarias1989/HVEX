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

public class ReportService :IReportService
{
    private readonly IReportRepository _repository;
    public ReportService(IReportRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<ReportViewModel>> GetReportsAsync()
    {
        var entity = await _repository.GetAllAsync();

        return entity
            .Select(e => new ReportViewModel(e.ReportId, e.Name, e.Status.ToString()))
            .ToList();
    }
    public async Task<ReportViewModel> GetReportByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return ReportViewModel.FromEntity(entity);
    }

    public async Task AddReportAsync(AddReportInputModel model)
    {
        var ReportModel = model.ToEntity();
        await _repository.AddAsync(ReportModel);
    } 
    
    public async Task UpdateReportAsync(UpdateReportInputModel model)
    {
        var ReportModel = model
            .ToEntity();

        await _repository.UpdateAsync(ReportModel);
    }
}
