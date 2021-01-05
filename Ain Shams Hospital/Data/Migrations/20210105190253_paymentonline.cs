using Microsoft.EntityFrameworkCore.Migrations;

namespace Ain_Shams_Hospital.Migrations
{
    public partial class paymentonline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Follow_Up_Type_Id",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Follow_Up_Type_Id",
                table: "Payments",
                column: "Follow_Up_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Patient_Id",
                table: "Payments",
                column: "Patient_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Follow_Ups_Types_Follow_Up_Type_Id",
                table: "Payments",
                column: "Follow_Up_Type_Id",
                principalTable: "Follow_Ups_Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Patients_Patient_Id",
                table: "Payments",
                column: "Patient_Id",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Follow_Ups_Types_Follow_Up_Type_Id",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Patients_Patient_Id",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_Follow_Up_Type_Id",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_Patient_Id",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Follow_Up_Type_Id",
                table: "Payments");
        }
    }
}
