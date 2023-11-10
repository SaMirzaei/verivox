using System.Collections.Generic;
using MediatR;
using Verivox.Application.Models;
using Verivox.Application.Wrappers;

namespace Verivox.Application.Features.Tariffs.Queries
{
    public class GetTariffByConsumptionQuery : IRequest<Response<List<Comparison>>>
    {
        public int ConsumptionKwh { get; set; }
    }
}