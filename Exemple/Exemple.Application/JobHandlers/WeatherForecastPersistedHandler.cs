using Exemple.Domain.Interfaces.Repositories;
using Exemple.Domain.Jobs;
using Harpy.Application.JobHandlers;
using System.Threading;
using System.Threading.Tasks;

namespace Exemple.Application.JobHandlers {

    public class WeatherForecastPersistedHandler: JobHandler<WeatherForecastPersistedJob> {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastPersistedHandler( IWeatherForecastRepository weatherForecastRepository ) {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public override async Task Handle( WeatherForecastPersistedJob notification, CancellationToken cancellationToken ) {
            var weatherForeacastList = await _weatherForecastRepository.ToListAsync( cancellationToken );

            foreach ( var weatherForeacast in weatherForeacastList ) {
                var temperatureF = 32 + ( int ) ( weatherForeacast.TemperatureC / 0.5556 );

                weatherForeacast.SetTemperatureF( temperatureF );

                _weatherForecastRepository.UpdateAsync( weatherForeacast );
            }

            await _weatherForecastRepository.SaveChangesAsync( cancellationToken );
        }
    }
}