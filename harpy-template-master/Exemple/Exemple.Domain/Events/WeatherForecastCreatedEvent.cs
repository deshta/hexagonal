using Harpy.Domain.Events.Base;

namespace Exemple.Domain.Events {

    public class WeatherForecastCreatedEvent: Event {
        public long WeatherForecastId { get; private set; }

        public WeatherForecastCreatedEvent( long weatherForecastId ) {
            WeatherForecastId = weatherForecastId;
        }
    }
}