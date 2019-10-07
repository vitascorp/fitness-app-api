using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.Data.Migrations
{
    public partial class updateexercisetitles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_Exercises_ExcerciseId",
                table: "TrainingExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_Measures_MeasureId",
                table: "TrainingExercises");

            migrationBuilder.DropIndex(
                name: "IX_TrainingExercises_ExcerciseId",
                table: "TrainingExercises");

            migrationBuilder.DropIndex(
                name: "IX_TrainingExercises_MeasureId",
                table: "TrainingExercises");

            migrationBuilder.DropColumn(
                name: "ExcerciseId",
                table: "TrainingExercises");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "TrainingExercises");

            migrationBuilder.DropColumn(
                name: "MeasureId",
                table: "TrainingExercises");

            migrationBuilder.DropColumn(
                name: "SupersetOrder",
                table: "TrainingExercises");

            migrationBuilder.AddColumn<int>(
                name: "SupersetOrder",
                table: "TrainingExerciseAttempts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TrainingExerciseTitles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrainingExerciseId = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    ExcerciseId = table.Column<int>(nullable: true),
                    MeasureId = table.Column<int>(nullable: false),
                    SupersetOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExerciseTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingExerciseTitles_Exercises_ExcerciseId",
                        column: x => x.ExcerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingExerciseTitles_Measures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingExerciseTitles_TrainingExercises_TrainingExerciseId",
                        column: x => x.TrainingExerciseId,
                        principalTable: "TrainingExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExerciseTitles_ExcerciseId",
                table: "TrainingExerciseTitles",
                column: "ExcerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExerciseTitles_MeasureId",
                table: "TrainingExerciseTitles",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExerciseTitles_TrainingExerciseId",
                table: "TrainingExerciseTitles",
                column: "TrainingExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingExerciseTitles");

            migrationBuilder.DropColumn(
                name: "SupersetOrder",
                table: "TrainingExerciseAttempts");

            migrationBuilder.AddColumn<int>(
                name: "ExcerciseId",
                table: "TrainingExercises",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "TrainingExercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeasureId",
                table: "TrainingExercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupersetOrder",
                table: "TrainingExercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercises_ExcerciseId",
                table: "TrainingExercises",
                column: "ExcerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercises_MeasureId",
                table: "TrainingExercises",
                column: "MeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercises_Exercises_ExcerciseId",
                table: "TrainingExercises",
                column: "ExcerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercises_Measures_MeasureId",
                table: "TrainingExercises",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
