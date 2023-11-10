using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Verivox.Application.Interfaces;
using Verivox.Application.Models;
using Verivox.Application.Wrappers;
using Verivox.Domain.Entities;
using Verivox.Domain.Interfaces;

namespace Verivox.Application.Features.Tariffs.Queries
{
    public class TariffCalculationHandler : IRequestHandler<GetTariffByConsumptionQuery, Response<List<Comparison>>>
    {
        private List<ElectricityProduct> _products;

        public TariffCalculationHandler(ITariffProvider tariffProvider)
        {
            Task.Run(async () => _products = await tariffProvider.GetProducts()).Wait();
        }

        public async Task<Response<List<Comparison>>> Handle(GetTariffByConsumptionQuery request, CancellationToken cancellationToken)
        {
            var result = new List<Comparison>();

            foreach (var product in _products)
            {
                var annualCost = ((IProductStrategy)product).GetCalculationStrategy(request.ConsumptionKwh);

                result.Add(new Comparison
                {
                    TariffName = product.Name,
                    AnnualCost = annualCost
                });
            }

            return await Task.FromResult(new Response<List<Comparison>>(result));
        }
    }
}