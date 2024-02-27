using Microsoft.AspNetCore.Mvc;
using MvcMovie.Auth;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class LoginController : Controller
    {
        private readonly MvcMovieContext _context;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public LoginController(MvcMovieContext context, IConfiguration configuration, IAuthService authService)
        {
            _context = context;
            _configuration = configuration;
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

                if(user is null){
                    return Problem("Invalid Credentials: Login or Password invalid.");
                }
                
                var token = _authService.GenerateJwtToken(_encriptedPassword, "Admin");

                Console.WriteLine($"{token}");

                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }
    }
}
