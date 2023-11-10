using Verivox.Domain.Interfaces;

namespace Verivox.Domain.Entities
{
    public class BasicTariffElectricityProduct : ElectricityProduct, IProductStrategy
    {
        public decimal GetCalculationStrategy(int consumptionKwh)
        {
            return (BaseCost * 12) + (consumptionKwh * (AdditionalKwhCost / 100));
        }
    }
}