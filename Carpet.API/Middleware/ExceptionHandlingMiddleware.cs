using Carpet.Domain.LogTables;
using Newtonsoft.Json.Linq;

namespace Carpet.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    public ExceptionHandlingMiddleware(
        IServiceScopeFactory scopeFactory,
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _scopeFactory = scopeFactory;
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {

            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    public async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            JObject jo = JObject.Parse(exception.Message);
            var input = "";
            var output = exception.Message;
            if (!string.IsNullOrEmpty(jo.SelectToken("inputdto").ToString()))
            {
                input = jo.SelectToken("inputdto").ToString();
                output = jo.SelectToken("code").ToString() + " ," + jo.SelectToken("message").ToString();
            }
            var errorService = scope.ServiceProvider.GetRequiredService<IlogTableRepository>();
            await errorService.CreateErrorLog(input, exception.StackTrace, exception.Message,DateTime.Now, context.Response.StatusCode);
        }
    }
}
