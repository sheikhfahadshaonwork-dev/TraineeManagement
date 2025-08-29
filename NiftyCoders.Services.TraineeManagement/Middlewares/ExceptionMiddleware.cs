namespace NiftyCoders.Services.TraineeManagement.Middlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception occurred.");
            context.Response.StatusCode = 500;
            var response = new { message = "An internal server error occurred." };
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
