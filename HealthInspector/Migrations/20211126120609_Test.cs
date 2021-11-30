using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthInspector.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAvailabilities_Clinics_ClinicId",
                table: "DoctorAvailabilities");

            migrationBuilder.DropIndex(
                name: "IX_DoctorAvailabilities_ClinicId",
                table: "DoctorAvailabilities");

            migrationBuilder.AddColumn<int>(
                name: "DoctorAvailabilityId",
                table: "Clinics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_DoctorAvailabilityId",
                table: "Clinics",
                column: "DoctorAvailabilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_DoctorAvailabilities_DoctorAvailabilityId",
                table: "Clinics",
                column: "DoctorAvailabilityId",
                principalTable: "DoctorAvailabilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_DoctorAvailabilities_DoctorAvailabilityId",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_DoctorAvailabilityId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "DoctorAvailabilityId",
                table: "Clinics");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAvailabilities_ClinicId",
                table: "DoctorAvailabilities",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAvailabilities_Clinics_ClinicId",
                table: "DoctorAvailabilities",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
