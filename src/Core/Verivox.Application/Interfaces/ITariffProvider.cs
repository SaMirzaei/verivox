using System.Collections.Generic;
using System.Threading.Tasks;
using Verivox.Domain.Entities;

namespace Verivox.Application.Interfaces
{
    public interface ITariffProvider
    {
        Task<List<ElectricityProduct>> GetProducts();
    }
}
