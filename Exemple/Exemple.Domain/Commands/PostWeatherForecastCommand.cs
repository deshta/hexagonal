using Exemple.Domain.AggregateModels;
using Harpy.Domain.Commands;
using System;

namespace Exemple.Domain.Commands {

    public class PostWeatherForecastCommand: Command<WeatherForecast> {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }

        public PostWeatherForecastCommand( DateTime date, int temperatureC, string summary ) {
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }
    }
}