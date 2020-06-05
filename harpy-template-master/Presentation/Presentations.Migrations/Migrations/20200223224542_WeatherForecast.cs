using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Presentations.Migrations.Migrations {

    public partial class WeatherForecast: Migration {

        protected override void Up( MigrationBuilder migrationBuilder ) {
            migrationBuilder.CreateTable(
                name: "weather_forecast",
                columns: table => new {
                    weather_forecast_id = table.Column<long>( nullable: false ),
                    date = table.Column<DateTime>( ),
                    temperature_c = table.Column<int>( ),
                    temperature_f = table.Column<int>( nullable: true ),
                    summary = table.Column<string>( )
                },
                constraints: table => {
                    table.PrimaryKey( "pk_weather_forecast", x => x.weather_forecast_id );
                }
                );
        }

        protected override void Down( MigrationBuilder migrationBuilder ) {
            migrationBuilder.DropTable( name: "weather_forecast" );
        }
    }
}