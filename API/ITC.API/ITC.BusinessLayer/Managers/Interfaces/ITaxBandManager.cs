using ITC.BusinessLayer.Models;

namespace ITC.BusinessLayer.Managers.Interfaces
{
    public interface ITaxBandManager
    {
        Task<IEnumerable<TaxBandModel>> GetAllAsync();

        Task<TaxBandsConsistencyResult> CheckConsistencyAsync();
    }
}
