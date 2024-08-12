using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopper.Application.Product.Commands.CreateProduct;
using Shopper.Application.Product.Commands.DeleteProduct;
using Shopper.Application.Product.Commands.UpdateProduct;
using Shopper.Application.Product.Dtos;
using Shopper.Application.Product.Queries.GetAllProducts;
using Shopper.Application.Product.Queries.GetProductById;
using Shopper.Domain.Constants;


namespace Shopper.Api.Controllers
{

    [Authorize]
    public class ProductsController(IMediator mediator) : BaseApiController
    {

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts([FromQuery] GetAllProductsQuery query)
        {

            var products = await mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]



        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]

        [Authorize(Roles = UserRoles.Owner)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {

            int productId = await mediator.Send(createProductCommand);
            return CreatedAtAction(nameof(GetProduct), new { id = productId }, createProductCommand);


        }


        [HttpPatch("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductCommand updateProductCommand)
        {
            updateProductCommand.Id = id;
            await mediator.Send(updateProductCommand);
            return NoContent();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            await mediator.Send(new DeleteProductCommand(id));

            return NoContent();

        }
    }


}
