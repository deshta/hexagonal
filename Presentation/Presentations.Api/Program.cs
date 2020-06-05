using Harpy.Presentation.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Harpy.Template {

    public class Program {

        public static void Main( string[ ] args ) =>
            CreateWebHostBuilder( args ).Build( ).Run( );

        private static IWebHostBuilder CreateWebHostBuilder( string[ ] args ) =>
            WebHost.CreateDefaultBuilder( args )
                .UseUrls( "http://0.0.0.0:5000", "https://0.0.0.0:5001" )
                .UseKestrel( )
                .UseContentRoot( Directory.GetCurrentDirectory( ) )
                .UseFullLog( )
                .UseStartup<Startup>( );
    }
}