using Microsoft.AspNetCore.Mvc;
using _28MarchAssessment.Interfaces;
using _28MarchAssessment.Models;

namespace _28MarchAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _service;

        public ProductController(IProduct service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            return Ok(await _service.AddAsync(product));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var result = await _service.UpdateAsync(product);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}