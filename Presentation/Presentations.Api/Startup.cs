using Exemple.Infrastructure.CrossCutting.IoC;
using Exemple.Infrastructure.Data.Context;
using Hangfire;
using Harpy.IoC;
using Harpy.IoC.SQLite;
using Harpy.Presentation.Conventions;
using Harpy.Presentation.Extensions;
using Harpy.Presentation.SQLite.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Harpy.Template {

    public class Startup {
        private readonly string _defaultConnetion;
        private readonly string _hangfireConnection;

        private readonly ILogger<Startup> _logger;
        private readonly IConfiguration _configuration;

        public Startup( ILogger<Startup> logger, IConfiguration configuration ) {
            _logger = logger;
            _configuration = configuration;

            _defaultConnetion = _configuration.GetConnectionStringFile( "DefaultConnection" );
            _hangfireConnection = _configuration.GetConnectionStringFile( "HangfireConnection" );
        }

        public void ConfigureServices( IServiceCollection services ) {
            services.AddSwaggerMiddleware( AppVersion.GetCurrent( ) );

            services.AddHarpyPolice( );

            services.AddCulture( "en-US" );

            services.AddHangfire( HangfireSQLite.UseStorage( _hangfireConnection ) );

            services
                .AddControllers( opt => opt.Conventions.Add( new CommaSeparatedRouteConvention( ) ) )
                .AddHarpySettings( );

            services.AddDatabase(
                connection => connection.UseSqliteConnection( _defaultConnetion, options =>
                    options.AddMigrations( "Presentations.Migrations" )
                ),
                context => {
                    context.AddContext<ExempleContext>( );
                },
                options => options
                    .EnableLog( )
            //.UseTransaction( )
            );

            services.AddHarpy( );
            services.AddExemple( );
        }

        public void Configure( IApplicationBuilder app, IWebHostEnvironment env ) {
            if ( env.IsDevelopment( ) )
                app.UseDeveloperExceptionPage( );

            app.UseStaticFiles( file =>
                file.IncludePath( Directory.GetCurrentDirectory( ), "images" )
            );

            app.UseCors( "HarpyPolicy" );

            app.UseHarpySwagger( );

            app.UseHangfireDashboard( );

            app.UseAuthorizationInterceptor( );

            app.UseRouting( );

            app.UseAuthentication( );

            app.UseAuthorization( );

            app.UseEndpoints( endpoints => endpoints.MapControllers( ) );

            app.UseExceptionMiddleware( _logger );

            app.UseHttpsRedirection( );
        }
    }
}