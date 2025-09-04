using prueba_tecnica.Application.DTOs;

namespace prueba_tecnica.Application.Services
{
    public interface IProductService
    {
        Task<ProductDto?> GetproductById(int id);
        Task<ProductDto> GetAllProducts();
        Task<ProductDto> CreateProduct(CreateProductDto dto);
        Task<ProductDto> UpdateProductById(UpdateProductDto dto);
        Task DeleteProductById(int id);
    }
}
