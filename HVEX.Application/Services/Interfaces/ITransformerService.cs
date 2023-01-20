using HVEX.Application.InputModels;
using HVEX.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.Services.Interfaces
{
    public interface ITransformerService
    {
        Task<List<TransformerViewModel>> GetTransformersAsync();
        Task<TransformerViewModel> GetTransformerByIdAsync(Guid id);
        Task AddTransformerAsync(AddTransformerInputModel model);
        Task UpdateTransformerAsync(UpdateTransformerInputModel model);
    }
}
