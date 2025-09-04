using AutoMapper;
using prueba_tecnica.Application.DTOs;
using prueba_tecnica.Application.FormValidations.FormProduct;
using prueba_tecnica.Domain.Entities;
using prueba_tecnica.Domain.Interfaces;

namespace prueba_tecnica.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFormProduct _formProduct;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IFormProduct formProduct)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _formProduct = formProduct;
        }

        public async Task<ApiResponse<ProductDto>> CreateProduct(CreateProductDto dto)
        {
            Product product = await _formProduct.ValidateRegisterProduct(dto);
            product = await _unitOfWork.Product.AddAsync(product);
            int count = await _unitOfWork.SaveChangesAsync();
            string txtRes = count > 0 ? "Created" : "Error";
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return new ApiResponse<ProductDto>
            {
                Data = productDto,
                Message = txtRes,
                Success = count > 0
            };
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

        public async Task<ApiResponse<ProductDto>> GetProductById(int id)
        {
            Product? product = await _formProduct.ValidateGetProductById(id);
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return new ApiResponse<ProductDto>
            {
                Data = productDto,
                Message = "Consulted",
                Success = true
            };
        }

        public async Task<ApiResponse<ProductDto>> UpdateProductById(UpdateProductDto dto)
        {
            Product product = await _formProduct.ValidateUpdateProduct(dto);
            _unitOfWork.Product.Update(product);
            int count = await _unitOfWork.SaveChangesAsync();
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return new ApiResponse<ProductDto>
            {
                Data = productDto,
                Message = count > 0 ? "Updated" : "Error",
                Success = count > 0
            };
        }

        public async Task<ApiResponse<ProductDto>> DeleteProductById(int id)
        {
            Product product = await _formProduct.ValidateGetProductById(id);
            await _unitOfWork.Product.DeleteAsync(product.Id);
            int count = await _unitOfWork.SaveChangesAsync();
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return new ApiResponse<ProductDto>
            {
                Data = productDto,
                Message = count > 0 ? "Deleted" : "Error",
                Success = count > 0
            };
        }
    }
}
