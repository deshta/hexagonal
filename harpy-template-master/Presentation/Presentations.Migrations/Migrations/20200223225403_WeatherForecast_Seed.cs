using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Presentations.Migrations.Migrations {

    public partial class WeatherForecast_Seed: Migration {

        protected override void Up( MigrationBuilder migrationBuilder ) {
            var rng = new Random( );
            var summaries = new[ ] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

            for ( var i = 1; i < 11; i++ ) {
                migrationBuilder.InsertData(
                    table: "weather_forecast",
                    columns: new[ ] { "date", "temperature_c", "summary" },
                    values: new object[ ] {
                    DateTime.Now.AddDays(1),
                    rng.Next( -20, 55 ),
                    summaries[ rng.Next( summaries.Length ) ]
                    }
               );
            }
        }

        protected override void Down( MigrationBuilder migrationBuilder ) {
            migrationBuilder.DeleteData(
                table: "weather_forecast",
                keyColumns: new[ ] { "weather_forecast_id" },
                keyValues: new object[ ] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            );
        }
    }
}