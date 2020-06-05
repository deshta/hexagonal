using Exemple.Domain.AggregateModels;
using Exemple.Domain.Interfaces.Queries;
using Exemple.Domain.Interfaces.Repositories;
using Exemple.Domain.Specifications;
using Harpy.Domain.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Exemple.Application.Queries {

    public class WeatherForecastQuery: IWeatherForecastQuery {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastQuery( IWeatherForecastRepository weatherForecastRepository ) {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public Task<bool> ExistsAsync( long id, CancellationToken cancellationToken ) {
            var spec = SpecBuilder<WeatherForecast>.Create( )
                .WithId( id );

            return _weatherForecastRepository.AnyAsync( spec, cancellationToken );
        }

        public Task<bool> NotExistsAsync( int temperature, CancellationToken cancellationToken ) {
            var spec = SpecBuilder<WeatherForecast>.Create( )
                .WithNotTemperature( temperature );

            return _weatherForecastRepository.AnyAsync( spec, cancellationToken );
        }

        public ValueTask<WeatherForecast> GetAsync( long id, CancellationToken cancellationToken ) {
            return _weatherForecastRepository.FindAsync( cancellationToken, id );
        }

        public Task<List<WeatherForecast>> GetAsync( CancellationToken cancellationToken ) {
            return _weatherForecastRepository.ToListAsync( cancellationToken );
        }
    }
}