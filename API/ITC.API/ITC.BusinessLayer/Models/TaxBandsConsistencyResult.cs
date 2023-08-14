using System.Collections.Generic;

namespace ITC.BusinessLayer.Models
{
    public class TaxBandsConsistencyResult
    {
        public IEnumerable<string> CheckResultMessages { get; set; }

        public bool IsConsistent { get; set; }
    }
}
