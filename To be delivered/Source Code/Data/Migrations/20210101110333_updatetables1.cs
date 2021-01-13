using Microsoft.EntityFrameworkCore.Migrations;

namespace Ain_Shams_Hospital.Migrations
{
    public partial class updatetables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Patients_Patient_Id",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_Patient_Id",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "End_Hour",
                table: "Follow_Ups_History");

            migrationBuilder.RenameColumn(
                name: "Start_Hour",
                table: "Follow_Ups_History",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Staff_Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Follow_Ups_History",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Facility_Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff_Schedules",
                table: "Staff_Schedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follow_Ups_History",
                table: "Follow_Ups_History",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facility_Reservations",
                table: "Facility_Reservations",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff_Schedules",
                table: "Staff_Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follow_Ups_History",
                table: "Follow_Ups_History");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facility_Reservations",
                table: "Facility_Reservations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Staff_Schedules");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Follow_Ups_History");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Facility_Reservations");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Follow_Ups_History",
                newName: "Start_Hour");

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

            migrationBuilder.AddColumn<string>(
                name: "End_Hour",
                table: "Follow_Ups_History",
                type: "nvarchar(max)",
                nullable: true);

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
