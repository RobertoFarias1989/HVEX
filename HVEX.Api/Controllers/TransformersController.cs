using HVEX.Application.InputModels;
using HVEX.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HVEX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransformersController : ControllerBase
    {
        private readonly ITransformerService _service;

        public TransformersController(ITransformerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var transformerModel = await _service.GetTransformersAsync();

            return Ok(transformerModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var transformerModel = await _service.GetTransformerByIdAsync(id);

            if (transformerModel == null)
                return NotFound();

            return Ok(transformerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddTransformerInputModel model)
        {
            var id =  _service.AddTransformerAsync(model);

            return CreatedAtAction(nameof(GetById), new { id }, model);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateTransformerInputModel model)
        {
            await _service.UpdateTransformerAsync(model);

            return NoContent();
        }
    }
}
