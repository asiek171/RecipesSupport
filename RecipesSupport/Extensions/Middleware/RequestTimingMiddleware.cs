using System.Diagnostics;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestTimingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var startTime = DateTime.UtcNow;

        // Przekazanie żądania do następnego komponentu middleware
        await _next(context);

        var processingTime = DateTime.UtcNow - startTime;
        Debug.WriteLine($"Time execution: {processingTime.TotalMilliseconds} ms. {context.GetEndpoint()?.DisplayName}");
    }
}
