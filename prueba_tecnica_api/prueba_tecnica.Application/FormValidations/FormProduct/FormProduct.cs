using AutoMapper;
using prueba_tecnica.Application.DTOs;
using prueba_tecnica.Domain.Entities;
using prueba_tecnica.Domain.Interfaces;

namespace prueba_tecnica.Application.FormValidations.FormProduct
{
    public class FormProduct : IFormProduct
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public FormProduct(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> ValidateRegisterProduct(CreateProductDto dto)
        {
            Product product = _mapper.Map<Product>(dto);
            // Validar si el producto ya existe
            var existingProduct = (await _unitOfWork.Product.GetAllAsync())
                .FirstOrDefault(p => p.Name.ToLower() == dto.Name.ToLower());
            if (existingProduct != null)
            {
                throw new Exception("El producto ya existe.");
            }
            return product;
        }
    }
}
