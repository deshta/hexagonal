using Harpy.Template;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace Presentations.Test.Scenarios.Exemple.WeatherForecast.Base {

    public class WeatherForecastScenarios: ExempleScenarios {
        protected string _endpointUrl { get; set; } = "WeatherForecast";

        public WeatherForecastScenarios( WebApplicationFactory<Startup> factory, ITestOutputHelper output )
            : base( factory, output ) {
        }
    }
}