using AutoMapper;
using prueba_tecnica.Application.DTOs;
using prueba_tecnica.Domain.Entities;

namespace prueba_tecnica.Application.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
