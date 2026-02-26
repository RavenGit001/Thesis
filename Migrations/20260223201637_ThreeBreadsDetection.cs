using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thesis.Migrations
{
    /// <inheritdoc />
    public partial class ThreeBreadsDetection : Migration
    {
        /// <inheritdoc />
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
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreadResultsJson",
                table: "DetectionLogs");

            migrationBuilder.AddColumn<bool>(
                name: "IsMoldDetected",
                table: "DetectionLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "MoldProbability",
                table: "DetectionLogs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
