using ITC.BusinessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITC.BusinessLayer.Managers.Interfaces
{
    public interface ITaxBandManager
    {
        Task<IEnumerable<TaxBandModel>> GetAllAsync();

        Task<TaxBandsConsistencyResult> CheckConsistencyAsync();
    }
}
