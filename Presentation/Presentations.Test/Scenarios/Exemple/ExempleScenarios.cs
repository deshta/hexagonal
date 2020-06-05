using Harpy.Template;
using Harpy.Test.Presentation;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace Presentations.Test.Scenarios.Exemple {

    public class ExempleScenarios: ScenarioBase<Startup> {

        public ExempleScenarios( WebApplicationFactory<Startup> factory, ITestOutputHelper output )
            : base( factory, output, "api/Exemple" ) {
        }
    }
}