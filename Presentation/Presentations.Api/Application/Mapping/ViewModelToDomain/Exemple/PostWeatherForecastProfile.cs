using AutoMapper;
using Exemple.Domain.Commands;
using Presentations.Api.Application.ViewModels.Exemple;

namespace Presentations.Api.Application.Mapping.ViewModelToDomain.Exemple {

    public class PostWeatherForecastProfile: Profile {

        public PostWeatherForecastProfile( ) {
            CreateMap<PostWeatherForecastViewModel, PostWeatherForecastCommand>( );
        }
    }
}