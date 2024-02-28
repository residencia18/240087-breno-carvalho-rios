using System.Net.Http;

namespace ResTIConnect.Infrastructure.Middleware;

public class AuthorizationMiddleware
 {
//     private readonly RequestDelegate _next;

//     public AuthorizationMiddleware(RequestDelegate next)
//     {
//         _next = next;
//     }

//     public async Task InvokeAsync(HttpContent context)
//     {
//         // Verifique se o usuário está autenticado.
//         if (!context.User.Identity.IsAuthenticated)
//         {
//             context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//             return;
//         }

//         // Verifique se o usuário tem as permissões necessárias para acessar o endpoint.
//         var authorizationResult = await context.AuthorizationService.AuthorizeAsync(context.User, context.Request.Path);
//         if (!authorizationResult.Succeeded)
//         {
//             context.Response.StatusCode = StatusCodes.Status403Forbidden;
//             return;
//         }

//         await _next(context);
//     }
}