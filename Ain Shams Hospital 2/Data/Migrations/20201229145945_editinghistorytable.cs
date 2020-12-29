using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ain_Shams_Hospital.Migrations
{
    public partial class editinghistorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Start_Hour",
                table: "Follow_Ups_History");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Follow_Ups_History",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Follow_Ups_History",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Start_Hour",
                table: "Follow_Ups_History",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
