using prueba_tecnica.Application.DTOs;

namespace prueba_tecnica.Application.Services
{
    public interface IProductService
    {
        Task<ApiResponse<ProductDto>> CreateProduct(CreateProductDto dto);
        Task<ApiResponse<List<ProductDto>>> GetAllProducts();
        Task<ApiResponse<ProductDto>> GetProductById(int id);
        Task<ApiResponse<ProductDto>> UpdateProductById(UpdateProductDto dto);
        Task<ApiResponse<ProductDto>> DeleteProductById(int id);
    }
}
