using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplySecureLocal.Data.Migrations
{
    public partial class StatusToStateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusChanges",
                table: "StatusChanges");

            migrationBuilder.RenameTable(
                name: "StatusChanges",
                newName: "StateChanges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StateChanges",
                table: "StateChanges",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StateChanges",
                table: "StateChanges");

            migrationBuilder.RenameTable(
                name: "StateChanges",
                newName: "StatusChanges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusChanges",
                table: "StatusChanges",
                column: "Id");
        }
    }
}
