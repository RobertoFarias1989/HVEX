using HVEX.Application.InputModels;
using HVEX.Application.Services.Interfaces;
using HVEX.Application.ViewModels;
using HVEX.Core.Repositories;


namespace HVEX.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<UserViewModel>> GetUsersAsync()
    {
        var entity = await _repository.GetAllAsync();

        return entity
            .Select(e=> new UserViewModel(e.UserId,e.Name,e.Email))
            .ToList();
    }
    public async Task<UserViewModel> GetUserByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return UserViewModel.FromEntity(entity);
            
    }
    public async Task AddUserAsync(AddUserInputModel model)
    {
        var userModel = model.ToEntity();
        await _repository.AddAsync(userModel);

    }
    public async Task UpdateUserAsync(UpdateUserInputModel model)
    {
        var userModel = model
            .ToEntity();

        //var userModel = model
        //    .Transformers.Select(t=> t.ToEntity()).ToList();

        await _repository.UpdateAsync(userModel);

    }
}
