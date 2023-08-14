using AutoMapper;
using ITC.BusinessLayer.Models;
using ITC.DataAccess.Entities;

namespace ITC.BusinessLayer.MappingProfiles
{
    public class TaxBandProfile : Profile
    {
            public TaxBandProfile()
            {
                CreateMap<TaxBand, TaxBandModel>();
            }
    }
}
