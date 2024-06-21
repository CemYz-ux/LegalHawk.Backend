namespace LegalHawk.Backend.Controllers;

[ApiController]
public class LegalContractsController(ILegalContractService legalContractsService) : BaseController
{
    [HttpGet("legal-contracts")]
    public async Task<IActionResult> GetLegalContractsAsync([FromQuery] SieveModel sieveModel)
    {
        var legalContracts = await legalContractsService.GetLegalContractsAsync(sieveModel);

        var legalContractsTotalCount = await legalContractsService.GetLegalContractsCountAsync();

        return OkListResponse(legalContracts, legalContractsTotalCount);
    }

    [HttpGet("legal-contracts/{id}")]
    public async Task<IActionResult> GetLegalContractByIdAsync([FromRoute] Guid id)
    {
        var legalContract = await legalContractsService.GetLegalContractByIdAsync(id)
            ?? throw new NotFoundException($"The legal contract with the id {id} does not exists");

        return OkResponse(legalContract);
    }

    [HttpPost("legal-contracts")]
    public async Task<IActionResult> CreateLegalConractAsync([FromBody] LegalContractCreateOptions createOptions)
    {
        var legalContract = await legalContractsService.CreateLegalContractAsync(createOptions);

        return CreatedResponse(legalContract);
    }

    [HttpDelete("legal-contracts/{id}")]
    public async Task<IActionResult> DeleteLegalContractById([FromRoute] Guid id)
    {
        await legalContractsService.DeleteLegalContractAsync(id);

        return DeletedResponse();
    }
}