using Harpy.Domain.Jobs.Base;

namespace Exemple.Domain.Jobs {

    public class WeatherForecastUpdatedJob: Job {
        public long WeatherForecastId { get; private set; }

        public WeatherForecastUpdatedJob( long weatherForecastId ) {
            WeatherForecastId = weatherForecastId;
        }
    }
}