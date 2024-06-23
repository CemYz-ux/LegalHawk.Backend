namespace LegalHawk.Backend.Services;

public class LegalContractService(DatabaseContext dbContext, ISieveProcessor sieveProcessor) : ILegalContractService
{
    public async Task<List<LegalContractListDto>> GetLegalContractsAsync(SieveModel sieveModel)
    {
        var query = dbContext.LegalConracts.AsNoTracking();

        var filteredQuery = sieveProcessor.Apply(sieveModel, query);

        return await filteredQuery.Select(LegalContractListDto.ToProjection).ToListAsync();
    }

    public async Task<int> GetLegalContractsCountAsync()
        => await dbContext.LegalConracts.CountAsync();

    public async Task<LegalContractDetailDto?> GetLegalContractByIdAsync(Guid id)
        => await dbContext.LegalConracts.AsNoTracking().Where(q => q.Id == id).Select(LegalContractDetailDto.ToProjection).FirstOrDefaultAsync();

    public async Task<LegalContractDetailDto> CreateLegalContractAsync(LegalContractCreateOptions createOptions)
    {
        var legalContract = new LegalContract
        {
            Id = Guid.NewGuid(),
            Author = createOptions.Author,
            Title = createOptions.Title,
            Description = createOptions.Description,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };

        dbContext.LegalConracts.Add(legalContract);
        
        await dbContext.SaveChangesAsync();

        return LegalContractDetailDto.FromEntity(legalContract)!;
    }

    public async Task<LegalContractDetailDto> UpdateLegalContractAsync(Guid legalContractId, LegalContractUpdateOptions updateOptions)
    {
        var foundLegalContract = await dbContext.LegalConracts.FirstOrDefaultAsync(q => q.Id == legalContractId)
            ?? throw new NotFoundException($"The legal contract with the id {legalContractId} does not exists");

        foundLegalContract.Author = updateOptions.Author;
        foundLegalContract.Title = updateOptions.Title;
        foundLegalContract.Description = updateOptions.Description;
        foundLegalContract.ModifiedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();

        return LegalContractDetailDto.FromEntity(foundLegalContract)!;
    }

    public async Task DeleteLegalContractAsync(Guid id)
    {
        var foundLegalContract = await dbContext.LegalConracts.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id) 
            ?? throw new NotFoundException($"The legal contract with the id {id} does not exists");

        dbContext.Remove(foundLegalContract);

        await dbContext.SaveChangesAsync();
    }
}
