using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thesis.Migrations
{
    public partial class ThreeBreadsDetection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMoldDetected",
                table: "DetectionLogs");

            migrationBuilder.DropColumn(
                name: "MoldProbability",
                table: "DetectionLogs");

            migrationBuilder.AddColumn<string>(
                name: "BreadResultsJson",
                table: "DetectionLogs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreadResultsJson",
                table: "DetectionLogs");

            migrationBuilder.AddColumn<bool>(
                name: "IsMoldDetected",
                table: "DetectionLogs",
                type: "boolean",    // <- changed from "bit"
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "MoldProbability",
                table: "DetectionLogs",
                type: "double precision",  // <- changed from "float"
                nullable: false,
                defaultValue: 0.0);
        }
    }
}