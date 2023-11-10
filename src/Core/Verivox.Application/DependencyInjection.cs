using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Verivox.Application.Features.Tariffs.Queries;

namespace Verivox.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddMediatR(configuration =>
                {
                    configuration.RegisterServicesFromAssemblyContaining(typeof(TariffCalculationHandler));
                });
        }
    }
}
