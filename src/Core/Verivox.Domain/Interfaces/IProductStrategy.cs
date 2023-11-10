namespace Verivox.Domain.Interfaces
{
    public interface IProductStrategy
    {
        decimal GetCalculationStrategy(int consumptionKwh);
    }
}