using DDMS.Application.Features.Brands.DTOs;
using DDMS.Application.Features.Brands.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController (IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
            var brands = await _brandService.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var brand = await _brandService.GetByIdAsync(id);
            if (brand == null)
            {
                return NotFound();

            }
            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandRequest request)
        {
            var id = await _brandService.CreateAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id },
                new { Id = id, Message = "Brand created successfully." });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateBrandRequest request)
        {
            if (id != request.Id)
                return BadRequest("Route id and request id do not match.");

            await _brandService.UpdateAsync(request);

            return Ok(new
            {
                Message = "Brand updated successfully."
            });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _brandService.DeleteAsync(id);

            return Ok(new
            {
                Message = "Brand deleted successfully."
            });
        }

    }
}
