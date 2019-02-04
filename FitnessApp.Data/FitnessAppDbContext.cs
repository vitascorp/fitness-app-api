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

        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
