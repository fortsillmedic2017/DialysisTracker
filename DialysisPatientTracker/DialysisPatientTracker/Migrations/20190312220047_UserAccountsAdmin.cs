using Microsoft.EntityFrameworkCore.Migrations;

namespace DialysisPatientTracker.Migrations
{
    public partial class UserAccountsAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAmin",
                table: "UserAccounts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAmin",
                table: "UserAccounts");
        }
    }
}
