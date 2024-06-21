namespace LegalHawk.Backend.Services;

public interface ILegalContractService
{
    public Task<List<LegalContract>> GetLegalContractsAsync(SieveModel sieveModel);
    public Task<int> GetLegalContractsCountAsync();

    public Task<LegalContract?> GetLegalContractByIdAsync(Guid id);

    public Task<LegalContract> CreateLegalContractAsync(LegalContractCreateOptions createOptions);

    public Task DeleteLegalContractAsync(Guid id);
}