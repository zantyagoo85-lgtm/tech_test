using prueba_tecnica.Application.DTOs;
using prueba_tecnica.Domain.Entities;

namespace prueba_tecnica.Application.FormValidations.FormProduct
{
    public interface IFormProduct
    {
        Task<Product> ValidateRegisterProduct(CreateProductDto dto);

        Task ValidateExistingProduct(string name);

        Task<Product> ValidateUpdateProduct(UpdateProductDto dto);

        Task<Product> ValidateGetProductById(int id);

    }
}
