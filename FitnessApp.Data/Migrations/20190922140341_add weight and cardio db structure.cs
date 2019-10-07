using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class addweightandcardiodbstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Trainings",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "TrainingCardios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrainingId = table.Column<int>(nullable: false),
                    CardioAngle = table.Column<decimal>(nullable: false),
                    CardioSpeed = table.Column<decimal>(nullable: false),
                    CardioTime = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCardios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingCardios_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCardios_TrainingId",
                table: "TrainingCardios",
                column: "TrainingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingCardios");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Trainings");
        }
    }
}
