
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopper.Domain.Constants;
using Shopper.Domain.Exceptions;

using Shopper.Domain.Repositories;

namespace Shopper.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger,
    IProductRepository productRepository, IMapper mapper ) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductCommandHandler called with id: {Id} with {@UpdateProduct}", request.Id, request);
        var product = await productRepository.GetProductByIdAsync(request.Id)
        ?? throw new NotFoundException(nameof(Product) , request.Id.ToString());
       

        mapper.Map(request, product);
        await productRepository.SaveChangesAsync();


    }
}