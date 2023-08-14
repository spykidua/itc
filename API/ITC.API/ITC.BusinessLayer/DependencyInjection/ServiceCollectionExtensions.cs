using ITC.BusinessLayer.Calculators;
using ITC.BusinessLayer.Calculators.Interfaces;
using ITC.BusinessLayer.Managers;
using ITC.BusinessLayer.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ITC.BusinessLayer.MappingProfiles;

namespace ITC.BusinessLayer.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<ISalaryCalculator, SalaryCalculator>();
            services.AddScoped<ISalaryManager, SalaryManager>();
            services.AddScoped<ITaxBandManager, TaxBandManager>();
            services.AddAutoMapper(typeof(TaxBandProfile));

            return services;
        }
    }
}
