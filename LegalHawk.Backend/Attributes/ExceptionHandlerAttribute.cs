namespace LegalHawk.Backend.Attributes;

public class ExceptionHandlerAttribute(ILoggerFactory loggerFactory) : ExceptionFilterAttribute
{
    //private readonly IStringLocalizer exceptionLocalizer;
    private readonly ILogger logger = loggerFactory.CreateLogger<Exception>();

    public override void OnException(ExceptionContext context)
    {
        if (context.Exception != null)
        {
            var exception = new
            {
                message = context.Exception.Message,
                data = context.Exception.Data,
                innerException = context.Exception.InnerException,
                stackTrace = context.Exception.StackTrace,
                source = context.Exception.Source
            };

            logger.LogError(context.Exception, context.Exception.Message);

            try
            {
                var errorResponse = new ErrorResponse
                {
                    Code = ((BaseException)context.Exception).ErrorCode,
                    Errors = exception,
                    Description = $"Exception at path {context.HttpContext.Request.Path}",//exceptionLocalizer[ExceptionKeys.Description, context.HttpContext.Request.Path],
                    Message = context.Exception.Message,
                };

                context.Result = new JsonResult(errorResponse)
                {
                    ContentType = "application/json",
                    StatusCode = ((BaseException)context.Exception).ErrorCode,
                };
            }
            catch (Exception)
            {
                var errorResponse = new ErrorResponse
                {
                    Code = (int)HttpStatusCode.InternalServerError,
                    Errors = exception,
                    Description = $"Exceptin at path: {context.HttpContext.Request.Path}", //exceptionLocalizer[ExceptionKeys.Description, context.HttpContext.Request.Path],
                    Message = context.Exception.Message,
                };

                context.Result = new JsonResult(errorResponse)
                {
                    ContentType = "application/json",
                    StatusCode = 500,
                };
            }
        }
    }
}
