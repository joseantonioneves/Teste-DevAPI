using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarteiraDigital.Application.Services;
using CarteiraDigital.Domain.Entities;

namespace CarteiraDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly ExampleService _exampleService;

        public ExampleController(ExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExampleEntity>>> Get()
        {
            var examples = await _exampleService.GetAllAsync();
            return Ok(examples);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExampleEntity>> Get(int id)
        {
            var example = await _exampleService.GetByIdAsync(id);
            if (example == null)
            {
                return NotFound();
            }
            return Ok(example);
        }

        [HttpPost]
        public async Task<ActionResult<ExampleEntity>> Post([FromBody] ExampleEntity example)
        {
            var createdExample = await _exampleService.CreateAsync(example);
            return CreatedAtAction(nameof(Get), new { id = createdExample.Id }, createdExample);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ExampleEntity example)
        {
            if (id != example.Id)
            {
                return BadRequest();
            }

            await _exampleService.UpdateAsync(example);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _exampleService.DeleteAsync(id);
            return NoContent();
        }
    }
}