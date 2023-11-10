using Microsoft.AspNetCore.Mvc;
using System.Net;
using Verivox.Application.Features.Tariffs.Queries;

namespace Verivox.Calculator.Controllers;

public class TariffController : BaseApiController
{
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [HttpGet]
    public async Task<IActionResult> Get(int consumptionKwh, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetTariffByConsumptionQuery
        {
            ConsumptionKwh = consumptionKwh
        }, cancellationToken);

        return Ok(result);
    }
}
