using Harpy.Domain.Constants;
using Harpy.Domain.Jobs.Base;

namespace Exemple.Domain.Jobs {

    public class WeatherForecastPersistedJob: PersistedJob {

        public WeatherForecastPersistedJob( )
            : base( "update-dates", Cron.Daily ) {
        }
    }
}