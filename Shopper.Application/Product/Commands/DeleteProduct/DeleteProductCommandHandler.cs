

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopper.Domain.Constants;
using Shopper.Domain.Exceptions;

using Shopper.Domain.Repositories;

namespace Shopper.Application.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger,
    IProductRepository productRepository  
    
    ) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {

        logger.LogInformation("DeleteProductCommandHandler called with id: {Id}", request.Id);
        var product = await productRepository.GetProductByIdAsync(request.Id)
         ?? throw new NotFoundException(nameof(Product) , request.Id.ToString());
       
     
        await productRepository.DeleteProductAsync(product);

    }
}
