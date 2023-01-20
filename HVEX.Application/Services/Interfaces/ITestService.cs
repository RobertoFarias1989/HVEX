using HVEX.Application.InputModels;
using HVEX.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.Services.Interfaces
{
    public interface ITestService
    {
        Task<List<TestViewModel>> GetTestsAsync();
        Task<TestViewModel> GetTestByIdAsync(Guid id);
        Task AddTestAsync(AddTestInputModel model);
        Task UpdateTestAsync(UpdateTestInputModel model);
    }
}
