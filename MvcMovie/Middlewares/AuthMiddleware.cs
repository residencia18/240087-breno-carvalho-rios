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
      //verificar se existe a chave Authorization no Header da requisição
      Console.WriteLine(context.Request.Cookies.ToJson());
      
    //   if(!context.Request.Headers.ContainsKey("Authorization"))
    //   {
    //      //context.Response.Headers.Add("WWW-Authenticate", "Basic");
    //      context.Response.StatusCode = 401;
    //      await context.Response.WriteAsync("Authorization header is missing");
    //      return;
    //   }

      if(false)
      {
         context.Response.StatusCode = 401;
         await context.Response.WriteAsync("Invalid username or password");
         return;
      }

      await _next(context);
   }
}
