using Microsoft.EntityFrameworkCore.Migrations;

namespace Ain_Shams_Hospital.Migrations
{
    public partial class UpdatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Reservations_Hospital_Facilities_Facility_IdId",
                table: "Facility_Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Reservations_Patients_Patient_IdId",
                table: "Facility_Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Reservations_Staffs_Staff_IdId",
                table: "Facility_Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Up_Patients_Patient_IdId",
                table: "Follow_Up");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Up_Staffs_Staff_IdId",
                table: "Follow_Up");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Up_History_Follow_Up_Follow_Up_IdId",
                table: "Follow_Up_History");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Up_History_Follow_Up_Types_TypeId",
                table: "Follow_Up_History");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Patients_Patient_IdId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Schedules_Staffs_Staff_IdId",
                table: "Staff_Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follow_Up_Types",
                table: "Follow_Up_Types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follow_Up",
                table: "Follow_Up");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "Staff");

            migrationBuilder.RenameTable(
                name: "Follow_Up_Types",
                newName: "Follow_Ups_Types");

            migrationBuilder.RenameTable(
                name: "Follow_Up_History",
                newName: "Follow_Ups_History");

            migrationBuilder.RenameTable(
                name: "Follow_Up",
                newName: "Follow_Ups");

            migrationBuilder.RenameColumn(
                name: "Staff_IdId",
                table: "Staff_Schedules",
                newName: "Specialization_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_Schedules_Staff_IdId",
                table: "Staff_Schedules",
                newName: "IX_Staff_Schedules_Specialization_Id");

            migrationBuilder.RenameColumn(
                name: "payed",
                table: "Payments",
                newName: "Payed");

            migrationBuilder.RenameColumn(
                name: "Patient_IdId",
                table: "Payments",
                newName: "Patient_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_Patient_IdId",
                table: "Payments",
                newName: "IX_Payments_Patient_Id");

            migrationBuilder.RenameColumn(
                name: "Staff_IdId",
                table: "Facility_Reservations",
                newName: "Staff_Id");

            migrationBuilder.RenameColumn(
                name: "Patient_IdId",
                table: "Facility_Reservations",
                newName: "Patient_Id");

            migrationBuilder.RenameColumn(
                name: "Facility_IdId",
                table: "Facility_Reservations",
                newName: "Hospital_Facility_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_Reservations_Staff_IdId",
                table: "Facility_Reservations",
                newName: "IX_Facility_Reservations_Staff_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_Reservations_Patient_IdId",
                table: "Facility_Reservations",
                newName: "IX_Facility_Reservations_Patient_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_Reservations_Facility_IdId",
                table: "Facility_Reservations",
                newName: "IX_Facility_Reservations_Hospital_Facility_Id");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Blood_Units",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Follow_Ups_History",
                newName: "Follow_Up_Type_Id");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Follow_Ups_History",
                newName: "Start_Hour");

            migrationBuilder.RenameColumn(
                name: "Follow_Up_IdId",
                table: "Follow_Ups_History",
                newName: "Follow_Up_Id");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Follow_Ups_History",
                newName: "End_Hour");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_Up_History_TypeId",
                table: "Follow_Ups_History",
                newName: "IX_Follow_Ups_History_Follow_Up_Type_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_Up_History_Follow_Up_IdId",
                table: "Follow_Ups_History",
                newName: "IX_Follow_Ups_History_Follow_Up_Id");

            migrationBuilder.RenameColumn(
                name: "Staff_IdId",
                table: "Follow_Ups",
                newName: "Staff_Id");

            migrationBuilder.RenameColumn(
                name: "Patient_IdId",
                table: "Follow_Ups",
                newName: "Patient_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_Up_Staff_IdId",
                table: "Follow_Ups",
                newName: "IX_Follow_Ups_Staff_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_Up_Patient_IdId",
                table: "Follow_Ups",
                newName: "IX_Follow_Ups_Patient_Id");

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

            migrationBuilder.AlterColumn<int>(
                name: "Registration_Id",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Hospital_Id",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Specialization_Id",
                table: "Staff",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Registration_Id",
                table: "Staff",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follow_Ups_Types",
                table: "Follow_Ups_Types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follow_Ups",
                table: "Follow_Ups",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Hospital_Id",
                table: "Patients",
                column: "Hospital_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Registration_Id",
                table: "Patients",
                column: "Registration_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Registration_Id",
                table: "Staff",
                column: "Registration_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Specialization_Id",
                table: "Staff",
                column: "Specialization_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Reservations_Hospital_Facilities_Hospital_Facility_Id",
                table: "Facility_Reservations",
                column: "Hospital_Facility_Id",
                principalTable: "Hospital_Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Reservations_Patients_Patient_Id",
                table: "Facility_Reservations",
                column: "Patient_Id",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Reservations_Staff_Staff_Id",
                table: "Facility_Reservations",
                column: "Staff_Id",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Ups_Patients_Patient_Id",
                table: "Follow_Ups",
                column: "Patient_Id",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Ups_Staff_Staff_Id",
                table: "Follow_Ups",
                column: "Staff_Id",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Ups_History_Follow_Ups_Follow_Up_Id",
                table: "Follow_Ups_History",
                column: "Follow_Up_Id",
                principalTable: "Follow_Ups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Ups_History_Follow_Ups_Types_Follow_Up_Type_Id",
                table: "Follow_Ups_History",
                column: "Follow_Up_Type_Id",
                principalTable: "Follow_Ups_Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Patients_Patient_Id",
                table: "Payments",
                column: "Patient_Id",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Registrations_Registration_Id",
                table: "Staff",
                column: "Registration_Id",
                principalTable: "Registrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Specializations_Specialization_Id",
                table: "Staff",
                column: "Specialization_Id",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Schedules_Specializations_Specialization_Id",
                table: "Staff_Schedules",
                column: "Specialization_Id",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Reservations_Hospital_Facilities_Hospital_Facility_Id",
                table: "Facility_Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Reservations_Patients_Patient_Id",
                table: "Facility_Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_Reservations_Staff_Staff_Id",
                table: "Facility_Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Ups_Patients_Patient_Id",
                table: "Follow_Ups");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Ups_Staff_Staff_Id",
                table: "Follow_Ups");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Ups_History_Follow_Ups_Follow_Up_Id",
                table: "Follow_Ups_History");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_Ups_History_Follow_Ups_Types_Follow_Up_Type_Id",
                table: "Follow_Ups_History");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Registrations_Registration_Id",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Transfer_Hospitals_Hospital_Id",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Patients_Patient_Id",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Registrations_Registration_Id",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Specializations_Specialization_Id",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Schedules_Specializations_Specialization_Id",
                table: "Staff_Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Hospital_Id",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Registration_Id",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_Registration_Id",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_Specialization_Id",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follow_Ups_Types",
                table: "Follow_Ups_Types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follow_Ups",
                table: "Follow_Ups");

            migrationBuilder.DropColumn(
                name: "Day",
                table: "Donations");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "Staffs");

            migrationBuilder.RenameTable(
                name: "Follow_Ups_Types",
                newName: "Follow_Up_Types");

            migrationBuilder.RenameTable(
                name: "Follow_Ups_History",
                newName: "Follow_Up_History");

            migrationBuilder.RenameTable(
                name: "Follow_Ups",
                newName: "Follow_Up");

            migrationBuilder.RenameColumn(
                name: "Specialization_Id",
                table: "Staff_Schedules",
                newName: "Staff_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_Schedules_Specialization_Id",
                table: "Staff_Schedules",
                newName: "IX_Staff_Schedules_Staff_IdId");

            migrationBuilder.RenameColumn(
                name: "Payed",
                table: "Payments",
                newName: "payed");

            migrationBuilder.RenameColumn(
                name: "Patient_Id",
                table: "Payments",
                newName: "Patient_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_Patient_Id",
                table: "Payments",
                newName: "IX_Payments_Patient_IdId");

            migrationBuilder.RenameColumn(
                name: "Staff_Id",
                table: "Facility_Reservations",
                newName: "Staff_IdId");

            migrationBuilder.RenameColumn(
                name: "Patient_Id",
                table: "Facility_Reservations",
                newName: "Patient_IdId");

            migrationBuilder.RenameColumn(
                name: "Hospital_Facility_Id",
                table: "Facility_Reservations",
                newName: "Facility_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_Reservations_Staff_Id",
                table: "Facility_Reservations",
                newName: "IX_Facility_Reservations_Staff_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_Reservations_Patient_Id",
                table: "Facility_Reservations",
                newName: "IX_Facility_Reservations_Patient_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_Reservations_Hospital_Facility_Id",
                table: "Facility_Reservations",
                newName: "IX_Facility_Reservations_Facility_IdId");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Blood_Units",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Start_Hour",
                table: "Follow_Up_History",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "Follow_Up_Type_Id",
                table: "Follow_Up_History",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "Follow_Up_Id",
                table: "Follow_Up_History",
                newName: "Follow_Up_IdId");

            migrationBuilder.RenameColumn(
                name: "End_Hour",
                table: "Follow_Up_History",
                newName: "End");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_Ups_History_Follow_Up_Type_Id",
                table: "Follow_Up_History",
                newName: "IX_Follow_Up_History_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_Ups_History_Follow_Up_Id",
                table: "Follow_Up_History",
                newName: "IX_Follow_Up_History_Follow_Up_IdId");

            migrationBuilder.RenameColumn(
                name: "Staff_Id",
                table: "Follow_Up",
                newName: "Staff_IdId");

            migrationBuilder.RenameColumn(
                name: "Patient_Id",
                table: "Follow_Up",
                newName: "Patient_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_Ups_Staff_Id",
                table: "Follow_Up",
                newName: "IX_Follow_Up_Staff_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_Ups_Patient_Id",
                table: "Follow_Up",
                newName: "IX_Follow_Up_Patient_IdId");

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

            migrationBuilder.AlterColumn<int>(
                name: "Registration_Id",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Hospital_Id",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Specialization_Id",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Registration_Id",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follow_Up_Types",
                table: "Follow_Up_Types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follow_Up",
                table: "Follow_Up",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Reservations_Hospital_Facilities_Facility_IdId",
                table: "Facility_Reservations",
                column: "Facility_IdId",
                principalTable: "Hospital_Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Reservations_Patients_Patient_IdId",
                table: "Facility_Reservations",
                column: "Patient_IdId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_Reservations_Staffs_Staff_IdId",
                table: "Facility_Reservations",
                column: "Staff_IdId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Up_Patients_Patient_IdId",
                table: "Follow_Up",
                column: "Patient_IdId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Up_Staffs_Staff_IdId",
                table: "Follow_Up",
                column: "Staff_IdId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Up_History_Follow_Up_Follow_Up_IdId",
                table: "Follow_Up_History",
                column: "Follow_Up_IdId",
                principalTable: "Follow_Up",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_Up_History_Follow_Up_Types_TypeId",
                table: "Follow_Up_History",
                column: "TypeId",
                principalTable: "Follow_Up_Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Patients_Patient_IdId",
                table: "Payments",
                column: "Patient_IdId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Schedules_Staffs_Staff_IdId",
                table: "Staff_Schedules",
                column: "Staff_IdId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
