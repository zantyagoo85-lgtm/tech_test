using AutoMapper;
using prueba_tecnica.Application.DTOs;
using prueba_tecnica.Domain.Entities;
using prueba_tecnica.Domain.Interfaces;

namespace prueba_tecnica.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDto> CreateProduct(CreateProductDto dto)
        {
            Product product = await _unitOfWork.Product.AddAsync(_mapper.Map<Product>(dto));
        }

        public async Task<ApiResponse<List<ProductDto>>> GetAllProducts()
        {
            List<Product> products = (await _unitOfWork.Product.GetAllAsync()).ToList();
            List<ProductDto> productsDto = _mapper.Map<List<ProductDto>>(products);
            return new ApiResponse<List<ProductDto>>
            {
                Data = productsDto ?? [],
                Message = "Consulted",
                Success = true
            };
        }

        public async Task<ProductDto?> GetproductById(int id)
        {
            Product? product = await _unitOfWork.Product.GetByIdAsync(id);
        }

        public Task<ProductDto> UpdateProductById(UpdateProductDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
