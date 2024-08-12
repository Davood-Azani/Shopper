

using AutoMapper;
using Shopper.Application.Product.Commands.CreateProduct;
using Shopper.Application.Product.Commands.UpdateProduct;
using Shopper.Application.Product.Dtos;
using Shopper.Domain.Entities;

namespace Shopper.Application.Product.Mapper;

public class ProductProfile : Profile
{


    public ProductProfile()
    {
        CreateMap<Domain.Entities.Product, ProductDto>()
    .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
    .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
    .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());


        CreateMap<CreateProductCommand, Domain.Entities.Product>();
        //.ForMember(d => d.ProductBrand, o => o.MapFrom(a => new ProductBrand { Id = a.ProductBrandId }))
        //.ForMember(d => d.ProductType, o => o.MapFrom(a => new ProductType { Id = a.ProductTypeId }));

        CreateMap<UpdateProductCommand, Domain.Entities.Product>();



    }
}