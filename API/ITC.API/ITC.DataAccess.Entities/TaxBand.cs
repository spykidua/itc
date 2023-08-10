namespace ITC.DataAccess.Entities
{
    public class TaxBand : BaseEntity
    {
        public string Name { get; set; }

        public int UpperLimit { get; set; }

        public int LowerLimit { get; set;}

        public int Rate { get; set; }
    }
}
