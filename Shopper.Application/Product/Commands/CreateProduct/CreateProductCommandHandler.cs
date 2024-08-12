

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopper.Application.Users;
using Shopper.Domain.Repositories;

namespace Shopper.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger, IMapper mapper,
        IProductRepository productRepository, IUserContext userContext) : IRequestHandler<CreateProductCommand, int>
    {
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();

            logger.LogInformation("{User} with {Userid} Called CreateProductCommandHandler with  {@product}", currentUser!.Email, currentUser.Id, request);

            var product = mapper.Map<Domain.Entities.Product>(request);
            product.OwnerId = currentUser.Id;

            return await productRepository.AddProductAsync(product);
        }
    }
}
