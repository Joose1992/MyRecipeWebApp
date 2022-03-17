using Microsoft.EntityFrameworkCore;
using RecipesWebApp.Data.Models;

namespace RecipesWebApp.Data;

public class PracticeContext : DbContext
{
    public PracticeContext()
    {
        
    }

    public PracticeContext(DbContextOptions<PracticeContext> options) : base(options)
    {
        
    }
    
    public DbSet<Recipes> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipes>(
            entity =>
            {
                entity.HasKey(e => e.RecipeId);

                entity.Property(e => e.RecipeId)
                    .HasColumnName("RecipeId");

                entity.Property(e => e.RecipeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MealType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MainIngredients)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PrepTime)
                    .IsRequired()
                    .HasMaxLength(50);
            }
        );
    }
    
}