namespace LegalHawk.Backend.Models.Reponses;

public class ErrorResponse : BaseResponse<string>
{
    public object? Errors { get; set; }
}

