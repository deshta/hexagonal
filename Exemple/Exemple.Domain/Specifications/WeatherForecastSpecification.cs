using Exemple.Domain.AggregateModels;
using Harpy.Domain.Interfaces.Specfication;

namespace Exemple.Domain.Specifications {

    public static class WeatherForecastSpecification {

        public static ISpec<WeatherForecast> WithId( this ISpec<WeatherForecast> spec, long id ) =>
            spec.And( x => x.WeatherForecastId == id );

        public static ISpec<WeatherForecast> WithNotTemperature( this ISpec<WeatherForecast> spec, int temperature ) =>
            spec.And( x => x.TemperatureC != temperature );
    }
}