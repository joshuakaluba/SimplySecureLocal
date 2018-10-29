using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplySecureLocal.Data.Migrations
{
    public partial class ChangedStatusToState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "StatusChanges");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "HeartBeats");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BootMessages");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "StatusChanges",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "HeartBeats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "BootMessages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "StatusChanges");

            migrationBuilder.DropColumn(
                name: "State",
                table: "HeartBeats");

            migrationBuilder.DropColumn(
                name: "State",
                table: "BootMessages");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "StatusChanges",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "HeartBeats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BootMessages",
                nullable: false,
                defaultValue: 0);
        }
    }
}
