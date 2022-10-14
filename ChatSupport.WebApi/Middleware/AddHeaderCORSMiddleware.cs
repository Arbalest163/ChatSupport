namespace ChatSupport.WebApi.Middleware;
public class AddHeaderCORSMiddleware
{
    private readonly RequestDelegate _next;
    public AddHeaderCORSMiddleware(RequestDelegate next) =>
        _next = next;

    public async Task Invoke(HttpContext context)
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        await _next(context);
    }
}
