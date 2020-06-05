using AutoMapper;
using Exemple.Domain.AggregateModels;
using Exemple.Domain.Commands;
using Exemple.Domain.Interfaces.Queries;
using Exemple.Domain.Jobs;
using Harpy.Domain.Events;
using Harpy.Domain.Interfaces.Mediator;
using Harpy.Presentation.Controller;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Presentations.Api.Application.ViewModels.Exemple;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Presentations.Api.Controllers.Exemple {

    [AllowAnonymous]
    [Route( "api/Exemple/" )]
    [OpenApiTags( "Exemple" )]
    public class WeatherForecastController: ApiController {
        private readonly IWeatherForecastQuery _weatherForecastQuery;
        // private readonly DbTransaction _dbTransaction;

        public WeatherForecastController(
                INotificationHandler<DomainNotification> notifications,
                IMediatorHandler mediator,
                IMapper mapper,
                // DbTransaction dbTransaction,
                IWeatherForecastQuery weatherForecastQuery )
                : base( notifications, mediator, mapper ) {
            _weatherForecastQuery = weatherForecastQuery;
            // _dbTransaction = dbTransaction;
        }

        [HttpGet( "[controller]" )]
        [OpenApiOperation( "Get all weather forecast", "Return all forecasts save in database" )]
        [ProducesResponseType( typeof( IEnumerable<WeatherForecastViewModel> ), StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        public async Task<IActionResult> GetAsync( CancellationToken cancellationToken ) {
            var weatherForecasts = await _weatherForecastQuery.GetAsync( cancellationToken );
            var result = _mapper.Map<IEnumerable<WeatherForecastViewModel>>( weatherForecasts );
            return Response( result );
        }

        [HttpGet( "[controller]/{id}" )]
        [OpenApiOperation( "Get single weather forecast", "Return forecast by id" )]
        [ProducesResponseType( typeof( WeatherForecastViewModel ), StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        public async Task<IActionResult> GetAsync( [FromRoute] long id, CancellationToken cancellationToken ) {
            var weatherForecasts = await _weatherForecastQuery.GetAsync( id, cancellationToken );
            var result = _mapper.Map<WeatherForecastViewModel>( weatherForecasts );
            return Response( result );
        }

        [HttpPost( "[controller]" )]
        [OpenApiOperation( "Post weather forecast", "Create a new forecast" )]
        [ProducesResponseType( typeof( WeatherForecastViewModel ), StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        public async Task<IActionResult> PostAsync( [FromBody] PostWeatherForecastViewModel postWeatherForecast, CancellationToken cancellationToken ) {
            // SQLite does not support multiple transactions, to use transactions do not use persistent jobs
            // await using var transaction = new Transactions( _dbTransaction );
            var command = _mapper.Map<PostWeatherForecastCommand>( postWeatherForecast );
            var result = await _mediator.SendCommandAsync<PostWeatherForecastCommand, WeatherForecast>( command, cancellationToken );
            var response = _mapper.Map<WeatherForecast, WeatherForecastViewModel>( result );

            if ( result != null ) {
                //    await transaction.CommitAsync( );

                var simpleJob = new WeatherForecastUpdatedJob( response.WeatherForecastId );
                var jobId = _mediator.RaiseJob( simpleJob );

                var continuedJob = new WeatherForecastContinuedJob( response.WeatherForecastId, jobId );
                _mediator.RaiseJob( continuedJob );
            }

            return ResponseRedirect( "Get", new { id = response?.WeatherForecastId }, response );
        }
    }
}