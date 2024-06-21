namespace LegalHawk.Backend.Models.Reponses;

public class OkListResponse<T> : BaseResponse<T> where T : class
{
    public new IEnumerable<T> Data { get; set; } = [];

    public int Count { get; set; } = 0;

    public int TotalCount { get; set; } = 0;
}
