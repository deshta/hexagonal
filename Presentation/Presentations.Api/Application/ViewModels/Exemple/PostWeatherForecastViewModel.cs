using System;

namespace Presentations.Api.Application.ViewModels.Exemple {

    public class PostWeatherForecastViewModel {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }

        public PostWeatherForecastViewModel( ) {
        }

        public PostWeatherForecastViewModel( DateTime date, int temperatureC, string summary ) {
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }
    }
}