namespace LegalHawk.Backend.Services;

public class LegalContractService(DatabaseContext dbContext, ISieveProcessor sieveProcessor) : ILegalContractService
{
    public async Task<List<LegalContract>> GetLegalContractsAsync(SieveModel sieveModel)
    {
        var query = dbContext.LegalConracts.AsNoTracking();

        var filteredQuery = sieveProcessor.Apply(sieveModel, query);

        return await filteredQuery.ToListAsync();
    }

    public async Task<int> GetLegalContractsCountAsync()
        => await dbContext.LegalConracts.CountAsync();

    public async Task<LegalContract?> GetLegalContractByIdAsync(Guid id)
        => await dbContext.LegalConracts.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);

    public async Task<LegalContract> CreateLegalContractAsync(LegalContractCreateOptions createOptions)
    {
        var legalContract = new LegalContract
        {
            Id = Guid.NewGuid(),
            Author = createOptions.Author,
            Title = createOptions.Title,
            Description = createOptions.Description,
        };

        dbContext.LegalConracts.Add(legalContract);
        
        await dbContext.SaveChangesAsync();

        return legalContract;
    }

    public async Task DeleteLegalContractAsync(Guid id)
    {
        var foundLegalContract = await dbContext.LegalConracts.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id) 
            ?? throw new NotFoundException($"The user with the id {id} does not exists");

        dbContext.Remove(foundLegalContract);

        await dbContext.SaveChangesAsync();
    }
}
