namespace LegalHawk.Backend.Models.Reponses.Base;

public class BaseResponse<T>
{
    /// <summary>
    /// The HTTP response status codes
    /// </summary>
    public int? Code { get; set; }

    /// <summary>
    /// The response object e.g. can be any kind of object
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// A text describing the response
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// A response message delivered with the response
    /// </summary>
    public string? Message { get; set; }
}
