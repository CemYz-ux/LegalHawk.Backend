namespace LegalHawk.Backend.Seeders;

public class DatabaseContextSeeder(DatabaseContext dbContext)
{
    /// <summary>
    /// Database context initializer
    /// </summary>
    /// <returns></returns>
    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Try to seed the database with some initial data
    /// </summary>
    /// <returns></returns>
    public async Task TrySeedAsync()
    {
        await TrySeedLegalContracts();

        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Try to seed the database with some legal contracts
    /// </summary>
    /// <returns></returns>
    private async Task TrySeedLegalContracts()
    {
        dbContext.LegalConracts.AddRange([
            new() 
            {
                Id = Guid.NewGuid(),
                Title = "Legal Contract 1",
                Author = "Peter Doe",
                Description = "This is a legal contract 1",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Legal Contract 2",
                Description = "This is a legal contract 2",
                Author = "Max Doe",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Legal Contract 3",
                Author = "Alex Doe",
                Description = "This is a legal contract 3",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            }
        ]);
    }
}
