namespace LegalHawk.Backend.Controllers.Base;

[MvcRoute("api/v1/")]
public class BaseController : ControllerBase
{
    [NonAction]
    public IActionResult OkListResponse<T>(List<T> data, int total) where T : class
        => Ok(new OkListResponse<T>
        {
            Code = (int)HttpStatusCode.OK,
            Data = data,
            Count = data.Count,
            TotalCount = total,
            Message = "GET Request was successful",
            Description = "GET Request was successful. Here is your data",
        });

    [NonAction]
    public IActionResult OkResponse<T>(T data) where T : class
        => Ok(new OkResponse<T>
        {
            Code = (int)HttpStatusCode.OK,
            Data = data,
            Message = "GET Request was successful",
            Description = "GET Request was successful. Here is your data",
        });

    [NonAction]
    public IActionResult CreatedResponse<T>(T data) where T : class
        => Ok(new CreatedResponse<T>
        {
            Code = (int)HttpStatusCode.Created,
            Data = data,
            Message = "POST Request was successful",
            Description = "POST Request was successful. Here is the created object",
        });

    [NonAction]
    public IActionResult DeletedResponse()
        => Ok(new DeletedResponse
        {
            Code = (int)HttpStatusCode.NotFound,
        });
}
