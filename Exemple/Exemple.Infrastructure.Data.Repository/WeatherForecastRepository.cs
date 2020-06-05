using Exemple.Domain.AggregateModels;
using Exemple.Domain.Interfaces.Repositories;
using Exemple.Infrastructure.Data.Context;
using Harpy.Repository.Entity;

namespace Exemple.Infrastructure.Data.Repository {

    public class WeatherForecastRepository: EntityReadWriteRepository<WeatherForecast>, IWeatherForecastRepository {

        public WeatherForecastRepository( ExempleContext context ) : base( context ) {
        }
    }
}