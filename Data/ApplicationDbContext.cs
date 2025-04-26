using ExamenParcial.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace ExamenParcial.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    public DbSet<Team> DbSetTeam { get; set; }
    public DbSet<Assignment> DbSetAssignment { get; set; }
    public DbSet<Player> DbSetPlayer { get; set; }


protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Restricción: un jugador no puede estar dos veces en el mismo equipo
    modelBuilder.Entity<Assignment>()
        .HasIndex(a => new { a.PlayerId, a.TeamId })
        .IsUnique();
}

}



 
