using Exemple.Domain.Jobs;
using Harpy.Domain.Interfaces.Mediator;
using Harpy.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Exemple.Infrastructure.CrossCutting.IoC {

    public static class InjectorContainer {

        public static IServiceCollection AddExemple( this IServiceCollection services ) {
            services.AddRepositories( );
            services.AddQueries( );
            services.AddUpdateJob( );
            return services;
        }

        private static IServiceCollection AddUpdateJob( this IServiceCollection services ) {
            var serviceProvider = services.BuildServiceProvider( );

            var mediator = serviceProvider.GetService<IMediatorHandler>( );

            var updateJob = new WeatherForecastPersistedJob( );
            mediator.RaiseJob( updateJob );

            return services;
        }
    }
}