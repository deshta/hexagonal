using System;

namespace Exemple.Domain.AggregateModels {

    public class WeatherForecast {
        public long WeatherForecastId { get; private set; }

        public DateTime Date { get; private set; }

        public int TemperatureC { get; private set; }

        public int? TemperatureF { get; private set; }

        public string Summary { get; private set; }

        public WeatherForecast( ) {
        }

        public WeatherForecast( DateTime date, int temperatureC, string summary ) {
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }

        public void UpdateSummary( string summary ) {
            Summary = summary;
        }

        public void UpdateDate( DateTime date ) {
            Date = date;
        }

        public void SetTemperatureF( int temperature ) {
            TemperatureF = temperature;
        }
    }
}