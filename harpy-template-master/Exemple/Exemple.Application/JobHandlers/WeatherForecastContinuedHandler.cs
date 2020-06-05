using Exemple.Domain.Interfaces.Repositories;
using Exemple.Domain.Jobs;
using Harpy.Application.JobHandlers;
using System.Threading;
using System.Threading.Tasks;

namespace Exemple.Application.JobHandlers {

    public class WeatherForecastContinuedHandler: JobHandler<WeatherForecastContinuedJob> {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastContinuedHandler( IWeatherForecastRepository weatherForecastRepository ) {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public override async Task Handle( WeatherForecastContinuedJob notification, CancellationToken cancellationToken ) {
            var weatherForeacast = await _weatherForecastRepository.FindAsync( cancellationToken, notification.WeatherForecastId );

            var temperatureF = 32 + ( int ) ( weatherForeacast.TemperatureC / 0.5556 );

            weatherForeacast.SetTemperatureF( temperatureF );

            _weatherForecastRepository.UpdateAsync( weatherForeacast );

            await _weatherForecastRepository.SaveChangesAsync( cancellationToken );
        }
    }
}