using System.Net.Http.Headers;
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
        private readonly IHttpClientFactory _clientFactory;

        public LoginController(MvcMovieContext context, IAuthService authService, IHttpClientFactory clientFactory)
        {
            _context = context;
            _authService = authService;
            _clientFactory = clientFactory;
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

                var token = _authService.GenerateJwtToken(login.Email, "Admin");

                var httpClient = _clientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }
    }
}
