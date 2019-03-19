using Microsoft.EntityFrameworkCore.Migrations;

namespace DialysisPatientTracker.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Physician",
                table: "CompleteLists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Physician",
                table: "CompleteLists");
        }
    }
}
