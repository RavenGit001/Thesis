using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Thesis.Migrations
{
    public partial class ForThesisDeployment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // SensorReadings
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "SensorReadings",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<double>(
                name: "Temperature",
                table: "SensorReadings",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Humidity",
                table: "SensorReadings",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SensorReadings",
                type: "integer",
                nullable: false)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            // DetectionLogs
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "DetectionLogs",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "DetectionLogs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "BreadResultsJson",
                table: "DetectionLogs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DetectionLogs",
                type: "integer",
                nullable: false)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // SensorReadings
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "SensorReadings",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<double>(
                name: "Temperature",
                table: "SensorReadings",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Humidity",
                table: "SensorReadings",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SensorReadings",
                type: "integer",
                nullable: false)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            // DetectionLogs
            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "DetectionLogs",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "DetectionLogs",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "BreadResultsJson",
                table: "DetectionLogs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DetectionLogs",
                type: "integer",
                nullable: false)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}