using ITC.BusinessLayer.Calculators;
using ITC.BusinessLayer.Calculators.Interfaces;
using ITC.BusinessLayer.Managers;
using ITC.BusinessLayer.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ITC.BusinessLayer.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<ISalaryCalculatorBuilder, SalaryCalculatorBuilder>();
            services.AddScoped<ISalaryManager, SalaryManager>();

            return services;
        }
    }
}
