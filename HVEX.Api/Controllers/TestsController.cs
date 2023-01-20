using HVEX.Application.InputModels;
using HVEX.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HVEX.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
    private readonly ITestService _service;
    public TestsController(ITestService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var TestModel = await _service.GetTestsAsync();

        return Ok(TestModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var TestModel = await _service.GetTestByIdAsync(id);

        if (TestModel == null)
            return NotFound();

        return Ok(TestModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddTestInputModel model)
    {
        var id =  _service.AddTestAsync(model);

        return CreatedAtAction(nameof(GetById), new { id }, model);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateTestInputModel model)
    {
        await _service.UpdateTestAsync(model);

        return NoContent();
    }
}
