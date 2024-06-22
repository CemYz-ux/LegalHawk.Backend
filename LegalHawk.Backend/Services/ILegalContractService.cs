namespace LegalHawk.Backend.Services;

public interface ILegalContractService
{
    public Task<List<LegalContractListDto>> GetLegalContractsAsync(SieveModel sieveModel);
    public Task<int> GetLegalContractsCountAsync();

    public Task<LegalContractDetailDto?> GetLegalContractByIdAsync(Guid id);

    public Task<LegalContractDetailDto> CreateLegalContractAsync(LegalContractCreateOptions createOptions);

    public Task DeleteLegalContractAsync(Guid id);
}