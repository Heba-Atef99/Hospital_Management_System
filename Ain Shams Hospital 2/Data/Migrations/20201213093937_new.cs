using Microsoft.EntityFrameworkCore.Migrations;

namespace Ain_Shams_Hospital.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Registrations_Registration_Id",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Transfer_Hospitals_Hospital_Id",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Hospital_Id",
                table: "Patients",
                newName: "RegistrationId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_Hospital_Id",
                table: "Patients",
                newName: "IX_Patients_RegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Registrations_RegistrationId",
                table: "Patients",
                column: "RegistrationId",
                principalTable: "Registrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Transfer_Hospitals_Registration_Id",
                table: "Patients",
                column: "Registration_Id",
                principalTable: "Transfer_Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Registrations_RegistrationId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Transfer_Hospitals_Registration_Id",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "RegistrationId",
                table: "Patients",
                newName: "Hospital_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_RegistrationId",
                table: "Patients",
                newName: "IX_Patients_Hospital_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Registrations_Registration_Id",
                table: "Patients",
                column: "Registration_Id",
                principalTable: "Registrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Transfer_Hospitals_Hospital_Id",
                table: "Patients",
                column: "Hospital_Id",
                principalTable: "Transfer_Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
