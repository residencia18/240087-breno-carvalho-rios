using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using NuGet.Common;
using NuGet.Protocol;

namespace MvcMovie.Middlewares;
public class AuthMiddleware
{
   private readonly RequestDelegate _next;
   public AuthMiddleware(RequestDelegate next)
   {
      _next = next;
   }

   public async Task InvokeAsync(HttpContext context)
   {
      if (context.Request.Cookies.ContainsKey("Token"))
      {
         context.Request.Headers.Authorization = "Bearer " + context.Request.Cookies["Token"];
      }
      await _next(context);
   }
}
