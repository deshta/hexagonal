using Exemple.Domain.AggregateModels;
using Harpy.Domain.Interfaces.Queries.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Exemple.Domain.Interfaces.Queries {

    public interface IWeatherForecastQuery: IQuery {

        Task<bool> ExistsAsync( long id, CancellationToken cancellationToken );

        Task<bool> NotExistsAsync( int temperature, CancellationToken cancellationToken );

        ValueTask<WeatherForecast> GetAsync( long id, CancellationToken cancellationToken );

        Task<List<WeatherForecast>> GetAsync( CancellationToken cancellationToken );
    }
}