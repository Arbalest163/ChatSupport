namespace ChatSupport.WebApi.Middleware;
public static class AddHeaderCORSMiddlewareExtentions
{
    public static IApplicationBuilder UseAddHeaderCorsMiddleware(this
    IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AddHeaderCORSMiddleware>();
    }
}
