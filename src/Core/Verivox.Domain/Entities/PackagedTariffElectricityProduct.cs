using Verivox.Domain.Interfaces;

namespace Verivox.Domain.Entities
{
    public class PackagedTariffElectricityProduct : ElectricityProduct, IProductStrategy
    {
        public int IncludedKwh { get; set; }

        public decimal GetCalculationStrategy(int consumptionKwh)
        {
            if (consumptionKwh <= IncludedKwh)
            {
                return BaseCost;
            }

            return BaseCost + (consumptionKwh - IncludedKwh) * (AdditionalKwhCost / 100);
        }
    }
}