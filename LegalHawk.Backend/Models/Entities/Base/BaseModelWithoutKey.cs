namespace LegalHawk.Backend.Models.Entities.Base;

public class BaseModelWithoutKey
{
    public DateTimeOffset CreatedAt { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public DateTimeOffset ModifiedAt { get; set; }
}
