using Harpy.Domain.Jobs.Base;

namespace Exemple.Domain.Jobs {

    public class WeatherForecastContinuedJob: ContinueJob {
        public long WeatherForecastId { get; private set; }

        public WeatherForecastContinuedJob( long weatherForecastId, string parentJob )
            : base( parentJob ) {
            WeatherForecastId = weatherForecastId;
        }
    }
}