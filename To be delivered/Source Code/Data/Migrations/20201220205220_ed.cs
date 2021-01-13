using Microsoft.EntityFrameworkCore.Migrations;

namespace Ain_Shams_Hospital.Migrations
{
    public partial class ed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Reservations_Hospital_Facilities_Hospital_Facility_ID",
                table: "Facility_Reservations");

            migrationBuilder.RenameColumn(
                name: "Hospital_Facility_ID",
                table: "Facility_Reservations",
                newName: "Hospital_Facility_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_Reservations_Hospital_Facility_ID",
                table: "Facility_Reservations",
                newName: "IX_Facility_Reservations_Hospital_Facility_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Reservations_Hospital_Facilities_Hospital_Facility_Id",
                table: "Facility_Reservations",
                column: "Hospital_Facility_Id",
                principalTable: "Hospital_Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Reservations_Hospital_Facilities_Hospital_Facility_Id",
                table: "Facility_Reservations");

            migrationBuilder.RenameColumn(
                name: "Hospital_Facility_Id",
                table: "Facility_Reservations",
                newName: "Hospital_Facility_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_Reservations_Hospital_Facility_Id",
                table: "Facility_Reservations",
                newName: "IX_Facility_Reservations_Hospital_Facility_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Reservations_Hospital_Facilities_Hospital_Facility_ID",
                table: "Facility_Reservations",
                column: "Hospital_Facility_ID",
                principalTable: "Hospital_Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
