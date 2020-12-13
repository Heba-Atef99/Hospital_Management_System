using Microsoft.EntityFrameworkCore.Migrations;

namespace Ain_Shams_Hospital.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Schedules_Specializations_Specialization_Id",
                table: "Staff_Schedules");

            migrationBuilder.RenameColumn(
                name: "Specialization_Id",
                table: "Staff_Schedules",
                newName: "Staff_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_Schedules_Specialization_Id",
                table: "Staff_Schedules",
                newName: "IX_Staff_Schedules_Staff_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Schedules_Staff_Staff_Id",
                table: "Staff_Schedules",
                column: "Staff_Id",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Schedules_Staff_Staff_Id",
                table: "Staff_Schedules");

            migrationBuilder.RenameColumn(
                name: "Staff_Id",
                table: "Staff_Schedules",
                newName: "Specialization_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_Schedules_Staff_Id",
                table: "Staff_Schedules",
                newName: "IX_Staff_Schedules_Specialization_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Schedules_Specializations_Specialization_Id",
                table: "Staff_Schedules",
                column: "Specialization_Id",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
