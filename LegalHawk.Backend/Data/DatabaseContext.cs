namespace LegalHawk.Backend.Data;

public class DatabaseContext : DbContext
{
    public DbSet<LegalContract> LegalConracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("LegalHawkDatabase");

        base.OnConfiguring(optionsBuilder);
    }
}
