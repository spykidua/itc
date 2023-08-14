using ITC.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITC.BusinessLayer.Managers.Interfaces
{
    public interface ITaxBandManager
    {
        Task<IEnumerable<TaxBandModel>> GetAllAsync();

        Task<TaxBandsConsistencyResult> CheckConsistencyAsync();
    }
}
