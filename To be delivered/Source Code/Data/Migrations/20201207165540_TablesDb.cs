using Microsoft.EntityFrameworkCore.Migrations;

namespace Ain_Shams_Hospital.Migrations
{
    public partial class TablesDb : Migration
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
                    amount = table.Column<int>(type: "int", nullable: false)
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
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Follow_Up_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow_Up_Types", x => x.Id);
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
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registration_Id = table.Column<int>(type: "int", nullable: false),
                    Hospital_Id = table.Column<int>(type: "int", nullable: false),
                    Medical_Record = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Health_Progress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
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
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Starting_Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization_Id = table.Column<int>(type: "int", nullable: false),
                    Registration_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
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
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_IdId = table.Column<int>(type: "int", nullable: true),
                    Money = table.Column<int>(type: "int", nullable: false),
                    payed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Patients_Patient_IdId",
                        column: x => x.Patient_IdId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facility_Reservations",
                columns: table => new
                {
                    Facility_IdId = table.Column<int>(type: "int", nullable: true),
                    Start_Hour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End_Hour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Staff_IdId = table.Column<int>(type: "int", nullable: true),
                    Patient_IdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Facility_Reservations_Hospital_Facilities_Facility_IdId",
                        column: x => x.Facility_IdId,
                        principalTable: "Hospital_Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facility_Reservations_Patients_Patient_IdId",
                        column: x => x.Patient_IdId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facility_Reservations_Staffs_Staff_IdId",
                        column: x => x.Staff_IdId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Follow_Up",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_IdId = table.Column<int>(type: "int", nullable: true),
                    Patient_IdId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow_Up", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follow_Up_Patients_Patient_IdId",
                        column: x => x.Patient_IdId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follow_Up_Staffs_Staff_IdId",
                        column: x => x.Staff_IdId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff_Schedules",
                columns: table => new
                {
                    Staff_IdId = table.Column<int>(type: "int", nullable: true),
                    Working_Day = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Staff_Schedules_Staffs_Staff_IdId",
                        column: x => x.Staff_IdId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Follow_Up_History",
                columns: table => new
                {
                    Follow_Up_IdId = table.Column<int>(type: "int", nullable: true),
                    Start = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Follow_Up_History_Follow_Up_Follow_Up_IdId",
                        column: x => x.Follow_Up_IdId,
                        principalTable: "Follow_Up",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follow_Up_History_Follow_Up_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Follow_Up_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facility_Reservations_Facility_IdId",
                table: "Facility_Reservations",
                column: "Facility_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_Reservations_Patient_IdId",
                table: "Facility_Reservations",
                column: "Patient_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_Reservations_Staff_IdId",
                table: "Facility_Reservations",
                column: "Staff_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_Up_Patient_IdId",
                table: "Follow_Up",
                column: "Patient_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_Up_Staff_IdId",
                table: "Follow_Up",
                column: "Staff_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_Up_History_Follow_Up_IdId",
                table: "Follow_Up_History",
                column: "Follow_Up_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_Up_History_TypeId",
                table: "Follow_Up_History",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Patient_IdId",
                table: "Payments",
                column: "Patient_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Schedules_Staff_IdId",
                table: "Staff_Schedules",
                column: "Staff_IdId");
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
                name: "Follow_Up_History");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Staff_Schedules");

            migrationBuilder.DropTable(
                name: "Transfer_Hospitals");

            migrationBuilder.DropTable(
                name: "Hospital_Facilities");

            migrationBuilder.DropTable(
                name: "Follow_Up");

            migrationBuilder.DropTable(
                name: "Follow_Up_Types");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
