using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class correctedcardiofieldnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardioTime",
                table: "TrainingCardios",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "CardioSpeed",
                table: "TrainingCardios",
                newName: "Speed");

            migrationBuilder.RenameColumn(
                name: "CardioAngle",
                table: "TrainingCardios",
                newName: "Angle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "TrainingCardios",
                newName: "CardioTime");

            migrationBuilder.RenameColumn(
                name: "Speed",
                table: "TrainingCardios",
                newName: "CardioSpeed");

            migrationBuilder.RenameColumn(
                name: "Angle",
                table: "TrainingCardios",
                newName: "CardioAngle");
        }
    }
}
