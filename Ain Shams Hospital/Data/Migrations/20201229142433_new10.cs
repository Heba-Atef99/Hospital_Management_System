using Microsoft.EntityFrameworkCore.Migrations;

namespace Ain_Shams_Hospital.Migrations
{
    public partial class new10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Patients_Patient_Id",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_Patient_Id",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Patient_Id",
                table: "Payments",
                column: "Patient_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Patients_Patient_Id",
                table: "Payments",
                column: "Patient_Id",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
