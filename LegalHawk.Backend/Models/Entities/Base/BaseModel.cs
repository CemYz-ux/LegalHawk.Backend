namespace LegalHawk.Backend.Models.Entities.Base;

public class BaseModel : BaseModelWithoutKey
{
    [Key]
    public Guid Id { get; set; }
}
