using HVEX.Application.InputModels;
using HVEX.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.Services.Interfaces
{
    public interface IReportService
    {
        Task<List<ReportViewModel>> GetReportsAsync();
        Task<ReportViewModel> GetReportByIdAsync(Guid id);
        Task AddReportAsync(AddReportInputModel model);
        Task UpdateReportAsync(UpdateReportInputModel model);
    }
}
