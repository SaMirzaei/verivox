namespace Verivox.Domain.Entities
{
    public class ElectricityProduct : BaseEntity<long>
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public decimal BaseCost { get; set; }
        public decimal AdditionalKwhCost { get; set; }
    }
}
