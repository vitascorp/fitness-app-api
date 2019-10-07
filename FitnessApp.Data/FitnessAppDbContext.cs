using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data
{
    public class FitnessAppDbContext : DbContext
    {
        public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingExercise> TrainingExercises { get; set; }
        public DbSet<TrainingExerciseAttempt> TrainingExerciseAttempts { get; set; }
        public DbSet<TrainingExerciseTitle> TrainingExerciseTitles { get; set; }
        public DbSet<TrainingCardio> TrainingCardios { get; set; }

    }
}
