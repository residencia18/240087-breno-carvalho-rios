using System.Net;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Auth;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class LoginController : Controller
    {
        private readonly MvcMovieContext _context;
        private readonly IAuthService _authService;

        public LoginController(MvcMovieContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Email,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                var _encriptedPassword = _authService.ComputeSha256Hash(login.Password);
                var user = _context.User.FirstOrDefault(user =>
                    user.Email == login.Email && user.Password == _encriptedPassword
                );

                if (user is null)
                {
                    return Problem("Invalid Credentials: Login or Password invalid.");
                }

                var token = _authService.GenerateJwtToken(login.Email, "Admin");
                HttpContext.Response.Cookies.Append("Token", token);

                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("Token");
            return RedirectToAction("Index", "Login");
        }
    }
}
