using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopper.Application.ProductCharacteristic.Commands.CreateProductCharacteristic;
using Shopper.Application.ProductCharacteristic.Commands.DeleteProductCharacteristic;
using Shopper.Application.ProductCharacteristic.Commands.UpdateProductCharacteristic;
using Shopper.Application.ProductCharacteristic.Dtos;
using Shopper.Application.ProductCharacteristic.Queries;
using Shopper.Application.ProductCharacteristic.Queries.GetProductCharacteristicById;
using Shopper.Application.ProductCharacteristic.Queries.GetProductCharacteristicsByType;
using Shopper.Domain.Constants;

namespace Shopper.Api.Controllers
{


    [Authorize(Roles = UserRoles.Admin)]
    public class ProductCharacteristicController(IMediator mediator) : BaseApiController
    {

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductCharacteristicDto>>> GetProductCharacteristics
            ([FromQuery] GetAllProductCharacteristicsQuery query)
        {

            var productCharacteristics = await mediator.Send(query);
            return Ok(productCharacteristics);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductCharacteristicDto>> GetProductCharacteristic(int id)
        {
            var productCharacteristic = await mediator.Send(new GetProductCharacteristicByIdQuery(id));
            return Ok(productCharacteristic);
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProductCharacteristic(
            [FromBody] CreateProductCharacteristicCommand createProductCharacteristicCommand)
        {

            int productCharacteristicId = await mediator.Send(createProductCharacteristicCommand);
            return CreatedAtAction(nameof(GetProductCharacteristic), new { id = productCharacteristicId },
                createProductCharacteristicCommand);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProductCharacteristic([FromRoute] int id,
            [FromBody] UpdateProductCharacteristicCommand updateProductCharacteristicCommand)
        {
            updateProductCharacteristicCommand.Id = id;
            await mediator.Send(updateProductCharacteristicCommand);
            return NoContent();
        }

        [HttpGet("type/{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]

        public async Task<ActionResult<IReadOnlyList<ProductCharacteristicByTypeDto>>> GetProductCharacteristicsByType(int id)
        {
            var productCharacteristics =
                await mediator.Send(new GetProductCharacteristicsByTypeQuery(id));
            return Ok(productCharacteristics);
        }

        //[HttpDelete("{id}")]
        //[ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        //[ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> DeleteProductCharacteristic(int id)
        //{
        //    await mediator.Send(new DeleteProductCharacteristicCommand(id));
        //    return NoContent();
        //}


    }
}



