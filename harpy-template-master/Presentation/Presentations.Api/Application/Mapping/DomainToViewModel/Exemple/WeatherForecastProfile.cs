using AutoMapper;
using Exemple.Domain.AggregateModels;
using Presentations.Api.Application.ViewModels.Exemple;

namespace Presentations.Api.Application.Mapping.DomainToViewModel.Exemple {

    public class WeatherForecastProfile: Profile {

        public WeatherForecastProfile( ) {
            CreateMap<WeatherForecast, WeatherForecastViewModel>( );
        }
    }
}