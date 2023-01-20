using HVEX.Application.InputModels;
using HVEX.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HVEX.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly IReportService _service;

    public ReportsController(IReportService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var ReportModel = await _service.GetReportsAsync();

        return Ok(ReportModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var ReportModel = await _service.GetReportByIdAsync(id);

        if (ReportModel == null)
            return NotFound();

        return Ok(ReportModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddReportInputModel model)
    {
        var id =  _service.AddReportAsync(model);

        return CreatedAtAction(nameof(GetById), new { id }, model);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateReportInputModel model)
    {
        await _service.UpdateReportAsync(model);

        return NoContent();
    }
}
