using AutoMapper;
using prueba_tecnica.Application.DTOs;
using prueba_tecnica.Application.DTOs.Common;
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
            await ValidateExistingProduct(dto.Name);
            if (dto.Price < 0 || dto.Price == null) throw new BusinessException("El precio es requerido y no puede ser negativo.");
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new BusinessException("El nombre es requerido.");
            Product product = _mapper.Map<Product>(dto);
            return product;
        }

        public async Task ValidateExistingProduct(string name)
        {
            Product? existingProduct = (await _unitOfWork.Product.GetAllAsync())
                .FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            if (existingProduct != null) throw new BusinessException("El producto ya existe.");
        }

        public async Task<Product> ValidateUpdateProduct(UpdateProductDto dto)
        {
            Product product = await ValidateGetProductById(dto.Id);
            if (dto.Name != product.Name) await ValidateExistingProduct(dto.Name);
            if (dto.Price < 0) throw new BusinessException("El precio no puede ser negativo.");
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new BusinessException("El nombre es requerido.");
            _mapper.Map(dto, product);
            return product;
        }

        public async Task<Product> ValidateGetProductById(int id)
        {
            Product? product = await _unitOfWork.Product.GetByIdAsync(id);
            if (product == null) throw new BusinessException("El producto no existe.");
            return product;
        }
    }
}
