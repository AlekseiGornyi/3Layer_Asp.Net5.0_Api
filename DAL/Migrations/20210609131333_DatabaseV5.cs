using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DatabaseV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "manufacturer_creation_date",
                table: "manufacturer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 9, 13, 13, 32, 941, DateTimeKind.Utc).AddTicks(8154),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 9, 13, 12, 10, 710, DateTimeKind.Utc).AddTicks(6121));

            migrationBuilder.AlterColumn<string>(
                name: "good_descript",
                table: "good",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "good",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 9, 13, 13, 32, 957, DateTimeKind.Utc).AddTicks(6462),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 9, 13, 12, 10, 726, DateTimeKind.Utc).AddTicks(1242));

            migrationBuilder.AlterColumn<DateTime>(
                name: "availability_status_creation_date",
                table: "availablility_status",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 9, 13, 13, 32, 955, DateTimeKind.Utc).AddTicks(5251),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 9, 13, 12, 10, 724, DateTimeKind.Utc).AddTicks(785));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "manufacturer_creation_date",
                table: "manufacturer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 9, 13, 12, 10, 710, DateTimeKind.Utc).AddTicks(6121),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 9, 13, 13, 32, 941, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.AlterColumn<string>(
                name: "good_descript",
                table: "good",
                type: "nvarchar(150)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "good",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 9, 13, 12, 10, 726, DateTimeKind.Utc).AddTicks(1242),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 9, 13, 13, 32, 957, DateTimeKind.Utc).AddTicks(6462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "availability_status_creation_date",
                table: "availablility_status",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 9, 13, 12, 10, 724, DateTimeKind.Utc).AddTicks(785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 9, 13, 13, 32, 955, DateTimeKind.Utc).AddTicks(5251));
        }
    }
}
