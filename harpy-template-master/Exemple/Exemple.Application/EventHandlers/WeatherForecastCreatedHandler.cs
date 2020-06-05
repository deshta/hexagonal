using Exemple.Domain.Events;
using Exemple.Domain.Interfaces.Repositories;
using Harpy.Application.EventHandlers;
using System.Threading;
using System.Threading.Tasks;

namespace Exemple.Application.EventHandlers {

    public class WeatherForecastCreatedHandler: EventHandler<WeatherForecastCreatedEvent> {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastCreatedHandler( IWeatherForecastRepository weatherForecastRepository ) {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public override async Task Handle( WeatherForecastCreatedEvent notification, CancellationToken cancellationToken ) {
            var weatherForeacast = await _weatherForecastRepository.FindAsync( cancellationToken, notification.WeatherForecastId );

            weatherForeacast.UpdateSummary( weatherForeacast.Summary.ToUpper( ) );

            _weatherForecastRepository.UpdateAsync( weatherForeacast );

            await _weatherForecastRepository.SaveChangesAsync( cancellationToken );
        }
    }
}