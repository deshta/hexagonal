using Harpy.Template;
using Harpy.Test.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Presentations.Api.Application.ViewModels.Exemple;
using Presentations.Test.Scenarios.Exemple.WeatherForecast.Base;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Presentations.Test.Scenarios.Exemple.WeatherForecast {

    public class GetWeatherForecastScenarios: WeatherForecastScenarios {

        public GetWeatherForecastScenarios( WebApplicationFactory<Startup> factory, ITestOutputHelper output )
            : base( factory, output ) {
        }

        [Fact]
        public async void Get_all_weather_forecast_ok( ) {
            var response = await _client.GetAsync( $"{_apiUrl}/{_endpointUrl}" );

            if ( response.IsSuccessStatusCode ) {
                var weatherForecast = await response.GetResponseAsync<IEnumerable<WeatherForecastViewModel>>( );

                Assert.NotNull( weatherForecast );
            }
        }

        [Fact]
        public async void Get_first_weather_forecast_ok( ) {
            var response = await _client.GetAsync( $"{_apiUrl}/{_endpointUrl}/1" );

            if ( response.IsSuccessStatusCode ) {
                var weatherForecast = await response.GetResponseAsync<WeatherForecastViewModel>( );

                Assert.NotNull( weatherForecast );
            }
        }
    }
}