public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var memberId = context.Session.GetString("MemberID");

        // Nếu không có session và không phải trang Login/Register
        if (string.IsNullOrEmpty(memberId) &&
            !context.Request.Path.StartsWithSegments("/Login") &&
            !context.Request.Path.StartsWithSegments("/Register"))
        {
            context.Response.Redirect("/Login");
            return;
        }

        await _next(context);
    }
}