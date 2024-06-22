namespace LegalHawk.Backend.Models.Dtos;

public class LegalContractListDto
{
    public Guid Id { get; set; }

    public required string Title { get; set; }

    public required string Author { get; set; }

    public string? Description { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset ModifiedAt { get; set; }

    public static Expression<Func<LegalContract, LegalContractListDto>> ToProjection = legalContract =>
        new LegalContractListDto()
        {
            Id = legalContract.Id,
            Author = legalContract.Author,
            CreatedAt = legalContract.CreatedAt,
            Description = legalContract.Description,
            ModifiedAt = legalContract.ModifiedAt,
            Title = legalContract.Title
        };

    public static LegalContractListDto? FromEntity(LegalContract? entity)
        => entity is not null ? ToProjection.Compile().Invoke(entity) : null;
}
