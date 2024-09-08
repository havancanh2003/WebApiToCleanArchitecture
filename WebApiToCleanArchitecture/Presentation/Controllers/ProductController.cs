using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiToCleanArchitecture.Application.DTOs;
using WebApiToCleanArchitecture.Application.Services;

namespace WebApiToCleanArchitecture.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductDto productDto)
        {
            try
            {
                await _productService.AddProductAsync(productDto);
                return Ok("successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); 
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, ProductDto productDto)
        {
            if (id != productDto.Id) return BadRequest();   
            await _productService.UpdateProductAsync(productDto);
            return Ok("successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return Ok("successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

    }
}
