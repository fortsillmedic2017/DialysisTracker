using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DialysisPatientTracker.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientDemographic",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MedicalRecord = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDemographic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PatientMasterLists",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MedicalRecord = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Physician = table.Column<string>(nullable: true),
                    TreatmentDays = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMasterLists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentMasterLists",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MedicalRecord = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Physician = table.Column<string>(nullable: true),
                    TreatmentDays = table.Column<int>(nullable: false),
                    TreatmentTime = table.Column<string>(nullable: true),
                    AccessType = table.Column<int>(nullable: false),
                    KBath = table.Column<int>(nullable: false),
                    CaBath = table.Column<string>(nullable: true),
                    NaBath = table.Column<string>(nullable: true),
                    BiCarb = table.Column<string>(nullable: true),
                    Temp = table.Column<string>(nullable: true),
                    DialyzerSize = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentMasterLists", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientDemographic");

            migrationBuilder.DropTable(
                name: "PatientMasterLists");

            migrationBuilder.DropTable(
                name: "TreatmentMasterLists");
        }
    }
}
