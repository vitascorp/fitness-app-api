using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class correctedrelationbetweentrainingandcardio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrainingCardios_TrainingId",
                table: "TrainingCardios");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCardios_TrainingId",
                table: "TrainingCardios",
                column: "TrainingId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrainingCardios_TrainingId",
                table: "TrainingCardios");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCardios_TrainingId",
                table: "TrainingCardios",
                column: "TrainingId");
        }
    }
}
