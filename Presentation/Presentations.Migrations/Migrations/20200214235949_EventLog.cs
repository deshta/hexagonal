using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Presentations.Migrations.Migrations {

    public partial class EventLogDomain: Migration {
        private readonly string _tableName = "event_log";

        protected override void Up( MigrationBuilder migrationBuilder ) {
            migrationBuilder.CreateTable(
                name: _tableName,
                columns: table => new {
                    event_log_id = table.Column<Guid>( nullable: false ),
                    content = table.Column<string>( nullable: false ),
                    created_at = table.Column<DateTime>( nullable: false ),
                    type_name = table.Column<string>( nullable: false ),
                    state = table.Column<int>( nullable: false )
                },
                constraints: table => {
                    table.PrimaryKey( "pk_event_log", x => x.event_log_id );
                }
                );
        }

        protected override void Down( MigrationBuilder migrationBuilder ) {
            migrationBuilder.DropTable( name: _tableName );
        }
    }
}