using Exemple.Infrastructure.CrossCutting.IoC;
using Exemple.Infrastructure.Data.Context;
using Harpy.IoC;
using Harpy.IoC.SQLite;
using Harpy.Test.Domain;
using Harpy.Test.Domain.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

[assembly: TestFramework( "Exemple.Test.Domain.StartupTest", "Exemple.Test.Domain" )]

namespace Exemple.Test.Domain {

    public class StartupTest: StartupTestBase {

        public StartupTest( IMessageSink messageSink ) : base( messageSink ) {
        }

        protected override void ConfigureServices( IServiceCollection services ) {
            base.ConfigureServices( services );

            services.AddDatabase(
                connection => connection.UseSqliteConnection( "" ),
                context => {
                    context.AddContext<ExempleContext>( );
                }
            );

            services.CreateTestDatabase<ExempleContext>( );

            services.AddExemple( );
        }
    }
}