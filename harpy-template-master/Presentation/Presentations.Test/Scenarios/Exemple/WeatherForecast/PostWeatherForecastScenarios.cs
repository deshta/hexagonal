using Harpy.Template;
using Harpy.Test.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Presentations.Api.Application.ViewModels.Exemple;
using Presentations.Test.Scenarios.Exemple.WeatherForecast.Base;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Presentations.Test.Scenarios.Exemple.WeatherForecast {

    public class PostWeatherForecastScenarios: WeatherForecastScenarios {

        public PostWeatherForecastScenarios( WebApplicationFactory<Startup> factory, ITestOutputHelper output )
            : base( factory, output ) {
        }

        [Fact]
        public async void Post_weather_forecast_ok( ) {
            var date = DateTime.Now;
            var temperature = 25;
            var summary = "Hot";
            var request = new PostWeatherForecastViewModel( date, temperature, summary );

            var response = await _client.PostAsync( $"{_apiUrl}/{_endpointUrl}", request );

            if ( response.IsSuccessStatusCode ) {
                var weatherForecast = await response.GetResponseAsync<WeatherForecastViewModel>( );

                Assert.NotNull( weatherForecast );
            }
        }
    }
}