namespace LegalHawk.Backend.Controllers;

[ApiController]
[Produces("application/json")]
public class LegalContractsController(ILegalContractService legalContractsService) : BaseController
{
    [HttpGet("legal-contracts")]
    [SwaggerResponse(StatusCodes.Status200OK, nameof(OkListResponse), typeof(OkListResponse<LegalContractListDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, nameof(NotFound))]
    [SwaggerOperation(OperationId = nameof(GetLegalContractsAsync))]
    public async Task<IActionResult> GetLegalContractsAsync([FromQuery] SieveModel sieveModel)
    {
        var legalContracts = await legalContractsService.GetLegalContractsAsync(sieveModel);

        var legalContractsTotalCount = await legalContractsService.GetLegalContractsCountAsync();

        return OkListResponse(legalContracts, legalContractsTotalCount);
    }

    [HttpGet("legal-contracts/{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, nameof(OkListResponse), typeof(OkResponse<LegalContractDetailDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, nameof(NotFound))]
    [SwaggerOperation(OperationId = nameof(GetLegalContractByIdAsync))]
    public async Task<IActionResult> GetLegalContractByIdAsync([FromRoute] Guid id)
    {
        var legalContract = await legalContractsService.GetLegalContractByIdAsync(id)
            ?? throw new NotFoundException($"The legal contract with the id {id} does not exists");

        return OkResponse(legalContract);
    }

    [HttpPost("legal-contracts")]
    [SwaggerResponse(StatusCodes.Status201Created, nameof(CreatedResponse), typeof(CreatedResponse<LegalContractDetailDto>))]
    [SwaggerOperation(OperationId = nameof(CreateLegalConractAsync))]
    public async Task<IActionResult> CreateLegalConractAsync([FromBody] LegalContractCreateOptions createOptions)
    {
        var legalContract = await legalContractsService.CreateLegalContractAsync(createOptions);

        return CreatedResponse(legalContract);
    }

    [HttpPatch("legal-contracts/{id}")]
    [SwaggerResponse(StatusCodes.Status201Created, nameof(UpdatedResponse), typeof(UpdatedResponse<LegalContractDetailDto>))]
    [SwaggerOperation(OperationId = nameof(UpdateLegalConractAsync))]
    public async Task<IActionResult> UpdateLegalConractAsync([FromRoute] Guid id, [FromBody] LegalContractUpdateOptions updateOptions)
    {
        var legalContract = await legalContractsService.UpdateLegalContractAsync(id, updateOptions);

        return UpdatedResponse(legalContract);
    }


    [HttpDelete("legal-contracts/{id}")]
    [SwaggerResponse(StatusCodes.Status404NotFound, nameof(NotFound))]
    [SwaggerOperation(OperationId = nameof(DeleteLegalContractById))]
    public async Task<IActionResult> DeleteLegalContractById([FromRoute] Guid id)
    {
        await legalContractsService.DeleteLegalContractAsync(id);

        return DeletedResponse();
    }
}