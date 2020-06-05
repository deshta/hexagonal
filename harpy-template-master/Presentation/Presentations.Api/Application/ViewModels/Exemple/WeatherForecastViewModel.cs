using System;

namespace Presentations.Api.Application.ViewModels.Exemple {

    public class WeatherForecastViewModel {
        public long WeatherForecastId { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string Summary { get; set; }
    }
}