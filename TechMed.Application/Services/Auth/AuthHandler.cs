using System.Text;
using Microsoft.AspNetCore.Http;

namespace TechMed.Application.Services.Auth;
public class AuthHandler
{
    private readonly RequestDelegate _next;

    public AuthHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.Headers.Add("www-Authenticate", "Basic");
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authorization header is missing.");
            return;
        }

        var header = context.Request.Headers["Authorization"].ToString();
        var encodedUsernamePassword = header.Substring(6);
        var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
        string[] usernamePassword = decodedUsernamePassword.Split(":");

        var username = usernamePassword[0].Trim();
        var password = usernamePassword[1].Trim();

        if (username != "brenorios" || password != "password")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid username or password");
            return;
        }

        await _next(context);
    }
}
