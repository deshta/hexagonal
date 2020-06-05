using Exemple.Domain.AggregateModels;
using Harpy.Domain.Interfaces.Repositories.Entity;

namespace Exemple.Domain.Interfaces.Repositories {

    public interface IWeatherForecastRepository: IEntityReadWriteRepository<WeatherForecast> {
    }
}