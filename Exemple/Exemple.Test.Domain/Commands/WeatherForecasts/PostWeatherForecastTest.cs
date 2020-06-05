using Exemple.Application.CommandHandlers;
using Exemple.Domain.AggregateModels;
using Exemple.Domain.Commands;
using Exemple.Domain.Interfaces.Queries;
using Exemple.Domain.Interfaces.Repositories;
using Exemple.Infrastructure.Data.Context;
using FluentValidation;
using Harpy.Test.Domain.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Exemple.Test.Domain.Commands.WeatherForecasts {

    public class PostWeatherForecastTest: CommandTest {
        protected readonly ExempleContext _context;
        protected readonly IWeatherForecastRepository _weatherForecastRepository;
        protected readonly IWeatherForecastQuery _weatherForecastQuery;
        protected readonly IValidator<PostWeatherForecastCommand> _validator;

        public PostWeatherForecastTest(
                ExempleContext context,
                IValidator<PostWeatherForecastCommand> validator,
                IWeatherForecastRepository weatherForecastRepository )
                : base( context ) {
            _context = context;
            _weatherForecastRepository = weatherForecastRepository;
            _validator = validator;
        }

        private async Task Mock( ) {
            await CleanContextAsync( );

            var hotForecast = new WeatherForecast( DateTime.Now, 25, "Hot" );
            var weatherForecast = ( await _context.WeatherForecasts.AddAsync( hotForecast ) ).Entity;

            await SaveContextAsync( );
        }

        [Fact]
        public async Task Weather_forecast_must_be_created( ) {
            await Mock( );

            Random random = new Random( );

            var command = new PostWeatherForecastCommand(
                DateTime.Now,
                10 + random.Next( ),
                "Freezing" );

            var handler = new PostWeatherForecastCommandHandler(
                _bus,
                _domainNotificationHandler,
                _validator,
                _weatherForecastRepository );

            var result = await handler.Handle( command, CancellationToken.None );

            Assert.NotNull( result );
        }
    }
}