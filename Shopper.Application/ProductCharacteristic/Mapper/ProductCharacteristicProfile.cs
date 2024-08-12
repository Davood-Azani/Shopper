

using AutoMapper;
using Shopper.Application.ProductCharacteristic.Commands.CreateProductCharacteristic;
using Shopper.Application.ProductCharacteristic.Commands.UpdateProductCharacteristic;
using Shopper.Application.ProductCharacteristic.Dtos;

namespace Shopper.Application.ProductCharacteristic.Mapper;

public class ProductCharacteristicProfile : Profile
{

    public ProductCharacteristicProfile()
    {
   
        CreateMap<Domain.Entities.ProductCharacteristic, ProductCharacteristicDto>();
        CreateMap<CreateProductCharacteristicCommand, Domain.Entities.ProductCharacteristic>();
        CreateMap<UpdateProductCharacteristicCommand, Domain.Entities.ProductCharacteristic>();
        CreateMap<Domain.Entities.ProductCharacteristic, ProductCharacteristicByTypeDto>();


    }
}