using HVEX.Application.InputModels;
using HVEX.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVEX.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetUsersAsync();
        Task<UserViewModel> GetUserByIdAsync(Guid id);
        Task AddUserAsync(AddUserInputModel model);       
        Task UpdateUserAsync(UpdateUserInputModel model);
    }
}
