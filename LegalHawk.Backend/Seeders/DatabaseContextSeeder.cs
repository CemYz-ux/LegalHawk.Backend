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
        AddLegalContracts();

        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Try to seed the database with some legal contracts
    /// </summary>
    /// <returns></returns>
    private void AddLegalContracts()
    {
        for (int i = 0; i < 20; i++)
        {
            dbContext.LegalConracts.Add(new()
            {
                Id = Guid.NewGuid(),
                Title = $"Legal Contract {i + 1}",
                Author = $"Author {i + 1}",
                Description = $"This is a legal contract {i + 1}",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            });
        }
    }
}
