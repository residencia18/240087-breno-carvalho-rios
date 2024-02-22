using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MvcMovie.AppUtils;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class LoginController : Controller
    {
        private readonly MvcMovieContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(MvcMovieContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
                var _token = GenerateJwtToken(login.Email, login.Password);                
                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }

        public string GenerateJwtToken(string email, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];
            //cria uma chave utilizando criptografia simétrica
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            //cria as credenciais do token
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("email", email)
            };

            var token = new JwtSecurityToken( //cria o token
               issuer: issuer, //emissor do token
               audience: audience, //destinatário do token
               claims: claims, //informações do usuário
               expires: DateTime.Now.AddMinutes(30), //tempo de expiração do token
               signingCredentials: credentials //credenciais do token
            );

            var tokenHandler = new JwtSecurityTokenHandler(); //cria um manipulador de token

            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
