using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplySecureLocal.Data.Migrations
{
    public partial class HeartbeatAcknowledge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Acknowledged",
                table: "HeartBeats",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acknowledged",
                table: "HeartBeats");
        }
    }
}
