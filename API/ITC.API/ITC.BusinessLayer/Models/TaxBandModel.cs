namespace ITC.BusinessLayer.Models
{
    public class TaxBandModel
    {
        public string Name { get; set; }

        public int? UpperLimit { get; set; }

        public int LowerLimit { get; set; }

        public int Rate { get; set; }
    }
}
