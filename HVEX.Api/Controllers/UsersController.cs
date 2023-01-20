using HVEX.Application.InputModels;
using HVEX.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HVEX.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userModel = await _service.GetUsersAsync();

        return Ok(userModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userModel = await _service.GetUserByIdAsync(id);

        if (userModel == null)
            return NotFound();

        return Ok(userModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddUserInputModel model)
    {
        var id = _service.AddUserAsync(model);

        return CreatedAtAction(nameof(GetById), new {id}, model);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateUserInputModel model)
    {
        await _service.UpdateUserAsync(model);

        return NoContent();
    }


}
