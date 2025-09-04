using Microsoft.AspNetCore.Mvc;
using prueba_tecnica.Application.DTOs;
using prueba_tecnica.Application.DTOs.Common;
using prueba_tecnica.Application.Services;

namespace prueba_tecnica.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("registerProduct")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterProduct(CreateProductDto productDto)
        {
            try
            {
                return Ok(await _productService.CreateProduct(productDto));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        [HttpGet("getAllProduct")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _productService.GetAllProducts());
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        [HttpGet("getProductById")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductById([FromQuery] int id)
        {
            try
            {
                return Ok(await _productService.GetProductById(id));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        [HttpDelete("deleteProductById")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProductById([FromQuery] int id)
        {
            try
            {
                return Ok(await _productService.DeleteProductById(id));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }

        [HttpPut("updateProductById")]
        [ProducesResponseType(typeof(ApiException), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<ProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProductById(UpdateProductDto productDto)
        {
            try
            {
                return Ok(await _productService.UpdateProductById(productDto));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiException(e));
            }
        }
    }
}
