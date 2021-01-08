using Microsoft.EntityFrameworkCore.Migrations;

namespace Ain_Shams_Hospital.Migrations
{
    public partial class FreshDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blood_Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blood_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Follow_Ups_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow_Ups_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospital_Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Start_Working_Hour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End_Working_Hour = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transfer_Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer_Hospitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Starting_Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization_Id = table.Column<int>(type: "int", nullable: true),
                    Registration_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Registrations_Registration_Id",
                        column: x => x.Registration_Id,
                        principalTable: "Registrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_Specializations_Specialization_Id",
                        column: x => x.Specialization_Id,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff_Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialization_Id = table.Column<int>(type: "int", nullable: true),
                    Working_Day = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Schedules_Specializations_Specialization_Id",
                        column: x => x.Specialization_Id,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registration_Id = table.Column<int>(type: "int", nullable: true),
                    Hospital_Id = table.Column<int>(type: "int", nullable: true),
                    Medical_Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Health_Progress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Registrations_Registration_Id",
                        column: x => x.Registration_Id,
                        principalTable: "Registrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patients_Transfer_Hospitals_Hospital_Id",
                        column: x => x.Hospital_Id,
                        principalTable: "Transfer_Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facility_Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hospital_Facility_Id = table.Column<int>(type: "int", nullable: true),
                    Start_Hour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End_Hour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Staff_Id = table.Column<int>(type: "int", nullable: true),
                    Patient_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facility_Reservations_Hospital_Facilities_Hospital_Facility_Id",
                        column: x => x.Hospital_Facility_Id,
                        principalTable: "Hospital_Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facility_Reservations_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facility_Reservations_Staff_Staff_Id",
                        column: x => x.Staff_Id,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Follow_Ups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_Id = table.Column<int>(type: "int", nullable: true),
                    Patient_Id = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow_Ups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follow_Ups_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follow_Ups_Staff_Staff_Id",
                        column: x => x.Staff_Id,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Id = table.Column<int>(type: "int", nullable: true),
                    Money = table.Column<int>(type: "int", nullable: false),
                    Payed = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Follow_Up_Type_Id = table.Column<int>(type: "int", nullable: true),
                    Online = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Follow_Ups_Types_Follow_Up_Type_Id",
                        column: x => x.Follow_Up_Type_Id,
                        principalTable: "Follow_Ups_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Patients_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Follow_Ups_History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Follow_Up_Id = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Follow_Up_Type_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow_Ups_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follow_Ups_History_Follow_Ups_Follow_Up_Id",
                        column: x => x.Follow_Up_Id,
                        principalTable: "Follow_Ups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follow_Ups_History_Follow_Ups_Types_Follow_Up_Type_Id",
                        column: x => x.Follow_Up_Type_Id,
                        principalTable: "Follow_Ups_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facility_Reservations_Hospital_Facility_Id",
                table: "Facility_Reservations",
                column: "Hospital_Facility_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_Reservations_Patient_Id",
                table: "Facility_Reservations",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_Reservations_Staff_Id",
                table: "Facility_Reservations",
                column: "Staff_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_Ups_Patient_Id",
                table: "Follow_Ups",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_Ups_Staff_Id",
                table: "Follow_Ups",
                column: "Staff_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_Ups_History_Follow_Up_Id",
                table: "Follow_Ups_History",
                column: "Follow_Up_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_Ups_History_Follow_Up_Type_Id",
                table: "Follow_Ups_History",
                column: "Follow_Up_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Hospital_Id",
                table: "Patients",
                column: "Hospital_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Registration_Id",
                table: "Patients",
                column: "Registration_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Follow_Up_Type_Id",
                table: "Payments",
                column: "Follow_Up_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Patient_Id",
                table: "Payments",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Registration_Id",
                table: "Staff",
                column: "Registration_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Specialization_Id",
                table: "Staff",
                column: "Specialization_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Schedules_Specialization_Id",
                table: "Staff_Schedules",
                column: "Specialization_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blood_Units");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Facility_Reservations");

            migrationBuilder.DropTable(
                name: "Follow_Ups_History");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Staff_Schedules");

            migrationBuilder.DropTable(
                name: "Hospital_Facilities");

            migrationBuilder.DropTable(
                name: "Follow_Ups");

            migrationBuilder.DropTable(
                name: "Follow_Ups_Types");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Transfer_Hospitals");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
