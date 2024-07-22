using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure;

public class JourneyDbContext : DbContext
{
    public DbSet<Trip> trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\isaque.henriques\\Desktop\\Programas\\Github\\Primeiro-programa-em-CSharp\\Atividade pratica\\JourneyDatabase.db");
    }
}
