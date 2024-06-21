namespace LegalHawk.Backend.Models.Entities;

public class LegalContract : BaseModel
{
    [Required, MaxLength(256)]
    [Sieve(CanFilter = true, CanSort = true)]
    public required string Title { get; set; }

    [Required, MaxLength(128)]
    [Sieve(CanFilter = true, CanSort = true)]
    public required string Author { get; set; }

    [MaxLength(512)]
    [Sieve(CanFilter = true, CanSort = true)]
    public string? Description { get; set; }
}
